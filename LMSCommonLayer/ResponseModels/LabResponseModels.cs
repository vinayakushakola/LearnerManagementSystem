//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System;

namespace LMSCommonLayer.ResponseModels
{
	public class LabRegistrationResponse
	{
		public int ID { get; set; }
		
		public string Name { get; set; }
		
		public string Location { get; set; }
		
		public string Address { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}

	public class LabThresholdResponse
	{
		public int ID { get; set; }
		
		public int LabID { get; set; }
		
		public string LabCapacity { get; set; }
		
		public string LeadThreshold { get; set; }
		
		public string IdeationEnggThreshold { get; set; }
		
		public string BuddyEnggThreshold { get; set; }
		
		public string Status { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}
}
