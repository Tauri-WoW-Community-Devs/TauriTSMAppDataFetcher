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
    public partial class PriceTrackerListingForm : Form
    {
        public PriceTrackerListingForm()
        {
            InitializeComponent();
            
            FillItems();
        }

        private void FillItems()
        {
            if (PriceTrackerUtils.AuctionItems == null || PriceTrackerUtils.AuctionItems.Count <= 0)
                return;
            
            gridAuctions.DataSource = PriceTrackerUtils.AuctionItems;
        }

        private void gridAuctions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var cIndex = e.ColumnIndex;
            var rIndex = e.RowIndex;

            var row = gridAuctions.Rows[rIndex];

            // Buyout
            if (cIndex == 2)
            {
                e.Value = Utils.FormatGold(row.Cells[cIndex].Value);
                e.FormattingApplied = true;
            }
            // Time left
            else if (cIndex == 3)
            {
                var value = row.Cells[cIndex].Value + "";
                switch (value)
                {
                    case "VERY_LONG":
                        e.Value = "12h-48h";
                        e.FormattingApplied = true;
                        break;
                    case "LONG":
                        e.Value = "2h-12h";
                        e.FormattingApplied = true;
                        break;
                    case "MEDIUM":
                        e.Value = "30m-2h";
                        e.FormattingApplied = true;
                        break;
                    case "SHORT":
                        e.Value = "< 30m";
                        e.FormattingApplied = true;
                        break;
                }
            }
        }
    }
}
