using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingAccounting.DataBase.Model.sqlProduct {
    public class DeliveryProduct {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        public int IdDelivery { get; set; }
        [ForeignKey("IdDelivery")]
        public virtual Delivery Delivery { get; set; }
    }
}
