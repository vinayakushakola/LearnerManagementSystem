//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System;

namespace LMSCommonLayer.ResponseModels
{
	public class TechStackResponse
	{
		public int ID { get; set; }

		public string TechName { get; set; }
		
		public string ImagePath { get; set; }
		
		public string Framework { get; set; }
		
		public string CurrentStatus { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}

	public class TechTypeResponse
	{
		public int ID { get; set; }
		
		public string TypeName { get; set; }
		
		public string CurrentStatus { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}
}
