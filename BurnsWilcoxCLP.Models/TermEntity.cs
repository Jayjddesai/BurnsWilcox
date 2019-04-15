using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BurnsWilcoxCLP.Models
{
    public class TermEntity
    {
        #region Fields

        [Required]
        [DataType(DataType.Date)]
        public string EffectiveDate { get; set; }

        [Required]
        public int TermInMonths { get; set; }

        [Required]      
        public decimal MEP { get; set; }
             
        #endregion

        #region Methods

        public static List<ListModel> GetTermInMonthsList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "Month1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "Month2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "Month3"
                },
            };
        }
        #endregion
    }
}
