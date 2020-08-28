using System.Collections.Generic;

namespace ClothingAccounting.DataBase.Model.sqlProduct {
    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Articul { get; set; }
        public virtual List<ColorProduct> ColorProduct { get; set; }
        public virtual List<SizeProduct> SizeProduct { get; set; }
        public virtual List<ProductPhoto> ProductPhoto { get; set; }
        public virtual List<DeliveryProduct> DeliveryProduct { get; set; }
        public string GetDelivery() {
            string result = "";
            foreach (var delivery in DeliveryProduct)
                if (result == "")
                    result = delivery.Delivery.Name;
                else
                    result += $", {delivery.Delivery.Name}";
            return result;
        }
    }
}
