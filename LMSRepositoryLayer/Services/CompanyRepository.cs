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
    }
}
