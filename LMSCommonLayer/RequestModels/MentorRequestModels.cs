//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

namespace LMSCommonLayer.RequestModels
{
	public class MentorRegistrationRequest
	{
		public string Name { get; set; }
		
		public string MentorType { get; set; }
		
		public int LabID { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
	}

	public class MentorIdeationRequest
	{
		public int LeadID { get; set; }
		
		public int MentorID { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
	}

	public class MentorTechStackRequest
	{
		public int MentorID { get; set; }
		
		public int TechStackID { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
	}
}
