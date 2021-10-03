using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using TauriTSMAppDataFetcher.PriceTracking;
using TauriTSMAppDataFetcher.Properties;

namespace TauriTSMAppDataFetcher
{
    public partial class MainForm : Form
    {
        public static NotifyIcon TrayIcon;

        public MainForm()
        {
            InitializeComponent();

            // Initialize Tray Icon
            TrayIcon = new NotifyIcon
            {
                Icon = Icon,
                ContextMenu = new ContextMenu(new[] {
                    new MenuItem("Price Alerts", TrayPriceAlerts),
                    new MenuItem("Setup Price Alerts", TraySetupPriceAlerts),
                    new MenuItem("-"),
                    new MenuItem("Set WoW directory", TraySetWoWDir),
                    new MenuItem("-"),
                    new MenuItem("Exit", Exit)
                }),
                Visible = true
            };

            TrayIcon.MouseDoubleClick += TrayIcon_MouseDoubleClick;

            if (Settings.Default.WoWLocation + "" == "")
                SelectWoWDirectory();
            else
                ValidateWoWDirectory();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            FetchAppData();

            PriceTrackerUtils.PriceTrackerRequest();
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void TrayPriceAlerts(object sender, EventArgs e)
        {
            var form = new PriceTrackerListingForm();
            form.Show();
        }

        private void TraySetupPriceAlerts(object sender, EventArgs e)
        {
            var form = new PriceTrackerSettingsForm();
            form.Show();
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
                TrayIcon.ShowBalloonTip(10000, "Valid WoW directory was selected", "Application can now run in background", ToolTipIcon.Info);
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
            TrayIcon.Visible = false;
            Application.Exit();
        }

        private string SelectDirectory(string caption)
        {
            using (var fbd = new FolderBrowserDialog())
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
            TrayIcon.Visible = false;
            TrayIcon.Icon = null;
        }

        #region Fetch LUA

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
                    wc.DownloadFile("https://tsm.topsoft4u.com/get-tsm-appdata", Path.Combine(Settings.Default.WoWLocation, "Interface", "AddOns", "TradeSkillMaster_AuctionDB", "AppData.lua"));
                }
            }
            catch (Exception)
            {
                // MessageBox.Show(e.Message);
            }
        }


        #endregion

        private void timerCheckPrices_Tick(object sender, EventArgs e)
        {
            PriceTrackerUtils.PriceTrackerRequest();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                TrayIcon.Visible = true;
                ShowInTaskbar = false;
            }
            else if (this.WindowState == FormWindowState.Normal || this.WindowState  == FormWindowState.Maximized)
            {
                ShowInTaskbar = true;
            }
        }
    }
}
