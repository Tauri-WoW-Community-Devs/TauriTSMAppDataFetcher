using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Windows.Forms;
using TauriTSMAppDataFetcher.PriceTracking;
using TauriTSMAppDataFetcher.Properties;

namespace TauriTSMAppDataFetcher
{
    public partial class MainForm : Form
    {
        public static NotifyIcon TrayIcon;

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;
 

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32();
                    if (command == SC_MINIMIZE)
                    {
                        HideForm();  // For example
                    }
                    else
                    {
                        if(WindowState != FormWindowState.Normal || WindowState != FormWindowState.Maximized)
                            ShowForm();
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        public void HideForm()
        {
            Hide(); 
            this.Visible = false;
            this.Opacity = 0;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ShowInTaskbar = false;
            TrayIcon.Visible = true;
        }
        
        public void ShowForm()
        {
            Show();
            TrayIcon.Visible = false;
            this.Visible = true;
            this.Opacity = 100;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //or whatever it was previously set to
            this.ShowInTaskbar = true;
        }

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

            MinimizeBox = true;

            if (string.IsNullOrEmpty(Settings.Default.WoWLocation))
                SelectWoWDirectory();
            else
                ValidateWoWDirectory();


            foreach (var item in Enum.GetValues(typeof(Servers)).Cast<Servers>())
            {
                serverSelectorCombo.Items.Add(item);
            }

            serverSelectorCombo.DropDownWidth = serverSelectorCombo.Width;

            serverSelectorCombo.SelectedItem = (Servers)Settings.Default.SelectedServer;
            serverSelectorCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            TrayIcon.MouseDoubleClick += TrayIcon_MouseDoubleClick;

            FetchAppData();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            PriceTrackerUtils.PriceTrackerRequest();

            HideForm();
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
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


            string folderPath = Path.Combine(Settings.Default.WoWLocation, "Interface", "AddOns", "TradeSkillMaster_AuctionDB");
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch
            {
                MessageBox.Show($"Unable to create path {folderPath}. Try to run this app as admin.");
                return;
            }
            try
            {
                string baseUrl = "https://tsm.topsoft4u.com/get-tsm-appdata?realms[tauri]={0}&realms[mistblade]={1}&realms[mistbladeS2]={2}";
                string calculatedUrl = null;
                Servers selectedRealm = (Servers)Settings.Default.SelectedServer;
                switch (selectedRealm)
                {
                    case Servers.Both:
                        calculatedUrl = string.Format(baseUrl, 1, 1, 1);
                        break;
                    case Servers.Tauri:
                        calculatedUrl = string.Format(baseUrl, 1, 0, 0);
                        break;
                    case Servers.Stormforge:
                        calculatedUrl = string.Format(baseUrl, 0, 1, 1);
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(calculatedUrl))
                {
                    MessageBox.Show("Choose a server to get the data from");
                    return;
                }

                using (var wc = new WebClient())
                {
                    wc.DownloadFile(string.Format(calculatedUrl), Path.Combine(Settings.Default.WoWLocation, "Interface", "AddOns", "TradeSkillMaster_AuctionDB", "AppData.lua"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        private void timerCheckPrices_Tick(object sender, EventArgs e)
        {
            PriceTrackerUtils.PriceTrackerRequest();
        }

        private void serverSelectorCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = (int)((Servers)serverSelectorCombo.SelectedItem);

            if (Settings.Default.SelectedServer != selectedItem)
            {
                Settings.Default.SelectedServer = selectedItem;
                Settings.Default.Save();

                FetchAppData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrayPriceAlerts(sender, e);
        }
    }
}
