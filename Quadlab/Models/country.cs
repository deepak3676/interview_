using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quadlab.Models
{
    public class country
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Country name required")]
        [DisplayName("Country Name")]
        public string Name { get; set; }
    }
}
