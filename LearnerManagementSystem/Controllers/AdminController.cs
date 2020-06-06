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
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace LearnerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBusiness _adminBusiness;

        private readonly IConfiguration _configuration;

        private readonly string _login = "Login";
        
        private readonly string _forgotPassword = "ForgotPassword";

        public AdminController(IAdminBusiness adminBusiness, IConfiguration configuration)
        {
            _adminBusiness = adminBusiness;
            _configuration = configuration;
        }

        /// <summary>
        /// It is used to Show all Admins Registration Data
        /// </summary>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            try
            {
                bool success = false;
                string message;
                var data = _adminBusiness.GetAllAdmins().ToList();
                if (data != null)
                {
                    success = true;
                    message = "Admins Data Fetched Successfully";
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
        /// It is used to Create Admin Account
        /// </summary>
        /// <param name="registration">Admin Registration Data</param>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpPost]
        public IActionResult Registration(RegistrationRequest registration)
        {
            try
            {
                bool success = false;
                string message;
                var data = _adminBusiness.Registration(registration);
                if (data != null)
                {
                    success = true;
                    message = "Admin Registered Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "Email Already Exists!";
                    return Ok(new { success, message });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to Update Admin Account
        /// </summary>
        /// <param name="updateRequest">Admin Update Data</param>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpPut]
        [Authorize]
        public IActionResult UpdateAdmin(AdminUpdateRequest updateRequest)
        {
            try
            {
                bool success = false;
                string message;
                var adminID = Convert.ToInt32(User.Claims.FirstOrDefault(id => id.Type.Equals("AdminID", StringComparison.InvariantCultureIgnoreCase)).Value);
                var data = _adminBusiness.UpdateAdmin(adminID, updateRequest);
                if (data != null)
                {
                    success = true;
                    message = "Admin Data Updated Successfully";
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
        /// It is used to Delete Admin Account
        /// </summary>
        /// <param name="adminID">AdminID</param>
        /// <returns>If Data Found return Ok else return NotFound or BadRequest</returns>
        [HttpDelete("{adminID}")]
        [Authorize]
        public IActionResult DeleteAdmin(int adminID)
        {
            try
            {
                bool success = false;
                string message;
                var data = _adminBusiness.DeleteAdmin(adminID);
                if (data)
                {
                    success = true;
                    message = "Admmin Data Deleted Successfully";
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
        /// It is used to Admin Login
        /// </summary>
        /// <param name="adminLogin">Admin Login Data</param>
        /// <returns>If Data Found return Ok else NotFound or BadRequest</returns>
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequest adminLogin)
        {
            try
            {
                if (!ValidateLoginRequest(adminLogin))
                    return BadRequest(new { Message = "Enter proper Input" });

                bool success = false;
                string message, token;
                var data = _adminBusiness.Login(adminLogin);
                if (data != null)
                {
                    success = true;
                    message = "Admin Logged In Successfully";
                    token = GenerateToken(data, _login);
                    return Ok(new { success, message, data, token });
                }
                else
                {
                    message = "Enter Valid Email & Password!";
                    return NotFound(new { success, message });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// It is used to send mail to change password
        /// </summary>
        /// <param name="forgot">Forgot Password</param>
        /// <returns>If Data Found return ok else NotFound or Badrequest</returns>
        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordRequest forgot)
        {
            try
            {
                bool success = false, sentMail;
                string message, token;
                var data = _adminBusiness.ForgotPassword(forgot);
                if (data != null)
                {
                    token = GenerateToken(data, _forgotPassword);
                    sentMail = SendMail(data, token);
                    if (sentMail)
                    {
                        success = true;
                        message = "Token Sent Successfully";
                        return Ok(new { success, message, data, token });
                    }
                    message = "Mail Not sent, Try again";
                    return Ok(new { success, message });
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
                var adminID = Convert.ToInt32(User.Claims.FirstOrDefault(id => id.Type.Equals("AdminID", StringComparison.InvariantCultureIgnoreCase)).Value);
                var data = _adminBusiness.ResetPassword(adminID, reset);
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
        private string GenerateToken(AdminResponseModel tokenData, string tokenType)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim("AdminID", tokenData.AdminID.ToString()),
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

        /// <summary>
        /// It is used to Send Mails
        /// </summary>
        /// <param name="data">Response Data</param>
        /// <param name="token">Token</param>
        private bool SendMail(AdminResponseModel data, string token)
        {
            try
            {
                if (data != null)
                {
                    string FROMNAME = "Vinayak Ushakola", FROM = "vinayak.mailtesting@gmail.com", TO = data.Email, SUBJECT = "Reset Password";
                    int PORT = 587;
                    string FullName = "\n" + data.FirstName + " " + data.LastName;
                    string message = "\nClick on this link to Reset your password: https://localhost:44314/api/user/resetpassword \nCopy this token & paste in your postman: " + token;
                    var BODY = "Hi," + FullName + message;

                    MailMessage mailMessage = new MailMessage();
                    SmtpClient client = new SmtpClient("smtp.gmail.com", PORT);
                    mailMessage.From = new MailAddress(FROM, FROMNAME);
                    mailMessage.To.Add(new MailAddress(TO));
                    mailMessage.Subject = SUBJECT;
                    mailMessage.Body = BODY;

                    client.Credentials = new NetworkCredential(FROM, "@bcd.1234");
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mailMessage);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ValidateLoginRequest(LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Email) ||
                string.IsNullOrWhiteSpace(loginRequest.Password) || !loginRequest.Email.Contains('@') ||
                !loginRequest.Email.Contains('.') || loginRequest.Password.Length < 8)
                return false;

            return true;
        }
    }
}