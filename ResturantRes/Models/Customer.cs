using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ResturantRes.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public int PhoneNumber { get; set; }

        [DisplayName("Reservation Date")]
        public DateTime ReservationDate { get; set; }

        [DisplayName("Mail Type")]
        public Mailtype mailType { get; set; }
    }

    public enum Mailtype
    {
        BreackFast = 0,
        Lunch,
        Dinner,
        Snaks,
        softdrinksWithShisha
    }
}
