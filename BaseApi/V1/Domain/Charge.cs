using System;

namespace BaseApi.V1.Domain
{
    public class Charge
    {
        public int Id { get; set; }
        public string ChargeType { get; set; }
        public string ChargeSource { get; set; }
        public string DebitCode { get; set; }
        public string DebitCodeDescription { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public string PeriodCode { get; set; }
        public DateTime DebitNextDue { get; set; }
        public DateTime DebitLastCharged { get; set; }
        public bool DebitActive { get; set; }
        public decimal DebitValue { get; set; }
        public bool PropertyDebit { get; set; }
        public string DebitSource { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ServiceChargeSchedule { get; set; }
        public string DataImportSource { get; set; }
    }
}
