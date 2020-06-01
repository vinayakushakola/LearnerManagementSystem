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
    public class FellowshipBusiness : IFellowshipBusiness
    {
        private readonly IFellowshipRepository _hiredRepository;

        public FellowshipBusiness(IFellowshipRepository hiredRepository)
        {
            _hiredRepository = hiredRepository;
        }

        
        public List<FellowshipResponseModel> GetAllFellowshipCandidates()
        {
            var responseData = _hiredRepository.GetAllFellowshipCandidates();
            return responseData;
        }

        public FellowshipResponseModel UpdateSelectedFellowshipCandidate(int candidateID, FellowshipUpdateRequest fellowshipUpdate)
        {
            var responseData = _hiredRepository.UpdateSelectedFellowshipCandidate(candidateID, fellowshipUpdate);
            return responseData;
        }

        public CandidateBankDetailResponse AddCandidateBankDetails(int candidateID, CandidateBankDetailRequest bankDetail)
        {
            var responseData = _hiredRepository.AddCandidateBankDetails(candidateID, bankDetail);
            return responseData;
        }

        public CandidateQualificationResponse AddCandidateQualification(int candidateID, CandidateQualificationRequest qualification)
        {
            var responseData = _hiredRepository.AddCandidateQualification(candidateID, qualification);
            return responseData;
        }

        public CandidateDocumentsResponse AddCanndidateDocuments(int candidateID, CandidateDocumentsRequest documents)
        {
            var responseData = _hiredRepository.AddCanndidateDocuments(candidateID, documents);
            return responseData;
        }

        public CandidateTechStackAssignResponse AddCandidateTechStackAssign(CandidateTechStackAssignRequest candidateTech)
        {
            var responseData = _hiredRepository.AddCandidateTechStackAssign(candidateTech);
            return responseData;
        }
    }
}
