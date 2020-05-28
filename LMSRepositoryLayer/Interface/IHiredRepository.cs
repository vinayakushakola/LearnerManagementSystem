﻿//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSRepositoryLayer.Interface
{
    public interface IHiredRepository
    {
        List<HiredResponseModel> GetAllHired();

        HiredResponseModel AddHired(HiredRegistrationRequest hiredRegistration);

        HiredResponseModel UpdateHired(int candidateID, HiredUpdateRequest hiredRegistrationUpdate);

        FellowshipResponseModel UpdateFellowshipCandidate(int candidateID, FellowshipUpdateRequest fellowshipUpdate);
    }
}
