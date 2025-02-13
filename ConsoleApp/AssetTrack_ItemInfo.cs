using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class AssetTrack_ItemInfo
    {
        public int Id { get; set; } //Primary key
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Location { get; set; }
        public double PriceInUSD { get; set; }
        public string Currency { get; set; }
        public double LocalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
