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
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<RegistrationResponse> GetAllUsers()
        {
            var responseData = _userRepository.GetAllUsers();
            return responseData;
        }

        public RegistrationResponse AddUser(RegistrationRequest registrationRequest)
        {
            var responseData = _userRepository.AddUser(registrationRequest);
            return responseData;
        }

        public RegistrationResponse UpdateUser(int userID, UserUpdateRequest updateRequest)
        {
            var responseData = _userRepository.UpdateUser(userID, updateRequest);
            return responseData;
        }

        public bool DeleteUser(int userID)
        {
            var responseData = _userRepository.DeleteUser(userID);
            return responseData;
        }

        public RegistrationResponse Login(LoginRequest login)
        {
            var responseData = _userRepository.Login(login);
            return responseData;
        }

        public RegistrationResponse ForgotPassword(ForgotPasswordRequest forogotPassword)
        {
            var responseData = _userRepository.ForgotPassword(forogotPassword);
            return responseData;
        }

        public bool ResetPassword(int userID, ResetPasswordRequest resetPassword)
        {
            var responseData = _userRepository.ResetPassword(userID, resetPassword);
            return responseData;
        }
    }
}
