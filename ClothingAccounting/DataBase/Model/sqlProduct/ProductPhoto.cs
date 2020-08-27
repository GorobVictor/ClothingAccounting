using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingAccounting.DataBase.Model.sqlProduct {
    class ProductPhoto {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
        public string Url { get; set; }
    }
}
