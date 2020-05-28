//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System.ComponentModel.DataAnnotations;

namespace LMSCommonLayer.DBModels
{
    public class UserDetails
    {
        public int AdminID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string Verified { get; set; }

        [Required]
        public string CreatorStamp { get; set; }

        [Required]
        public string CreatorUser { get; set; }

        [Required]
        public string CreatedDate { get; set; }

        [Required]
        public string ModifiedDate { get; set; }
    }
}
