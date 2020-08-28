using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ClothingAccounting.DataBase.Model.sqlPeople;
using ClothingAccounting.DataBase.Model.sqlProduct;

namespace ClothingAccounting.DataBase.Model.sqlOrders {
    public class Position {
        public int Id { get; set; }
        public int IdDock { get; set; }
        [ForeignKey("IdDock")]
        public virtual Document Document { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        public int IdSizeProduct { get; set; }
        [ForeignKey("IdSizeProduct")]
        public virtual SizeProduct SizeProduct { get; set; }
        public int IdColorProduct { get; set; }
        [ForeignKey("IdColorProduct")]
        public virtual ColorProduct ColorProduct { get; set; }
        public int IdStaff { get; set; }
        [ForeignKey("IdStaff")]
        public virtual Staff Staff { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
