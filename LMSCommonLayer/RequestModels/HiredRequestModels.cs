//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System;
using System.ComponentModel.DataAnnotations;

namespace LMSCommonLayer.RequestModels
{
	public class HiredRegistrationRequest
	{
		[Required]
		[MinLength(2, ErrorMessage = "Your Firstname Should be Minimum Length of 2")]
		[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "FirstName should contain only alphabets!")] 
		public string FirstName { get; set; }

		[Required]
		[MinLength(2, ErrorMessage = "Your MiddleName Should be Minimum Length of 2")]
		[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "MiddleName should contain only alphabets!")] 
		public string MiddleName { get; set; }

		[Required]
		[MinLength(2, ErrorMessage = "Your Lastname Should be Minimum Length of 2")]
		[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "LastName should contain only alphabets!")] 
		public string LastName { get; set; }

		[Required]
		[EmailAddress] 
		public string Email { get; set; }

		[Required]
		[MinLength(2, ErrorMessage = "Your Degree Should be Minimum Length of 2")]
		[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Degree should contain only alphabets!")]
		public string Degree { get; set; }

		[Required]
		[MinLength(10, ErrorMessage = "Your Mobile Number Should have 10 numbers")]
		[MaxLength(10, ErrorMessage = "Your Mobile Number Should have 10 numbers")]
		[RegularExpression("^[0-9]+$", ErrorMessage = "Your Mobile Number should contain only numbers!")]
		public string MobileNumber { get; set; }

		[Required]
		[MinLength(6, ErrorMessage = "Your Pincode Should have 6 numbers")]
		[MaxLength(6, ErrorMessage = "Your Pincode Should have 6 numbers")]
		[RegularExpression("^[0-9]+$", ErrorMessage = "Your Pincode should contain only numbers!")]
		public string PermanentPincode { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
	}
    public class HiredUpdateRequest
	{
		[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "City Name should contain only alphabets!")]
		public string HiredCity { get; set; }

		[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Lab Name should contain only alphabets!")]
		public string HiredLab { get; set; }

		public string Attitude { get; set; }

		public string CommunicationRemark { get; set; }

		public string KnowledgeRemark { get; set; }
		
		public string AggregateRemark { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
	}
}
