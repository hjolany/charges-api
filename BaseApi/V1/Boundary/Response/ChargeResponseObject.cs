using System;

namespace BaseApi.V1.Boundary.Response
{
    //TODO: Rename to represent to object you will be returning eg. ResidentInformation, HouseholdDetails e.t.c
    public class ChargeResponseObject
    {
        /// <example>
        /// 401
        /// </example>
        public Guid Id { get; set; }
        /// <example>
        /// 
        /// </example>
        public string ChargeType { get; set; }
        /// <example>
        /// 
        /// </example>
        public string ChargeSource { get; set; }
        /// <example>
        /// 
        /// </example>
        public string DebitCode { get; set; }
        /// <example>
        /// 
        /// </example>
        public string DebitCodeDescription { get; set; }
        /// <example>
        /// 
        /// </example>
        public DateTime EffectiveStartDate { get; set; }
        /// <example>
        /// 
        /// </example>
        public DateTime TerminationDate { get; set; }
        /// <example>
        /// 
        /// </example>
        public string PeriodCode { get; set; }
        /// <example>
        /// 
        /// </example>
        public DateTime DebitNextDue { get; set; }
        /// <example>
        /// 
        /// </example>
        public DateTime DebitLastCharged { get; set; }
        /// <example>
        /// 
        /// </example>
        public bool DebitActive { get; set; }
        /// <example>
        /// 
        /// </example>
        public decimal DebitValue { get; set; }
        /// <example>
        /// 
        /// </example>
        public bool PropertyDebit { get; set; }
        /// <example>
        /// 
        /// </example>
        public string DebitSource { get; set; }
        /// <example>
        /// 
        /// </example>
        public DateTime TimeStamp { get; set; }
        /// <example>
        /// 
        /// </example>
        public string ServiceChargeSchedule { get; set; }
        /// <example>
        /// 
        /// </example>
        public string DataImportSource { get; set; }
    }
}
