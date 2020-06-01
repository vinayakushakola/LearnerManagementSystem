//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSBusinessLayer.Interface;
using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using LMSRepositoryLayer.Interface;

namespace LMSBusinessLayer.Services
{
    public class TechBusiness : ITechBusiness
    {
        private readonly ITechRepository _techRepository;

        public TechBusiness(ITechRepository techRepository)
        {
            _techRepository = techRepository;
        }
        public TechStackResponse AddTechStack(TechStackRequest techStack)
        {
            var responseData = _techRepository.AddTechStack(techStack);
            return responseData;
        }

        public TechTypeResponse AddTechType(TechTypeRequest techType)
        {
            var responseData = _techRepository.AddTechType(techType);
            return responseData;
        }
    }
}
