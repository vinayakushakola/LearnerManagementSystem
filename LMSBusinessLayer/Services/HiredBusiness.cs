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
    public class HiredBusiness : IHiredBusiness
    {
        private readonly IHiredRepository _hiredRepository;

        public HiredBusiness(IHiredRepository hiredRepository)
        {
            _hiredRepository = hiredRepository;
        }
        public List<HiredResponseModel> GetAllCandidates()
        {
            var responseData = _hiredRepository.GetAllCandidates();
            return responseData;
        }

        public HiredResponseModel AddHired(HiredRegistrationRequest hiredRegistration)
        {
            var responseData = _hiredRepository.AddHired(hiredRegistration);
            return responseData;
        }

        public HiredResponseModel UpdateHired(int candidateID, HiredUpdateRequest hiredRegistrationUpdate)
        {
            var responseData = _hiredRepository.UpdateHired(candidateID, hiredRegistrationUpdate);
            return responseData;
        }

    }
}
