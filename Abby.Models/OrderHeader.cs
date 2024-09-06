using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Abby.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Order Price")]
        public double OrderTotalPrice { get; set; }
        [Required]
        [Display(Name = "Pickup Time")]
        public DateTime PickupTime { get; set; }
        [Required]
        [NotMapped]
        public DateTime PickupDate { get; set; }
        [Required]
        public string Status { get; set; }
        public string? Comments { get; set; }
        public string? TransactionId { get; set; }
        [Display(Name = "Pickup Name")]
        public string PickupName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
