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
        /// It Fetch All the Fellowship Candidates from the Database
        /// </summary>
        /// <returns>If Data Fetech Successfully return ResponseData else null or BadRequest</returns>
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

        /// <summary>
        /// It Stores Candidate Qualification Details in the Database
        /// </summary>
        /// <param name="candidateID">CandidateID</param>
        /// <param name="qualification">Candidate Qualification Data</param>
        /// <returns>If Data Added Successfully return ResponseData else null or Exception</returns>
        public CandidateQualificationResponse AddCandidateQualification(int candidateID, CandidateQualificationRequest qualification)
        {
            try
            {
                CandidateQualificationResponse responseData = null;
                try
                {
                    using(SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_AddCandidateQualification", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CandidateID", candidateID);
                        cmd.Parameters.AddWithValue("@Diploma", qualification.Diploma);
                        cmd.Parameters.AddWithValue("@DegreeName", qualification.DegreeName);
                        cmd.Parameters.AddWithValue("@IsDegreeNameVerified", qualification.IsDegreeNameVerified);
                        cmd.Parameters.AddWithValue("@EmployeeDiscipline", qualification.EmployeeDiscipline);
                        cmd.Parameters.AddWithValue("@IsEmployeeDisciplined", qualification.IsEmployeeDisciplined);
                        cmd.Parameters.AddWithValue("@PassingYear", qualification.PassingYear);
                        cmd.Parameters.AddWithValue("@IsPassingYearVerified", qualification.IsPassingYearVerified);
                        cmd.Parameters.AddWithValue("@AggregatePer", qualification.AggregatePer);
                        cmd.Parameters.AddWithValue("@IsAggregatePerVerified", qualification.IsAggregatePerVerified);
                        cmd.Parameters.AddWithValue("@FinalYearPer", qualification.FinalYearPer);
                        cmd.Parameters.AddWithValue("@IsFinalYearPerVerified", qualification.IsFinalYearPerVerified);
                        cmd.Parameters.AddWithValue("@TrainingInstitute", qualification.TrainingInstitute);
                        cmd.Parameters.AddWithValue("@IsTrainingInstituteVerified", qualification.IsTrainingInstituteVerified);
                        cmd.Parameters.AddWithValue("@TrainingDurationMon", qualification.TrainingDurationMon);
                        cmd.Parameters.AddWithValue("@IsTrainingDurationMonVerified", qualification.IsTrainingDurationMonVerified);
                        cmd.Parameters.AddWithValue("@OtherTraining", qualification.OtherTraining);
                        cmd.Parameters.AddWithValue("@IsOtherTrainingVerified", qualification.IsOtherTrainingVerified);
                        cmd.Parameters.AddWithValue("@CreatorStamp", qualification.CreatorStamp);
                        cmd.Parameters.AddWithValue("@CreatorUser", qualification.CreatorUser);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new CandidateQualificationResponse();
                            responseData.ID = Convert.ToInt32(dataReader["ID"].ToString());
                            responseData.CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString());
                            responseData.Diploma = dataReader["Diploma"].ToString();
                            responseData.DegreeName = dataReader["DegreeName"].ToString();
                            responseData.IsDegreeNameVerified = dataReader["IsDegreeNameVerified"].ToString();
                            responseData.EmployeeDiscipline = dataReader["EmployeeDiscipline"].ToString();
                            responseData.IsEmployeeDisciplined = dataReader["IsEmployeeDisciplined"].ToString();
                            responseData.PassingYear = dataReader["PassingYear"].ToString();
                            responseData.IsPassingYearVerified= dataReader["IsPassingYearVerified"].ToString();
                            responseData.AggregatePer = dataReader["AggregatePer"].ToString();
                            responseData.IsAggregatePerVerified = dataReader["IsAggregatePerVerified"].ToString();
                            responseData.FinalYearPer = dataReader["FinalYearPer"].ToString();
                            responseData.IsFinalYearPerVerified = dataReader["IsFinalYearPerVerified"].ToString();
                            responseData.TrainingInstitute = dataReader["TrainingInstitute"].ToString();
                            responseData.IsTrainingInstituteVerified = dataReader["IsTrainingInstituteVerified"].ToString();
                            responseData.TrainingDurationMon = dataReader["TrainingDurationMon"].ToString();
                            responseData.IsTrainingDurationMonVerified = dataReader["IsTrainingDurationMonVerified"].ToString();
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
        /// It Stores Candidate Documents into the Database
        /// </summary>
        /// <param name="candidateID">CandidateID</param>
        /// <param name="documents">Candidate Documents</param>
        /// <returns>If Data Added Successully return ResponseData else null or BadRequest</returns>
        public CandidateDocumentsResponse AddCanndidateDocuments(int candidateID, CandidateDocumentsRequest documents)
        {
            try
            {
                CandidateDocumentsResponse responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_AddCandidateDocuments", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CandidateID", candidateID);
                        cmd.Parameters.AddWithValue("@DocType", documents.DocType);
                        cmd.Parameters.AddWithValue("@DocPath", documents.DocPath);
                        cmd.Parameters.AddWithValue("@Status", documents.Status);
                        cmd.Parameters.AddWithValue("@CreatorStamp", documents.CreatorStamp);
                        cmd.Parameters.AddWithValue("@CreatorUser", documents.CreatorUser);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new CandidateDocumentsResponse();
                            responseData.ID = Convert.ToInt32(dataReader["ID"].ToString());
                            responseData.CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString());
                            responseData.DocType = dataReader["DocType"].ToString();
                            responseData.DocPath = dataReader["DocPath"].ToString();
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
        /// It is used to Add Candidate tech Stack in the Database
        /// </summary>
        /// <param name="candidateTech"></param>
        /// <returns>If Data Added Successfully return ResponseData else null or Exception</returns>
        public CandidateTechStackAssignResponse AddCandidateTechStackAssign(CandidateTechStackAssignRequest candidateTech)
        {
            try
            {
                CandidateTechStackAssignResponse responseData = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_CandidateTechStackAssignment", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RequirementID", candidateTech.RequirementID);
                    cmd.Parameters.AddWithValue("@CandidateID", candidateTech.CandidateID);
                    cmd.Parameters.AddWithValue("@AssignDate", candidateTech.AssignDate);
                    cmd.Parameters.AddWithValue("@Status", candidateTech.Status);
                    cmd.Parameters.AddWithValue("@CreatorStamp", candidateTech.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", candidateTech.CreatorUser);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData = new CandidateTechStackAssignResponse()
                        {
                            ID = Convert.ToInt32(dataReader["ID"]),
                            RequirementID = Convert.ToInt32(dataReader["RequirementID"]),
                            CandidateID = Convert.ToInt32(dataReader["CandidateID"]),
                            AssignDate = dataReader["AssignDate"].ToString(),
                            Status = dataReader["Status"].ToString(),
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
