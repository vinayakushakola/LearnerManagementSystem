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
    }
}
