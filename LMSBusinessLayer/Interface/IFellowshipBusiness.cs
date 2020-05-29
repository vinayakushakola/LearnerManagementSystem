﻿//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSBusinessLayer.Interface
{
    public interface IFellowshipBusiness
    {
        List<HiredResponseModel> GetAllCandidates();

        HiredResponseModel AddHired(HiredRegistrationRequest hiredRegistration);

        HiredResponseModel UpdateHired(int candidateID, HiredUpdateRequest hiredRegistrationUpdate);

        List<FellowshipResponseModel> GetAllFellowshipCandidates();

        FellowshipResponseModel UpdateSelectedFellowshipCandidate(int candidateID, FellowshipUpdateRequest fellowshipUpdate);

        CandidateBankDetailResponse AddCandidateBankDetails(int candidateID, CandidateBankDetailRequest bankDetail);

        CandidateQualificationResponse AddCandidateQualification(int candidateID, CandidateQualificationRequest qualification);
    
        CandidateDocumentsResponse AddCanndidateDocuments(int candidateID, CandidateDocumentsRequest documents);
    }
}