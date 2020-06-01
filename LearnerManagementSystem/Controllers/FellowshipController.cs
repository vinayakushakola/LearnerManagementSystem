//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSBusinessLayer.Interface;
using LMSCommonLayer.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LearnerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FellowshipController : ControllerBase
    {
        private readonly IFellowshipBusiness _fellowshipBusiness;
        public FellowshipController(IFellowshipBusiness fellowshipBusiness)
        {
            _fellowshipBusiness = fellowshipBusiness;
        }

        /// <summary>
        /// It is used to Show All Fellowship Candidates Data
        /// </summary>
        /// <returns>If Data Found return ok else null or BadRequest</returns>
        [HttpGet]
        public IActionResult GetAllFellowshipCandidates()
        {
            try
            {
                bool success = false;
                string message;
                var data = _fellowshipBusiness.GetAllFellowshipCandidates().ToList();
                if (data != null)
                {
                    success = true;
                    message = "Fellowship Candidates Data Fetched Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "No data Found!";
                    return NotFound(new { success, message });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to Add Selected Fellowship Candidate additional details
        /// </summary>
        /// <param name="candidateID">Candidate ID</param>
        /// <param name="updateRequest">Update Fellowship Data</param>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpPut]
        [Route("{candidateID}/FellowshipCandidate")]
        public IActionResult UpdateFellowshipCandidate(int candidateID, FellowshipUpdateRequest updateRequest)
        {
            try
            {
                bool success = false;
                string message;
                var data = _fellowshipBusiness.UpdateSelectedFellowshipCandidate(candidateID, updateRequest);
                if (data != null)
                {
                    success = true;
                    message = "Fellowship Candidate Data Added Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "Try Again!";
                    return NotFound(new { success, message });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to Add Candidate Bank Details
        /// </summary>
        /// <param name="candidateID">CandidateID</param>
        /// <param name="bankDetail">Candidate Bank Detail</param>
        /// <returns>If Data Found return Ok else NotFound or BadRequest</returns>
        [HttpPut]
        [Route("{candidateID}/BankDetails")]
        public IActionResult AddBankDetails(int candidateID, CandidateBankDetailRequest bankDetail)
        {
            try
            {
                bool success = false;
                string message;
                var data = _fellowshipBusiness.AddCandidateBankDetails(candidateID, bankDetail);
                if (data != null)
                {
                    success = true;
                    message = "Fellowship Candidate Bank Details Added Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "Try Again!";
                    return NotFound(new { success, message });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to Add Candidate Qualification 
        /// </summary>
        /// <param name="candidateID">CandidateID</param>
        /// <param name="qualification">Candidate Qualification Data</param>
        /// <returns>If Data Found return Ok else NotFound or BadRequest</returns>
        [HttpPut]
        [Route("{candidateID}/Qualification")]
        public IActionResult AddQualification(int candidateID, CandidateQualificationRequest qualification)
        {
            try
            {
                bool success = false;
                string message;
                var data = _fellowshipBusiness.AddCandidateQualification(candidateID, qualification);
                if (data != null)
                {
                    success = true;
                    message = "Fellowship Candidate Qualification Details Added Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "Try Again!";
                    return NotFound(new { success, message });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to Add Candidate Documents
        /// </summary>
        /// <param name="candidateID">CandidateID</param>
        /// <param name="documents">Candidate Documents</param>
        /// <returns>If Data Found return Ok else NotFound or Badrequest</returns>
        [HttpPut]
        [Route("{candidateID}/Documents")]
        public IActionResult AddDocuments(int candidateID, CandidateDocumentsRequest documents)
        {
            try
            {
                bool success = false;
                string message;
                var data = _fellowshipBusiness.AddCanndidateDocuments(candidateID, documents);
                if (data != null)
                {
                    success = true;
                    message = "Fellowship Candidate Documents Added Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "Try Again!";
                    return NotFound(new { success, message });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost]
        [Route("TechAssignment")]
        public IActionResult AddCandidateTecStackAssign(CandidateTechStackAssignRequest candidateTech)
        {
            try
            {
                bool success = false;
                string message;
                var data = _fellowshipBusiness.AddCandidateTechStackAssign(candidateTech);
                if (data != null)
                {
                    success = true;
                    message = "Candidate tech Added Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "Try Again!";
                    return NotFound(new { success, message });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}