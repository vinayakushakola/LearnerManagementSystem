//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSBusinessLayer.Interface
{
    public interface IUserBusiness
    {
        List<UserResponseModel> GetAllUsers();

        UserResponseModel AddUser(RegistrationRequest registrationRequest);

        UserResponseModel UpdateUser(int userID, UserUpdateRequest updateRequest);

        bool DeleteUser(int userID);

        UserResponseModel Login(LoginRequest login);

        UserResponseModel ForgotPassword(ForgotPasswordRequest forogotPassword);

        bool ResetPassword(int userID, ResetPasswordRequest resetPassword);
    }
}
