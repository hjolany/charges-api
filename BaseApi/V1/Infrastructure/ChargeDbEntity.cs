using Amazon.DynamoDBv2.DataModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseApi.V1.Infrastructure
{ 
    [DynamoDBTable("charges",LowerCamelCaseProperties = true)]
    public class ChargeDbEntity
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }

        [DynamoDBProperty(AttributeName = "charge_type")]
        public string ChargeType { get; set; }

        [DynamoDBProperty(AttributeName = "charge_source")]
        public string ChargeSource { get; set; }

        [DynamoDBProperty(AttributeName = "debit_code")]
        public string DebitCode { get; set; }

        [DynamoDBProperty(AttributeName = "debit_code_description")]
        public string DebitCodeDescription { get; set; }

        [DynamoDBProperty(AttributeName = "effective_start_date")]
        public DateTime EffectiveStartDate { get; set; }


        [DynamoDBProperty(AttributeName = "termination_date")]
        public DateTime TerminationDate { get; set; }

        [DynamoDBProperty(AttributeName = "period_code")]
        public string PeriodCode { get; set; }

        [DynamoDBProperty(AttributeName = "debit_next_due")]
        public DateTime DebitNextDue { get; set; }

        [DynamoDBProperty(AttributeName = "debit_last_charged")]
        public DateTime DebitLastCharged { get; set; }

        [DynamoDBProperty(AttributeName = "debit_active")]
        public bool DebitActive { get; set; }

        [DynamoDBProperty(AttributeName = "debit_value")]
        public decimal DebitValue { get; set; }

        [DynamoDBProperty(AttributeName = "property_debit")]
        public bool PropertyDebit { get; set; }

        [DynamoDBProperty(AttributeName = "debit_source")]
        public string DebitSource { get; set; }

        [DynamoDBProperty(AttributeName = "timestamp")]
        public DateTime TimeStamp { get; set; }

        [DynamoDBProperty(AttributeName = "service_charge_schedule")]
        public string ServiceChargeSchedule { get; set; }

        [DynamoDBProperty(AttributeName = "data_import_source")]
        public string DataImportSource { get; set; }
    }
}
