using System.Collections.Generic;

namespace ClothingAccounting.DataBase.Model.sqlProduct {
    public class Color {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<ColorProduct> ColorProduct { get; set; }
    }
}
