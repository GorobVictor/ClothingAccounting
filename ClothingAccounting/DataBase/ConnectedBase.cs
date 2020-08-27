using Microsoft.EntityFrameworkCore;

namespace ClothingAccounting.DataBase {
    class ConnectedBase : DbContext {
        private string _connectedKey { get; set; }
        public ConnectedBase(string connectedKey) {
            _connectedKey = connectedKey;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies()
               .UseSqlServer(_connectedKey);
    }
}
