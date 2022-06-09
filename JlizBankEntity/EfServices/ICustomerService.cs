using JlizBankEntity.JlizEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JlizBankEntity.EfServices
{
    public interface ICustomerService
    {
        public Task<bool> CreateCustomerAsync(BankPersonalInfo personalInfo, BankAccount account);
        public Task<bool> CreateTransactionRecordsAsync(TransactionRecordsDetails details);
        public Task<BankPersonalInfo> GetPersonalInfoAsync(string CustomerId);
        public Task<BankAccount> GetAccountAsync(string LoginAccount);
        public Task<BankAccount> GetAccountUseNumAsync(string AccountNum);
        public Task<List<TransactionInfo>> GetTransactionAsync(string AccountNum, DateTime start, DateTime end);
        public Task<List<BranchBank>> GetAllBank();
        public Task<bool> UpadatePersonalInfoAsync(BankPersonalInfo personalInfo);
        public Task<bool> UpdateBalanceAsync(BankAccount bankAccount);
        public Task<bool> ChangePassword(BankAccount bankAccount);
        

    }
}