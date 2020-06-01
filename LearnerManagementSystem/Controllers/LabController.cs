//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSBusinessLayer.Interface;
using LMSCommonLayer.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LearnerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LabController : ControllerBase
    {
        private readonly ILabBusiness _labBusiness;

        public LabController(ILabBusiness labBusiness)
        {
            _labBusiness = labBusiness;
        }

        /// <summary>
        /// It is used to show All Labs
        /// </summary>
        /// <returns>If Data Found return Ok else null or BadRequest</returns>
        [HttpGet]
        public IActionResult GetAllLabs()
        {
            try
            {
                bool success = false;
                string message;
                var data = _labBusiness.ListOfLabs();
                if (data != null)
                {
                    success = true;
                    message = "Labs Data Fetched Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "No Data Found";
                    return NotFound(new { success, message });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to Add Lab
        /// </summary>
        /// <param name="lab">Lab Data</param>
        /// <returns>If Data Found return Ok else null or BadRequest</returns>
        [HttpPost]
        public IActionResult AddLab(LabRegistrationRequest lab)
        {
            try
            {
                bool success = false;
                string message;
                var data = _labBusiness.AddLab(lab);
                if (data != null)
                {
                    success = true;
                    message = "Lab Data Added Successfully";
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
        /// It is used to add LabThreshold
        /// </summary>
        /// <param name="labThreshold">Lab Threshold</param>
        /// <returns>If Data Found return Ok else null or BadRequest</returns>
        [HttpPost]
        [Route("LabThreshold")]
        public IActionResult AddLabThreshold(LabThresholdRequest labThreshold)
        {
            try
            {
                bool success = false;
                string message;
                var data = _labBusiness.AddLabThreshold(labThreshold);
                if (data != null)
                {
                    success = true;
                    message = "LabThreshold Added Successfully";
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
