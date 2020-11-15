using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using TauriTSMAppDataFetcher.Properties;

namespace TauriTSMAppDataFetcher
{
    public partial class Form1 : Form
    {
        private NotifyIcon trayIcon;

        public Form1()
        {
            InitializeComponent();

            // Initialize Tray Icon
            trayIcon = new NotifyIcon
            {
                Icon = Icon,
                ContextMenu = new ContextMenu(new[] {
                    new MenuItem("Set WoW directory", TraySetWoWDir),
                    new MenuItem("-"),
                    new MenuItem("Exit", Exit)
                }),
                Visible = true
            };
            
            if (Settings.Default.WoWLocation + "" == "")
                SelectWoWDirectory();
            else
                ValidateWoWDirectory();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            FetchAppData();
        }

        private void SelectWoWDirectory(bool withClose = true)
        {
            var dir = SelectDirectory("Select your World of Warcraft directory");
            if (dir + "" == "")
            {
                if (withClose)
                    Application.Exit();
                else
                    return;
            }
            
            Settings.Default.WoWLocation = dir;
            Settings.Default.Save();

            ValidateWoWDirectory();
        }

        private void ValidateWoWDirectory()
        {
            // Keep selecting until a valid location is selected or none at all
            if (!Directory.Exists(Path.Combine(Settings.Default.WoWLocation, "Interface")))
                SelectWoWDirectory();
            else
                trayIcon.ShowBalloonTip(10000, "Valid WoW directory was selected", "Application can now run in background", ToolTipIcon.Info);
        }

        // private void OnTrayDoubleClick(object sender, EventArgs e)
        // {
        //     trayIcon.Visible = false;
        //     
        //     if (WindowState == FormWindowState.Minimized)
        //         WindowState = FormWindowState.Normal;
        //
        //     Activate();
        // }

        private void TraySetWoWDir(object sender, EventArgs e)
        {
            SelectWoWDirectory(false);
        }

        private void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
        
        private string SelectDirectory(string caption)
        {
            using(var fbd = new FolderBrowserDialog())
            {
                fbd.Description = caption;
                var result = fbd.ShowDialog();
                if (result != DialogResult.OK)
                    return "";

                return fbd.SelectedPath;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            trayIcon.Visible = false;
            trayIcon.Icon = null;
        }

        private void timerFetch_Tick(object sender, EventArgs e)
        {
            FetchAppData();
        }

        private void FetchAppData()
        {
            if (Settings.Default.WoWLocation + "" == "")
                return;

            try
            {
                using (var wc = new WebClient())
                {
                    wc.DownloadFile("https://tsm.topsoft4u.com/AppData.lua", Path.Combine(Settings.Default.WoWLocation, "Interface", "AddOns", "TradeSkillMaster_AuctionDB", "AppData.lua"));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
