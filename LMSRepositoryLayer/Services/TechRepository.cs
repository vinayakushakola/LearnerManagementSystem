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
    public class TechRepository : ITechRepository
    {
        private readonly IConfiguration _configuration;

        private readonly string sqlConnectionString;

        public TechRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnectionString = _configuration.GetConnectionString("LMSDBConnection");
        }

        public List<TechStackResponse> ListOfTechStacks()
        {
            try
            {
                List<TechStackResponse> techStackList = null;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    techStackList = new List<TechStackResponse>();
                    SqlCommand cmd = new SqlCommand("spGetAllTechStacks", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        TechStackResponse responseData = new TechStackResponse()
                        {
                            ID = Convert.ToInt32(dataReader["ID"]),
                            TechName = dataReader["TechName"].ToString(),
                            ImagePath = dataReader["ImagePath"].ToString(),
                            CurrentStatus = dataReader["CurrentStatus"].ToString(),
                            CreatorStamp = dataReader["CreatorStamp"].ToString(),
                            CreatorUser = dataReader["CreatorUser"].ToString(),
                            CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]),
                            ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"])
                        };
                        techStackList.Add(responseData);
                    }
                    conn.Close();
                }
                return techStackList;
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
                    SqlCommand cmd = new SqlCommand("SP_TechStack", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

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

        public List<TechTypeResponse> ListOfTechTypes()
        {
            try
            {
                List<TechTypeResponse> techTypeList = null;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    techTypeList = new List<TechTypeResponse>();
                    SqlCommand cmd = new SqlCommand("spGetAllTechTypes", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        TechTypeResponse responseData = new TechTypeResponse()
                        {
                            ID = Convert.ToInt32(dataReader["ID"]),
                            TypeName = dataReader["TypeName"].ToString(),
                            CurrentStatus = dataReader["CurrentStatus"].ToString(),
                            CreatorStamp = dataReader["CreatorStamp"].ToString(),
                            CreatorUser = dataReader["CreatorUser"].ToString(),
                            CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]),
                            ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"])
                        };
                        techTypeList.Add(responseData);
                    }
                    conn.Close();
                }
                return techTypeList;
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
                    SqlCommand cmd = new SqlCommand("SP_TechType", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

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
