using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AngularWebAPIProject.Model
{
    public class BuyersModel
    {
        public int ID { get; set; }
        public string? Purchaser { get; set; }
        public string? Offerors { get; set; }
        public string? FaxNo { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public bool PrimaryClient { get; set; }
        public string? Will_Purchase_SubjectP { get; set; }
        public string? PreClosing_Add { get; set; }
        public string? PostClosing_Add { get; set; }
        public string? Spousal_Status { get; set; }
        public string? Envelop_Saluation { get; set; }
        public string? Envelop_Sal_Contd { get; set; }
        public string? Dear { get; set; }
        public string? DirectDeposit { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? IsActive { get; set; }
        public int PFID { get; set; }
        public string? TempParty { get; set; }
        public string? AccountNo { get; set; }
        public DateTime? DepositDate { get; set; }
        public string? PreAddressId { get; set; }
        public string? PostAddressId { get; set; }
        public string? BankInfoId { get; set; }
        public string? Rowinx { get; set; }
        public SelectList? SelectListWill { get; set; }
        public SelectList? SelectListDirection { get; set; }
        public string? PrimaryClientEmail { get; set; }
        public int PartyId { get; set; }
        public string? Capacity { get; set; }
    }
}
