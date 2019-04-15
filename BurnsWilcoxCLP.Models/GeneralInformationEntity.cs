using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BurnsWilcoxCLP.Models.Quote
{
    class GeneralInformationEntity
    {
         #region Fields

        [Required]    
        public string APC { get; set; }

        [Required]
        public int PolicyAggregate { get; set; }

        [Required]      
        public int NSL { get; set; }

        [Required]      
        public int PrivacyLimit { get; set; }
          
        [Required]      
        public int Notification { get; set; }
             
        [Required]      
        public int RDPenalties { get; set; }
       
        [Required]      
        public int PCIPenalties { get; set; }

        [Required]      
        public int DataRestoration { get; set; }

        [Required]      
        public int Extortion { get; set; }

        [Required]      
        public int NBI { get; set; }

        [Required]      
        public int CyberCrime { get; set; }

        [Required]      
        public int MediaContent { get; set; }
        
        #endregion

        #region Methods

        public static List<ListModel> GetPolicyAggregateList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "PolicyAggregate1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "PolicyAggregate2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "PolicyAggregate3"
                },
            };
        }

        public static List<ListModel> GetNSLList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "NSL1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "NSL2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "NSL3"
                },
            };
        }

        public static List<ListModel> GetPrivacyLimitList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "PrivacyLimit1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "PrivacyLimit2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "PrivacyLimit3"
                },
            };
        }

        public static List<ListModel> GetNotificationList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "Notification1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "Notification2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "Notification3"
                },
            };
        }

        public static List<ListModel> GetRDPenaltyList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "RDPenalty1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "RDPenalty2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "RDPenalty3"
                },
            };
        }

        public static List<ListModel> GetPCIPenaltyList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "PCIPenalty1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "PCIPenalty2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "PCIPenalty3"
                },
            };
        }

        public static List<ListModel> GetDataRestorationList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "DataRestoration1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "DataRestoration2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "DataRestoration3"
                },
            };
        }

        public static List<ListModel> GetExtortionList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "Extortion1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "Extortion2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "Extortion3"
                },
            };
        }

        public static List<ListModel> GetNBIList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "NBI1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "NBI3"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "NBI3"
                },
            };
        }

        public static List<ListModel> GetCyberCrimeList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "CyberCrime1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "CyberCrime2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "CyberCrime3"
                },
            };
        }

        public static List<ListModel> GetMediaContentList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "MediaContent1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "MediaContent2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "MediaContent3"
                },
            };
        }

        #endregion
    }
    }

