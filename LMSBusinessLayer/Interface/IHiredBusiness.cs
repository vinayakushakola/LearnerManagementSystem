//
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
        List<HiredResponseModel> GetAllCandidates();

        List<HiredStatusPendingResponse> GetAllPendingCandidates();

        HiredResponseModel AddHired(HiredRegistrationRequest hiredRegistration);

        HiredResponseModel UpdateHired(int candidateID, HiredUpdateRequest hiredRegistrationUpdate);
    }
}
