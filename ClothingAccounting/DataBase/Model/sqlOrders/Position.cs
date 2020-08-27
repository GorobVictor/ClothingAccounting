using System.ComponentModel.DataAnnotations.Schema;
using ClothingAccounting.DataBase.Model.sqlPeople;
using ClothingAccounting.DataBase.Model.sqlProduct;

namespace ClothingAccounting.DataBase.Model.sqlOrders {
    class Position {
        public int Id { get; set; }
        public int IdDock { get; set; }
        [ForeignKey("IdDock")]
        public Document Document { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
        public int IdSize { get; set; }
        [ForeignKey("IdSize")]
        public Size Size { get; set; }
        public int IdColor { get; set; }
        [ForeignKey("IdColor")]
        public Color Color { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public Users User { get; set; }
        public int Quantity { get; set; }
    }
}
