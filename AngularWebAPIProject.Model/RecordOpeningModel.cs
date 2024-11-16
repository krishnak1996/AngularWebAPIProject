using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebAPIProject.Model
{
    public class RecordOpeningModel
    {
        public int PFID { get; set; }
        public string? FileNo { get; set; }
        public DateTime? FileOpeningDate { get; set; }
        public string? LawClerkInitial { get; set; }
        public string? LawyerInitial { get; set; }
        public string? LawyerName { get; set; }
        public string? ClientSurname { get; set; }
        public int? ClientID { get; set; }
        public string? VendorSurname { get; set; }
        public int? VendorID { get; set; }
        public DateTime? RecquisitionDate { get; set; }
        public int? IsRecquisitionSubmit { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int? IsClosing { get; set; }
        public string? ClosingFileNo { get; set; }
        public DateTime? DateofAgrt { get; set; }
        public string? RealStateBroker { get; set; }
        public string? ReferedBy { get; set; }
        public string? FeeQuote { get; set; }
        public string? TeraViewDocket { get; set; }
        public string? SpecialComment { get; set; }
        public string? PurchaserExec { get; set; }
        public DateTime? PurchaseOn { get; set; }
        public int? IsAppointSchedule { get; set; }
        public int? IsSignedRemotely { get; set; }
        public string? IsTransactionInsured { get; set; }
        public string? Insurer { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? IsActive { get; set; }
        public DateTime? FileInActiveDate { get; set; }
        public string? FileInActiveNotes { get; set; }
        public string? WitnessNotaryName { get; set; }
        public int? LawClerkID { get; set; }
        public int? SolicitorID { get; set; }
        public int? RealEstateBrokerID { get; set; }
        public int? JurisdictionID { get; set; }
        public int? WitnessNotaryID { get; set; }
        public int? AdjAsOfClsDate { get; set; }
        public bool? IsAssignor { get; set; }
        public int? RegistrationMethod { get; set; }
        public string? PSMType { get; set; }
        public bool? IsReqReport { get; set; }
        public string? ReqReportType { get; set; }
        public string? ReqReportBy { get; set; }
        public string? ReqReportDate { get; set; }
        public int? FirmId { get; set; }
        public DateTime? RequisitionSubmitDate { get; set; }
        public DateTime? OccupancyClosingDate { get; set; }
        public int? ReferralID { get; set; }
        public int? AssignerId { get; set; }
    }
}
