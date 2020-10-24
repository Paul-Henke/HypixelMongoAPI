using System;
using System.Collections.Generic;
using System.Text;

namespace Hypixel.Model
{
    public class BAZAAR_QUICK_STATUS
    {
        public string productId { get; set; }
        public float buyPrice { get; set; }
        public int buyVolume { get; set; }
        public int buyMovingWeek { get; set; }
        public int buyOrders { get; set; }
        public float sellPrice { get; set; }
        public int sellVolume { get; set; }
        public int sellMovingWeek { get; set; }
        public int sellOrders { get; set; }
    }
}
