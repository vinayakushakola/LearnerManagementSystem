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
}
