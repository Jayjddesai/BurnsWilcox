using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BurnsWilcoxCLP.Models
{
     public class InsuredEntity
    {
        #region Fields

        [Required]
        public int InsuredType { get; set; }

        [Required]
        public int Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string MiddleName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        public int Suffix { get; set; }

        [Required]
        public int LegalEntity { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string HomePhone { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string BussinessPhone { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        [Required]
        public string AddressLine2 { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }
        #endregion

        public bool SaveAsFirstLocation { get; set; }
        #region Methods

        public static List<ListModel> GetInsuredTypeList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "InsuredType1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "InsuredType2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "InsuredType3"
                },
            };
        }

        public static List<ListModel> GetTitleList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "Title1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "Title2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "Title3"
                },
            };
        }

        public static List<ListModel> GetSuffixList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "Suffix1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "Suffix2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "Suffix3"
                },
            };
        }

        public static List<ListModel> GetLEList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "Legal Entity1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "Legal Entity2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "Legal Entity3"
                },
            };
        }
        #endregion
    }
}
