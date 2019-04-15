using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnsWilcoxCLP.Models
{
    public class AgencyEntity
    {
        //public UserDetailEntity userdetailentity { get; set; }
        public int AgencyId { get; set; }
        [Required(ErrorMessage = "Agencyname is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        [MaxLength(10, ErrorMessage = "MaxLength is 10 character.")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "City  name is required")]
        [MaxLength(10, ErrorMessage = "MaxLength is 10 character.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State name is required")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "Country  name is required")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Phone  is required")]
        [MaxLength(10, ErrorMessage = "Enter valid mobile number.")]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter valid phone number.")]
        public string Phone { get; set; }
    }
}