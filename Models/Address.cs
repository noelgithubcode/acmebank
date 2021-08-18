using System;
using System.ComponentModel.DataAnnotations;

namespace VSStudioTestPRJ.Models
{
    public class Address
    {
        [Key]
        public int AddressPK { get; set; }
        public int PersonFK { get; set; }
        public string AddressInfo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}
