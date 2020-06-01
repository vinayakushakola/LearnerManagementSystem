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
    public class TechnologyController : ControllerBase
    {
        private readonly ITechBusiness _techBusiness;

        public TechnologyController(ITechBusiness techBusiness)
        {
            _techBusiness = techBusiness;
        }


        /// <summary>
        /// It is used to Add Tech Stack
        /// </summary>
        /// <param name="techStack">Tech Stack</param>
        /// <returns>If Data Found return Ok else null or BadRequest</returns>
        [HttpPost]
        [Route("TechStack")]
        public IActionResult AddTechStack(TechStackRequest techStack)
        {
            try
            {
                bool success = false;
                string message;
                var data = _techBusiness.AddTechStack(techStack);
                if (data != null)
                {
                    success = true;
                    message = "Tech Stack Data Added Successfully";
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
        /// It is used to Add Tech Type
        /// </summary>
        /// <param name="techType">Tech Type</param>
        /// <returns>If Data Found return Ok else null or BadRequest</returns>
        [HttpPost]
        [Route("TechType")]
        public IActionResult AddTechType(TechTypeRequest techType)
        {
            try
            {
                bool success = false;
                string message;
                var data = _techBusiness.AddTechType(techType);
                if (data != null)
                {
                    success = true;
                    message = "TechType Data Added Successfully";
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
