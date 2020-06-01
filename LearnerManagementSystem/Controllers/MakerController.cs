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
    public class MakerController : ControllerBase
    {
        private readonly IMakerBusiness _makerBusiness;

        public MakerController(IMakerBusiness makerBusiness)
        {
            _makerBusiness = makerBusiness;
        }

        /// <summary>
        /// It is used to Add Maker Program
        /// </summary>
        /// <param name="makerProgram">Maker Program</param>
        /// <returns>If Data Found return Ok else null or BadRequest</returns>
        [HttpPost]
        public IActionResult MakerProgram(MakerProgramRequest makerProgram)
        {
            try
            {
                bool success = false;
                string message;
                var data = _makerBusiness.AddMakerProgram(makerProgram);
                if (data != null)
                {
                    success = true;
                    message = "Maker Program Added Successfully";
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
