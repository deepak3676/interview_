using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Quadlab.Models
{
    public class modelClass
    {
        [Key]
        public int userId { get; set; }
        [Required(ErrorMessage = "User name required")]
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "User last required")]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "User email required")]
        [DisplayName("User Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "User Gender required")]
        [DisplayName("User Gender")]
        public string gender { get; set; }
        [Required(ErrorMessage = "User phone required")]
        [DisplayName("Phone Number")]
        public string phone { get; set; }
        [Required(ErrorMessage = "City required")]
        [DisplayName("City Name")]
        public string city { get; set; }
        [Required(ErrorMessage = "Country required")]
        [DisplayName("Country Name")]
        public string country { get; set; }
    }
}
