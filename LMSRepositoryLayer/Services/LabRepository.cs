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
    public class LabRepository : ILabRepository
    {
        private readonly IConfiguration _configuration;

        private readonly string sqlConnectionString;

        public LabRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnectionString = _configuration.GetConnectionString("LMSDBConnection");
        }

        /// <summary>
        /// It Fetch Data from the Database
        /// </summary>
        /// <returns>If Data Fetched Successfully return ResponseData else null or Excception</returns>
        public List<LabRegistrationResponse> ListOfLabs()
        {
            try
            {
                List<LabRegistrationResponse> labsList = null;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    labsList = new List<LabRegistrationResponse>();
                    SqlCommand cmd = new SqlCommand("spGetAllLabs", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        LabRegistrationResponse responseData = new LabRegistrationResponse()
                        {
                            ID = Convert.ToInt32(dataReader["LabID"]),
                            Name = dataReader["Name"].ToString(),
                            Location = dataReader["Location"].ToString(),
                            Address = dataReader["Address"].ToString(),
                            Status = dataReader["Status"].ToString(),
                            CreatorStamp = dataReader["CreatorStamp"].ToString(),
                            CreatorUser = dataReader["CreatorUser"].ToString(),
                            CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]),
                            ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"])
                        };
                        labsList.Add(responseData);
                    }
                    conn.Close();
                }
                return labsList;
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
                    SqlCommand cmd = new SqlCommand("spAddLab", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

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
                            ID = Convert.ToInt32(dataReader["LabID"]),
                            Name = dataReader["Name"].ToString(),
                            Location = dataReader["Location"].ToString(),
                            Address = dataReader["Address"].ToString(),
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
                    SqlCommand cmd = new SqlCommand("spAddLabThreshold", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

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
