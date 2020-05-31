//
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

        List<MentorRegistrationResponse> ListOfMentors();

        MentorRegistrationResponse AddMentor(MentorRegistrationRequest mentorRegistration);

        MentorIdeationResponse AddMentorIdeation(MentorIdeationRequest mentorIdeation);

        MentorTechStackResponse AddMentorTechStack(MentorTechStackRequest techStack);

        TechStackResponse AddTechStack(TechStackRequest techStack);

        TechTypeResponse AddTechType(TechTypeRequest techType);

        LabRegistrationResponse AddLab(LabRegistrationRequest lab);

        LabThresholdResponse AddLabThreshold(LabThresholdRequest labThreshold);

        CompanyRequirementResponse AddCompanyRequirement(CompanyRequirementRequest companyRequirement);

        CandidateTechStackAssignResponse AddCandidateTechStackAssign(CandidateTechStackAssignRequest candidateTech);
    }
}
