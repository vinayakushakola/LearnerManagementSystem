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
                Password = "bcd1234",
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
    }
}
