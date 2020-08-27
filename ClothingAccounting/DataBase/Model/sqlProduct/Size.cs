using System.Collections.Generic;

namespace ClothingAccounting.DataBase.Model.sqlProduct {
    public class Size {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<SizeProduct> SizeProduct { get; set; }
    }
}
