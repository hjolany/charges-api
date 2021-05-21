using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseApi.V1.Infrastructure
{ 
    [Table("charge_table")]
    public class ChargeDbEntity
    {
        [Key]
        [Column("id",TypeName ="int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("charge_type",TypeName = "varchar(50)")]
        public string ChargeType { get; set; }
        [Column("charge_source", TypeName = "varchar(50)")]
        public string ChargeSource { get; set; }
        [Column("debit_code", TypeName = "varchar(50)")]
        public string DebitCode { get; set; }
        [Column("debit_code_description", TypeName = "text")]
        public string DebitCodeDescription { get; set; }
        [Column("effective_start_date", TypeName = "datetime2")]
        public DateTime EffectiveStartDate { get; set; }
        [Column("termination_date", TypeName = "datetime2")]
        public DateTime TerminationDate { get; set; }
        [Column("period_code", TypeName = "varchar(50)")]
        public string PeriodCode { get; set; }
        [Column("debit_next_due", TypeName = "datetime2")]
        public DateTime DebitNextDue { get; set; }
        [Column("debit_last_charged", TypeName = "datetime2")]
        public DateTime DebitLastCharged { get; set; }
        [Column("debit_active")]
        public bool DebitActive { get; set; }
        [Column("debit_value",TypeName ="decimal")]
        public decimal DebitValue { get; set; }
        [Column("property_debit")]
        public bool PropertyDebit { get; set; }
        [Column("debit_source",TypeName ="varchar(50)")]
        public string DebitSource { get; set; }
        [Column("timestamp", TypeName = "datetime2")]
        public DateTime TimeStamp { get; set; }
        [Column("service_charge_schedule",TypeName = "varchar(50)")]
        public string ServiceChargeSchedule { get; set; }
        [Column("data_import_source", TypeName = "varchar(50)")]
        public string DataImportSource { get; set; }
    }
}
