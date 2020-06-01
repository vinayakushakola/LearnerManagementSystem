//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSBusinessLayer.Interface;
using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using LMSRepositoryLayer.Interface;
using System.Collections.Generic;

namespace LMSBusinessLayer.Services
{
    public class AdminBusiness : IAdminBusiness
    {
        private readonly IAdminRepository _adminRepository;

        public AdminBusiness(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public List<AdminResponseModel> GetAllAdmins()
        {
            var responseData = _adminRepository.GetAllAdmins();
            return responseData;
        }

        public AdminResponseModel Registration(RegistrationRequest registrationRequest)
        {
            var responseData = _adminRepository.Registration(registrationRequest);
            return responseData;
        }

        public AdminResponseModel UpdateAdmin(int userID, AdminUpdateRequest updateRequest)
        {
            var responseData = _adminRepository.UpdateAdmin(userID, updateRequest);
            return responseData;
        }

        public bool DeleteAdmin(int userID)
        {
            var responseData = _adminRepository.DeleteAdmin(userID);
            return responseData;
        }

        public AdminResponseModel Login(LoginRequest login)
        {
            var responseData = _adminRepository.Login(login);
            return responseData;
        }

        public AdminResponseModel ForgotPassword(ForgotPasswordRequest forogotPassword)
        {
            var responseData = _adminRepository.ForgotPassword(forogotPassword);
            return responseData;
        }

        public bool ResetPassword(int userID, ResetPasswordRequest resetPassword)
        {
            var responseData = _adminRepository.ResetPassword(userID, resetPassword);
            return responseData;
        }
    }
}
