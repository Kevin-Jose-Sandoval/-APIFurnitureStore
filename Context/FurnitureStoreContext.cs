using APIFurnitureStore.Models;
using Microsoft.EntityFrameworkCore;

namespace APIFurnitureStore.Context
{
    public class FurnitureStoreContext : DbContext
    {
        public FurnitureStoreContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<OrderDetailModel> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetailModel>()
                .HasKey(orderDetailModel => new { orderDetailModel.OrderId, orderDetailModel.ProductId });
        }
    }
}
