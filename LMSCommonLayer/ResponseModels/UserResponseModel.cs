//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

namespace LMSCommonLayer.ResponseModels
{
    public class UserResponseModel
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public string Verified { get; set; }

        public string CreatorStamp { get; set; }

        public string CreatorUser { get; set; }

        public string CreatedDate { get; set; }

        public string ModifiedDate { get; set; }
    }
}
