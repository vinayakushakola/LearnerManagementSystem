//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System;
using System.ComponentModel.DataAnnotations;

namespace LMSCommonLayer.RequestModels
{
	public class FellowshipAddRequest
    {
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string MiddleName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Degree { get; set; }

		[Required]
		public string MobileNumber { get; set; }

		[Required]
		public string PermanentPincode { get; set; }

		[Required]
		public string HiredCity { get; set; }

		[Required]
		public DateTime HiredDate { get; set; }

		[Required]
		public string HiredLab { get; set; }

		[Required]
		public string Attitude { get; set; }

		[Required]
		public string CommunicationRemark { get; set; }

		[Required]
		public string KnowledgeRemark { get; set; }

		[Required]
		public string AggregateRemark { get; set; }

		[Required]
		public string Status { get; set; }

		[Required]
		public string CreatorStamp { get; set; }

		[Required]
		public DateTime CreatedDate { get; set; }

		[Required]
		public DateTime ModifiedDate { get; set; }
	}
}
