using System;
using System.Collections.Generic;
using System.Text;

namespace Hypixel.Model
{
    public class BAZAAR_CHILD
    {
        public string product_id { get; set; }
        public List<BAZAAR_BUY_SUMMARY> buy_summary { get; set; }
        public List<BAZAAR_SELL_SUMARY> sell_summary { get; set; }
        public BAZAAR_QUICK_STATUS quick_status { get; set; }
        public List<BAZAAR_WEEK_HISTORIC> week_historic { get; set; }
        public float AveragePrice { get; set; }
    }
}
