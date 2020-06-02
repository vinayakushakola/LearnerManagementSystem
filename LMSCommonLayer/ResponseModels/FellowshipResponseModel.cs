//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System;

namespace LMSCommonLayer.ResponseModels
{
	public class FellowshipResponseModel
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
		
		public string BirthDate { get; set; }
		
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
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}

	public class CandidateBankDetailResponse
	{
		public int ID { get; set; }
		
		public int CandidateID { get; set; }
		
		public string Name { get; set; }
		
		public string AccountNumber { get; set; }

		public bool IsAccountNumberVerified { get; set; }
		
		public string IfscCode { get; set; }
		
		public bool IsIfscCodeVerified { get; set; }
		
		public string PanNumber { get; set; }
		
		public bool IsPanNumberVerified { get; set; }
		
		public string AdhaarNumber { get; set; }
		
		public bool IsAdhaarNumberVerified { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}

	public class CandidateQualificationResponse
	{
		public int ID { get; set; }
		
		public int CandidateID { get; set; }
		
		public string Diploma { get; set; }
		
		public string DegreeName { get; set; }
		
		public bool IsDegreeNameVerified { get; set; }
		
		public string EmployeeDiscipline { get; set; }
		
		public bool IsEmployeeDisciplined { get; set; }
		
		public string PassingYear { get; set; }
		
		public bool IsPassingYearVerified { get; set; }
		
		public string AggregatePer { get; set; }
		
		public bool IsAggregatePerVerified { get; set; }
		
		public string FinalYearPer { get; set; }
		
		public bool IsFinalYearPerVerified { get; set; }
		
		public string TrainingInstitute { get; set; }
		
		public bool IsTrainingInstituteVerified { get; set; }
		
		public string TrainingDurationMon { get; set; }
		
		public bool IsTrainingDurationMonVerified { get; set; }
		
		public string OtherTraining { get; set; }
		
		public bool IsOtherTrainingVerified { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}

	public class CandidateDocumentsResponse
	{
		public int ID { get; set; }
		
		public int CandidateID { get; set; }
		
		public string DocType { get; set; }
		
		public string DocPath { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}

	public class CandidateTechStackAssignResponse
	{
		public int ID { get; set; }
		
		public int RequirementID { get; set; }
		
		public int CandidateID { get; set; }
		
		public string AssignDate { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}
}
