﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace JlizBankEntity.JlizEntity
{
    public partial class BankAccount
    {
        public string AccountNum { get; set; }
        public Guid CustomerId { get; set; }
        public string BankId { get; set; }
        public string BankName { get; set; }
        public string LoginAccount { get; set; }
        public string HashPassword { get; set; }
        public decimal AccountBalance { get; set; }
        public bool AllertAccount { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public virtual BranchBank Bank { get; set; }
        public virtual BankPersonalInfo Customer { get; set; }
    }
}