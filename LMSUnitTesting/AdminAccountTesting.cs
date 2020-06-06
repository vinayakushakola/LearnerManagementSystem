//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LearnerManagementSystem.Controllers;
using LMSBusinessLayer.Interface;
using LMSBusinessLayer.Services;
using LMSCommonLayer.RequestModels;
using LMSRepositoryLayer.Interface;
using LMSRepositoryLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace LMSUnitTesting
{
    public class AdminAccountTesting
    {
        private readonly IAdminBusiness _adminBusiness;

        private readonly IAdminRepository _adminRepository;
        
        private readonly IConfiguration _configuration;

        public AdminAccountTesting()
        {
            IConfigurationBuilder configuration = new ConfigurationBuilder();
            configuration.AddJsonFile("appsettings.json");
            _configuration = configuration.Build();
            _adminRepository = new AdminRepository(_configuration);
            _adminBusiness = new AdminBusiness(_adminRepository);
        }

        [Fact]
        public void AdminRegistration_ValidData_Return_OkResult()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var adminData = new RegistrationRequest
            {
                FirstName = "Abcd",
                LastName = "Efgh",
                Email = "abcd@gmail.com",
                Password = "Abcd1234",
                ContactNumber =  "1234567890",
                IsVerified = true,
                CreatorStamp = "Vin",
                CreatorUser = "Vinayak"
            };

            var data = controller.Registration(adminData);

            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void AdminRegistration_Password_LessThan8_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var adminData = new RegistrationRequest
            {
                FirstName = "Mark",
                LastName = "Henry",
                Email = "MarkHenry@gmail.com",
                Password = "1234567",
                ContactNumber = "1234567890",
                IsVerified = true,
                CreatorStamp = "Vin",
                CreatorUser = "Vinayak"
            };

            var data = controller.Registration(adminData);

            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public void AdminRegistration_Null_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            RegistrationRequest newAdminData = null;

            var data = controller.Registration(newAdminData);

            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public void AdminRegistration_EmptyFields_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var newAdminData = new RegistrationRequest
            {
                FirstName = "",
                LastName = "",
                Email = "",
                Password = "",
                ContactNumber = "",
                IsVerified = false,
                CreatorStamp = "",
                CreatorUser = ""
            };

            var data = controller.Registration(newAdminData);

            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public void AdminRegistration_FirstName_LessThan2_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var newAdminData = new RegistrationRequest
            {
                FirstName = "A",
                LastName = "defg",
                Email = "adef@gmail.com",
                Password = "1234567891",
                ContactNumber = "1234567890",
                IsVerified = true,
                CreatorStamp = "Vin",
                CreatorUser = "Vinayak"
            };

            var data = controller.Registration(newAdminData);

            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public void AdminRegistration_LastName_LessThan2_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var newAdminData = new RegistrationRequest
            {
                FirstName = "John",
                LastName = "C",
                Email = "john@gmail.com",
                Password = "1234543216",
                ContactNumber = "1234567890",
                IsVerified = true,
                CreatorStamp = "Vin",
                CreatorUser = "Vinayak"
            };

            var data = controller.Registration(newAdminData);

            Assert.IsType<BadRequestObjectResult>(data);
        }


        [Fact]
        public void AdminRegistration_Email_NoAt_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var newAdminData = new RegistrationRequest
            {
                FirstName = "John",
                LastName = "Cena",
                Email = "JohnCenagmail.com",
                Password = "67584932",
                ContactNumber = "1234567890",
                IsVerified = true,
                CreatorStamp = "Vin",
                CreatorUser = "Vinayak"
            };

            var data = controller.Registration(newAdminData);

            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public void AdminRegistration_Email_NoDot_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var newAdminData = new RegistrationRequest
            {
                FirstName = "John",
                LastName = "Cena",
                Email = "JohnCena@gmailcom",
                Password = "67584932",
                ContactNumber = "1234567890",
                IsVerified = true,
                CreatorStamp = "Vin",
                CreatorUser = "Vinayak"
            };

            var data = controller.Registration(newAdminData);

            Assert.IsType<BadRequestObjectResult>(data);
        }



        [Fact]
        public void AdminLogin_ValidLoginData_Return_OkResult()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var loginData = new LoginRequest
            {
                Email = "abcd@gmail.com",
                Password = "Abcd1234"
            };

            var data = controller.Login(loginData);

            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void AdminLogin_InValidLoginData_Return_NotFoundResult()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var loginData = new LoginRequest
            {
                Email = "abc@gmail.com",
                Password = "abcd1234",
            };

            var data = controller.Login(loginData);

            Assert.IsType<NotFoundObjectResult>(data);
        }

        [Fact]
        public void AdminLogin_PasswordEmpty_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var logindata = new LoginRequest
            {
                Email = "JohnCena@gmail.com",
                Password = ""
            };

            var data = controller.Login(logindata);

            Assert.IsType<BadRequestObjectResult>(data);
        }


        [Fact]
        public void AdminLogin_EmailEmpty_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var logindata = new LoginRequest
            {
                Email = "",
                Password = "123445sdfs"
            };

            var data = controller.Login(logindata);

            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public void AdminLogin_Email_NoAt_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var logindata = new LoginRequest
            {
                Email = "abcdgmail.com",
                Password = "abcd1234"
            };

            var data = controller.Login(logindata);

            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public void AdminLogin_Email_NoDot_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var logindata = new LoginRequest
            {
                Email = "abcd@gmailcom",
                Password = "abcd1234"
            };

            var data = controller.Login(logindata);

            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public void AdminLogin_Password_LessThan8_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var logindata = new LoginRequest
            {
                Email = "abcde@gmail.com",
                Password = "abcd1"
            };

            var data = controller.Login(logindata);

            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public void AdminLogin_Null_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            LoginRequest logindata = null;

            var data = controller.Login(logindata);

            Assert.IsType<BadRequestObjectResult>(data);
        }



        [Fact]
        public void ForgotPassword_ValidEmailData_Return_OkResult()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var forgotPassword = new ForgotPasswordRequest
            {
                Email = "abcd@gmail.com"
            };

            var data = controller.ForgotPassword(forgotPassword);

            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void ForgotPassword_InValidEmailData_Return_NotFoundResult()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var forgotPassword = new ForgotPasswordRequest
            {
                Email = "Sam@gmail.com"
            };

            var data = controller.ForgotPassword(forgotPassword);

            Assert.IsType<NotFoundObjectResult>(data);

        }

        [Fact]
        public void ForgotPassword_Null_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            ForgotPasswordRequest forgotPassword = null;

            var data = controller.ForgotPassword(forgotPassword);

            Assert.IsType<BadRequestObjectResult>(data);

        }

        [Fact]
        public void ForgotPassword_EmptyEmailField_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var forgotPassword = new ForgotPasswordRequest
            {
                Email = ""
            };

            var data = controller.ForgotPassword(forgotPassword);

            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public void ForgotPassword_Email_NoAt_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var forgotPassword = new ForgotPasswordRequest
            {
                Email = "abcdgmail.com"
            };

            var data = controller.ForgotPassword(forgotPassword);

            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public void ForgotPassword_Email_NoDot_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var forgotPassword = new ForgotPasswordRequest
            {
                Email = "abcd@gmailcom"
            };

            var data = controller.ForgotPassword(forgotPassword);

            Assert.IsType<BadRequestObjectResult>(data);
        }



        [Fact]
        public void ResetPassword_Password_LessThan8_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var resetPassword = new ResetPasswordRequest
            {
                Password = "123456"
            };

            var data = controller.ResetPassword(resetPassword);

            Assert.IsType<BadRequestObjectResult>(data);

        }

        [Fact]
        public void ResetPassword_Null_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            ResetPasswordRequest resetPassword = null;

            var data = controller.ResetPassword(resetPassword);

            Assert.IsType<BadRequestObjectResult>(data);

        }

        [Fact]
        public void ResetPassword_EmptyPasswordField_Return_BadRequest()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var resetPassword = new ResetPasswordRequest
            {
                Password = ""
            };

            var data = controller.ResetPassword(resetPassword);

            Assert.IsType<BadRequestObjectResult>(data);

        }
    }
}
