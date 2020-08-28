using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingAccounting.DataBase.Model.Result {
    public class Balance {
        public int IdProduct { get; set; }
        public string Product { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public double FullPrice { get; set; }
        public double StockPrice { get; set; }
        public string Staff { get; set; }
        public string Delivery { get; set; }
        public int Quantity { get; set; }
    }
}
