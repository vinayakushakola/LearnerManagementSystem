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
    public class MentorController : Controller
    {
        private readonly IMentorBusiness _mentorBusiness;

        public MentorController(IMentorBusiness mentorBusiness)
        {
            _mentorBusiness = mentorBusiness;
        }

        /// <summary>
        /// It is used to Show all Mentors Information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllMentors()
        {
            try
            {
                bool success = false;
                string message;
                var data = _mentorBusiness.ListOfMentors();
                if (data != null)
                {
                    success = true;
                    message = "Mentors Data Fetched Successfully";
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
        /// It is used for Mentor Registration
        /// </summary>
        /// <param name="mentor">Mentor Registration Data</param>
        /// <returns>If Data Found return Ok else null or BadRequest</returns>
        [HttpPost]
        public IActionResult AddMentor(MentorRegistrationRequest mentor)
        {
            try
            {
                bool success = false;
                string message;
                var data = _mentorBusiness.AddMentor(mentor);
                if (data != null)
                {
                    success = true;
                    message = "Mentor Data Added Successfully";
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
        /// It is used to Map Lead to Mentors
        /// </summary>
        /// <param name="mentor"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MentorIdeation")]
        public IActionResult AddMentorIdeation(MentorIdeationRequest mentor)
        {
            try
            {
                bool success = false;
                string message;
                var data = _mentorBusiness.AddMentorIdeation(mentor);
                if (data != null)
                {
                    success = true;
                    message = "Mentor Ideation Data Added Successfully";
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
        /// It is used to Add Mentor Tech Stack
        /// </summary>
        /// <param name="mentor">Mentor TEch Stack</param>
        /// <returns>IF Data Found return Ok Else null or BadRequest</returns>
        [HttpPost]
        [Route("MentorTechStack")]
        public IActionResult AddMentorTechStack(MentorTechStackRequest mentor)
        {
            try
            {
                bool success = false;
                string message;
                var data = _mentorBusiness.AddMentorTechStack(mentor);
                if (data != null)
                {
                    success = true;
                    message = "Mentor Tech Stack Data Added Successfully";
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
