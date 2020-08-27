using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingAccounting.DataBase.Model.sqlProduct {
    class SizeProduct {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
        public int IdSize { get; set; }
        [ForeignKey("IdColor")]
        public Size Size { get; set; }
    }
}
