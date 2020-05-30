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

    public class CompanyBusiness : ICompanyBusiness 
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyBusiness(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public List<CompanyAddResponse> GetAllCompanies()
        {
            var responseData = _companyRepository.GetAllCompanies();
            return responseData;
        }

        public CompanyAddResponse AddCompany(CompanyAddRequest companyAddRequest)
        {
            var responseData = _companyRepository.AddCompany(companyAddRequest);
            return responseData;
        }

        public MakerProgramResponse AddMakerProgram(MakerProgramRequest makerProgram)
        {
            var responseData = _companyRepository.AddMakerProgram(makerProgram);
            return responseData;
        }

        public MentorRegistrationResponse AddMentor(MentorRegistrationRequest mentorRegistration)
        {
            var responseData = _companyRepository.AddMentor(mentorRegistration);
            return responseData;
        }

        public MentorIdeationResponse AddMentorIdeation(MentorIdeationRequest mentorIdeation)
        {
            var responseData = _companyRepository.AddMentorIdeation(mentorIdeation);
            return responseData;
        }

        public MentorTechStackResponse AddMentorTechStack(MentorTechStackRequest techStack)
        {
            var responseData = _companyRepository.AddMentorTechStack(techStack);
            return responseData;
        }

    }
}
