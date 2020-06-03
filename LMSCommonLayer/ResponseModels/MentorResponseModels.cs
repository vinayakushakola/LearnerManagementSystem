//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System;
using System.Collections.Generic;

namespace LMSCommonLayer.ResponseModels
{
	public class MentorRegistrationResponse
	{
		public int ID { get; set; }
		
		public string Name { get; set; }
		
		public string MentorType { get; set; }
		
		public int LabID { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}

	public class MentorIdeationResponse
	{
		public int ID { get; set; }
		
		public int LeadID { get; set; }
		
		public int MentorID { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}

	public class MentorTechStackResponse
	{
		public int ID { get; set; }
		
		public int MentorID { get; set; }
		
		public int TechStackID { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ModifiedDate { get; set; }
	}

	public class LeadBuddyResponse
	{
		public List<LeadResponse> Leads { get; set; }
	}
	public class LeadResponse
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public List<BuddyResponse> Buddy { get; set; }
	}

	public class BuddyResponse
	{
		public string Name { get; set; }

		public string Stack { get; set; }

		public int ID { get; set; }
	}
}
