//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSBusinessLayer.Interface
{
    public interface IAdminBusiness
    {
        List<AdminResponseModel> GetAllUsers();

        AdminResponseModel AddUser(RegistrationRequest registrationRequest);

        AdminResponseModel UpdateUser(int adminID, AdminUpdateRequest updateRequest);

        bool DeleteUser(int adminID);

        AdminResponseModel Login(LoginRequest login);

        AdminResponseModel ForgotPassword(ForgotPasswordRequest forogotPassword);

        bool ResetPassword(int userID, ResetPasswordRequest resetPassword);
    }
}
