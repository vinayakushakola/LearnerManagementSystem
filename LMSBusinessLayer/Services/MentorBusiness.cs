//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSBusinessLayer.Interface;
using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using LMSRepositoryLayer.Interface;
using System.Collections.Generic;

namespace LMSBusinessLayer.Services
{
    public class MentorBusiness : IMentorBusiness
    {
        private readonly IMentorRepository _mentorRepository;

        public MentorBusiness(IMentorRepository mentorRepository)
        {
            _mentorRepository = mentorRepository;
        }

        public List<MentorRegistrationResponse> ListOfMentors()
        {
            var responseData = _mentorRepository.ListOfMentors();
            return responseData;
        }

        public MentorRegistrationResponse AddMentor(MentorRegistrationRequest mentorRegistration)
        {
            var responseData = _mentorRepository.AddMentor(mentorRegistration);
            return responseData;
        }

        public MentorTechStackResponse AddMentorTechStack(MentorTechStackRequest techStack)
        {
            var responseData = _mentorRepository.AddMentorTechStack(techStack);
            return responseData;
        }

        public MentorIdeationResponse AddMentorIdeation(MentorIdeationRequest mentorIdeation)
        {
            var responseData = _mentorRepository.AddMentorIdeation(mentorIdeation);
            return responseData;
        }
    }
}
