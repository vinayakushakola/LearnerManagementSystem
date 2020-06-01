//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMSCommonLayer.DBModels
{
    public class AdminDetails
    {
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
        [DefaultValue("false")]
        public bool IsVerified { get; set; }

        [Required]
        public string CreatorStamp { get; set; }

        [Required]
        public string CreatorUser { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
