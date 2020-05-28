﻿//
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
    public class FellowshipRepository : IFellowshipRepository
    {
        private readonly IConfiguration _configuration;

        private readonly string sqlConnectionString;

        public FellowshipRepository(IConfiguration configuration)
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
                    SqlCommand cmd = new SqlCommand("SP_GetAllHired", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        HiredResponseModel responseData = new HiredResponseModel();
                        responseData.CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString());
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
        public HiredResponseModel AddHired(HiredRegistrationRequest hiredRegistration)
        {
            try
            {
                HiredResponseModel responseData = null;
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
                            responseData = new HiredResponseModel();
                            responseData.CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString());
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
                        responseData = new HiredResponseModel();
                        responseData.CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString());
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
                        SqlCommand cmd = new SqlCommand("SP_FellowshipInsert", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
                            responseData = new FellowshipResponseModel();
                            responseData.CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString());
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
                            responseData.BirthDate = dataReader["BirthDate"].ToString();
                            responseData.IsBirthDateVerified = dataReader["IsBirthDateVerified"].ToString();
                            responseData.ParentName = dataReader["ParentName"].ToString();
                            responseData.ParentOccupation = dataReader["ParentOccupation"].ToString();
                            responseData.ParentsMobileNumber = dataReader["ParentsMobileNumber"].ToString();
                            responseData.ParentsAnnualSalary = dataReader["ParentsAnnualSalary"].ToString();
                            responseData.LocalAddress = dataReader["LocalAddress"].ToString();
                            responseData.PermanentAddress = dataReader["PermanentAddress"].ToString();
                            responseData.PhotoPath = dataReader["PhotoPath"].ToString();
                            responseData.JoiningDate = dataReader["JoiningDate"].ToString();
                            responseData.CandidateStatus = dataReader["CandidateStatus"].ToString();
                            responseData.PersonalInformation = dataReader["PersonalInformation"].ToString();
                            responseData.BankInformation = dataReader["BankInformation"].ToString();
                            responseData.EducationalInformation = dataReader["EducationalInformation"].ToString();
                            responseData.DocumentStatus = dataReader["DocumentStatus"].ToString();
                            responseData.Remark = dataReader["Remark"].ToString();
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<FellowshipResponseModel> GetAllFellowshipCandidates()
        {
            try
            {
                List<FellowshipResponseModel> fellowshipCandidates = null;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    fellowshipCandidates = new List<FellowshipResponseModel>();
                    SqlCommand cmd = new SqlCommand("SP_GetAllFellowshipCandidates", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        FellowshipResponseModel responseData = new FellowshipResponseModel();
                        responseData.CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString());
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
                        responseData.BirthDate = dataReader["BirthDate"].ToString();
                        responseData.IsBirthDateVerified = dataReader["IsBirthDateVerified"].ToString();
                        responseData.ParentName = dataReader["ParentName"].ToString();
                        responseData.ParentOccupation = dataReader["ParentOccupation"].ToString();
                        responseData.ParentsMobileNumber = dataReader["ParentsMobileNumber"].ToString();
                        responseData.ParentsAnnualSalary = dataReader["ParentsAnnualSalary"].ToString();
                        responseData.LocalAddress = dataReader["LocalAddress"].ToString();
                        responseData.PermanentAddress = dataReader["PermanentAddress"].ToString();
                        responseData.PhotoPath = dataReader["PhotoPath"].ToString();
                        responseData.JoiningDate = dataReader["JoiningDate"].ToString();
                        responseData.CandidateStatus = dataReader["CandidateStatus"].ToString();
                        responseData.PersonalInformation = dataReader["PersonalInformation"].ToString();
                        responseData.BankInformation = dataReader["BankInformation"].ToString();
                        responseData.EducationalInformation = dataReader["EducationalInformation"].ToString();
                        responseData.DocumentStatus = dataReader["DocumentStatus"].ToString();
                        responseData.Remark = dataReader["Remark"].ToString();
                        responseData.CreatorStamp = dataReader["CreatorStamp"].ToString();
                        responseData.CreatorUser = dataReader["CreatorUser"].ToString();
                        responseData.CreatedDate = dataReader["CreatedDate"].ToString();
                        responseData.ModifiedDate = dataReader["ModifiedDate"].ToString();

                        fellowshipCandidates.Add(responseData);
                    }
                    conn.Close();
                }
                return fellowshipCandidates;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Update Fellowship Candidate Details
        /// </summary>
        /// <param name="candidateID">Candidate ID</param>
        /// <param name="fellowshipUpdate">Update Fellowship Candidate</param>
        /// <returns>If Data Updated Successfully, It return ResponseData else null or Exception</returns>
        public FellowshipResponseModel UpdateSelectedFellowshipCandidate(int candidateID, FellowshipUpdateRequest fellowshipUpdate)
        {
            try
            {
                FellowshipResponseModel responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_FellowshipUpdate", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CandidateID", candidateID);
                        cmd.Parameters.AddWithValue("@BirthDate", fellowshipUpdate.BirthDate);
                        cmd.Parameters.AddWithValue("@IsBirthDateVerified", fellowshipUpdate.IsBirthDateVerified);
                        cmd.Parameters.AddWithValue("@ParentName", fellowshipUpdate.ParentName);
                        cmd.Parameters.AddWithValue("@ParentOccupation", fellowshipUpdate.ParentOccupation);
                        cmd.Parameters.AddWithValue("@ParentsMobileNumber", fellowshipUpdate.ParentsMobileNumber);
                        cmd.Parameters.AddWithValue("@ParentsAnnualSalary", fellowshipUpdate.ParentsAnnualSalary);
                        cmd.Parameters.AddWithValue("@LocalAddress", fellowshipUpdate.LocalAddress);
                        cmd.Parameters.AddWithValue("@PermanentAddress", fellowshipUpdate.PermanentAddress);
                        cmd.Parameters.AddWithValue("@PhotoPath", fellowshipUpdate.PhotoPath);
                        cmd.Parameters.AddWithValue("@JoiningDate", fellowshipUpdate.JoiningDate);
                        cmd.Parameters.AddWithValue("@CandidateStatus", fellowshipUpdate.CandidateStatus);
                        cmd.Parameters.AddWithValue("@PersonalInformation", fellowshipUpdate.PersonalInformation);
                        cmd.Parameters.AddWithValue("@BankInformation", fellowshipUpdate.BankInformation);
                        cmd.Parameters.AddWithValue("@EducationalInformation", fellowshipUpdate.EducationalInformation);
                        cmd.Parameters.AddWithValue("@DocumentStatus", fellowshipUpdate.DocumentStatus);
                        cmd.Parameters.AddWithValue("@Remark", fellowshipUpdate.Remark);
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new FellowshipResponseModel();
                            responseData.CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString());
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
                            responseData.BirthDate = dataReader["BirthDate"].ToString();
                            responseData.IsBirthDateVerified = dataReader["IsBirthDateVerified"].ToString();
                            responseData.ParentName = dataReader["ParentName"].ToString();
                            responseData.ParentOccupation = dataReader["ParentOccupation"].ToString();
                            responseData.ParentsMobileNumber = dataReader["ParentsMobileNumber"].ToString();
                            responseData.ParentsAnnualSalary = dataReader["ParentsAnnualSalary"].ToString();
                            responseData.LocalAddress = dataReader["LocalAddress"].ToString();
                            responseData.PermanentAddress = dataReader["PermanentAddress"].ToString();
                            responseData.PhotoPath = dataReader["PhotoPath"].ToString();
                            responseData.JoiningDate = dataReader["JoiningDate"].ToString();
                            responseData.CandidateStatus = dataReader["CandidateStatus"].ToString();
                            responseData.PersonalInformation = dataReader["PersonalInformation"].ToString();
                            responseData.BankInformation = dataReader["BankInformation"].ToString();
                            responseData.EducationalInformation = dataReader["EducationalInformation"].ToString();
                            responseData.DocumentStatus = dataReader["DocumentStatus"].ToString();
                            responseData.Remark = dataReader["Remark"].ToString();
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Adds Candidate Bank Details in the database
        /// </summary>
        /// <param name="candidateID">CandidateID</param>
        /// <param name="bankDetail">Bank Details</param>
        /// <returns>If Data Added Successfully return ResponseData else null or Exception</returns>
        public CandidateBankDetailResponse AddCandidateBankDetails(int candidateID, CandidateBankDetailRequest bankDetail)
        {
            try
            {
                CandidateBankDetailResponse responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_AddCandidateBankDetails", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CandidateID", candidateID);
                        cmd.Parameters.AddWithValue("@Name", bankDetail.Name);
                        cmd.Parameters.AddWithValue("@AccountNumber", bankDetail.AccountNumber);
                        cmd.Parameters.AddWithValue("@IsAccountNumberVerified", bankDetail.IsAccountNumberVerified);
                        cmd.Parameters.AddWithValue("@IfscCode", bankDetail.IfscCode);
                        cmd.Parameters.AddWithValue("@IsIfscCodeVerified", bankDetail.IsIfscCodeVerified);
                        cmd.Parameters.AddWithValue("@PanNumber", bankDetail.PanNumber);
                        cmd.Parameters.AddWithValue("@IsPanNumberVerified", bankDetail.IsPanNumberVerified);
                        cmd.Parameters.AddWithValue("@AdhaarNumber", bankDetail.AdhaarNumber);
                        cmd.Parameters.AddWithValue("@IsAdhaarNumberVerified", bankDetail.IsAdhaarNumberVerified);
                        cmd.Parameters.AddWithValue("@CreatorStamp", bankDetail.CreatorStamp);
                        cmd.Parameters.AddWithValue("@CreatorUser", bankDetail.CreatorUser);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new CandidateBankDetailResponse();
                            responseData.ID = Convert.ToInt32(dataReader["ID"].ToString());
                            responseData.CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString());
                            responseData.Name = dataReader["Name"].ToString();
                            responseData.AccountNumber = dataReader["AccountNumber"].ToString();
                            responseData.IsAccountNumberVerified= dataReader["IsAccountNumberVerified"].ToString();
                            responseData.IfscCode = dataReader["IfscCode"].ToString();
                            responseData.IsIfscCodeVerified = dataReader["IsIfscCodeVerified"].ToString();
                            responseData.PanNumber = dataReader["PanNumber"].ToString();
                            responseData.IsPanNumberVerified = dataReader["IsPanNumberVerified"].ToString();
                            responseData.AdhaarNumber = dataReader["AdhaarNumber"].ToString();
                            responseData.IsAdhaarNumberVerified = dataReader["IsAdhaarNumberVerified"].ToString();
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
