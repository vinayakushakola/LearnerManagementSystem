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
		public string CreatedDate { get; set; }
		public string ModifiedDate { get; set; }
	}

	public class MakerProgramResponse
	{
		public int ID { get; set; }
		public string ProgramName { get; set; }
		public string ProgramType { get; set; }
		public string ProgramLink { get; set; }
		public int TechStackID { get; set; }
		public int TechTypeID { get; set; }
		public string IsProgramApproved { get; set; }
		public string DescriptionStatus { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public string CreatedDate { get; set; }
		public string ModifiedDate { get; set; }
	}

	public class MentorRegistrationResponse
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string MentorType { get; set; }
		public int LabID { get; set; }
		public string Status { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public string CreatedDate { get; set; }
		public string ModifiedDate { get; set; }
	}

	public class MentorIdeationResponse
	{
		public int ID { get; set; }
		public int LeadID { get; set; }
		public int MentorID { get; set; }
		public string Status { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public string CreatedDate { get; set; }
		public string ModifiedDate { get; set; }
	}

	public class MentorTechStackResponse
	{
		public int ID { get; set; }
		public int MentorID { get; set; }
		public int TechStackID { get; set; }
		public string Status { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public string CreatedDate { get; set; }
		public string ModifiedDate { get; set; }
	}

	public class TechStackResponse
	{
		public int ID { get; set; }
		public string TechName { get; set; }
		public string ImagePath { get; set; }
		public string Framework { get; set; }
		public string CurrentStatus { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public string CreatedDate { get; set; }
		public string ModifiedDate { get; set; }
	}

	public class TechTypeResponse
	{
		public int ID { get; set; }
		public string TypeName { get; set; }
		public string CurrentStatus { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public string CreatedDate { get; set; }
		public string ModifiedDate { get; set; }
	}
}
