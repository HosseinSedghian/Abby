namespace Abby.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int Count { get; set; }
        public double MenuItemPrice { get; set; }
        public string MenuItemName { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
