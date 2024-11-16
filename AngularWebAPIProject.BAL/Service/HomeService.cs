using AngularWebAPIProject.BAL.Interface;
using AngularWebAPIProject.DAL;
using AngularWebAPIProject.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebAPIProject.BAL.Service
{
    public class HomeService:IHome
    {

        private readonly DatabaseContext dbContext;
        private readonly IMapper mapper;
        public HomeService(DatabaseContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Transactions
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetTransactions()
        {
            ResponseModel responseModel = new();
            List<TransactionModel> transactionModels = new List<TransactionModel>();
            var transactions = dbContext.RecordOpening.Where(u => u.IsActive == 1).ToList();
            if (transactions != null)
            {
                transactionModels.AddRange(transactions.Select(p => new TransactionModel
                {
                    PFID = p.PFID,
                    FileNo = p.FileNo,
                    ClientSurname = p.ClientSurname,
                    LawyerName = p.LawyerName,
                    ClosingDate = p.ClosingDate,
                    PSMType = p.PSMType,
                    IsClosed = p.IsClosing,
                    LawClerkID = p.LawClerkID,
                    LawyerID = p.SolicitorID,
                    UserId = p.ModifiedBy,
                    RequisitionDate = p.RecquisitionDate
                }));
            }
            responseModel.Id = 1;
            responseModel.Status = HttpStatusCode.OK.ToString();
            responseModel.Message = Message.Success;
            responseModel.Data = transactions;
            return responseModel;
        }
    }
}
