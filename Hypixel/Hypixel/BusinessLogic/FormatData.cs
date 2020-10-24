using Hypixel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hypixel.BusinessLogic
{
    public class FormatData
    {
        public HashSet<BAZAAR> FormatBazaarItems(HashSet<BAZAAR> items)
        {
            float AveragePrice = 0;
            long time = DateTimeOffset.Now.ToUnixTimeMilliseconds() - 300000;
            HashSet<BAZAAR> res = new HashSet<BAZAAR>();
            foreach (BAZAAR item in items)
            {
                List<BAZAAR_WEEK_HISTORIC> res1 = new List<BAZAAR_WEEK_HISTORIC>();
                foreach (var item1 in item.product_info.week_historic)
                {
                    if (item1.timestamp >= time)
                        res1.Add(item1);
                }
                foreach (var item1 in item.product_info.sell_summary)
                {
                    AveragePrice += item1.pricePerUnit;
                }


                BAZAAR bas = item;
                bas.product_info.AveragePrice = AveragePrice / item.product_info.sell_summary.Count;
                bas.product_info.week_historic = res1;
                res.Add(bas);
            }
            return res;
        }

        public List<BAZAAR_CHILD> FormatDatas(HashSet<BAZAAR> items)
        {
            List<BAZAAR_CHILD> ret = new List<BAZAAR_CHILD>();
            foreach (BAZAAR item in items)
            {
                item.product_info.sell_summary = null;
                item.product_info.buy_summary = null;
                ret.Add(item.product_info);
            }
            return ret;
        }
    }
}
