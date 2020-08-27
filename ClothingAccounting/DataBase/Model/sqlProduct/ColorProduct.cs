using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingAccounting.DataBase.Model.sqlProduct {
    class ColorProduct {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
        public int IdColor { get; set; }
        [ForeignKey("IdColor")]
        public Color Color { get; set; }
    }
}
