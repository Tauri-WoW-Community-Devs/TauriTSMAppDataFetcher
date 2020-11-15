using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TauriTSMAppDataFetcher.PriceTracking;

namespace TauriTSMAppDataFetcher
{
    public partial class PriceTrackerSettingsForm : Form
    {
        public PriceTrackerSettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            var ds = PriceTrackerDS.GetFromConfig();
            if (ds == null)
                return;
            
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                priceTrackerDS.PriceTracker.Rows.Add(row.ItemArray);
            }
        }

        private void PriceTrackerSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.PriceTrackerData = JsonConvert.SerializeObject(priceTrackerDS);
            Properties.Settings.Default.Save();
        }

        private void gridPrices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
                return;
            
            var index = e.RowIndex;
            var row = gridPrices.Rows[index];
            if (row.IsNewRow)
                return;

            gridPrices.Rows.RemoveAt(index);
        }

        private void gridPrices_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var cIndex = e.ColumnIndex;
            var rIndex = e.RowIndex;
            
            var value = e.FormattedValue + "";

            if (value == "")
                return;

            var row = gridPrices.Rows[rIndex];
            
            if (row.IsNewRow)
                return;

            switch (cIndex)
            {
                case 0:
                case 1:
                {
                    ulong numberVal;
                    if (!ulong.TryParse(e.FormattedValue + "", out numberVal))
                    {
                        e.Cancel = true;
                        row.ErrorText = $"Column '{gridPrices.Columns[cIndex].HeaderText}' must be a value > 0";
                    }
                    return;
                }
            }
        }
    }
}
