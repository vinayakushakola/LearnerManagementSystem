//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System.ComponentModel;

namespace LMSCommonLayer.RequestModels
{
	public class MakerProgramRequest
	{
		public string ProgramName { get; set; }

		public string ProgramType { get; set; }
		
		public string ProgramLink { get; set; }
		
		public int TechStackID { get; set; }
		
		public int TechTypeID { get; set; }
		
		[DefaultValue("false")]
		public bool IsProgramApproved { get; set; }
		
		public string DescriptionStatus { get; set; }
		
		public string CreatorStamp { get; set; }
		
		public string CreatorUser { get; set; }
	}
}
