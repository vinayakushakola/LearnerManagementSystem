//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSBusinessLayer.Interface
{
    public interface IMakerBusiness
    {
        List<MakerProgramResponse> ListOfMakerProgram();

        MakerProgramResponse AddMakerProgram(MakerProgramRequest makerProgram);
    }
}
