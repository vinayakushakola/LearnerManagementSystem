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
        public void AdminRegistration_Valid_Return_OkResult()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var adminData = new RegistrationRequest
            {
                FirstName = "Abcd",
                LastName = "Efgh",
                Email = "abcd1234@gmail.com",
                Password = "Abcd1234",
                ContactNumber =  "1234567890",
                Verified = "yes",
                CreatorStamp = "Vin",
                CreatorUser = "Vinayak"
            };

            var data = controller.AddAdmin(adminData);

            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void AdminRegistration_InValid_Return_NotFound()
        {
            var controller = new AdminController(_adminBusiness, _configuration);
            var adminData = new RegistrationRequest
            {
                FirstName = "Abcd",
                LastName = "Efgh",
                Email = "abcd1234@gmail.com",
                Password = "Abcd1234",
                ContactNumber = "1234567890",
                Verified = "yes",
                CreatorStamp = "Vin",
                CreatorUser = "Vinayak"
            };

            var data = controller.AddAdmin(adminData);

            Assert.IsType<NotFoundObjectResult>(data);
        }
    }
}
