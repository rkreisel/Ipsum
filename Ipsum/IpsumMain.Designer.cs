﻿namespace Ipsum
{
    partial class IpsumMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IpsumMain));
            this.btnExport = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showIpsumWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getRandomIpsumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitIpsumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetRandomIpsum = new System.Windows.Forms.Button();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.cmTrayIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(9, 61);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(204, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export Current Ipsums";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // sfd
            // 
            this.sfd.Filter = "TextFiles|*.txt|All Files|*.*";
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "Manage Ipsum";
            this.trayIcon.BalloonTipTitle = "Ipsum";
            this.trayIcon.ContextMenuStrip = this.cmTrayIcon;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Ipsum";
            this.trayIcon.Visible = true;
            // 
            // cmTrayIcon
            // 
            this.cmTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showIpsumWindowToolStripMenuItem,
            this.getRandomIpsumToolStripMenuItem,
            this.exitIpsumToolStripMenuItem});
            this.cmTrayIcon.Name = "cmTrayIcon";
            this.cmTrayIcon.Size = new System.Drawing.Size(187, 70);
            this.cmTrayIcon.DoubleClick += new System.EventHandler(this.cmTrayIcon_DoubleClick);
            // 
            // showIpsumWindowToolStripMenuItem
            // 
            this.showIpsumWindowToolStripMenuItem.Name = "showIpsumWindowToolStripMenuItem";
            this.showIpsumWindowToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showIpsumWindowToolStripMenuItem.Text = "Show Ipsum Window";
            this.showIpsumWindowToolStripMenuItem.Click += new System.EventHandler(this.showIpsumWindowToolStripMenuItem_Click);
            // 
            // getRandomIpsumToolStripMenuItem
            // 
            this.getRandomIpsumToolStripMenuItem.Name = "getRandomIpsumToolStripMenuItem";
            this.getRandomIpsumToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.getRandomIpsumToolStripMenuItem.Text = "Get Random Ipsum";
            this.getRandomIpsumToolStripMenuItem.Click += new System.EventHandler(this.getRandomIpsumToolStripMenuItem_Click);
            // 
            // exitIpsumToolStripMenuItem
            // 
            this.exitIpsumToolStripMenuItem.Name = "exitIpsumToolStripMenuItem";
            this.exitIpsumToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitIpsumToolStripMenuItem.Text = "Exit Ipsum";
            this.exitIpsumToolStripMenuItem.Click += new System.EventHandler(this.exitIpsumToolStripMenuItem_Click);
            // 
            // btnGetRandomIpsum
            // 
            this.btnGetRandomIpsum.Location = new System.Drawing.Point(9, 7);
            this.btnGetRandomIpsum.Name = "btnGetRandomIpsum";
            this.btnGetRandomIpsum.Size = new System.Drawing.Size(204, 23);
            this.btnGetRandomIpsum.TabIndex = 1;
            this.btnGetRandomIpsum.Text = "Get Random Ipsum";
            this.btnGetRandomIpsum.UseVisualStyleBackColor = true;
            this.btnGetRandomIpsum.Click += new System.EventHandler(this.btnGetRandomIpsum_Click);
            // 
            // btnViewLog
            // 
            this.btnViewLog.Location = new System.Drawing.Point(9, 34);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(204, 23);
            this.btnViewLog.TabIndex = 2;
            this.btnViewLog.Text = "View Log";
            this.btnViewLog.UseVisualStyleBackColor = true;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // IpsumMain
            // 
            this.AcceptButton = this.btnGetRandomIpsum;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 89);
            this.Controls.Add(this.btnGetRandomIpsum);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnViewLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IpsumMain";
            this.Text = "Ipsum";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IpsumMain_FormClosing);
            this.Resize += new System.EventHandler(this.IpsumMain_Resize);
            this.cmTrayIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnExport;
        private SaveFileDialog sfd;
        private NotifyIcon trayIcon;
        private ContextMenuStrip cmTrayIcon;
        private ToolStripMenuItem showIpsumWindowToolStripMenuItem;
        private ToolStripMenuItem getRandomIpsumToolStripMenuItem;
        private ToolStripMenuItem exitIpsumToolStripMenuItem;
        private Button btnGetRandomIpsum;
        private Button btnViewLog;
    }
}