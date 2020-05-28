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
        /// It is used to Show all Hired Users Data
        /// </summary>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpGet]
        public IActionResult GetAllHired()
        {
            try
            {
                bool success = false;
                string message;
                var data = _hiredBusiness.GetAllHired().ToList();
                if (data != null)
                {
                    success = true;
                    message = "Hired Users Data Fetched Successfully";
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
        /// It is used to Add Hired UserData
        /// </summary>
        /// <param name="registration">Hired Registration Data</param>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpPost]
        public IActionResult AddUser(HiredRegistrationRequest registration)
        {
            try
            {
                bool success = false;
                string message;
                var data = _hiredBusiness.AddHired(registration);
                if (data != null)
                {
                    success = true;
                    message = "Hired User Data Added Successfully";
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

        /// It is used to Update Hired UserData
        /// </summary>
        /// <param name="candidateID">CandidateID</param>
        /// <param name="updateRequest">Hired Update Data</param>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpPut]
        [Route("{candidateID}")]
        public IActionResult UpdateHired(int candidateID, HiredUpdateRequest updateRequest)
        {
            try
            {
                bool success = false;
                string message;
                var data = _hiredBusiness.UpdateHired(candidateID, updateRequest);
                if (data != null)
                {
                    success = true;
                    message = "Hired User Data Updated Successfully";
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
        /// It is used to Update Data
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
                var data = _hiredBusiness.UpdateFellowshipCandidate(candidateID, updateRequest);
                if (data != null)
                {
                    success = true;
                    message = "Fellowship Candidate Data Updated Successfully";
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