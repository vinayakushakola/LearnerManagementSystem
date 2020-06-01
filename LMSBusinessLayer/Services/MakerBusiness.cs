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
    public class MakerBusiness : IMakerBusiness
    {
        private readonly IMakerRepository _makerRepository;

        public MakerBusiness(IMakerRepository makerRepository)
        {
            _makerRepository = makerRepository;
        }

        public MakerProgramResponse AddMakerProgram(MakerProgramRequest makerProgram)
        {
            var responseData = _makerRepository.AddMakerProgram(makerProgram);
            return responseData;
        }
    }
}
