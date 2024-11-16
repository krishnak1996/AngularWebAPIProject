using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebAPIProject.Model
{
    public class TransactionModel
    {
        public int PFID { get; set; }
        public string? FileNo { get; set; }
        public string? ClientSurname { get; set; }
        public string? LawyerName { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int? IsActive { get; set; }
        public string? StrisActive { get; set; }
        public string? PurchaserAddress { get; set; }
        public bool LockMode { get; set; }
        public string? LockBy { get; set; }
        public string? PSMType { get; set; }
        public int? IsClosed { get; set; }
        public string? ClosingDateValue { get; set; }
        public int? LawyerID { get; set; }
        public int? LawClerkID { get; set; }
        public string? LawyerInitialName { get; set; }
        public string? LawClerkInitialName { get; set; }
        public int? UserId { get; set; }
        public bool RecordClosingStatus { get; set; }
        public DateTime? RequisitionDate { get; set; }
        public string? RequistionDate { get; set; }
        public string? LawyerFullName { get; set; }
        public string? LawClerkFullName { get; set; }
        public string? PropertyAddress { get; set; }
        public bool IsRequsitionExpireStatus { get; set; }
        public bool RecordClosingOverdueStatus { get; set; }
        public bool? IsReportSubmitStatus { get; set; }
    }
}
