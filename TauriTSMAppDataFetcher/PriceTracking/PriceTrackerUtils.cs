using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TauriTSMAppDataFetcher.Properties;

namespace TauriTSMAppDataFetcher.PriceTracking
{
    static class PriceTrackerUtils
    {
        public static DateTime lastNotify = DateTime.MinValue;
        public static List<PriceTrackerResponseItem> AuctionItems = new List<PriceTrackerResponseItem>();

        public static void PriceTrackerRequest()
        {
            if (Settings.Default.PriceTrackerData + "" == "")
                return;

            var ds = PriceTrackerDS.GetFromConfig();
            if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
                return;

            var body = new Dictionary<string, PriceTrackerRequestItem>();
            foreach (PriceTrackerDS.PriceTrackerRow row in ds.Tables[0].Rows)
            {
                body.Add(row.ItemID + "", new PriceTrackerRequestItem()
                {
                    Price = row.PriceCooper,
                    Faction = row.Faction
                });
            }

            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    wc.Headers.Add(HttpRequestHeader.Accept, "application/json");

                    var json = JsonConvert.SerializeObject(body);
                    wc.UploadStringCompleted += (sender, e) =>
                    {
                        if (e.Error != null)
                        {
                            Console.WriteLine(e.Error.Message);
                            return;
                        }

                        var result = JsonConvert.DeserializeObject<PriceTrackerResponseItem[]>(e.Result);
                        if (result == null)
                        {
                            AuctionItems = new List<PriceTrackerResponseItem>();
                            return;
                        }

                        AuctionItems = result.ToList();

                        var count = result.Sum(x => x.StackCount);
                        if (count > 0 && lastNotify.AddHours(1) < DateTime.Now)
                        {
                            MainForm.TrayIcon.ShowBalloonTip(10000, "Price tracker",
                                $"{count} items from price tracker matches their conditions", ToolTipIcon.Info);
                            lastNotify = DateTime.Now;
                        }
                    };
                    wc.UploadStringAsync(new Uri("http://localhost:9876/check-prices"), "POST", json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class PriceTrackerRequestItem
    {
        [JsonProperty("price")] public ulong Price;
        [JsonProperty("faction")] public string Faction;
    }

    public class PriceTrackerResponseItem
    {
        [JsonProperty("itemId")] public ulong ItemId { get; set; }
        [JsonProperty("itemName")] public string ItemName { get; set; }
        [JsonProperty("pricePerItem")] public ulong PricePerItem { get; set; }
        [JsonProperty("timeLeft")] public string TimeLeft { get; set; }
        [JsonProperty("stackCount")] public uint StackCount { get; set; }
    }
}