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
}
