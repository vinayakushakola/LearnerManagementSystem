﻿//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSBusinessLayer.Interface
{
    public interface ICompanyBusiness
    {
        List<CompanyAddResponse> GetAllCompanies();

        CompanyAddResponse AddCompany(CompanyAddRequest companyAddRequest);

        MakerProgramResponse AddMakerProgram(MakerProgramRequest makerProgram);

        MentorRegistrationResponse AddMentor(MentorRegistrationRequest mentorRegistration);

        MentorIdeationResponse AddMentorIdeation(MentorIdeationRequest mentorIdeation);

        MentorTechStackResponse AddMentorTechStack(MentorTechStackRequest techStack);
    }
}
