using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TauriTSMAppDataFetcher
{
    public static class Utils
    {
        public static string FormatGold(object value)
        {
            ulong cooperVal;
            if (!ulong.TryParse(value + "", out cooperVal))
                return value + "";
            
            var copper = cooperVal % 100;
            cooperVal= (cooperVal - copper) / 100;
            var silver = cooperVal % 100;
            var gold = (cooperVal - silver) / 100;

            var result = "";
            if (gold > 0)
                result += gold + "g";
            if (silver > 0)
                result += (silver + "").PadLeft(2, '0') + "s";
            if (copper > 0)
                result += (copper + "").PadLeft(2, '0') + "c";

            return result;
        }
    }
}
