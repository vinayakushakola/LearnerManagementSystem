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
        private readonly IFellowshipBusiness _hiredBusiness;
        public FellowshipController(IFellowshipBusiness hiredBusiness)
        {
            _hiredBusiness = hiredBusiness;
        }

        /// <summary>
        /// It is used to Show all Candidates Data
        /// </summary>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpGet]
        public IActionResult GetAllCandidates()
        {
            try
            {
                bool success = false;
                string message;
                var data = _hiredBusiness.GetAllCandidates().ToList();
                if (data != null)
                {
                    success = true;
                    message = "Candidates Data Fetched Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "No data Found!";
                    return NotFound(new { success, message });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to Add Candidate(Hired) Data
        /// </summary>
        /// <param name="registration">Candidate Registration Data</param>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpPost]
        public IActionResult AddCandidate(HiredRegistrationRequest registration)
        {
            try
            {
                bool success = false;
                string message;
                var data = _hiredBusiness.AddHired(registration);
                if (data != null)
                {
                    success = true;
                    message = "Candidate(Hired) Data Added Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "Email Already Exists!";
                    return NotFound(new { success, message });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to Update Candidate(Hired) Data, If Candidate is Selected It aslo adds Candidate Data to FellowshipProgram
        /// </summary>
        /// <param name="candidateID">CandidateID</param>
        /// <param name="updateRequest">Hired Data</param>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpPut]
        [Route("{candidateID}")]
        public IActionResult UpdateCandidate(int candidateID, HiredUpdateRequest updateRequest)
        {
            try
            {
                bool success = false;
                string message;
                var data = _hiredBusiness.UpdateHired(candidateID, updateRequest);
                if (data != null)
                {
                    success = true;
                    message = "Candidate(Hired) Data Updated Successfully";
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
        /// It is used to Show All Fellowship Candidates Data
        /// </summary>
        /// <returns>If Data Found return ok else null or BadRequest</returns>
        [HttpGet]
        [Route("FellowshipCandidates")]
        public IActionResult GetAllFellowshipCandidates()
        {
            try
            {
                bool success = false;
                string message;
                var data = _hiredBusiness.GetAllFellowshipCandidates().ToList();
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
                var data = _hiredBusiness.UpdateSelectedFellowshipCandidate(candidateID, updateRequest);
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
                var data = _hiredBusiness.AddCandidateBankDetails(candidateID, bankDetail);
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
                var data = _hiredBusiness.AddCandidateQualification(candidateID, qualification);
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
                var data = _hiredBusiness.AddCanndidateDocuments(candidateID, documents);
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
    }
}