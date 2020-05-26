//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using LMSCommonLayer.RequestModels;
using LMSCommonLayer.ResponseModels;
using LMSRepositoryLayer.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LMSRepositoryLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        private static int count;

        private readonly string sqlConnectionString;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnectionString = _configuration.GetConnectionString("LMSDBConnection");
        }

        /// <summary>
        /// It Fetch Data from the Database
        /// </summary>
        /// <returns>If Retrieving Data Successfull return Data else return null or Exception</returns>
        public List<RegistrationResponse> GetAllUsers()
        {
            try
            {
                List<RegistrationResponse> userList = null;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    userList = new List<RegistrationResponse>();
                    SqlCommand cmd = new SqlCommand("SP_GetAllUsers", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        RegistrationResponse user = new RegistrationResponse();
                        user.UserID = Convert.ToInt32(dataReader["UserID"].ToString());
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
        public RegistrationResponse AddUser(RegistrationRequest registrationRequest)
        {
            try
            {
                RegistrationResponse responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_InsertUser", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@FirstName", registrationRequest.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", registrationRequest.LastName);
                        cmd.Parameters.AddWithValue("@Email", registrationRequest.Email);
                        cmd.Parameters.AddWithValue("@Password", registrationRequest.Password);
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
                            responseData = new RegistrationResponse();
                            responseData.UserID = Convert.ToInt32(dataReader["UserID"].ToString());
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
        /// It Updates a Specific User in the Database
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <param name="updateRequest">Update Data</param>
        /// <returns>If Updating Data Successfull return ResponseData else return null or Exception</returns>
        public RegistrationResponse UpdateUser(int userID, UserUpdateRequest updateRequest)
        {
            try
            {
                RegistrationResponse responseData = new RegistrationResponse();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateUser", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Email", updateRequest.Email);
                    cmd.Parameters.AddWithValue("@Password", updateRequest.Password);
                    cmd.Parameters.AddWithValue("@ContactNumber", updateRequest.ContactNumber);
                    cmd.Parameters.AddWithValue("@Verified", updateRequest.Verified);
                    cmd.Parameters.AddWithValue("@CreatorStamp", updateRequest.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", updateRequest.CreatorUser);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData.UserID = Convert.ToInt32(dataReader["UserID"].ToString());
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
        /// It Deletes data from the Database
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <returns>If Deleting Data Successfull return true else false or Exception</returns>
        public bool DeleteUser(int userID)
        {
            try
            {
                if (userID > 0)
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_DeleteUser", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserID", userID);

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
        /// It checks login Email & Password
        /// </summary>
        /// <param name="login">Login Data</param>
        /// <returns>If Data Found return ResponseData else null or BadRequest</returns>
        public RegistrationResponse Login(LoginRequest login)
        {
            try
            {
                RegistrationResponse responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_LoginValidation", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Email", login.Email);
                        cmd.Parameters.AddWithValue("@Password", login.Password);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new RegistrationResponse();
                            responseData.UserID = Convert.ToInt32(dataReader["UserID"].ToString());
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

        public RegistrationResponse ForgotPassword(ForgotPasswordRequest forogotPassword)
        {
            try
            {
                RegistrationResponse responseData = null;
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
                            responseData = new RegistrationResponse();
                            responseData.UserID = Convert.ToInt32(dataReader["UserID"].ToString());
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

    }
}
