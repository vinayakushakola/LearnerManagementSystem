﻿//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSRepositoryLayer.Interface
{
    public interface IMakerRepository
    {
        List<MakerProgramResponse> ListOfMakerProgram();
        
        MakerProgramResponse AddMakerProgram(MakerProgramRequest makerProgram);
    }
}
