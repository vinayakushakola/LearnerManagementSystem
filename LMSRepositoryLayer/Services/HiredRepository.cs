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
    public class HiredRepository : IHiredRepository
    {
        private readonly IConfiguration _configuration;

        private readonly string sqlConnectionString;

        public HiredRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnectionString = _configuration.GetConnectionString("LMSDBConnection");
        }

        /// <summary>
        /// It Fetch Data from the Database
        /// </summary>
        /// <returns>If Retrieving Data Successfull return Data else return null or Exception</returns>
        public List<HiredRegistrationResponse> GetAllHired()
        {
            try
            {
                List<HiredRegistrationResponse> userList = null;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    userList = new List<HiredRegistrationResponse>();
                    SqlCommand cmd = new SqlCommand("SP_GetAllHired", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        HiredRegistrationResponse responseData = new HiredRegistrationResponse();
                        responseData.CandidateID = Convert.ToInt32(dataReader["ID"].ToString());
                        responseData.FirstName = dataReader["FirstName"].ToString();
                        responseData.MiddleName = dataReader["MiddleName"].ToString();
                        responseData.LastName = dataReader["LastName"].ToString();
                        responseData.Email = dataReader["Email"].ToString();
                        responseData.Degree = dataReader["Degree"].ToString();
                        responseData.MobileNumber = dataReader["MobileNumber"].ToString();
                        responseData.PermanentPincode = dataReader["PermanentPincode"].ToString();
                        responseData.HiredCity = dataReader["HiredCity"].ToString();
                        responseData.HiredDate = dataReader["HiredDate"].ToString();
                        responseData.HiredLab = dataReader["HiredLab"].ToString();
                        responseData.Attitude = dataReader["Attitude"].ToString();
                        responseData.CommunicationRemark = dataReader["CommunicationRemark"].ToString();
                        responseData.KnowledgeRemark = dataReader["KnowledgeRemark"].ToString();
                        responseData.AggregateRemark = dataReader["AggregateRemark"].ToString();
                        responseData.Status = dataReader["Status"].ToString();
                        responseData.CreatorStamp = dataReader["CreatorStamp"].ToString();
                        responseData.CreatorUser = dataReader["CreatorUser"].ToString();
                        responseData.CreatedDate = dataReader["CreatedDate"].ToString();
                        responseData.ModifiedDate = dataReader["ModifiedDate"].ToString();

                        userList.Add(responseData);
                    }
                    conn.Close();
                }
                return userList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Stores Data in the Database
        /// </summary>
        /// <param name="hiredRegistration">Hired Registration Data</param>
        /// <returns>If Storing Data Successfull it return ResponseData else null or Exception</returns>
        public HiredRegistrationResponse AddHired(HiredRegistrationRequest hiredRegistration)
        {
            try
            {
                HiredRegistrationResponse responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_HiredInsert", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@FirstName", hiredRegistration.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", hiredRegistration.MiddleName);
                        cmd.Parameters.AddWithValue("@LastName", hiredRegistration.LastName);
                        cmd.Parameters.AddWithValue("@Email", hiredRegistration.Email);
                        cmd.Parameters.AddWithValue("@Degree", hiredRegistration.Degree);
                        cmd.Parameters.AddWithValue("@MobileNumber", hiredRegistration.MobileNumber);
                        cmd.Parameters.AddWithValue("@PermanentPincode", hiredRegistration.PermanentPincode);

                        cmd.Parameters.AddWithValue("@CreatorStamp", hiredRegistration.CreatorStamp);
                        cmd.Parameters.AddWithValue("@CreatorUser", hiredRegistration.CreatorUser);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new HiredRegistrationResponse();
                            responseData.CandidateID = Convert.ToInt32(dataReader["ID"].ToString());
                            responseData.FirstName = dataReader["FirstName"].ToString();
                            responseData.MiddleName = dataReader["MiddleName"].ToString();
                            responseData.LastName = dataReader["LastName"].ToString();
                            responseData.Email = dataReader["Email"].ToString();
                            responseData.Degree = dataReader["Degree"].ToString();
                            responseData.MobileNumber = dataReader["MobileNumber"].ToString();
                            responseData.PermanentPincode = dataReader["PermanentPincode"].ToString();
                            responseData.HiredCity = dataReader["HiredCity"].ToString();
                            responseData.HiredDate = dataReader["HiredDate"].ToString();
                            responseData.HiredLab = dataReader["HiredLab"].ToString();
                            responseData.Attitude = dataReader["Attitude"].ToString();
                            responseData.CommunicationRemark = dataReader["CommunicationRemark"].ToString();
                            responseData.KnowledgeRemark = dataReader["KnowledgeRemark"].ToString();
                            responseData.AggregateRemark = dataReader["AggregateRemark"].ToString();
                            responseData.Status = dataReader["Status"].ToString();
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Updates a Specific User in the Database
        /// </summary>
        /// <param name="candidateID">CandidateID</param>
        /// <param name="hiredRegistrationUpdate">Hired Update Data</param>
        /// <returns>If Updating Data Successfull return ResponseData else return null or Exception</returns>
        public HiredRegistrationResponse UpdateHired(int candidateID, HiredUpdateRequest hiredRegistrationUpdate)
        {
            try
            {
                HiredRegistrationResponse responseData = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_HiredUpdate", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CandidateID", candidateID);
                    cmd.Parameters.AddWithValue("@HiredCity", hiredRegistrationUpdate.HiredCity);
                    cmd.Parameters.AddWithValue("@HiredDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@HiredLab", hiredRegistrationUpdate.HiredLab);
                    cmd.Parameters.AddWithValue("@Attitude", hiredRegistrationUpdate.Attitude);
                    cmd.Parameters.AddWithValue("@CommunicationRemark", hiredRegistrationUpdate.CommunicationRemark);
                    cmd.Parameters.AddWithValue("@KnowledgeRemark", hiredRegistrationUpdate.KnowledgeRemark);
                    cmd.Parameters.AddWithValue("@AggregateRemark", hiredRegistrationUpdate.AggregateRemark);
                    cmd.Parameters.AddWithValue("@Status", hiredRegistrationUpdate.Status);
                    cmd.Parameters.AddWithValue("@CreatorStamp", hiredRegistrationUpdate.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", hiredRegistrationUpdate.CreatorUser);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData = new HiredRegistrationResponse();
                        responseData.CandidateID = Convert.ToInt32(dataReader["ID"].ToString());
                        responseData.FirstName = dataReader["FirstName"].ToString();
                        responseData.MiddleName = dataReader["MiddleName"].ToString();
                        responseData.LastName = dataReader["LastName"].ToString();
                        responseData.Email = dataReader["Email"].ToString();
                        responseData.Degree = dataReader["Degree"].ToString();
                        responseData.MobileNumber = dataReader["MobileNumber"].ToString();
                        responseData.PermanentPincode = dataReader["PermanentPincode"].ToString();
                        responseData.HiredCity = dataReader["HiredCity"].ToString();
                        responseData.HiredDate = dataReader["HiredDate"].ToString();
                        responseData.HiredLab = dataReader["HiredLab"].ToString();
                        responseData.Attitude = dataReader["Attitude"].ToString();
                        responseData.CommunicationRemark = dataReader["CommunicationRemark"].ToString();
                        responseData.KnowledgeRemark = dataReader["KnowledgeRemark"].ToString();
                        responseData.AggregateRemark = dataReader["AggregateRemark"].ToString();
                        responseData.Status = dataReader["Status"].ToString();
                        responseData.CreatorStamp = dataReader["CreatorStamp"].ToString();
                        responseData.CreatorUser = dataReader["CreatorUser"].ToString();
                        responseData.CreatedDate = dataReader["CreatedDate"].ToString();
                        responseData.ModifiedDate = dataReader["ModifiedDate"].ToString();
                    }
                    conn.Close();
                }
                return responseData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
