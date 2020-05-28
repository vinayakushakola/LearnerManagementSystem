//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSRepositoryLayer.Interface
{
    public interface IAdminRepository
    {
        List<AdminResponseModel> GetAllUsers();

        AdminResponseModel AddUser(RegistrationRequest registrationRequest);

        AdminResponseModel UpdateUser(int userID, AdminUpdateRequest updateRequest);

        bool DeleteUser(int userID);

        AdminResponseModel Login(LoginRequest login);

        AdminResponseModel ForgotPassword(ForgotPasswordRequest forogotPassword);

        bool ResetPassword(int userID, ResetPasswordRequest resetPassword);
    }
}
