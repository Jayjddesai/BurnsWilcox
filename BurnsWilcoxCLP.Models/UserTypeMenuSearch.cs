using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnsWilcoxCLP.Models
{
    public class UserTypeMenuSearch
    {
        public int MenuId { get; set; }

        public int? UserTypeMenuId { get; set; }

        public int? UserTypeId { get; set; }

        public bool? IsAdd { get; set; }

        public bool? IsDelete { get; set; }

        public bool? IsView { get; set; }

        public bool? IsEdit { get; set; }

        public string MenuName { get; set; }
    }
}
