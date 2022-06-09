using JlizBankEntity.JlizContext;
using JlizBankEntity.JlizEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JlizBankEntity.EfServices
{
    public class CustomerService : ICustomerService
    {
        private readonly JlizBankContext _context;

        public CustomerService(JlizBankContext context)
        {
            _context = context;
        }
        public async Task<bool> ChangePassword(BankAccount account)
        {
            var user = await _context.BankAccount.Where(b=>b.LoginAccount==account.LoginAccount).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            user.HashPassword = account.HashPassword;
            //存入DB
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateCustomerAsync(BankPersonalInfo personalInfo, BankAccount account)
        {
            await _context.BankPersonalInfo.AddAsync(personalInfo);
            await _context.BankAccount.AddAsync(account);
            //存入DB
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateTransactionRecordsAsync(TransactionRecordsDetails details)
        {
            await _context.TransactionRecordsDetails.AddAsync(details);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<BankAccount> GetAccountAsync(string LoginAccount)
        {
            var entity =  await _context.BankAccount.Where(b=>b.LoginAccount==LoginAccount).FirstOrDefaultAsync();
            if (entity==null)
            {
                return null;
            }
            return entity;
        }


        public async Task<List<BranchBank>> GetAllBank()
        {
            var entity = _context.BranchBank;
            var bankList= await entity.ToListAsync();
            return bankList;
        }

        public Task<BankPersonalInfo> GetPersonalInfoAsync(string CustomerId)
        {
            var entity = _context.BankPersonalInfo.Where(b=>b.CustomerId.ToString()==CustomerId).FirstOrDefaultAsync();
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

        public async Task<List<TransactionInfo>> GetTransactionAsync(string AccountNum, DateTime start, DateTime end)
        {
            var query =from t in _context.TransactionRecordsDetails
                       where (t.FromAccountNum == AccountNum && t.TransactionType=="Transfer") ||   (t.ToAccountNum== AccountNum && t.TransactionType=="Receive")
                        select new TransactionInfo
                        {
                            FromAccountNum = t.FromAccountNum,
                            ToAccountNum = t.ToAccountNum,
                            AccountBalance=t.AccountBalance,
                            FromBankName=t.FromBankName,
                            ToBankName=t.ToBankName,
                            HandlingFees=t.HandlingFees,
                            TransactionMoney=t.TransactionMoney,
                            TransactionTime=t.TransactionTime,
                            TransactionType=t.TransactionType,
                            Remark=t.Remark
                        };
            //篩選日期區間
            query = query.Where(q=>q.TransactionTime>=start).Where(q=>q.TransactionTime<=end);

            //最後呼叫ToList才不會影響效能
            return await query.OrderByDescending(q => q.TransactionTime).ToListAsync();
        }



        public async Task<bool> UpadatePersonalInfoAsync(BankPersonalInfo personalInfo)
        {
            var user = await _context.BankPersonalInfo.Where(b => b.CustomerId == personalInfo.CustomerId).FirstOrDefaultAsync();
            if (user !=null)
            {
                user.UserName = personalInfo.UserName;
                user.Phone=personalInfo.Phone;
                user.Email=personalInfo.Email;
                user.Mobile = personalInfo.Mobile;
                user.Address = personalInfo.Address;
                user.ModifyDate = DateTime.Now;
                //存入DB
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdateBalanceAsync(BankAccount bankAccount)
        {
            var user = await _context.BankAccount.Where(b=>b.AccountNum==bankAccount.AccountNum).FirstOrDefaultAsync();
            if (user !=null)
            {
                user.AccountBalance =bankAccount.AccountBalance;
                user.ModifyDate = bankAccount.ModifyDate;
                //存入DB
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<BankAccount> GetAccountUseNumAsync(string AccountNum)
        {
            var entity = await _context.BankAccount.Where(b=>b.AccountNum==AccountNum).FirstOrDefaultAsync();
            if (entity==null)
            {
                return null;
            }
            return entity;
        }
    }
}
