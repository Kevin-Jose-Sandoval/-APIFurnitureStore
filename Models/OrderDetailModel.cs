namespace APIFurnitureStore.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("order_detail")]
    public class OrderDetailModel
    {
        [Key, Column("order_id")]
        public int OrderId { get; set; }

        [Key, Column("product_id")]
        public int ProductId { get; set; }

        [JsonIgnore]
        public virtual ProductModel? Product { get; set; }
        [JsonIgnore]
        public virtual OrderModel? Order { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
