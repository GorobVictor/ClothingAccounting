using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingAccounting.DataBase.Model.sqlProduct {
    public class ProductPrice {
        public int Id { get; set; }
        public int IdSizeProduct { get; set; }
        [ForeignKey("IdSizeProduct")]
        public virtual SizeProduct SizeProduct { get; set; }
        public int IdColorProduct { get; set; }
        [ForeignKey("IdColorProduct")]
        public virtual ColorProduct ColorProduct { get; set; }
        public double FullPrice { get; set; }
        public double StockPrice { get; set; }
    }
}
