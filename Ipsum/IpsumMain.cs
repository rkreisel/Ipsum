using System.Runtime.InteropServices;
using System.Text;
using RK.HotRS.ToolsStd.Helpers;
using EX = RK.HotRS.ToolsStd.Extensions;
using System.Reflection;

namespace Ipsum;

public partial class IpsumMain : Form
{
    private static bool ctrlCaught = false;
    private static bool shiftCaught = false;
    private static bool iCaught = false;

    private static InterceptKeys.LowLevelKeyboardProc _proc = HookCallBack;
    private static List<string> ipsums = new List<string>();
    private static bool enableLogging = false;
    private static bool enableDebugging = false;
    private static string logFileName = "IpsumLog.txt";
    private const string dateFormat = "yyyyMMdd-hhmmss.fff";

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();

    private Viewer? viewer;

    public IpsumMain(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
        var argList = ArgumentHelpers.ParseArgs(args, "=");
        if (argList.ContainsKey("/h"))
        {
            var msg = new StringBuilder();
            msg.AppendLine("Parameters");
            msg.AppendLine("    /d debug - Opens a console output window.");
            msg.AppendLine("    /l logs stuff to a file");
            msg.AppendLine("    /nh DO NOT use the global keystroke hook");
            msg.AppendLine("    /h Display this help information");
            MessageBox.Show(msg.ToString(), "Ipsum Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        if (argList.ContainsKey("/d"))
        {
            enableDebugging = true;
            AllocConsole();
        }
        if (argList.ContainsKey("/l"))
        {
            enableLogging = true;
            logFileName = $"{logFileName}-{DateTime.Now.ToString("yyyyMMdd")}.txt";
        }
        InitializeComponent();
        ipsums = LoadIpsums();
        if (argList.ContainsKey("/nh"))
        {
            MessageBox.Show("Keyboard hook not installed. Use the context menu of the Ipsum icon in the system tray to generate an ipsum.");
            ReportIt("Keystroke hook not installed");
        }
        else
        {
            InterceptKeys._hookID = InterceptKeys.SetHook(_proc);
        }
    }

    public static IntPtr HookCallBack(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode == 0 && wParam == (IntPtr)InterceptKeys.WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            if (vkCode == (int)InterceptKeys.VK_LCONTROL || vkCode == (int)InterceptKeys.VK_RCONTROL)
                ctrlCaught = true;
            if (vkCode == (int)InterceptKeys.VK_LSHIFT || vkCode == (int)InterceptKeys.VK_RSHIFT)
                shiftCaught = true;
            if (vkCode == (int)InterceptKeys.IKEY)
                iCaught = true;
            if (ctrlCaught && shiftCaught && iCaught)
            {
                ReportIt("CRTL-Shift-I was caught.");
                var ipsumText = GetRandomIpsum();
                ReportIt($"Randon Ipsum:{ipsumText}");
                Clipboard.SetText(ipsumText);
                ResetCaught();
            }
        }
        else
        {
            if (nCode >= 0 && wParam == (IntPtr)InterceptKeys.WM_KEYUP)
                ResetCaught();
        }
        return InterceptKeys.CallNextHookEx(InterceptKeys._hookID, nCode, wParam, lParam);
    }

    private static void ResetCaught() =>
        ctrlCaught = shiftCaught = iCaught = false;

    private static void ReportIt(string message)
    {
        if (enableLogging)
            File.AppendAllText(logFileName, $"{DateTime.Now.ToString(dateFormat)}: {message}{Environment.NewLine}");
        if (enableDebugging)
            Console.Write(message);
    }

    private static string GetRandomIpsum()
    {
        Random r = new Random();
        int rInt = r.Next(0, ipsums.Count()-1);
        return ipsums[rInt];
    }

    private void UnhandledException(object sender, UnhandledExceptionEventArgs args)
    {
        Exception e = (Exception)args.ExceptionObject;
        ReportIt(e.Message);
    }

    private static List<string> LoadIpsums()
    {
        var result = new List<string>();
        string ipsumText;
        if (File.Exists("Ipsums.txt"))
        {
            ipsumText = File.ReadAllText("Ipsums.txt");
            ReportIt("Loading ipsums from extgernal file.");
        }
        else
        {
            ipsumText = EX.AssemblyExtensions.GetTextFileFromAssembly(Assembly.GetExecutingAssembly(), "Data.DefaultIpsums.txt");
            ReportIt("Loading ipsums from embeded content.");
        }
        var lines = ipsumText.Split(Environment.NewLine);
        result.AddRange(lines);
        return result;
    }

    private void IpsumMain_FormClosing(object sender, FormClosingEventArgs e) =>
        InterceptKeys.UnhookWindowsHookEx(InterceptKeys._hookID);

    private void btnExport_Click(object sender, EventArgs e)
    {
        sfd.InitialDirectory = Application.StartupPath;
        sfd.FileName = "Ipsums.txt";
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            ReportIt("Saving Ipsums");
            File.WriteAllText(sfd.FileName, string.Join(Environment.NewLine, ipsums));
        }
    }

    private void showIpsumWindowToolStripMenuItem_Click(object sender, EventArgs e) =>
        trayIcon_MouseDoubleClick(sender, (MouseEventArgs) e);

    private void exitIpsumToolStripMenuItem_Click(object sender, EventArgs e) =>
        Application.ExitThread();
    

    private void getRandomIpsumToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var msg = GetRandomIpsum();
        ReportIt($"Random Ipsum:{Environment.NewLine}{msg}");
        Clipboard.SetText(msg);
        MessageBox.Show($"Ipsum copied to clipboard:{Environment.NewLine}{msg}", "Ipsum", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void IpsumMain_Resize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
            this.Hide();
    }

    private void btnGetRandomIpsum_Click(object sender, EventArgs e) =>
        getRandomIpsumToolStripMenuItem_Click(sender, e);

    private void btnViewLog_Click(object sender, EventArgs e)
    {
        if(enableLogging)
        {
            ReportIt("Displaying log file contents.");
            if (this.viewer == null || this.viewer.IsDisposed)
            {
                this.viewer = new Viewer();
                viewer.Text = $"Ipsum Log Viewer - {logFileName}";
            }
            viewer.LoadText(File.ReadAllText(logFileName));
            viewer.Show();
        }
        else
        {
            ReportIt("Cannot show log file. Logging is not enabled.");
            MessageBox.Show("Logging not enabled. You can enable it with the 'l' command line argument.");
        }
    }

    private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        this.Show();
        WindowState = FormWindowState.Normal;
    }

    private void viewLogToolStripMenuItem_Click(object sender, EventArgs e) =>    
        btnViewLog_Click(sender, e);    
}
