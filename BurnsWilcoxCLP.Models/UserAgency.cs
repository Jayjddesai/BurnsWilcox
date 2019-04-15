using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnsWilcoxCLP.Models
{
    public class UserAgency
    {
        // User Master Details
        public int UserId { get; set; }

        [Required(ErrorMessage = "Display name is required")]
        [MaxLength(50, ErrorMessage = "MaxLength is 50 character.")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [MaxLength(50, ErrorMessage = "MaxLength is 50 character.")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,50}", ErrorMessage = "Please enter correct email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(50, ErrorMessage = "MaxLength is 50 character.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Confirm Password Mismatch")]
        public string ConfirmPassword { get; set; }

        public bool IsSelected { get; set; }
        [Required(ErrorMessage = "Office name is required")]
        public Nullable<int> OfficeId { get; set; }

        [Required(ErrorMessage = "Access Code is required")]
        public string AccessCode { get; set; }

        [Required(ErrorMessage = "Producer Name is required")]
        public Nullable<int> ProducerId { get; set; }


        //public string AdressCode { get; set; }

        public Nullable<int> CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public Nullable<byte> UserTypeId { get; set; }

        public string UserTypeName { get; set; }

        public string AgencyTypeName { get; set; }
        public bool IsUserVerified { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }


        // Agency Details
        public int AgencyId { get; set; }
        [Required(ErrorMessage = "Agency Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        [MaxLength(10, ErrorMessage = "MaxLength is 10 character.")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MaxLength(10, ErrorMessage = "MaxLength is 10 character.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Stateis required")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Phone  is required")]
        [MaxLength(10, ErrorMessage = "Enter valid mobile number.")]
        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Enter valid phone number.")]
        public string Phone { get; set; }
    }
}
