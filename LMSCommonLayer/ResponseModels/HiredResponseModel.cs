//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System;

namespace LMSCommonLayer.ResponseModels
{
	public class HiredResponseModel
    {
		public int CandidateID { get; set; }

		public string FirstName { get; set; }
		
		public string MiddleName { get; set; }
		
		public string LastName { get; set; }
		
		public string Email { get; set; }
		
		public string Degree { get; set; }
		
		public string MobileNumber { get; set; }
		
		public string PermanentPincode { get; set; }
		
		public string HiredCity { get; set; }
		
		public string HiredDate { get; set; }
		
		public string HiredLab { get; set; }
		
		public string Attitude { get; set; }
		
		public string CommunicationRemark { get; set; }
		
		public string KnowledgeRemark { get; set; }
		
		public string AggregateRemark { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ModifiedDate { get; set; }
	}

	public class HiredStatusPendingResponse
	{
		public int CandidateID { get; set; }

		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string Degree { get; set; }

		public string MobileNumber { get; set; }

		public string Status { get; set; }

		public string CreatorStamp { get; set; }

		public string CreatorUser { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ModifiedDate { get; set; }
	}
}
