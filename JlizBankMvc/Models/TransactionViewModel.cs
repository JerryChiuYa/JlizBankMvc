using System;
using System.Collections.Generic;

namespace JlizBankMvc.Models
{
    public class TransactionViewModel
    {
        public Guid CustomerId { get; set; }
        public DateTime TransactionTime { get; set; }
        public List<string> AllBanks { get; set; }
        public string FromAccountNum { get; set; }
        public string ToAccountNum { get; set; }
        public string FromBankName { get; set; }
        public string TransactionType { get; set; }
        public decimal TransactionMoney { get; set; }
        public string ToBankName { get; set; }
        public decimal? HandlingFees { get; set; }
        public decimal AccountBalance { get; set; }
        public string TransferCode { get; set; }
        public string Remark { get; set; }
    }
}
