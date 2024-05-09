using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.ComponentModel.DataAnnotations;

namespace Quadlab.Models
{
    public class cities
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "City name required")]
        [DisplayName("City Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country ID required")]
        [DisplayName("Country ID")]
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual country Country { get; set; }
    }
}
