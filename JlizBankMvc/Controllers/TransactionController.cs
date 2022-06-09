using JlizBankEntity;
using JlizBankEntity.EfServices;
using JlizBankEntity.JlizEntity;
using JlizBankMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JlizBankMvc.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ICustomerService _customerService;

        public TransactionController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ShowTransactionDetails(DateTime start, DateTime end)
        {
            if (start == DateTime.MinValue || end == DateTime.MinValue)
            {
                ViewBag.errorMsg = "Please select Start date and End date!";
                return View("Index");
            }
            if (start > end)
            {
                ViewBag.errorMsg = "Start date must be earlier or equal than End date!";
                return View("Index");
            }
            ViewBag.start = start.ToShortDateString();
            ViewBag.end = end.ToShortDateString();
            var bankAccount = await _customerService.GetAccountAsync(User.FindFirstValue(ClaimTypes.GivenName));

            var query = await _customerService.GetTransactionAsync(bankAccount.AccountNum, start, end);

            var data = new List<TransactionViewModel>();
            foreach (var item in query)
            {
                data.Add(new TransactionViewModel()
                {
                    //AccountNum = item.AccountNum,
                    FromAccountNum = item.FromAccountNum,
                    ToAccountNum=item.ToAccountNum,
                    AccountBalance = item.AccountBalance,
                    CustomerId = item.CustomerId,
                    FromBankName = item.FromBankName,
                    HandlingFees = item.HandlingFees,
                    Remark = item.Remark,
                    ToBankName = item.ToBankName,
                    TransactionMoney = item.TransactionMoney,
                    TransactionTime = item.TransactionTime,
                    TransactionType = item.TransactionType
                });
            }
            return View("Index",data);
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SpecificTransactionDetails(string radioDate)
        {
         
            var query = new List<TransactionInfo>();
            double duration = 0;
            switch (radioDate)
            {
                case "1d":
                    duration = -1;
                    break;
                case "1w":
                    duration = -7;
                    break;
                case "1m":
                    duration = -31;
                    break;
                case "3m":
                    duration = -92;
                    break;
                case "6m":
                    duration =-183 ;
                    break;
            }
            var user = await _customerService.GetAccountAsync(User.FindFirstValue(ClaimTypes.GivenName));
            query = await _customerService.GetTransactionAsync(user.AccountNum, DateTime.Now.AddDays(duration), DateTime.Now);
            ViewBag.start = DateTime.Now.AddDays(duration).ToShortDateString();
            ViewBag.end = DateTime.Now.ToShortDateString();
            var data = new List<TransactionViewModel>();
            foreach (var item in query)
            {
                data.Add(new TransactionViewModel()
                {
                    FromAccountNum=item.FromAccountNum,
                    ToAccountNum=item.ToAccountNum,
                    AccountBalance = item.AccountBalance,
                    CustomerId = item.CustomerId,
                    FromBankName = item.FromBankName,
                    HandlingFees = item.HandlingFees,
                    Remark = item.Remark,
                    ToBankName = item.ToBankName,
                    TransactionMoney = item.TransactionMoney,
                    TransactionTime = item.TransactionTime,
                    TransactionType = item.TransactionType
                });
            }
            return View("Index", data);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> BalanceView()
        {
            var loginAccount = User.FindFirstValue(ClaimTypes.GivenName);
            var user = await _customerService.GetAccountAsync(loginAccount);
            RegisterViewModel viewModel=new RegisterViewModel();
            viewModel.AccountBalance=user.AccountBalance.ToString("N0");
            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> TransferMoney()
        {
            var loginAccount = User.FindFirstValue(ClaimTypes.GivenName);
            var user = await _customerService.GetAccountAsync(loginAccount);

            TransactionViewModel viewModel=new TransactionViewModel();
            var bankList= await _customerService.GetAllBank();
            //將所有銀行新增至List
            viewModel.AllBanks = new List<string>();
            foreach (var item in bankList)
            {
                string IdName = string.Empty;
                IdName = item.BankId + item.BankName;
                viewModel.AllBanks.Add(IdName);
            }
            viewModel.AccountBalance= user.AccountBalance;
            viewModel.FromAccountNum = user.AccountNum;
            viewModel.FromBankName = user.BankId+user.BankName;
            return View(viewModel);
        }
        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> TransferMoney(TransactionViewModel viewModel)
        {
            var loginAccount = User.FindFirstValue(ClaimTypes.GivenName);
            var user = await _customerService.GetAccountAsync(loginAccount);

            viewModel.AccountBalance = user.AccountBalance;
            viewModel.FromAccountNum = user.AccountNum;
            viewModel.FromBankName = user.BankId + user.BankName;

            //TransactionViewModel viewModel = new TransactionViewModel();
            var bankList = await _customerService.GetAllBank();

            //將所有銀行新增至List
            viewModel.AllBanks = new List<string>();
            foreach (var item in bankList)
            {
                string IdName = string.Empty;
                IdName = item.BankId + item.BankName;
                viewModel.AllBanks.Add(IdName);
            }

            //檢查轉帳金額
            if (viewModel.TransactionMoney<1 || viewModel.TransactionMoney>50000 || (viewModel.TransactionMoney > viewModel.AccountBalance))
            {
                ViewBag.Wrong = "Please check the amount of transfer money!";
                return View(viewModel);
            }

            //檢查是否存在銀行
            var existBank=viewModel.AllBanks.Find(b=>b==viewModel.ToBankName);
            if (existBank ==null)
            {
                ViewBag.Wrong = "Please check the Bank Name!";
                return View(viewModel);
            }

            //檢查收款人是否存在
            var receiveUser = await _customerService.GetAccountUseNumAsync(viewModel.ToAccountNum);
            if (receiveUser == null)
            {
                ViewBag.wrong = "The account number of the receiver doesn't exist, please check again!";
                return View(viewModel);
            }
            //發送Email驗證碼
            var personalInfo = await _customerService.GetPersonalInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var emailService=new SendCodeMailService();
            //string code = emailService.GetVerificationCode(personalInfo.Email);
            string code = "123";
            HttpContext.Session.SetString("TransferCode", code);
            if (viewModel.TransferCode==null && string.IsNullOrEmpty(viewModel.TransferCode) )
            {
                return View(viewModel);
            }
            if (HttpContext.Session.GetString("TransferCode") != viewModel.TransferCode)
            {
                ViewBag.Wrong = "Please check the Vefify code!";
                return View(viewModel);
            }
            //Update帳戶餘額
            if (user.AllertAccount==true)
            {
                viewModel.HandlingFees = 15;
            }
            viewModel.HandlingFees = 0;
            user.AccountBalance= (decimal)(user.AccountBalance-viewModel.TransactionMoney-viewModel.HandlingFees);
            user.ModifyDate = DateTime.Now;
            await _customerService.UpdateBalanceAsync(user);

            //匯錢產生交易紀錄
            TransactionRecordsDetails transferDetails = new TransactionRecordsDetails();
            transferDetails.TransactionNum=Guid.NewGuid();
            transferDetails.TransactionTime=DateTime.Now;
            transferDetails.FromAccountNum = viewModel.FromAccountNum;
            transferDetails.ToAccountNum = viewModel.ToAccountNum;
            transferDetails.FromBankId = viewModel.FromBankName.Substring(0,3);
            transferDetails.FromBankName = viewModel.FromBankName.Substring(3);
            transferDetails.TransactionType = "Transfer";
            transferDetails.TransactionMoney=viewModel.TransactionMoney;
            transferDetails.ToBankId = viewModel.ToBankName.Substring(0,3);
            transferDetails.ToBankName=viewModel.ToBankName.Substring(3);
            transferDetails.HandlingFees = 15M;
            transferDetails.AccountBalance = user.AccountBalance;
            transferDetails.Remark = viewModel.Remark;

   
            await _customerService.CreateTransactionRecordsAsync(transferDetails);

            //Update收款人餘額 
            receiveUser.AccountBalance = receiveUser.AccountBalance + viewModel.TransactionMoney;
            receiveUser.ModifyDate = transferDetails.TransactionTime;
            await _customerService.UpdateBalanceAsync(receiveUser);

            //收錢產生交易紀錄 
            var receiveDetails = transferDetails;
            receiveDetails.TransactionNum= Guid.NewGuid();
            receiveDetails.AccountBalance = receiveUser.AccountBalance;
            receiveDetails.TransactionType = "Receive";

            await _customerService.CreateTransactionRecordsAsync(receiveDetails);

            ViewBag.Success = "Successful transaction!";
            HttpContext.Session.Remove("TransferCode");
            return View("ShowTransactionResult", viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult ShowTransactionResult(TransactionViewModel viewModel)
        {
            return View();
        }
    }
}
