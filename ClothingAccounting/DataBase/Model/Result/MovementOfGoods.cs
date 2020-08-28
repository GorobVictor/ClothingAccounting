using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingAccounting.DataBase.Model.Result {
    public class MovementOfGoods : Balance {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
