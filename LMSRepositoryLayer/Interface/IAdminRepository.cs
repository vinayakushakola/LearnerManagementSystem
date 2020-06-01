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
        List<AdminResponseModel> GetAllAdmins();

        AdminResponseModel Registration(RegistrationRequest registrationRequest);

        AdminResponseModel UpdateAdmin(int adminID, AdminUpdateRequest updateRequest);

        bool DeleteAdmin(int adminID);

        AdminResponseModel Login(LoginRequest login);

        AdminResponseModel ForgotPassword(ForgotPasswordRequest forogotPassword);

        bool ResetPassword(int adminID, ResetPasswordRequest resetPassword);
    }
}
