using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BurnsWilcoxCLP.Models
{
    public class PartyEntity
    {

        #region fields 
        [Required]
        public int OfficeId { get; set; }

        [Required]
        public int ProducerId { get; set; }

        [Required]
        public string Agency { get; set; }

        [Required]
        public int AffiliateId { get; set; }
        #endregion

        #region Methods
        public static List<ListModel> GetOfficeList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "Office"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "Office2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "Office3"
                },
            };
        }


        public static List<ListModel> GetProducerList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "Producer"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "Producer2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "Producer3"
                },
            };
        }


        public static List<ListModel> GetAffiliateList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "Affiliate1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "Affiliate2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "Affiliate3"
                },
            };
        }
       #endregion
    }
   
}
