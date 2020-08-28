using ClothingAccounting.DataBase.Model.Result;
using ClothingAccounting.DataBase.Model.sqlOrders;
using ClothingAccounting.DataBase.Model.sqlPeople;
using ClothingAccounting.DataBase.Model.sqlProduct;
using ExcelLibrary.SpreadSheet;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClothingAccounting.DataBase {
    public class ConnectedBase : DbContext {
        private string _connectedKey { get; set; }
        public ConnectedBase(string connectedKey) {
            _connectedKey = connectedKey;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies()
               .UseSqlServer(_connectedKey);
        public DbSet<Document> Document { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<ColorProduct> ColorProduct { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<DeliveryProduct> DeliveryProduct { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPhoto> ProductPhoto { get; set; }
        public DbSet<ProductPrice> ProductPrice { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<SizeProduct> SizeProduct { get; set; }
        /// <summary>
        /// Возвращает объект баланса с полами {IdProduct, product, size, color, FullPrice, StockPrice, staff, Quantity}
        /// </summary>
        /// <returns>Возвращает объект баланса с полами {IdProduct, product, size, color, FullPrice, StockPrice, staff, Quantity}</returns>
        public IEnumerable<Balance> GetBalance() =>
               from pos in Position.ToList()
               join dock in Document.ToList() on pos.IdDock equals dock.Id
               join prod in Product.ToList() on pos.IdProduct equals prod.Id
               join price in ProductPrice.ToList()
               on new { pos.IdColorProduct, pos.IdSizeProduct } equals new { price.IdColorProduct, price.IdSizeProduct }
               group pos by new {
                   pos.IdProduct,
                   product = pos.Product.Name,
                   size = pos.SizeProduct.Size.Name,
                   color = pos.ColorProduct.Color.Name,
                   price.FullPrice,
                   price.StockPrice,
                   delivery = prod.GetDelivery(),
                   staff = pos.Staff.Name
               } into final
               select new Balance {
                   IdProduct = final.Key.IdProduct,
                   Product = final.Key.product,
                   Size = final.Key.size,
                   Color = final.Key.color,
                   FullPrice = final.Key.FullPrice,
                   StockPrice = final.Key.StockPrice,
                   Staff = final.Key.staff,
                   Delivery = final.Key.delivery,
                   Quantity = final.Sum(x => x.Document.Type == true ? x.Quantity : x.Quantity * -1)
               };

        public IEnumerable<MovementOfGoods> GetMovementOfGoods() =>
               from pos in Position.ToList()
               join dock in Document.ToList() on pos.IdDock equals dock.Id
               join prod in Product.ToList() on pos.IdProduct equals prod.Id
               join price in ProductPrice.ToList()
               on new { pos.IdColorProduct, pos.IdSizeProduct } equals new { price.IdColorProduct, price.IdSizeProduct }
               group pos by new {
                   pos.Id,
                   pos.IdProduct,
                   product = pos.Product.Name,
                   size = pos.SizeProduct.Size.Name,
                   color = pos.ColorProduct.Color.Name,
                   price.FullPrice,
                   price.StockPrice,
                   delivery = prod.GetDelivery(),
                   staff = pos.Staff.Name,
                   type = dock.Type,
                   pos.Quantity,
                   pos.Date
               } into final
               select new MovementOfGoods {
                   Id = final.Key.Id,
                   IdProduct = final.Key.IdProduct,
                   Product = final.Key.product,
                   Size = final.Key.size,
                   Color = final.Key.color,
                   FullPrice = final.Key.FullPrice,
                   StockPrice = final.Key.StockPrice,
                   Staff = final.Key.staff,
                   Delivery = final.Key.delivery,
                   Date = final.Key.Date,
                   Quantity = final.Key.type == true ? final.Key.Quantity : final.Key.Quantity * -1
               };

        public string SaveBalance(string name) {
            var balance = GetBalance().ToList();
            var worksheet = new Worksheet("balance");
            if (balance.Count() < 101)
                for (int i = balance.Count(); i < balance.Count() + 101; i++)
                    worksheet.Cells[i, 0] = new Cell("");

            for (int i = 0; i < balance.Count(); i++) {
                worksheet.Cells[i, 0] = new Cell(balance[i].IdProduct);
                worksheet.Cells[i, 1] = new Cell(balance[i].Product);
                worksheet.Cells[i, 2] = new Cell(balance[i].Size);
                worksheet.Cells[i, 3] = new Cell(balance[i].Color);
                worksheet.Cells[i, 4] = new Cell(balance[i].FullPrice);
                worksheet.Cells[i, 5] = new Cell(balance[i].StockPrice);
                worksheet.Cells[i, 6] = new Cell(balance[i].Staff);
                worksheet.Cells[i, 7] = new Cell(balance[i].Delivery);
                worksheet.Cells[i, 8] = new Cell(balance[i].Quantity);
            }
            var book = new Workbook();
            book.Worksheets.Add(worksheet);
            if (!Directory.Exists("Result")) Directory.CreateDirectory("Result");
            book.Save($"Result\\{name}.xls");
            return $"Result\\{name}";
        }
        public string SaveMovementOfGoods(string name) {
            var balance = GetMovementOfGoods().ToList();
            var worksheet = new Worksheet("balance");
            if (balance.Count() < 101)
                for (int i = balance.Count(); i < balance.Count() + 101; i++)
                    worksheet.Cells[i, 0] = new Cell("");

            for (int i = 0; i < balance.Count(); i++) {
                worksheet.Cells[i, 0] = new Cell(balance[i].Id);
                worksheet.Cells[i, 1] = new Cell(balance[i].Date);
                worksheet.Cells[i, 2] = new Cell(balance[i].IdProduct);
                worksheet.Cells[i, 3] = new Cell(balance[i].Product);
                worksheet.Cells[i, 4] = new Cell(balance[i].Size);
                worksheet.Cells[i, 5] = new Cell(balance[i].Color);
                worksheet.Cells[i, 6] = new Cell(balance[i].FullPrice);
                worksheet.Cells[i, 7] = new Cell(balance[i].StockPrice);
                worksheet.Cells[i, 8] = new Cell(balance[i].Staff);
                worksheet.Cells[i, 9] = new Cell(balance[i].Delivery);
                worksheet.Cells[i, 10] = new Cell(balance[i].Quantity);
            }
            var book = new Workbook();
            book.Worksheets.Add(worksheet);
            if (!Directory.Exists("Result")) Directory.CreateDirectory("Result");
            book.Save($"Result\\{name}.xls");
            return $"Result\\{name}";
        }
        public string SaveStaff(string name) {
            var result = MainWindow._connectedBase.Staff.AsEnumerable().ToList();
            var worksheet = new Worksheet("balance");
            if (result.Count() < 101)
                for (int i = result.Count(); i < result.Count() + 101; i++)
                    worksheet.Cells[i, 0] = new Cell("");

            for (int i = 0; i < result.Count(); i++) {
                worksheet.Cells[i, 0] = new Cell(result[i].Id);
                worksheet.Cells[i, 1] = new Cell(result[i].IdPost);
                worksheet.Cells[i, 2] = new Cell(result[i].Name);
                worksheet.Cells[i, 3] = new Cell(result[i].getPost);
            }
            var book = new Workbook();
            book.Worksheets.Add(worksheet);
            if (!Directory.Exists("Result")) Directory.CreateDirectory("Result");
            book.Save($"Result\\{name}.xls");
            return $"Result\\{name}";
        }
        public string SaveUsers(string name) {
            var result = MainWindow._connectedBase.Users.AsEnumerable().ToList();
            var worksheet = new Worksheet("balance");
            if (result.Count() < 101)
                for (int i = result.Count(); i < result.Count() + 101; i++)
                    worksheet.Cells[i, 0] = new Cell("");

            for (int i = 0; i < result.Count(); i++) {
                worksheet.Cells[i, 0] = new Cell(result[i].Id);
                worksheet.Cells[i, 1] = new Cell(result[i].Name);
                worksheet.Cells[i, 2] = new Cell(result[i].Phone);
                worksheet.Cells[i, 3] = new Cell(result[i].Email);
                worksheet.Cells[i, 4] = new Cell(result[i].Bonus);
            }
            var book = new Workbook();
            book.Worksheets.Add(worksheet);
            if (!Directory.Exists("Result")) Directory.CreateDirectory("Result");
            book.Save($"Result\\{name}.xls");
            return $"Result\\{name}";
        }
    }
}
