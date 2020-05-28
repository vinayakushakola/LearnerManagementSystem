using System;

namespace LMSCommonLayer.DBModels
{
	public class CandidateBankDetails
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
}
