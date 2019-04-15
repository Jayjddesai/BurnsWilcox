using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BurnsWilcoxCLP.Models
{
    public class LocationEntity
    {
        #region fields
        [Required]
        public int LocationId { get; set; }

        [Required]
        public string LocationDescription { get; set; }

        [Required]
        public string AddessL1 { get; set; }

        [Required]
        public string AddessL2 { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string TownCode { get; set; }

        [Required]
        public bool InCity { get; set; }
        #endregion
    }


}
