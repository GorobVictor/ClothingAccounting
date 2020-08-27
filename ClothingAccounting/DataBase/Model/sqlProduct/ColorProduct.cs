using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingAccounting.DataBase.Model.sqlProduct {
    public class ColorProduct {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        public int IdColor { get; set; }
        [ForeignKey("IdColor")]
        public virtual Color Color { get; set; }
        public virtual List<ProductPrice> ProductPrice { get; set; }
    }
}
