﻿//
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

        


        

        public CompanyRequirementResponse AddCompanyRequirement(CompanyRequirementRequest companyRequirement)
        {
            var responseData = _companyRepository.AddCompanyRequirement(companyRequirement);
            return responseData;
        }

      

    }
}
