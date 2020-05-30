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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IConfiguration _configuration;

        private readonly string sqlConnectionString;

        public CompanyRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnectionString = _configuration.GetConnectionString("LMSDBConnection");
        }

        /// <summary>
        /// It Fetch All Comapnies Data
        /// </summary>
        /// <returns>If Data Found return ResponseData else null or Exception</returns>
        public List<CompanyAddResponse> GetAllCompanies()
        {
            try
            {
                List<CompanyAddResponse> companiesList = null;

                using(SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    companiesList = new List<CompanyAddResponse>();
                    SqlCommand cmd = new SqlCommand("SP_GetAllCompanies", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        CompanyAddResponse responseData = new CompanyAddResponse()
                        {
                            CompanyID = Convert.ToInt32(dataReader["ID"]),
                            Name = dataReader["Name"].ToString(),
                            Address = dataReader["Address"].ToString(),
                            Location = dataReader["Location"].ToString(),
                            Status = dataReader["Status"].ToString(),
                            CreatorStamp = dataReader["CreatorStamp"].ToString(),
                            CreatorUser = dataReader["CreatorUser"].ToString(),
                            CreatedDate = dataReader["CreatedDate"].ToString(),
                            ModifiedDate = dataReader["ModifiedDate"].ToString()
                        };
                        companiesList.Add(responseData);
                    }
                    conn.Close();
                }
                return companiesList;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Stores Data in the Datbase
        /// </summary>
        /// <param name="companyAdd">Caompany Data</param>
        /// <returns>If Data Found return ResponseData else nul or Exception</returns>
        public CompanyAddResponse AddCompany(CompanyAddRequest companyAddRequest)
        {
            try
            {
                CompanyAddResponse responseData = null;
                try
                {
                    using(SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_AddCompanies", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", companyAddRequest.Name);
                        cmd.Parameters.AddWithValue("@Address", companyAddRequest.Address);
                        cmd.Parameters.AddWithValue("@Location", companyAddRequest.Location);
                        cmd.Parameters.AddWithValue("@Status", companyAddRequest.Status);
                        cmd.Parameters.AddWithValue("@CreatorStamp", companyAddRequest.CreatorStamp);
                        cmd.Parameters.AddWithValue("@CreatorUser", companyAddRequest.CreatorUser);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new CompanyAddResponse()
                            {
                                CompanyID = Convert.ToInt32(dataReader["ID"]),
                                Name = dataReader["Name"].ToString(),
                                Address = dataReader["Address"].ToString(),
                                Location = dataReader["Location"].ToString(),
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
        /// It Stores Data into the Database
        /// </summary>
        /// <param name="makerProgram">MakerProgram</param>
        /// <returns>If Data Added Successfully return ResponseData else null or Exception</returns>
        public MakerProgramResponse AddMakerProgram(MakerProgramRequest makerProgram)
        {
            try
            {
                MakerProgramResponse responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_MakerProgram", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ProgramName", makerProgram.ProgramName);
                        cmd.Parameters.AddWithValue("@ProgramType", makerProgram.ProgramType);
                        cmd.Parameters.AddWithValue("@ProgramLink", makerProgram.ProgramLink);
                        cmd.Parameters.AddWithValue("@TechStackID", makerProgram.TechStackID);
                        cmd.Parameters.AddWithValue("@TechTypeID", makerProgram.TechTypeID);
                        cmd.Parameters.AddWithValue("@IsprogramApproved", makerProgram.TechStackID);
                        cmd.Parameters.AddWithValue("@DescriptionStatus", makerProgram.DescriptionStatus);
                        cmd.Parameters.AddWithValue("@CreatorStamp", makerProgram.CreatorStamp);
                        cmd.Parameters.AddWithValue("@CreatorUser", makerProgram.CreatorUser);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new MakerProgramResponse()
                            {
                                ID = Convert.ToInt32(dataReader["ID"]),
                                ProgramName = dataReader["ProgramName"].ToString(),
                                ProgramType = dataReader["ProgramType"].ToString(),
                                ProgramLink = dataReader["ProgramLink"].ToString(),
                                TechStackID = Convert.ToInt32(dataReader["TechStackID"]),
                                TechTypeID = Convert.ToInt32(dataReader["TechTypeID"]),
                                DescriptionStatus = dataReader["DescriptionStatus"].ToString(),
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

        /// <summary>
        /// It Stores Mentor Data in the Database
        /// </summary>
        /// <param name="mentorRegistration">Mentor Registration</param>
        /// <returns>If Data Added Successfully it returns ResponseData else null or Exception</returns>
        public MentorRegistrationResponse AddMentor(MentorRegistrationRequest mentorRegistration)
        {
            try
            {
                MentorRegistrationResponse responseData = null;
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SP_InsertMentor", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", mentorRegistration.Name);
                        cmd.Parameters.AddWithValue("@MentorType", mentorRegistration.MentorType);
                        cmd.Parameters.AddWithValue("@LabID", mentorRegistration.LabID);
                        cmd.Parameters.AddWithValue("@Status", mentorRegistration.Status);
                        cmd.Parameters.AddWithValue("@CreatorStamp", mentorRegistration.CreatorStamp);
                        cmd.Parameters.AddWithValue("@CreatorUser", mentorRegistration.CreatorUser);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                        conn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            responseData = new MentorRegistrationResponse()
                            {
                                ID = Convert.ToInt32(dataReader["ID"]),
                                Name = dataReader["Name"].ToString(),
                                MentorType = dataReader["MentorType"].ToString(),
                                LabID = Convert.ToInt32(dataReader["LabID"]),
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
        /// It is used to Add Data in the Database
        /// </summary>
        /// <param name="mentorIdeation">Mentor Ideation</param>
        /// <returns>If Data Added Successfully return ResponseData else null or Exception</returns>
        public MentorIdeationResponse AddMentorIdeation(MentorIdeationRequest mentorIdeation)
        {
            try
            {
                MentorIdeationResponse responseData = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_MentorIdeationMap", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LeadID", mentorIdeation.LeadID);
                    cmd.Parameters.AddWithValue("@MentorID", mentorIdeation.MentorID);
                    cmd.Parameters.AddWithValue("@Status", mentorIdeation.Status);
                    cmd.Parameters.AddWithValue("@CreatorStamp", mentorIdeation.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", mentorIdeation.CreatorUser);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData = new MentorIdeationResponse()
                        {
                            ID = Convert.ToInt32(dataReader["ID"]),
                            LeadID = Convert.ToInt32(dataReader["LeadID"]),
                            MentorID = Convert.ToInt32(dataReader["MentorID"]),
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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Stored Mentor Tech Stack in the Database
        /// </summary>
        /// <param name="techStack">Tech Stack</param>
        /// <returns>If Data Added Successfully return ResponseData else null or Exception</returns>
        public MentorTechStackResponse AddMentorTechStack(MentorTechStackRequest techStack)
        {
            try
            {
                MentorTechStackResponse responseData = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_MentorTechStack", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MentorID", techStack.MentorID);
                    cmd.Parameters.AddWithValue("@TechStackID", techStack.TechStackID);
                    cmd.Parameters.AddWithValue("@Status", techStack.Status);
                    cmd.Parameters.AddWithValue("@CreatorStamp", techStack.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", techStack.CreatorUser);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData = new MentorTechStackResponse()
                        {
                            ID = Convert.ToInt32(dataReader["ID"]),
                            MentorID = Convert.ToInt32(dataReader["MentorID"]),
                            TechStackID = Convert.ToInt32(dataReader["TechStackID"]),
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

        /// <summary>
        /// It Stores Tech Type Data in the Database
        /// </summary>
        /// <param name="techStack">Tech Stack</param>
        /// <returns>If Data Added Successfully return ResponseData else null or Exception</returns>
        public TechStackResponse AddTechStack(TechStackRequest techStack)
        {
            try
            {
                TechStackResponse responseData = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_TechStack", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TechName", techStack.TechName);
                    cmd.Parameters.AddWithValue("@ImagePath", techStack.ImagePath);
                    cmd.Parameters.AddWithValue("@Framework", techStack.Framework);
                    cmd.Parameters.AddWithValue("@CurrentStatus", techStack.CurrentStatus);
                    cmd.Parameters.AddWithValue("@CreatorStamp", techStack.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", techStack.CreatorUser);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData = new TechStackResponse()
                        {
                            ID = Convert.ToInt32(dataReader["ID"]),
                            TechName = dataReader["TechName"].ToString(),
                            ImagePath = dataReader["ImagePath"].ToString(),
                            CurrentStatus = dataReader["CurrentStatus"].ToString(),
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

        /// <summary>
        /// It Stores Data in the Database
        /// </summary>
        /// <param name="techType">tech Type</param>
        /// <returns>If Data Added Successfully return ResponseData else null or Exception</returns>
        public TechTypeResponse AddTechType(TechTypeRequest techType)
        {
            try
            {
                TechTypeResponse responseData = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_TechType", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TypeName", techType.TypeName);
                    cmd.Parameters.AddWithValue("@CurrentStatus", techType.CurrentStatus);
                    cmd.Parameters.AddWithValue("@CreatorStamp", techType.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", techType.CreatorUser);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData = new TechTypeResponse()
                        {
                            ID = Convert.ToInt32(dataReader["ID"]),
                            TypeName = dataReader["TypeName"].ToString(),
                            CurrentStatus = dataReader["CurrentStatus"].ToString(),
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

        /// <summary>
        /// It Stores Lab Data in the Database
        /// </summary>
        /// <param name="lab">Lab Data</param>
        /// <returns>If Data Added Successfully return ResponseData else null or Exception</returns>
        public LabRegistrationResponse AddLab(LabRegistrationRequest lab)
        {
            try
            {
                LabRegistrationResponse responseData = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertLab", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", lab.Name);
                    cmd.Parameters.AddWithValue("@Location", lab.Location);
                    cmd.Parameters.AddWithValue("@Address", lab.Address);
                    cmd.Parameters.AddWithValue("@Status", lab.Status);
                    cmd.Parameters.AddWithValue("@CreatorStamp", lab.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", lab.CreatorUser);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData = new LabRegistrationResponse()
                        {
                            ID = Convert.ToInt32(dataReader["ID"]),
                            Name = dataReader["Name"].ToString(),
                            Location = dataReader["Location"].ToString(),
                            Address = dataReader["Address"].ToString(),
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

        /// <summary>
        /// It Stores Data in the Database
        /// </summary>
        /// <param name="labThreshold"></param>
        /// <returns>If Data Added Successfully return ResponseData else null or Exception</returns>
        public LabThresholdResponse AddLabThreshold(LabThresholdRequest labThreshold)
        {
            try
            {
                LabThresholdResponse responseData = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_LabThreshold", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LabID", labThreshold.LabID);
                    cmd.Parameters.AddWithValue("@LabCapacity", labThreshold.LabCapacity);
                    cmd.Parameters.AddWithValue("@LeadThreshold", labThreshold.LeadThreshold);
                    cmd.Parameters.AddWithValue("@IdeationEnggThreshold", labThreshold.IdeationEnggThreshold);
                    cmd.Parameters.AddWithValue("@BuddyEnggThreshold", labThreshold.BuddyEnggThreshold);
                    cmd.Parameters.AddWithValue("@Status", labThreshold.Status);
                    cmd.Parameters.AddWithValue("@CreatorStamp", labThreshold.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", labThreshold.CreatorUser);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData = new LabThresholdResponse()
                        {
                            ID = Convert.ToInt32(dataReader["ID"]),
                            LabID = Convert.ToInt32(dataReader["LabID"]),
                            LabCapacity = dataReader["LabCapacity"].ToString(),
                            LeadThreshold = dataReader["LeadThreshold"].ToString(),
                            IdeationEnggThreshold = dataReader["IdeationEnggThreshold"].ToString(),
                            BuddyEnggThreshold = dataReader["BuddyEnggThreshold"].ToString(),
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

        /// <summary>
        /// It Stores data in the Database
        /// </summary>
        /// <param name="companyRequirement"></param>
        /// <returns>If Data Added Successfully return ResponseData else null or Exception</returns>
        public CompanyRequirementResponse AddCompanyRequirement(CompanyRequirementRequest companyRequirement)
        {
            try
            {
                CompanyRequirementResponse responseData = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_CompanyRequirement", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CompanyID", companyRequirement.CompanyID);
                    cmd.Parameters.AddWithValue("@RequestedMonth", companyRequirement.RequestedMonth);
                    cmd.Parameters.AddWithValue("@City", companyRequirement.City);
                    cmd.Parameters.AddWithValue("@IsDocVerified", companyRequirement.IsDocVerified);
                    cmd.Parameters.AddWithValue("@RequirementDocPath", companyRequirement.RequirementDocPath);
                    cmd.Parameters.AddWithValue("@NumOfEngg", companyRequirement.NumOfEngg);
                    cmd.Parameters.AddWithValue("@TechStackID", companyRequirement.TechStackID);
                    cmd.Parameters.AddWithValue("@TechTypeID", companyRequirement.TechTypeID);
                    cmd.Parameters.AddWithValue("@MakerProgramID", companyRequirement.MakerProgramID);
                    cmd.Parameters.AddWithValue("@LeadID", companyRequirement.LeadID);
                    cmd.Parameters.AddWithValue("@IdeationEnggID", companyRequirement.IdeationEnggID);
                    cmd.Parameters.AddWithValue("@BuddyEnggID", companyRequirement.BuddyEnggID);
                    cmd.Parameters.AddWithValue("@SpecialRemark", companyRequirement.SpecialRemark);
                    cmd.Parameters.AddWithValue("@Status", companyRequirement.Status);
                    cmd.Parameters.AddWithValue("@CreatorStamp", companyRequirement.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", companyRequirement.CreatorUser);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData = new CompanyRequirementResponse()
                        {
                            ID = Convert.ToInt32(dataReader["ID"]),
                            CompanyID = Convert.ToInt32(dataReader["CompanyID"]),
                            RequestedMonth = dataReader["RequestedMonth"].ToString(),
                            City = dataReader["City"].ToString(),
                            IsDocVerified = dataReader["IsDocVerified"].ToString(),
                            RequirementDocPath = dataReader["RequirementDocPath"].ToString(),
                            NumOfEngg = dataReader["NumOfEngg"].ToString(),
                            TechStackID = Convert.ToInt32(dataReader["TechStackID"]),
                            TechTypeID = Convert.ToInt32(dataReader["TechTypeID"]),
                            MakerProgramID = Convert.ToInt32(dataReader["MakerProgramID"]),
                            LeadID = Convert.ToInt32(dataReader["LeadID"]),
                            IdeationEnggID = Convert.ToInt32(dataReader["IdeationEnggID"]),
                            BuddyEnggID = Convert.ToInt32(dataReader["BuddyEnggID"]),
                            SpecialRemark = dataReader["SpecialRemark"].ToString(),
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
