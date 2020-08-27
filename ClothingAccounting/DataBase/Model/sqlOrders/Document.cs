using System.Collections.Generic;

namespace ClothingAccounting.DataBase.Model.sqlOrders {
    public class Document {
        public int Id { get; set; }
        public bool Type { get; set; }
        public virtual List<Position> Position { get; set; }
    }
}
