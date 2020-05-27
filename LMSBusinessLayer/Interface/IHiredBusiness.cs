﻿//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSBusinessLayer.Interface
{
    public interface IHiredBusiness
    {
        List<HiredRegistrationResponse> GetAllHired();

        HiredRegistrationResponse AddHired(HiredRegistrationRequest hiredRegistration);
        
        HiredRegistrationResponse UpdateHired(int candidateID, HiredUpdateRequest hiredRegistrationUpdate);
    }
}