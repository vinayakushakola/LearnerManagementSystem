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
using System.Data;
using System.Data.SqlClient;

namespace LMSRepositoryLayer.Services
{
    public class MentorRepository : IMentorRepository
    {
        private readonly IConfiguration _configuration;

        private readonly string sqlConnectionString;

        public MentorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnectionString = _configuration.GetConnectionString("LMSDBConnection");
        }

        /// <summary>
        /// It Fetch Data from the Database
        /// </summary>
        /// <returns>If Data Retrieved Successfully return ResponseData else null or Exception</returns>
        public List<MentorRegistrationResponse> ListOfMentors()
        {
            try
            {
                List<MentorRegistrationResponse> mentorsList = null;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    mentorsList = new List<MentorRegistrationResponse>();
                    SqlCommand cmd = new SqlCommand("spGetAllMentors", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        MentorRegistrationResponse responseData = new MentorRegistrationResponse()
                        {
                            ID = Convert.ToInt32(dataReader["MentorID"]),
                            Name = dataReader["Name"].ToString(),
                            MentorType = dataReader["MentorType"].ToString(),
                            LabID = Convert.ToInt32(dataReader["LabID"]),
                            Status = dataReader["Status"].ToString(),
                            CreatorStamp = dataReader["CreatorStamp"].ToString(),
                            CreatorUser = dataReader["CreatorUser"].ToString(),
                            CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]),
                            ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"])
                        };
                        mentorsList.Add(responseData);
                    }
                    conn.Close();
                }
                return mentorsList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Fetches Leads Information from the Database
        /// </summary>
        /// <returns>If Data Found return Response Data else null or Exception</returns>
        public List<LeadBuddyResponse> ListOfLeads()
        {
            try
            {
                List<LeadBuddyResponse> leadBuddyList = null;
                List<LeadResponse> leadsList = null;
                List<BuddyResponse> buddyList = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    leadsList = new List<LeadResponse>();
                    buddyList = new List<BuddyResponse>();
                    SqlCommand cmd = new SqlCommand("spGetAllLeads", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        LeadResponse responseData = new LeadResponse()
                        {
                            ID = Convert.ToInt32(dataReader["MentorID"]),
                            Name = dataReader["Name"].ToString(),
                            Buddy = buddyList
                        };
                        buddyList = GetBuddiesUnderALead(responseData.ID);
                        responseData.Buddy = buddyList;
                        leadsList.Add(responseData);

                    }
                    conn.Close();
                    LeadBuddyResponse leadBuddyResponse = new LeadBuddyResponse
                    {
                        Leads = leadsList
                    };
                    leadBuddyList = new List<LeadBuddyResponse>();
                    leadBuddyList.Add(leadBuddyResponse);
                }
                return leadBuddyList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// It Fetches Data of Buddies who are under a Lead 
        /// </summary>
        /// <param name="leadID">LeadID</param>
        /// <returns>If Data Found return Response Data else null or Exception</returns>
        public List<BuddyResponse> GetBuddiesUnderALead(int leadID)
        {
            try
            {
                List<BuddyResponse> buddyList = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    buddyList = new List<BuddyResponse>();
                    SqlCommand cmd = new SqlCommand("spGetAllLeadsBuddies", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LeadID", leadID);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        BuddyResponse buddyResponse = new BuddyResponse()
                        {
                            ID = Convert.ToInt32(dataReader["MentorID"]),
                            Name = dataReader["BuddyName"].ToString(),
                            TechStack = dataReader["TechName"].ToString()
                        };
                        buddyList.Add(buddyResponse);
                    }
                    conn.Close();
                }
                return buddyList;
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
                        SqlCommand cmd = new SqlCommand("spAddMentor", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

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
                                ID = Convert.ToInt32(dataReader["MentorID"]),
                                Name = dataReader["Name"].ToString(),
                                MentorType = dataReader["MentorType"].ToString(),
                                LabID = Convert.ToInt32(dataReader["LabID"]),
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
                    SqlCommand cmd = new SqlCommand("spAddMentorIdeationMap", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

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
                    SqlCommand cmd = new SqlCommand("spAddMentorTechStack", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

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
