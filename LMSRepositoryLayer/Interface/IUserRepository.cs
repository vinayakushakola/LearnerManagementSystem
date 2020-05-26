//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using System.Collections.Generic;

namespace LMSRepositoryLayer.Interface
{
    public interface IUserRepository
    {
        List<RegistrationResponse> GetAllUsers();

        RegistrationResponse AddUser(RegistrationRequest registrationRequest);

        RegistrationResponse UpdateUser(int userID, UserUpdateRequest updateRequest);

        bool DeleteUser(int userID);

        RegistrationResponse Login(LoginRequest login);
        
        RegistrationResponse ForgotPassword(ForgotPasswordRequest forogotPassword);
    }
}
