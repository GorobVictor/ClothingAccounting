using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingAccounting.DataBase.Model.sqlProduct {
    class ProductPrice {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
        public int IdSize { get; set; }
        [ForeignKey("IdSize")]
        public Size Size { get; set; }
        public int IdColor { get; set; }
        [ForeignKey("IdColor")]
        public Color Color { get; set; }
        public double FullPrice { get; set; }
        public double StockPrice { get; set; }
    }
}
