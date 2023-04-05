namespace APIFurnitureStore.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("product")]
    public class ProductModel
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }
        
        // Many to One: Category
        public virtual CategoryModel Category { get; set; }

        // Many to Many: OrderDetail
        public virtual ICollection<OrderDetailModel> OrderDetails { get; set; }
    }
}
