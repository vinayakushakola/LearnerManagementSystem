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
                    SqlCommand cmd = new SqlCommand("spGetAllFellowshipCandidates", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        FellowshipResponseModel responseData = new FellowshipResponseModel()
                        {
                            CandidateID = Convert.ToInt32(dataReader["CandidateID"]),
                            FirstName = dataReader["FirstName"].ToString(),
                            MiddleName = dataReader["MiddleName"].ToString(),
                            LastName = dataReader["LastName"].ToString(),
                            Email = dataReader["Email"].ToString(),
                            Degree = dataReader["Degree"].ToString(),
                            MobileNumber = dataReader["MobileNumber"].ToString(),
                            PermanentPincode = dataReader["PermanentPincode"].ToString(),
                            HiredCity = dataReader["HiredCity"].ToString(),
                            HiredDate = Convert.ToDateTime(dataReader["HiredDate"]),
                            HiredLab = dataReader["HiredLab"].ToString(),
                            Attitude = dataReader["Attitude"].ToString(),
                            CommunicationRemark = dataReader["CommunicationRemark"].ToString(),
                            KnowledgeRemark = dataReader["KnowledgeRemark"].ToString(),
                            AggregateRemark = dataReader["AggregateRemark"].ToString(),
                            Status = dataReader["Status"].ToString(),
                            CreatorStamp = dataReader["CreatorStamp"].ToString(),
                            CreatorUser = dataReader["CreatorUser"].ToString(),
                            BirthDate = dataReader["BirthDate"].ToString(),
                            IsBirthDateVerified = Convert.ToBoolean(dataReader["IsBirthDateVerified"]),
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
                            CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]),
                            ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"])
                        };
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
                        SqlCommand cmd = new SqlCommand("spUpdateFellowshipCandidate", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };
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
                                HiredDate = Convert.ToDateTime(dataReader["HiredDate"]),
                                HiredLab = dataReader["HiredLab"].ToString(),
                                Attitude = dataReader["Attitude"].ToString(),
                                CommunicationRemark = dataReader["CommunicationRemark"].ToString(),
                                KnowledgeRemark = dataReader["KnowledgeRemark"].ToString(),
                                AggregateRemark = dataReader["AggregateRemark"].ToString(),
                                Status = dataReader["Status"].ToString(),
                                BirthDate = dataReader["BirthDate"].ToString(),
                                IsBirthDateVerified = Convert.ToBoolean(dataReader["IsBirthDateVerified"]),
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
                        SqlCommand cmd = new SqlCommand("spAddCandidateBankDetails", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };
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
                            responseData = new CandidateBankDetailResponse()
                            {
                                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                                CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString()),
                                Name = dataReader["Name"].ToString(),
                                AccountNumber = dataReader["AccountNumber"].ToString(),
                                IsAccountNumberVerified = Convert.ToBoolean(dataReader["IsAccountNumberVerified"]),
                                IfscCode = dataReader["IfscCode"].ToString(),
                                IsIfscCodeVerified = Convert.ToBoolean(dataReader["IsIfscCodeVerified"]),
                                PanNumber = dataReader["PanNumber"].ToString(),
                                IsPanNumberVerified = Convert.ToBoolean(dataReader["IsPanNumberVerified"]),
                                AdhaarNumber = dataReader["AdhaarNumber"].ToString(),
                                IsAdhaarNumberVerified = Convert.ToBoolean(dataReader["IsAdhaarNumberVerified"]),
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
                        SqlCommand cmd = new SqlCommand("spAddCandidateQualification", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

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
                            responseData = new CandidateQualificationResponse
                            {
                                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                                CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString()),
                                Diploma = dataReader["Diploma"].ToString(),
                                DegreeName = dataReader["DegreeName"].ToString(),
                                IsDegreeNameVerified = Convert.ToBoolean(dataReader["IsDegreeNameVerified"]),
                                EmployeeDiscipline = dataReader["EmployeeDiscipline"].ToString(),
                                IsEmployeeDisciplined = Convert.ToBoolean(dataReader["IsEmployeeDisciplined"]),
                                PassingYear = dataReader["PassingYear"].ToString(),
                                IsPassingYearVerified = Convert.ToBoolean(dataReader["IsPassingYearVerified"]),
                                AggregatePer = dataReader["AggregatePer"].ToString(),
                                IsAggregatePerVerified = Convert.ToBoolean(dataReader["IsAggregatePerVerified"]),
                                FinalYearPer = dataReader["FinalYearPer"].ToString(),
                                IsFinalYearPerVerified = Convert.ToBoolean(dataReader["IsFinalYearPerVerified"]),
                                TrainingInstitute = dataReader["TrainingInstitute"].ToString(),
                                IsTrainingInstituteVerified = Convert.ToBoolean(dataReader["IsTrainingInstituteVerified"]),
                                TrainingDurationMon = dataReader["TrainingDurationMon"].ToString(),
                                IsTrainingDurationMonVerified = Convert.ToBoolean(dataReader["IsTrainingDurationMonVerified"]),
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
                        SqlCommand cmd = new SqlCommand("spAddCandidateDocuments", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

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
                            responseData = new CandidateDocumentsResponse()
                            {
                                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                                CandidateID = Convert.ToInt32(dataReader["CandidateID"].ToString()),
                                DocType = dataReader["DocType"].ToString(),
                                DocPath = dataReader["DocPath"].ToString(),
                                Status = dataReader["Status"].ToString(),
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
                    SqlCommand cmd = new SqlCommand("spAddCandidateTechStackAssignment", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
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
                            CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]),
                            ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"])
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
