// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace JlizBankEntity.JlizEntity
{
    public partial class TransactionRecordsDetails
    {
        public Guid TransactionNum { get; set; }
        public DateTime TransactionTime { get; set; }
        public string FromAccountNum { get; set; }
        public string ToAccountNum { get; set; }
        public string FromBankId { get; set; }
        public string FromBankName { get; set; }
        public string TransactionType { get; set; }
        public decimal TransactionMoney { get; set; }
        public string ToBankId { get; set; }
        public string ToBankName { get; set; }
        public decimal? HandlingFees { get; set; }
        public decimal AccountBalance { get; set; }
        public string Remark { get; set; }
    }
}