using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebAPIProject.DAL
{
    public class Buyers
    {
        [Key]
        public int ID { get; set; }
        public int? PFID { get; set; }
        public string?  Purchaser { get; set; }
        public string? Offerors { get; set; }
        public string? FaxNo { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public bool? PrimaryClient { get; set; }
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
        public string? AccountNo { get; set; }
        public DateTime? DepositDate { get; set; }
        public string? PreAddressId { get; set; }
        public string? PostAddressId { get; set; }
        public string? BankInfoId { get; set; }
        public string?  Rowinx { get; set; }
    }
}
