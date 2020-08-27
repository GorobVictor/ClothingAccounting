using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Documents;

namespace ClothingAccounting.DataBase.Model.sqlProduct {
    public class SizeProduct {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        public int IdSize { get; set; }
        [ForeignKey("IdSize")]
        public virtual Size Size { get; set; }
        public virtual List<ProductPrice> ProductPrice { get; set; }
    }
}
