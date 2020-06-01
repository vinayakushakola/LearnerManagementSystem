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
    public class HiredController : ControllerBase
    {
        private readonly IHiredBusiness _hiredBusiness;
        public HiredController(IHiredBusiness hiredBusiness)
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
    }
}