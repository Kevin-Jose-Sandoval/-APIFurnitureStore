namespace APIFurnitureStore.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
    }
}
