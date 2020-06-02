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
                    SqlCommand cmd = new SqlCommand("SP_GetAllCompanies", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
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
                            CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]),
                            ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"])
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
        /// It Stores Data in the Database
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
                        SqlCommand cmd = new SqlCommand("SP_AddCompanies", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };
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
                    SqlCommand cmd = new SqlCommand("SP_CompanyRequirement", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

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
                            IsDocVerified = Convert.ToBoolean(dataReader["IsDocVerified"]),
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
