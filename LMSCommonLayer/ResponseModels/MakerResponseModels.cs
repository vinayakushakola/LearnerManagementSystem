//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System;

namespace LMSCommonLayer.ResponseModels
{
	public class MakerProgramResponse
	{
		public int ID { get; set; }

		public string ProgramName { get; set; }
		
		public string ProgramType { get; set; }
		
		public string ProgramLink { get; set; }
		
		public int TechStackID { get; set; }
		
		public int TechTypeID { get; set; }
		
		public bool IsProgramApproved { get; set; }
		
		public string DescriptionStatus { get; set; }
		
		public string CreatorStamp { get; set; }

		public string CreatorUser { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime ModifiedDate { get; set; }
	}
}
