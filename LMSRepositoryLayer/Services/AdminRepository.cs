﻿//
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
using System.Data;
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
        public List<AdminResponseModel> GetAllAdmins()
        {
            try
            {
                List<AdminResponseModel> adminList = null;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    adminList = new List<AdminResponseModel>();
                    SqlCommand cmd = new SqlCommand("spGetAllAdminAccounts", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure                    
                    };
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        AdminResponseModel adminData = new AdminResponseModel
                        {
                            AdminID = Convert.ToInt32(dataReader["AdminID"].ToString()),
                            FirstName = dataReader["FirstName"].ToString(),
                            LastName = dataReader["LastName"].ToString(),
                            Email = dataReader["Email"].ToString(),
                            ContactNumber = dataReader["ContactNumber"].ToString(),
                            IsVerified = Convert.ToBoolean(dataReader["IsVerified"]),
                            CreatorStamp = dataReader["CreatorStamp"].ToString(),
                            CreatorUser = dataReader["CreatorUser"].ToString(),
                            CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]),
                            ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"])
                        };   
                        adminList.Add(adminData);
                    }
                    conn.Close();
                }
                return adminList;
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
        public AdminResponseModel Registration(RegistrationRequest registrationRequest)
        {
            try
            {
                AdminResponseModel responseData = null;
                
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddAdminAccount", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@FirstName", registrationRequest.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", registrationRequest.LastName);
                    cmd.Parameters.AddWithValue("@Email", registrationRequest.Email);
                    cmd.Parameters.AddWithValue("@Password", EncodeDecode.EncodePasswordToBase64(registrationRequest.Password));
                    cmd.Parameters.AddWithValue("@ContactNumber", registrationRequest.ContactNumber);
                    cmd.Parameters.AddWithValue("@IsVerified", registrationRequest.IsVerified);
                    cmd.Parameters.AddWithValue("@CreatorStamp", registrationRequest.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", registrationRequest.CreatorUser);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData = new AdminResponseModel
                        {
                            AdminID = Convert.ToInt32(dataReader["AdminID"].ToString()),
                            FirstName = dataReader["FirstName"].ToString(),
                            LastName = dataReader["LastName"].ToString(),
                            Email = dataReader["Email"].ToString(),
                            ContactNumber = dataReader["ContactNumber"].ToString(),
                            IsVerified = Convert.ToBoolean(dataReader["IsVerified"]),
                            CreatorStamp = dataReader["CreatorStamp"].ToString(),
                            CreatorUser = dataReader["CreatorUser"].ToString(),
                            CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]),
                            ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"])
                        };
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
        /// It Updates a Specific Admin Data in the Database
        /// </summary>
        /// <param name="adminID">AdminID</param>
        /// <param name="updateRequest">Update Data</param>
        /// <returns>If Updating Data Successfull return ResponseData else return null or Exception</returns>
        public AdminResponseModel UpdateAdmin(int adminID, AdminUpdateRequest updateRequest)
        {
            try
            {
                AdminResponseModel responseData = new AdminResponseModel();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateAdminAccount", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@AdminID", adminID);
                    cmd.Parameters.AddWithValue("@FirstName", updateRequest.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", updateRequest.LastName);
                    cmd.Parameters.AddWithValue("@ContactNumber", updateRequest.ContactNumber);
                    cmd.Parameters.AddWithValue("@IsVerified", updateRequest.IsVerified);
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
                        responseData.IsVerified = Convert.ToBoolean(dataReader["IsVerified"]);
                        responseData.CreatorStamp = dataReader["CreatorStamp"].ToString();
                        responseData.CreatorUser = dataReader["CreatorUser"].ToString();
                        responseData.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);
                        responseData.ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"]);
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
        public bool DeleteAdmin(int adminID)
        {
            try
            {
                if (adminID > 0)
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteAdminAccount", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure,
                        };
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
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spValidateAdminLogin", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    SqlParameter parm = new SqlParameter("@Status", SqlDbType.Int);
                    parm.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parm);
                    cmd.Parameters.AddWithValue("@Email", login.Email);
                    cmd.Parameters.AddWithValue("@Password", EncodeDecode.EncodePasswordToBase64(login.Password));
             
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    var status = Convert.ToInt32(parm.Value);
                    if (status > 0)
                    {
                        SqlDataReader dataReader = cmd.ExecuteReader();

                        while (dataReader.Read())
                        {
                            responseData = new AdminResponseModel()
                            {
                                AdminID = Convert.ToInt32(dataReader["AdminID"]),
                                FirstName = dataReader["FirstName"].ToString(),
                                LastName = dataReader["LastName"].ToString(),
                                Email = dataReader["Email"].ToString(),
                                ContactNumber = dataReader["ContactNumber"].ToString(),
                                IsVerified = Convert.ToBoolean(dataReader["IsVerified"]),
                                CreatorStamp = dataReader["CreatorStamp"].ToString(),
                                CreatorUser = dataReader["CreatorUser"].ToString(),
                                CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]),
                                ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"])
                            };
                        }
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
                        SqlCommand cmd = new SqlCommand("spCheckEmailExists", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

                        cmd.Parameters.AddWithValue("@Email", forogotPassword.Email);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new AdminResponseModel()
                            {
                                AdminID = Convert.ToInt32(dataReader["AdminID"].ToString()),
                                FirstName = dataReader["FirstName"].ToString(),
                                LastName = dataReader["LastName"].ToString(),
                                Email = dataReader["Email"].ToString(),
                                ContactNumber = dataReader["ContactNumber"].ToString(),
                                IsVerified = Convert.ToBoolean(dataReader["IsVerified"]),
                                CreatorStamp = dataReader["CreatorStamp"].ToString(),
                                CreatorUser = dataReader["CreatorUser"].ToString(),
                                CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]),
                                ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"])
                            };
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
                    SqlCommand cmd = new SqlCommand("spResetAdminPassword", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
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
