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
    public class MakerBusiness : IMakerBusiness
    {
        private readonly IMakerRepository _makerRepository;

        public MakerBusiness(IMakerRepository makerRepository)
        {
            _makerRepository = makerRepository;
        }

        public List<MakerProgramResponse> ListOfMakerProgram()
        {
            var responseData = _makerRepository.ListOfMakerProgram();
            return responseData;
        }


        public MakerProgramResponse AddMakerProgram(MakerProgramRequest makerProgram)
        {
            var responseData = _makerRepository.AddMakerProgram(makerProgram);
            return responseData;
        }
    }
}
