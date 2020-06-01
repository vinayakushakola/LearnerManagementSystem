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
	}

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

	public class TechStackRequest
	{
		public string TechName { get; set; }
		public string ImagePath { get; set; }
		public string Framework { get; set; }
		public string CurrentStatus { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
	}

	public class TechTypeRequest
	{
		public string TypeName { get; set; }
		public string CurrentStatus { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
	}

	public class LabRegistrationRequest
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string Address { get; set; }
		public string Status { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
	}

	public class LabThresholdRequest
	{
		public int LabID { get; set; }
		public string LabCapacity { get; set; }
		public string LeadThreshold { get; set; }
		public string IdeationEnggThreshold { get; set; }
		public string BuddyEnggThreshold { get; set; }
		public string Status { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
	}

	public class CompanyRequirementRequest
	{
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
	}

	public class CandidateTechStackAssignRequest
	{
		public int RequirementID { get; set; }
		public int CandidateID { get; set; }
		public string AssignDate { get; set; }
		public string Status { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
	}
}
