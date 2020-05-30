//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSRepositoryLayer.Interface
{
    public interface ICompanyRepository
    {
        List<CompanyAddResponse> GetAllCompanies();

        CompanyAddResponse AddCompany(CompanyAddRequest companyAddRequest);

        MakerProgramResponse AddMakerProgram(MakerProgramRequest makerProgram);

        MentorRegistrationResponse AddMentor(MentorRegistrationRequest mentorRegistration);
    }
}
