//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSBusinessLayer.Interface
{
    public interface IMentorBusiness
    {
        List<MentorRegistrationResponse> ListOfMentors();

        List<LeadBuddyResponse> ListOfLeads();

        MentorRegistrationResponse AddMentor(MentorRegistrationRequest mentorRegistration);

        MentorIdeationResponse AddMentorIdeation(MentorIdeationRequest mentorIdeation);

        MentorTechStackResponse AddMentorTechStack(MentorTechStackRequest techStack);
    }
}
