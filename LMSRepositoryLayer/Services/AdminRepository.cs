//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.DBModels;
using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using LMSRepositoryLayer.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LMSRepositoryLayer.Services
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IConfiguration _configuration;

        private static int count;

        private readonly string sqlConnectionString;

        public AdminRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnectionString = _configuration.GetConnectionString("LMSDBConnection");
        }

        /// <summary>
        /// It Fetch Data from the Database
        /// </summary>
        /// <returns>If Retrieving Data Successfull return Data else return null or Exception</returns>
        public List<AdminResponseModel> GetAllUsers()
        {
            try
            {
                List<AdminResponseModel> userList = null;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    userList = new List<AdminResponseModel>();
                    SqlCommand cmd = new SqlCommand("SP_GetAllAdmins", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        AdminResponseModel user = new AdminResponseModel();
                        user.AdminID = Convert.ToInt32(dataReader["AdminID"].ToString());
                        user.FirstName = dataReader["FirstName"].ToString();
                        user.LastName = dataReader["LastName"].ToString();
                        user.Email = dataReader["Email"].ToString();
                        user.ContactNumber = dataReader["ContactNumber"].ToString();
                        user.Verified = dataReader["Verified"].ToString();
                        user.CreatorStamp = dataReader["CreatorStamp"].ToString();
                        user.CreatorUser = dataReader["CreatorUser"].ToString();
                        user.CreatedDate = dataReader["CreatedDate"].ToString();
                        user.ModifiedDate = dataReader["ModifiedDate"].ToString();
                        
                        userList.Add(user);
                    }
                    conn.Close();
                }
                return userList;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Stores Data in the Database
        /// </summary>
        /// <param name="registrationRequest">User Data</param>
        /// <returns>If Storing Data Successfull it return ResponseData else null or Exception</returns>
        public AdminResponseModel AddUser(RegistrationRequest registrationRequest)
        {
            try
            {
                AdminResponseModel responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_InsertAdmin", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@FirstName", registrationRequest.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", registrationRequest.LastName);
                        cmd.Parameters.AddWithValue("@Email", registrationRequest.Email);
                        cmd.Parameters.AddWithValue("@Password", EncodeDecode.EncodePasswordToBase64(registrationRequest.Password));
                        cmd.Parameters.AddWithValue("@ContactNumber", registrationRequest.ContactNumber);
                        cmd.Parameters.AddWithValue("@Verified", registrationRequest.Verified);
                        cmd.Parameters.AddWithValue("@CreatorStamp", registrationRequest.CreatorStamp);
                        cmd.Parameters.AddWithValue("@CreatorUser", registrationRequest.CreatorUser);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new AdminResponseModel();
                            responseData.AdminID = Convert.ToInt32(dataReader["AdminID"].ToString());
                            responseData.FirstName = dataReader["FirstName"].ToString();
                            responseData.LastName = dataReader["LastName"].ToString();
                            responseData.Email = dataReader["Email"].ToString();
                            responseData.ContactNumber = dataReader["ContactNumber"].ToString();
                            responseData.Verified = dataReader["Verified"].ToString();
                            responseData.CreatorStamp = dataReader["CreatorStamp"].ToString();
                            responseData.CreatorUser = dataReader["CreatorUser"].ToString();
                            responseData.CreatedDate = dataReader["CreatedDate"].ToString();
                            responseData.ModifiedDate = dataReader["ModifiedDate"].ToString();
                        }
                        conn.Close();
                    }
                }
                catch
                {
                    return null;
                }
                return responseData;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Updates a Specific Admin Data in the Database
        /// </summary>
        /// <param name="adminID">AdminID</param>
        /// <param name="updateRequest">Update Data</param>
        /// <returns>If Updating Data Successfull return ResponseData else return null or Exception</returns>
        public AdminResponseModel UpdateUser(int adminID, AdminUpdateRequest updateRequest)
        {
            try
            {
                AdminResponseModel responseData = new AdminResponseModel();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateAdmin", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdminID", adminID);
                    cmd.Parameters.AddWithValue("@Email", updateRequest.Email);
                    cmd.Parameters.AddWithValue("@ContactNumber", updateRequest.ContactNumber);
                    cmd.Parameters.AddWithValue("@Verified", updateRequest.Verified);
                    cmd.Parameters.AddWithValue("@CreatorStamp", updateRequest.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", updateRequest.CreatorUser);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData.AdminID = Convert.ToInt32(dataReader["AdminID"].ToString());
                        responseData.FirstName = dataReader["FirstName"].ToString();
                        responseData.LastName = dataReader["LastName"].ToString();
                        responseData.Email = dataReader["Email"].ToString();
                        responseData.ContactNumber = dataReader["ContactNumber"].ToString();
                        responseData.Verified = dataReader["Verified"].ToString();
                        responseData.CreatorStamp = dataReader["CreatorStamp"].ToString();
                        responseData.CreatorUser = dataReader["CreatorUser"].ToString();
                        responseData.CreatedDate = dataReader["CreatedDate"].ToString();
                        responseData.ModifiedDate = dataReader["ModifiedDate"].ToString();
                    }
                    conn.Close();
                }
                return responseData;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Deletes Admin data from the Database
        /// </summary>
        /// <param name="adminID">AdminID</param>
        /// <returns>If Deleting Data Successfull return true else false or Exception</returns>
        public bool DeleteUser(int adminID)
        {
            try
            {
                if (adminID > 0)
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_DeleteAdmin", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@AdminID", adminID);

                        conn.Open();
                        count = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (count > 0)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It checks Email & Password
        /// </summary>
        /// <param name="login">Login Data</param>
        /// <returns>If Data Found return ResponseData else null or Exception</returns>
        public AdminResponseModel Login(LoginRequest login)
        {
            try
            {
                AdminResponseModel responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_LoginValidation", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Email", login.Email);
                        cmd.Parameters.AddWithValue("@Password", EncodeDecode.EncodePasswordToBase64(login.Password));

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new AdminResponseModel();
                            responseData.AdminID = Convert.ToInt32(dataReader["AdminID"].ToString());
                            responseData.FirstName = dataReader["FirstName"].ToString();
                            responseData.LastName = dataReader["LastName"].ToString();
                            responseData.Email = dataReader["Email"].ToString();
                            responseData.ContactNumber = dataReader["ContactNumber"].ToString();
                            responseData.Verified = dataReader["Verified"].ToString();
                            responseData.CreatorStamp = dataReader["CreatorStamp"].ToString();
                            responseData.CreatorUser = dataReader["CreatorUser"].ToString();
                            responseData.CreatedDate = dataReader["CreatedDate"].ToString();
                            responseData.ModifiedDate = dataReader["ModifiedDate"].ToString();
                        }
                        conn.Close();
                    }
                }
                catch
                {
                    return null;
                }
                return responseData;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Checks Email
        /// </summary>
        /// <param name="forogotPassword">Forgot Password Data</param>
        /// <returns>If Data Found return ResponseData else null or Exception</returns>
        public AdminResponseModel ForgotPassword(ForgotPasswordRequest forogotPassword)
        {
            try
            {
                AdminResponseModel responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_VerifyEmail", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Email", forogotPassword.Email);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new AdminResponseModel();
                            responseData.AdminID = Convert.ToInt32(dataReader["AdminID"].ToString());
                            responseData.FirstName = dataReader["FirstName"].ToString();
                            responseData.LastName = dataReader["LastName"].ToString();
                            responseData.Email = dataReader["Email"].ToString();
                            responseData.ContactNumber = dataReader["ContactNumber"].ToString();
                            responseData.Verified = dataReader["Verified"].ToString();
                            responseData.CreatorStamp = dataReader["CreatorStamp"].ToString();
                            responseData.CreatorUser = dataReader["CreatorUser"].ToString();
                            responseData.CreatedDate = dataReader["CreatedDate"].ToString();
                            responseData.ModifiedDate = dataReader["ModifiedDate"].ToString();
                        }
                        conn.Close();
                    }
                    return responseData;
                }
                catch
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Changes the Admin Password in the Database
        /// </summary>
        /// <param name="resetPassword">Reset Password</param>
        /// <returns>If Password Changed it return true else false or Exception</returns>
        public bool ResetPassword(int adminID, ResetPasswordRequest resetPassword)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ResetPassword", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdminID", adminID);
                    cmd.Parameters.AddWithValue("@Password", resetPassword.Password);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        return true;
                    }
                    conn.Close();
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
