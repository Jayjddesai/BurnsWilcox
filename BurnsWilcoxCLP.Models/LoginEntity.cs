using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace BurnsWilcoxCLP.Models
{
    public class LoginEntity
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Email address required")]
        [DisplayName("Email Address")]
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password required")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Password { get; set; }
        public string AgencyName { get; set; }
        public string DisplayName { get; set; }
        public byte UserTypeId { get; set; }
    }
}
