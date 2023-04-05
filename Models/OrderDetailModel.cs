namespace APIFurnitureStore.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("order_detail")]
    public class OrderDetailModel
    {
        [Key, Column("order_id")]
        public int OrderId { get; set; }

        [Key, Column("product_id")]
        public int ProductId { get; set; }

        public virtual ProductModel Product { get; set; }
        public virtual OrderModel Order { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
