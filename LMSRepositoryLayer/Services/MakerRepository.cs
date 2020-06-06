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
    public class MakerRepository : IMakerRepository
    {
        private readonly IConfiguration _configuration;

        private readonly string sqlConnectionString;

        public MakerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnectionString = _configuration.GetConnectionString("LMSDBConnection");
        }

        /// <summary>
        /// It Fetches Data of Maker Programs from the Database
        /// </summary>
        /// <returns>If Data Found return Response Data else null or Exception</returns>
        public List<MakerProgramResponse> ListOfMakerProgram()
        {
            try
            {
                List<MakerProgramResponse> makerProgramList = null;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    makerProgramList = new List<MakerProgramResponse>();
                    SqlCommand cmd = new SqlCommand("spGetAllMakerPrograms", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        MakerProgramResponse responseData = new MakerProgramResponse()
                        {
                            ID = Convert.ToInt32(dataReader["ID"]),
                            ProgramName = dataReader["ProgramName"].ToString(),
                            ProgramType = dataReader["ProgramType"].ToString(),
                            ProgramLink = dataReader["ProgramLink"].ToString(),
                            TechStackID = Convert.ToInt32(dataReader["TechStackID"]),
                            TechTypeID = Convert.ToInt32(dataReader["TechTypeID"]),
                            IsProgramApproved = Convert.ToBoolean(dataReader["IsProgramApproved"]),
                            DescriptionStatus = dataReader["DescriptionStatus"].ToString(),
                            CreatorStamp = dataReader["CreatorStamp"].ToString(),
                            CreatorUser = dataReader["CreatorUser"].ToString(),
                            CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]),
                            ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"])
                        };
                        makerProgramList.Add(responseData);
                    }
                    conn.Close();
                }
                return makerProgramList;
            }
            catch (Exception ex)
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
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddMakerProgram", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@ProgramName", makerProgram.ProgramName);
                    cmd.Parameters.AddWithValue("@ProgramType", makerProgram.ProgramType);
                    cmd.Parameters.AddWithValue("@ProgramLink", makerProgram.ProgramLink);
                    cmd.Parameters.AddWithValue("@TechStackID", makerProgram.TechStackID);
                    cmd.Parameters.AddWithValue("@TechTypeID", makerProgram.TechTypeID);
                    cmd.Parameters.AddWithValue("@IsprogramApproved", makerProgram.IsProgramApproved);
                    cmd.Parameters.AddWithValue("@DescriptionStatus", makerProgram.DescriptionStatus);
                    cmd.Parameters.AddWithValue("@CreatorStamp", makerProgram.CreatorStamp);
                    cmd.Parameters.AddWithValue("@CreatorUser", makerProgram.CreatorUser);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        responseData = new MakerProgramResponse
                        {
                            ID = Convert.ToInt32(dataReader["ID"]),
                            ProgramName = dataReader["ProgramName"].ToString(),
                            ProgramType = dataReader["ProgramType"].ToString(),
                            ProgramLink = dataReader["ProgramLink"].ToString(),
                            TechStackID = Convert.ToInt32(dataReader["TechStackID"]),
                            TechTypeID = Convert.ToInt32(dataReader["TechTypeID"]),
                            IsProgramApproved = Convert.ToBoolean(dataReader["IsProgramApproved"]),
                            DescriptionStatus = dataReader["DescriptionStatus"].ToString(),
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
