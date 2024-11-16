using AngularWebAPIProject.BAL.Interface;
using AngularWebAPIProject.DAL;
using AngularWebAPIProject.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebAPIProject.BAL.Service
{
    public class RecordOpeningService : IRecordOpening
    {
        private readonly DatabaseContext dbContext;
        private readonly IMapper mapper;
        public RecordOpeningService(DatabaseContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Record Opening By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ResponseModel GetRecordOpeningById(int Id)
        {
            ResponseModel responseModel = new();
            RecordOpeningModel recordOpeningModel = new RecordOpeningModel();
            var recordOpening = dbContext.RecordOpening.Where(u => u.PFID == Id).FirstOrDefault();
            if (recordOpening != null)
            {
                recordOpeningModel = mapper.Map<RecordOpeningModel>(recordOpening);
            }
            responseModel.Id = 1;
            responseModel.Status = HttpStatusCode.OK.ToString();
            responseModel.Message = Message.Success;
            responseModel.Data = recordOpeningModel;
            return responseModel;
        }

        /// <summary>
        /// Save Record Opening
        /// </summary>
        /// <param name="recordOpeningModel"></param>
        /// <returns></returns>
        public ResponseModel SaveRecordOpening(RecordOpeningModel recordOpeningModel)
        {
            ResponseModel responseModel = new();
            int status = 0;
            if (recordOpeningModel != null)
            {
                var recordOpening = mapper.Map<RecordOpening>(recordOpeningModel);
                if (recordOpening != null)
                {
                    if (recordOpening.PFID > 0)
                    {
                        recordOpening.ModifiedBy = recordOpeningModel.CreatedBy;
                        recordOpening.ModifiedDate = DateTime.Now;
                        dbContext.RecordOpening.Update(recordOpening);
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
                        recordOpening.CreatedDate = DateTime.Now;
                        dbContext.RecordOpening.AddAsync(recordOpening);
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
    }
}
