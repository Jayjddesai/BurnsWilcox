using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace BurnsWilcoxCLP.Models
{
    public class TeamEntity
    {

        public Int64 TeamId { get; set; }
        [Required(ErrorMessage = "Team name is required")]
        public string TeamName { get; set; }

        [Required(ErrorMessage="Effective date is required")]
        //[DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public Nullable<DateTime> EffectiveDate { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
         
        

        //public List<UserEntity> GetAllUser { get; set; }
        //public List<UserEntity> GetSelectUser { get; set; }


        public SelectList AvailableUser { get; set; }
        public SelectList SelectUser { get; set; }
        public string TeamMemberName { get; set; }

        


        public string dateeffective
        {
            get { return string.Format("{0}", EffectiveDate.Value.ToShortDateString()); }
        }
        

    }
}
