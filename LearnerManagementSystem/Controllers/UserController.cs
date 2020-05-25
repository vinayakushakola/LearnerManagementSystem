//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSBusinessLayer.Interface;
using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LearnerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        /// <summary>
        /// It is used to Show all Users Data
        /// </summary>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpGet]
        public IActionResult GetAllusers()
        {
            try
            {
                bool success = false;
                string message;
                var data = _userBusiness.GetAllUsers().ToList();
                if (data != null)
                {
                    success = true;
                    message = "Users Data Fetched Successfull";
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
        /// It is used to Register
        /// </summary>
        /// <param name="registration">User Registration Data</param>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpPost]
        public IActionResult AddUser(RegistrationRequest registration)
        {
            try
            {
                bool success = false;
                string message;
                RegistrationResponse data = _userBusiness.AddUser(registration);
                if (data != null)
                {
                    success = true;
                    message = "User Registered Successfully";
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
        /// It is used to Update User Data
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <param name="updateRequest">User Update Data</param>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpPut("{userID}")]
        public IActionResult UpdateUser(int userID, UserUpdateRequest updateRequest)
        {
            try
            {
                bool success = false;
                string message;
                RegistrationResponse data = _userBusiness.UpdateUser(userID, updateRequest);
                if (data != null)
                {
                    success = true;
                    message = "User Data Updated Successfully";
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
        /// It is used to Delete Data
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpDelete("{userID}")]
        public IActionResult DeleteUser(int userID)
        {
            try
            {
                bool success = false;
                string message;
                bool data = _userBusiness.DeleteUser(userID);
                if (data)
                {
                    success = true;
                    message = "User Data Deleted Successfully";
                    return Ok(new { success, message });
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