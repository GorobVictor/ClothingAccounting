using ClothingAccounting.DataBase.Model.sqlOrders;
using ClothingAccounting.DataBase.Model.sqlPeople;
using ClothingAccounting.DataBase.Model.sqlProduct;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPhoto> ProductPhoto { get; set; }
        public DbSet<ProductPrice> ProductPrice { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<SizeProduct> SizeProduct { get; set; }
    }
}
