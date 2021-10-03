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
            if (!ulong.TryParse(value + "", out ulong cooperVal))
                return value + "";

            ulong copper = cooperVal % 100;
            cooperVal= (cooperVal - copper) / 100;
            ulong silver = cooperVal % 100;
            ulong gold = (cooperVal - silver) / 100;

            string result = string.Empty;
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
