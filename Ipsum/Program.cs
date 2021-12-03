namespace Ipsum
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            const string appName = "Ipsum";
            bool createdNew;
            var mutex = new Mutex(true, appName, out createdNew);
            if (!createdNew)
                return;

            ApplicationConfiguration.Initialize();
            Application.ThreadExit += Application_ThreadExit;
            Application.Run(new IpsumMain(args));
        }

        private static void Application_ThreadExit(object? sender, EventArgs e)
        {
            InterceptKeys.UnhookWindowsHookEx(InterceptKeys._hookID);
            Application.ThreadExit -= Application_ThreadExit;
        }
    }
}