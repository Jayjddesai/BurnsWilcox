using BurnsWilcoxCLP.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BurnsWilcoxCLP.Models
{
    public class User
    {
        public class LoginUser
        {
            public int UserId { get; set; }
            //public string FirstName { get; set; }
            public string DisplayName { get; set; }
            public string EmailAddress { get; set; }
             
            public byte UserTypeId { get; set; }
            public string UserTypeName { get; set; }
            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }
            public List<Rights> RightsList { get; set; }

            private string RightsString
            {
                set
                {
                    RightsList = !string.IsNullOrEmpty(value) ? Utility.DeserializeFromXMLNew<RightsGroup>(value).RightsList : new RightsGroup().RightsList;
                }
            }
        }

        [XmlRoot("RightsGroup")]
        public class RightsGroup
        {
            public RightsGroup() { RightsList = new List<Rights>(); }

            [XmlElement("Rights", typeof(Rights))]
            public List<Rights> RightsList { get; set; }
        }

        /// <summary>
        /// Class Rights.
        /// </summary>
        public class Rights
        {
            /// <summary>
            /// Gets or sets the rights identifier.
            /// </summary>
            /// <value>The rights identifier.</value>
            public int RightsId { get; set; }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string RightsName { get; set; }

            /// <summary>
            /// Gets or sets the roleid.
            /// </summary>
            /// <value>role id.</value>
            public int RoleId { get; set; }
            /// <summary>
            /// Gets or sets the name of the display.
            /// </summary>
            /// <value>The name of the display.</value>
            public string DisplayName { get; set; }

            public int Assigned { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
