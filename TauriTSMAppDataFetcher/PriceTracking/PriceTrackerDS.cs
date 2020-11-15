using System;
using System.Data;
using Newtonsoft.Json;

namespace TauriTSMAppDataFetcher.PriceTracking
{
    public partial class PriceTrackerDS
    {
        public static DataSet GetFromConfig()
        {
            if (Properties.Settings.Default.PriceTrackerData + "" == "")
                return null;

            try
            {
                return JsonConvert.DeserializeObject<PriceTrackerDS>(Properties.Settings.Default.PriceTrackerData);
            }
            catch (Exception)
            {
                Properties.Settings.Default.PriceTrackerData = null;
                Properties.Settings.Default.Save();
            }

            return null;
        }
    }
}