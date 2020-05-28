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
		public string IsBirthDateVerified { get; set; }
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
		public string CreatedDate { get; set; }
		public string ModifiedDate { get; set; }
	}

	public class CandidateBankDetailResponse
	{
		public int ID { get; set; }
		public int CandidateID { get; set; }
		public string Name { get; set; }
		public string AccountNumber { get; set; }
		public string IsAccountNumberVerified { get; set; }
		public string IfscCode { get; set; }
		public string IsIfscCodeVerified { get; set; }
		public string PanNumber { get; set; }
		public string IsPanNumberVerified { get; set; }
		public string AdhaarNumber { get; set; }
		public string IsAdhaarNumberVerified { get; set; }
		public string CreatorStamp { get; set; }
		public string CreatorUser { get; set; }
		public string CreatedDate { get; set; }
		public string ModifiedDate { get; set; }
	}
}
