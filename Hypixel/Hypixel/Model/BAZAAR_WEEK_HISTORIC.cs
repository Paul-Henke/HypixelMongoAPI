using System;
using System.Collections.Generic;
using System.Text;

namespace Hypixel.Model
{
    public class BAZAAR_WEEK_HISTORIC
    {
        public string productId { get; set; }
        public Int64 timestamp { get; set; }
        public int nowBuyVolume { get; set; }
        public int nowSellVolume { get; set; }
        public float buyCoins { get; set; }
        public int buyVolume { get; set; }
        public int buys { get; set; }
        public float sellCoins { get; set; }
        public int sellVolume { get; set; }
        public int sells { get; set; }
    }
}
