//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System;

namespace LMSCommonLayer.RequestModels
{
	public class CompanyAddRequest
    {
		public string Name { get; set; }
		public string Address { get; set; }
		public string Location { get; set; }
		public string Status { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
	}

	public class MakerProgramRequest
	{
		public string ProgramName { get; set; }
		public string ProgramType { get; set; }
		public string ProgramLink { get; set; }
		public int TechStackID { get; set; }
		public int TechTypeID { get; set; }
		public bool IsProgramApproved { get; set; }
		public string DescriptionStatus { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
	}

	public class MentorRegistrationRequest
	{
		public string Name { get; set; }
		public string MentorType { get; set; }
		public int LabID { get; set; }
		public string Status { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
	}

	public class MentorIdeationRequest
	{
		public int LeadID { get; set; }
		public int MentorID { get; set; }
		public string Status { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
	}

	public class MentorTechStackRequest
	{
		public int MentorID { get; set; }
		public int TechStackID { get; set; }
		public string Status { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
	}

	public class TechStackRequest
	{
		public string TechName { get; set; }
		public string ImagePath { get; set; }
		public string Framework { get; set; }
		public string CurrentStatus { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
	}

	public class TechTypeRequest
	{
		public string TypeName { get; set; }
		public string CurrentStatus { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
	}
}
