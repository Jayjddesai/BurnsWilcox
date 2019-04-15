using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace BurnsWilcoxCLP.Models
{

    public class UserEntity
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Display name is required")]
        [MaxLength(50, ErrorMessage = "MaxLength is 50 character.")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [MaxLength(50, ErrorMessage = "MaxLength is 50 character.")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,50}", ErrorMessage = "Please enter correct email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "password is required")]
        [MaxLength(50, ErrorMessage = "MaxLength is 50 character.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwor ConfirmPassword Mismatch")]
        public string ConfirmPassword { get; set; }

        public bool IsSelected { get; set; }
        [Required(ErrorMessage = "Ofiice name is required")]
        public Nullable<int> OfficeId { get; set; }

        [Required(ErrorMessage = "Accesscode is required")]
        public string AccessCode { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public Nullable<int> ProducerId { get; set; }


        public string AdressCode { get; set; }

        public Nullable<int> CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public Nullable<byte> UserTypeId { get; set; }
       
        public string UserTypeName { get; set; }
        public int AgencyId { get; set; }
        public string AgencyTypeName { get; set; }
        public bool IsUserVerified { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }  

    }


    public class UserMasterList
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string AccessCode { get; set; }
        public string UserTypeName { get; set;}
        public string OfficeName { get; set; }
        public string ProducerName { get; set; }
        public string AgencyName { get; set; }
        public string IsEmailVerified { get; set; }
        public string IsUserVerified { get; set; }
        public string IsActive { get; set; }
    }
}
