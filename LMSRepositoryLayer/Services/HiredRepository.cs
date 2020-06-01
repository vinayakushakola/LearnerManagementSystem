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
        /// It Fetch All Candidates Data from the Database
        /// </summary>
        /// <returns>If Retrieving Data Successfull return Candidates Data else return null or Exception</returns>
        public List<HiredResponseModel> GetAllCandidates()
        {
            try
            {
                List<HiredResponseModel> userList = null;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    userList = new List<HiredResponseModel>();
                    SqlCommand cmd = new SqlCommand("SP_GetAllHired", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        HiredResponseModel responseData = new HiredResponseModel()
                        {
                            CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString()),
                            FirstName = dataReader["FirstName"].ToString(),
                            MiddleName = dataReader["MiddleName"].ToString(),
                            LastName = dataReader["LastName"].ToString(),
                            Email = dataReader["Email"].ToString(),
                            Degree = dataReader["Degree"].ToString(),
                            MobileNumber = dataReader["MobileNumber"].ToString(),
                            PermanentPincode = dataReader["PermanentPincode"].ToString(),
                            HiredCity = dataReader["HiredCity"].ToString(),
                            HiredDate = dataReader["HiredDate"].ToString(),
                            HiredLab = dataReader["HiredLab"].ToString(),
                            Attitude = dataReader["Attitude"].ToString(),
                            CommunicationRemark = dataReader["CommunicationRemark"].ToString(),
                            KnowledgeRemark = dataReader["KnowledgeRemark"].ToString(),
                            AggregateRemark = dataReader["AggregateRemark"].ToString(),
                            Status = dataReader["Status"].ToString(),
                            CreatorStamp = dataReader["CreatorStamp"].ToString(),
                            CreatorUser = dataReader["CreatorUser"].ToString(),
                            CreatedDate = dataReader["CreatedDate"].ToString(),
                            ModifiedDate = dataReader["ModifiedDate"].ToString()
                        };

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
        public HiredResponseModel AddHired(HiredRegistrationRequest hiredRegistration)
        {
            try
            {
                HiredResponseModel responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_HiredInsert", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };
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
                            responseData = new HiredResponseModel()
                            {
                                CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString()),
                                FirstName = dataReader["FirstName"].ToString(),
                                MiddleName = dataReader["MiddleName"].ToString(),
                                LastName = dataReader["LastName"].ToString(),
                                Email = dataReader["Email"].ToString(),
                                Degree = dataReader["Degree"].ToString(),
                                MobileNumber = dataReader["MobileNumber"].ToString(),
                                PermanentPincode = dataReader["PermanentPincode"].ToString(),
                                HiredCity = dataReader["HiredCity"].ToString(),
                                HiredDate = dataReader["HiredDate"].ToString(),
                                HiredLab = dataReader["HiredLab"].ToString(),
                                Attitude = dataReader["Attitude"].ToString(),
                                CommunicationRemark = dataReader["CommunicationRemark"].ToString(),
                                KnowledgeRemark = dataReader["KnowledgeRemark"].ToString(),
                                AggregateRemark = dataReader["AggregateRemark"].ToString(),
                                Status = dataReader["Status"].ToString(),
                                CreatorStamp = dataReader["CreatorStamp"].ToString(),
                                CreatorUser = dataReader["CreatorUser"].ToString(),
                                CreatedDate = dataReader["CreatedDate"].ToString(),
                                ModifiedDate = dataReader["ModifiedDate"].ToString()
                            };
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
        /// It Updates Data in the Database
        /// </summary>
        /// <param name="candidateID">CandidateID</param>
        /// <param name="hiredRegistrationUpdate">Hired Update Data</param>
        /// <returns>If Updating Data Successfull return ResponseData else return null or Exception</returns>
        public HiredResponseModel UpdateHired(int candidateID, HiredUpdateRequest hiredRegistrationUpdate)
        {
            try
            {
                HiredResponseModel responseData = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_HiredUpdate", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
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
                        responseData = new HiredResponseModel
                        {
                            CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString()),
                            FirstName = dataReader["FirstName"].ToString(),
                            MiddleName = dataReader["MiddleName"].ToString(),
                            LastName = dataReader["LastName"].ToString(),
                            Email = dataReader["Email"].ToString(),
                            Degree = dataReader["Degree"].ToString(),
                            MobileNumber = dataReader["MobileNumber"].ToString(),
                            PermanentPincode = dataReader["PermanentPincode"].ToString(),
                            HiredCity = dataReader["HiredCity"].ToString(),
                            HiredDate = dataReader["HiredDate"].ToString(),
                            HiredLab = dataReader["HiredLab"].ToString(),
                            Attitude = dataReader["Attitude"].ToString(),
                            CommunicationRemark = dataReader["CommunicationRemark"].ToString(),
                            KnowledgeRemark = dataReader["KnowledgeRemark"].ToString(),
                            AggregateRemark = dataReader["AggregateRemark"].ToString(),
                            Status = dataReader["Status"].ToString(),
                            CreatorStamp = dataReader["CreatorStamp"].ToString(),
                            CreatorUser = dataReader["CreatorUser"].ToString(),
                            CreatedDate = dataReader["CreatedDate"].ToString(),
                            ModifiedDate = dataReader["ModifiedDate"].ToString()
                        };
                    }
                    conn.Close();
                }
                if (responseData.Status.ToLower() == "accepted")
                {
                    var isAddedToFellowship = AddSelectedFellowshipCandidate(responseData);
                    if (isAddedToFellowship != null)
                    {
                        responseData.FellowshipResponseModel = isAddedToFellowship;
                    }
                    else
                    {
                        responseData.FellowshipResponseModel = null;
                    }
                }
                return responseData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It is used to Add Selected Candidate into the Database
        /// </summary>
        /// <param name="acceptedCandidate"></param>
        /// <returns>If Data Adding Successfull it return ResponseData else null or Exception</returns>
        public FellowshipResponseModel AddSelectedFellowshipCandidate(HiredResponseModel acceptedCandidate)
        {
            try
            {
                FellowshipResponseModel responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_FellowshipInsert", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

                        cmd.Parameters.AddWithValue("@FirstName", acceptedCandidate.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", acceptedCandidate.MiddleName);
                        cmd.Parameters.AddWithValue("@LastName", acceptedCandidate.LastName);
                        cmd.Parameters.AddWithValue("@Email", acceptedCandidate.Email);
                        cmd.Parameters.AddWithValue("@Degree", acceptedCandidate.Degree);
                        cmd.Parameters.AddWithValue("@MobileNumber", acceptedCandidate.MobileNumber);
                        cmd.Parameters.AddWithValue("@PermanentPincode", acceptedCandidate.PermanentPincode);
                        cmd.Parameters.AddWithValue("@HiredCity", acceptedCandidate.HiredCity);
                        cmd.Parameters.AddWithValue("@HiredDate", acceptedCandidate.HiredDate);
                        cmd.Parameters.AddWithValue("@HiredLab", acceptedCandidate.HiredLab);
                        cmd.Parameters.AddWithValue("@Attitude", acceptedCandidate.Attitude);
                        cmd.Parameters.AddWithValue("@CommunicationRemark", acceptedCandidate.CommunicationRemark);
                        cmd.Parameters.AddWithValue("@KnowledgeRemark", acceptedCandidate.KnowledgeRemark);
                        cmd.Parameters.AddWithValue("@AggregateRemark", acceptedCandidate.AggregateRemark);
                        cmd.Parameters.AddWithValue("@Status", acceptedCandidate.Status);
                        cmd.Parameters.AddWithValue("@CreatorStamp", acceptedCandidate.CreatorStamp);
                        cmd.Parameters.AddWithValue("@CreatorUser", acceptedCandidate.CreatorUser);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new FellowshipResponseModel()
                            {
                                CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString()),
                                FirstName = dataReader["FirstName"].ToString(),
                                MiddleName = dataReader["MiddleName"].ToString(),
                                LastName = dataReader["LastName"].ToString(),
                                Email = dataReader["Email"].ToString(),
                                Degree = dataReader["Degree"].ToString(),
                                MobileNumber = dataReader["MobileNumber"].ToString(),
                                PermanentPincode = dataReader["PermanentPincode"].ToString(),
                                HiredCity = dataReader["HiredCity"].ToString(),
                                HiredDate = dataReader["HiredDate"].ToString(),
                                HiredLab = dataReader["HiredLab"].ToString(),
                                Attitude = dataReader["Attitude"].ToString(),
                                CommunicationRemark = dataReader["CommunicationRemark"].ToString(),
                                KnowledgeRemark = dataReader["KnowledgeRemark"].ToString(),
                                AggregateRemark = dataReader["AggregateRemark"].ToString(),
                                Status = dataReader["Status"].ToString(),
                                BirthDate = dataReader["BirthDate"].ToString(),
                                IsBirthDateVerified = dataReader["IsBirthDateVerified"].ToString(),
                                ParentName = dataReader["ParentName"].ToString(),
                                ParentOccupation = dataReader["ParentOccupation"].ToString(),
                                ParentsMobileNumber = dataReader["ParentsMobileNumber"].ToString(),
                                ParentsAnnualSalary = dataReader["ParentsAnnualSalary"].ToString(),
                                LocalAddress = dataReader["LocalAddress"].ToString(),
                                PermanentAddress = dataReader["PermanentAddress"].ToString(),
                                PhotoPath = dataReader["PhotoPath"].ToString(),
                                JoiningDate = dataReader["JoiningDate"].ToString(),
                                CandidateStatus = dataReader["CandidateStatus"].ToString(),
                                PersonalInformation = dataReader["PersonalInformation"].ToString(),
                                BankInformation = dataReader["BankInformation"].ToString(),
                                EducationalInformation = dataReader["EducationalInformation"].ToString(),
                                DocumentStatus = dataReader["DocumentStatus"].ToString(),
                                Remark = dataReader["Remark"].ToString(),
                                CreatorStamp = dataReader["CreatorStamp"].ToString(),
                                CreatorUser = dataReader["CreatorUser"].ToString(),
                                CreatedDate = dataReader["CreatedDate"].ToString(),
                                ModifiedDate = dataReader["ModifiedDate"].ToString()
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
