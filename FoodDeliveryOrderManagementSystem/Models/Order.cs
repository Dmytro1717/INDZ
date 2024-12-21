namespace FoodDeliveryAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string FoodItem { get; set; }
        public double Price { get; set; }
        public string Status { get; set; } 
    }
}
