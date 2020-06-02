//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System;

namespace LMSCommonLayer.ResponseModels
{
	public class CompanyAddResponse
    {
		public int CompanyID { get; set; }
		
		public string Name { get; set; }
		
		public string Address { get; set; }
		
		public string Location { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}

	public class CompanyRequirementResponse
	{
		public int ID { get; set; }
		
		public int CompanyID { get; set; }
		
		public string RequestedMonth { get; set; }
		
		public string City { get; set; }
		
		public bool IsDocVerified { get; set; }

		public string RequirementDocPath { get; set; }
		
		public string NumOfEngg { get; set; }
		
		public int TechStackID { get; set; }
		
		public int TechTypeID { get; set; }
		
		public int MakerProgramID { get; set; }
		
		public int LeadID { get; set; }
		
		public int IdeationEnggID { get; set; }
		
		public int BuddyEnggID { get; set; }
		
		public string SpecialRemark { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}
}
