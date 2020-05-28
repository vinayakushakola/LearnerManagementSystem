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

        public List<AdminResponseModel> GetAllUsers()
        {
            var responseData = _adminRepository.GetAllUsers();
            return responseData;
        }

        public AdminResponseModel AddUser(RegistrationRequest registrationRequest)
        {
            var responseData = _adminRepository.AddUser(registrationRequest);
            return responseData;
        }

        public AdminResponseModel UpdateUser(int userID, AdminUpdateRequest updateRequest)
        {
            var responseData = _adminRepository.UpdateUser(userID, updateRequest);
            return responseData;
        }

        public bool DeleteUser(int userID)
        {
            var responseData = _adminRepository.DeleteUser(userID);
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
