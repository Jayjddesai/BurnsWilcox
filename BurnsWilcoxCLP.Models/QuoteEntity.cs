using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BurnsWilcoxCLP.Models
{
    public class QuoteEntity
    {
      
        // Business Description 
        [Required]
        public string BusinessDescription{ get; set; }

         [Required]
       //Number of Employee
        public string NumberOfEmp { get; set; }

         [Required]
        //Projected Fiscal Year Revenue
        public string PFYR { get; set; }

         [Required]
        //NAICS Code
        public string NAICSCode { get; set; }

         [Required]
        //Current Next Year Revenue
        public string CNYR { get; set; }

         [Required]
        //Any Previous Coverage
        public bool AnyPreviousCoverage { get; set; }

         [Required]
        //Notification
        public int NotificationId { get; set; }

         [Required]
        //Extortion 
        public int ExtortionId { get; set; }

         [Required]
        //Policy Aggregate 
        public int PolicyAggrigationId { get; set; }

         [Required]
        //Regular Defense/Fines and Penalties
        public int RDFPId { get; set; }

         [Required]
        //Network Business Ineruption
        public int NBId { get; set; }

         [Required]
        //Network Security Limit
        public int NSLId { get; set; }

         [Required]
        //PCI Fines and Penalties
        public int PCIFAPId { get; set; }

         [Required]
        //Cyber Crime
        public int CyberCrimeId { get; set;}

         [Required]
        //Privacy Limit 
        public int PrivacyLimitId { get; set; }

         [Required]
        //Data Restoration 
        public int DataRestorationId { get; set; }

         [Required]
        //Media Website Content
        public int MWContentId { get; set; }

         [Required]
         public bool QueE { get; set; }

         [Required]
         public bool QueB1 { get; set; }

         [Required]
         public bool QueB2 { get; set; }

    }
}