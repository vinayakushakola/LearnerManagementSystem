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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyBusiness _companyBusiness;

        public CompanyController(ICompanyBusiness companyBusiness)
        {
            _companyBusiness = companyBusiness;
        }

        /// <summary>
        /// It is used to Show all Companies Information
        /// </summary>
        /// <returns>If Data Found return Ok else NotFound or BadRequest</returns>
        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            try
            {
                bool success = false;
                string message;
                var data = _companyBusiness.GetAllCompanies();
                if (data != null)
                {
                    success = true;
                    message = "Companies Data Fetched Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "No Data Found";
                    return NotFound(new { success, message });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to Add a Company
        /// </summary>
        /// <param name="company">Company Info</param>
        /// <returns>If Data Found return Ok else NotFound or BadRequest</returns>
        [HttpPost]
        public IActionResult AddCompany(CompanyAddRequest company)
        {
            try
            {
                bool success = false;
                string message;
                var data = _companyBusiness.AddCompany(company);
                if (data != null)
                {
                    success = true;
                    message = "Company Data Added Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "Try Again!";
                    return NotFound(new { success, message });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to Add Maker Program
        /// </summary>
        /// <param name="makerProgram">Maker Program</param>
        /// <returns>If Data Found return Ok else null or BadRequest</returns>
        [HttpPost]
        [Route("MakerProgram")]
        public IActionResult MakerProgram(MakerProgramRequest makerProgram)
        {
            try
            {
                bool success = false;
                string message;
                var data = _companyBusiness.AddMakerProgram(makerProgram);
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

        /// <summary>
        /// It is used to Show all Mentors Information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Mentors")]
        public IActionResult GetAllMentors()
        {
            try
            {
                bool success = false;
                string message;
                var data = _companyBusiness.ListOfMentors();
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
        [Route("Mentor")]
        public IActionResult AddMentor(MentorRegistrationRequest mentor)
        {
            try
            {
                bool success = false;
                string message;
                var data = _companyBusiness.AddMentor(mentor);
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
                var data = _companyBusiness.AddMentorIdeation(mentor);
                if (data != null)
                {
                    success = true;
                    message = "MentorIdeation Data Added Successfully";
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
                var data = _companyBusiness.AddMentorTechStack(mentor);
                if (data != null)
                {
                    success = true;
                    message = "MentorTechStack Data Added Successfully";
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
                var data = _companyBusiness.AddTechStack(techStack);
                if (data != null)
                {
                    success = true;
                    message = "TechStack Data Added Successfully";
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
                var data = _companyBusiness.AddTechType(techType);
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

        [HttpGet]
        [Route("Labs")]
        public IActionResult GetAllLabs()
        {
            try
            {
                bool success = false;
                string message;
                var data = _companyBusiness.ListOfLabs();
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
        [Route("Lab")]
        public IActionResult AddLab(LabRegistrationRequest lab)
        {
            try
            {
                bool success = false;
                string message;
                var data = _companyBusiness.AddLab(lab);
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
                var data = _companyBusiness.AddLabThreshold(labThreshold);
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

        /// <summary>
        /// It is used to Add Company Requirements
        /// </summary>
        /// <param name="company">Company Requirement Information</param>
        /// <returns>If Data Found return Ok else null or BadRequest</returns>
        [HttpPost]
        [Route("CompanyRequirement")]
        public IActionResult AddCompanyRequirement(CompanyRequirementRequest company)
        {
            try
            {
                bool success = false;
                string message;
                var data = _companyBusiness.AddCompanyRequirement(company);
                if (data != null)
                {
                    success = true;
                    message = "Company Requirement Added Successfully";
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
        [Route("CandidateTechStackAssignment")]
        public IActionResult AddCandidateTecStackAssign(CandidateTechStackAssignRequest candidateTech)
        {
            try
            {
                bool success = false;
                string message;
                var data = _companyBusiness.AddCandidateTechStackAssign(candidateTech);
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