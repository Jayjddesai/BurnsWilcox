using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnsWilcoxCLP.Models
{
    public class UserTypeEntity
    {
       

       

        public int UserTypeId { get; set; }
        
        public string Name { get; set; }

        public List<UserTypeMenuSearch> userTypeMenuSearch { get; set; }


        //public UserTypeEntity userTypeEntity { get; set; }

    }
}
