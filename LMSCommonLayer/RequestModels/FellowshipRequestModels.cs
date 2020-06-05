//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System;
using System.ComponentModel;
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
	}

	public class FellowshipUpdateRequest
	{
		public string BirthDate { get; set; }
		
		[DefaultValue("false")]
		public bool IsBirthDateVerified { get; set; }
		
		public string ParentName { get; set; }
		
		public string ParentOccupation { get; set; }
		
		public string ParentsMobileNumber { get; set; }
		
		public string ParentsAnnualSalary { get; set; }
		
		public string LocalAddress { get; set; }
		
		public string PermanentAddress { get; set; }
		
		public string PhotoPath { get; set; }
		
		public string JoiningDate { get; set; }
		
		public string CandidateStatus { get; set; }
		
		public string PersonalInformation { get; set; }
		
		public string BankInformation { get; set; }
		
		public string EducationalInformation { get; set; }
		
		public string DocumentStatus { get; set; }
		
		public string Remark { get; set; }
	}

	public class CandidateBankDetailRequest
	{
		public string Name { get; set; }

		public string AccountNumber { get; set; }

		[DefaultValue("false")]
		public bool IsAccountNumberVerified { get; set; }

		public string IfscCode { get; set; }

		[DefaultValue("false")]
		public bool IsIfscCodeVerified { get; set; }

		public string PanNumber { get; set; }

		[DefaultValue("false")]
		public bool IsPanNumberVerified { get; set; }

		public string AdhaarNumber { get; set; }

		[DefaultValue("false")]
		public bool IsAdhaarNumberVerified { get; set; }

		public string CreatorStamp { get; set; }

		public string CreatorUser { get; set; }
	}

	public class CandidateQualificationRequest
	{
		public string Diploma { get; set; }

		public string DegreeName { get; set; }

		[DefaultValue("false")]
		public bool IsDegreeNameVerified { get; set; }

		public string EmployeeDiscipline { get; set; }

		[DefaultValue("false")]
		public bool IsEmployeeDisciplined { get; set; }

		public string PassingYear { get; set; }

		[DefaultValue("false")]
		public bool IsPassingYearVerified { get; set; }

		public string AggregatePer { get; set; }

		[DefaultValue("false")]
		public bool IsAggregatePerVerified { get; set; }

		public string FinalYearPer { get; set; }

		[DefaultValue("false")]
		public bool IsFinalYearPerVerified { get; set; }

		public string TrainingInstitute { get; set; }

		[DefaultValue("false")]
		public bool IsTrainingInstituteVerified { get; set; }

		public string TrainingDurationMon { get; set; }

		[DefaultValue("false")]
		public bool IsTrainingDurationMonVerified { get; set; }

		public string OtherTraining { get; set; }

		[DefaultValue("false")]
		public bool IsOtherTrainingVerified { get; set; }

		public string CreatorStamp { get; set; }

		public string CreatorUser { get; set; }

	}

	public class CandidateDocumentsRequest
	{
		public string DocType { get; set; }

		public string DocPath { get; set; }
		
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
