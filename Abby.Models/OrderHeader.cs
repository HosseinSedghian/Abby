using System.ComponentModel.DataAnnotations;
namespace Abby.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime OrderDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Order Price")]
        public double OrderTotalPrice { get; set; }
        [Display(Name = "Pickup Time")]
        public DateTime PickupTime { get; set; }
        public DateTime PickupDate { get; set; }
        public string Status { get; set; }
        public string? Comments { get; set; }
        public string? TransactionId { get; set; }
        [Display(Name = "Pickup Name")]
        public string PickupName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
