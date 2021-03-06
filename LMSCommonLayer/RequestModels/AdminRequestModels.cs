﻿//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMSCommonLayer.RequestModels
{
    public class RegistrationRequest
    {
        [Required]
        [MinLength(2, ErrorMessage = "Your Firstname Should be Minimum Length of 2")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "FirstName should contain only alphabets!")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Your Lastname Should be Minimum Length of 2")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "LastName should contain only alphabets!")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Your Password Should be Minimum Length of 8")]
        public string Password { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Your Mobile Number Should have 10 numbers")]
        [MaxLength(10, ErrorMessage = "Your Mobile Number Should have 10 numbers")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Your Mobile Number should contain only numbers!")]
        public string ContactNumber { get; set; }

        [Required]
        [DefaultValue("false")]
        public bool IsVerified { get; set; }

        [Required]
        public string CreatorStamp { get; set; }

        [Required]
        public string CreatorUser { get; set; }
    }

    public class AdminUpdateRequest
    {
        [Required]
        [MinLength(2, ErrorMessage = "Your Firstname Should be Minimum Length of 2")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "FirstName should contain only alphabets!")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Your Lastname Should be Minimum Length of 2")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "LastName should contain only alphabets!")]
        public string LastName { get; set; }

        [MinLength(10, ErrorMessage = "Your Mobile Number Should have 10 numbers")]
        [MaxLength(10, ErrorMessage = "Your Mobile Number Should have 10 numbers")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Your Mobile Number should contain only numbers!")]
        public string ContactNumber { get; set; }

        [DefaultValue("false")]
        public bool IsVerified { get; set; }

        public string CreatorStamp { get; set; }

        public string CreatorUser { get; set; }
    }

    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class ResetPasswordRequest
    {
        [Required]
        [MinLength(8, ErrorMessage = "Your Password Should be Minimum Length of 8")]
        public string Password{ get; set; }
    }
}
