using AngularWebAPIProject.BAL.Interface;
using AngularWebAPIProject.DAL;
using AngularWebAPIProject.Model;
using AutoMapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebAPIProject.BAL.Service
{
    public class BuyersService : IBuyers
    {
        private readonly DatabaseContext dbContext;
        private readonly IMapper mapper;
        public BuyersService(DatabaseContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }


        /// <summary>
        /// Get Buyers By PFID
        /// </summary>
        /// <param name="PFID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ResponseModel GetBuyersById(int PFID)
        {
            ResponseModel responseModel = new();
            BuyersModel buyersModel = new();
            var buyers = dbContext.Buyers.Where(u => u.PFID == PFID).FirstOrDefault();
            if (buyersModel != null)
            {
                buyersModel = mapper.Map<BuyersModel>(buyers);
            }
            responseModel.Id = 1;
            responseModel.Status = HttpStatusCode.OK.ToString();
            responseModel.Message = Message.Success;
            responseModel.Data = buyersModel;
            return responseModel;
        }

        /// <summary>
        /// Save Buyers
        /// </summary>
        /// <param name="buyersModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ResponseModel SaveBuyers(BuyersModel buyersModel)
        {
            ResponseModel responseModel = new();
            int status = 0;
            if (buyersModel != null)
            {
                var buyers = mapper.Map<Buyers>(buyersModel);
                if (buyers != null)
                {
                    if (buyers.PFID > 0)
                    {
                        buyers.ModifiedBy = buyersModel.CreatedBy;
                        buyers.ModifiedDate = DateTime.Now;
                        dbContext.Buyers.Update(buyers);
                        status = dbContext.SaveChanges();
                        if (status > 0)
                        {
                            responseModel.Message = Message.Update;
                            responseModel.Id = 2;
                            responseModel.Status = HttpStatusCode.OK.ToString();
                        }
                        else
                        {
                            responseModel.Message = Message.Error;
                            responseModel.Id = -1;
                            responseModel.Status = HttpStatusCode.InternalServerError.ToString();
                        }
                    }
                    else
                    {
                        buyers.CreatedDate = DateTime.Now;
                        dbContext.Buyers.AddAsync(buyers);
                        status = dbContext.SaveChanges();
                        if (status > 0)
                        {
                            responseModel.Message = Message.Success;
                            responseModel.Id = 1;
                            responseModel.Status = HttpStatusCode.OK.ToString();
                        }
                        else
                        {
                            responseModel.Message = Message.Error;
                            responseModel.Id = -1;
                            responseModel.Status = HttpStatusCode.InternalServerError.ToString();
                        }
                    }
                }
            }
            return responseModel;
        }


        public ResponseModel GetRecordOpeningById(int Id)
        {
            ResponseModel responseModel = new();
            RecordOpeningModel recordOpeningModel = null;

            // Connection string (update with your database details)
            string connectionString = "YourConnectionStringHere";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetRecordOpeningById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", Id));

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Assuming you have a method to map your data
                            recordOpeningModel = new RecordOpeningModel
                            {
                                // Map the fields from the reader to your model
                                // Example:
                                PFID = reader["PFID"] != DBNull.Value ? (int)reader["PFID"] : 0,
                                // Add other fields similarly
                            };
                        }
                    }
                }
            }

            if (recordOpeningModel != null)
            {
                responseModel.Id = 1;
                responseModel.Status = HttpStatusCode.OK.ToString();
                responseModel.Message = Message.Success;
                responseModel.Data = recordOpeningModel;
            }
            else
            {
                responseModel.Id = 0;
                responseModel.Status = HttpStatusCode.NotFound.ToString();
                responseModel.Message = "Record not found.";
                responseModel.Data = null;
            }

            return responseModel;
        }

    }
}
