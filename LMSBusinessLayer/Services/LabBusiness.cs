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
    public class LabBusiness : ILabBusiness
    {
        private readonly ILabRepository _labRepository;

        public LabBusiness(ILabRepository labRepository)
        {
            _labRepository = labRepository;
        }

        public List<LabRegistrationResponse> ListOfLabs()
        {
            var responseData = _labRepository.ListOfLabs();
            return responseData;
        }

        public LabRegistrationResponse AddLab(LabRegistrationRequest lab)
        {
            var responseData = _labRepository.AddLab(lab);
            return responseData;
        }

        public LabThresholdResponse AddLabThreshold(LabThresholdRequest labThreshold)
        {
            var responseData = _labRepository.AddLabThreshold(labThreshold);
            return responseData;
        }
    }
}
