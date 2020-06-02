//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

namespace LMSCommonLayer.RequestModels
{
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
}
