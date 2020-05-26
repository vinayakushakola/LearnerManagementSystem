//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSBusinessLayer.Interface;
using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace LearnerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        private readonly IConfiguration _configuration;

        private readonly string _login = "Login";
        
        private readonly string _forgotPassword = "ForgotPassword";

        public UserController(IUserBusiness userBusiness, IConfiguration configuration)
        {
            _userBusiness = userBusiness;
            _configuration = configuration;
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
        [HttpPut]
        [Authorize]
        public IActionResult UpdateUser(UserUpdateRequest updateRequest)
        {
            try
            {
                bool success = false;
                string message;
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(id => id.Type.Equals("UserID", StringComparison.InvariantCultureIgnoreCase)).Value);
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

        /// <summary>
        /// It is used to Login
        /// </summary>
        /// <param name="login">Login Data</param>
        /// <returns>If Data Found return Ok else NotFound or BadRequest</returns>
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequest login)
        {
            try
            {
                bool success = false;
                string message, token;
                RegistrationResponse data = _userBusiness.Login(login);
                if (data != null)
                {
                    success = true;
                    message = "User Logged In Successfully";
                    token = GenerateToken(data, _login);
                    return Ok(new { success, message, data, token });
                }
                else
                {
                    message = "Enter Valid Email & Password!";
                    return Ok(new { success, message });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is Forgot Password API
        /// </summary>
        /// <param name="forgot">Forgot Password</param>
        /// <returns>If Data Found return ok else NotFound or Badrequest</returns>
        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordRequest forgot)
        {
            try
            {
                bool success = false;
                string message, token;
                RegistrationResponse data = _userBusiness.ForgotPassword(forgot);
                if (data != null)
                {
                    success = true;
                    token = GenerateToken(data, _forgotPassword);
                    message = "Token Sent Successfully";
                    return Ok(new { success, message, data, token });
                }
                else
                {
                    message = "Email Not Found!";
                    return NotFound(new { success, message });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to Reset Password
        /// </summary>
        /// <param name="reset">Reset Password</param>
        /// <returns>If ResetPassword Successfull return ok else NotFound or BadRequest</returns>
        [Authorize]
        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(ResetPasswordRequest reset)
        {
            try
            {
                bool success = false;
                string message;
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(id => id.Type.Equals("UserID", StringComparison.InvariantCultureIgnoreCase)).Value);
                bool data = _userBusiness.ResetPassword(userID, reset);
                if (data)
                {
                    success = true;
                    message = "Password Changed Successfully";
                    return Ok(new { success, message });
                }
                else
                {
                    message = "Password Changing Unsuccessfull, Try Again!";
                    return NotFound(new { success, message });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to Generate Token
        /// </summary>
        /// <param name="tokenData">Response Data</param>
        /// <param name="tokenType">Token Type</param>
        /// <returns>It return Token</returns>
        private string GenerateToken(RegistrationResponse tokenData, string tokenType)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim("UserID", tokenData.UserID.ToString()),
                    new Claim("Email", tokenData.Email.ToString()),
                    new Claim("TokenType", tokenType),
                };

                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], 
                    _configuration["Jwt:Issuer"],
                    claims, 
                    expires: DateTime.Now.AddDays(1), 
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}