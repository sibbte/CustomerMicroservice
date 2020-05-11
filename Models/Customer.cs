using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Models
{
    public class Customer
    {
        public Guid ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Telephone No.")]
        public string TeleNumber { get; set; }
        [Display(Name = "Mob No.")]
        public string MobNumber { get; set; }
        [Display(Name = "1st line of address")]
        public string Address1 { get; set; }
        [Display(Name = "2nd line of address")]
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public int? Cats { get; set; }
        public string UserId { get; set; }
    }
}
