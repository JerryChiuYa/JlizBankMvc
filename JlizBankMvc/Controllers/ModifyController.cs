using JlizBankEntity.EfServices;
using JlizBankEntity.JlizEntity;
using JlizBankMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JlizBankMvc.Controllers
{
    public class ModifyController : Controller
    {
        private readonly ICustomerService _customerService;


        public ModifyController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index()
        {
            var cusid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var personalInfo = await _customerService.GetPersonalInfoAsync(cusid);
            var viewModel = new RegisterViewModel();
            viewModel.UserName = personalInfo.UserName;
            viewModel.Address = personalInfo.Address;
            viewModel.Phone = personalInfo.Phone;
            viewModel.Email = personalInfo.Email;
            viewModel.Mobile= personalInfo.Mobile;
            viewModel.IdentityNum = personalInfo.IdentityNum;

            viewModel.LoginAccount = User.FindFirstValue(ClaimTypes.GivenName);

            return View(viewModel);
        }
        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public IActionResult ModifyPersonalInfoGet(RegisterViewModel viewModel)
        {
            return View("ModifyPersonalInfo", viewModel);
        }
        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ModifyPersonalInfo(RegisterViewModel viewModel)
        {
            var custid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var personalInfo = new BankPersonalInfo();
            personalInfo.CustomerId = Guid.Parse(custid);
            personalInfo.UserName = viewModel.UserName;
            personalInfo.Address = viewModel.Address;
            personalInfo.Phone = viewModel.Phone;
            personalInfo.Email = viewModel.Email;
            personalInfo.Mobile = viewModel.Mobile;

            await _customerService.UpadatePersonalInfoAsync(personalInfo);
            ViewBag.ModifyMsg = "Update Success!";
            return View("ModifyPersonalInfo", viewModel);
        }
        [HttpGet]
        [Authorize]
        public IActionResult ModifyPassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ModifyPassword(ChangePwdViewModel viewModel)
        {
            var loginAccount = User.FindFirstValue(ClaimTypes.GivenName);
            var user = await _customerService.GetAccountAsync(loginAccount);

            var inputOldPwd = new HashService().GetHashPwd(viewModel.OldPwd, user.CustomerId.ToString());
            if (inputOldPwd !=user.HashPassword)
            {
                ViewBag.WrongMsg = "Old password is wrong, please fill in again!";
                return View();
            }
            var newPwd= new HashService().GetHashPwd(viewModel.NewPwd, user.CustomerId.ToString());
            if (user.HashPassword==newPwd)
            {
                ViewBag.WrongMsg = "New password cannot be the same with the old password!";
                return View();
            }
            user.HashPassword = newPwd;
            await _customerService.ChangePassword(user);
            ViewBag.ChangePwd = "Update Password Success!";
            return View();
        }
        
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ForgetPassword(ResetPwdViewModel viewModel)
        {
            var account= await _customerService.GetAccountAsync(viewModel.LoginAccount);
            //驗證帳號 & Email是否存在DB
            if (account == null)
            {
                TempData["IdWrongMsg"] = "The account doesn't exist in system, please check again!";
                return View();
            }
            var user = await _customerService.GetPersonalInfoAsync(account.CustomerId.ToString());
            if (user.Email != viewModel.Email)
            {
                TempData["IdWrongMsg"] = "The email doesn't exist in system, please check again!";
                return View();
            }

            //寄送mail驗證碼
            var code = new ResetPwdMailService().GetVerificationCode(viewModel.Email);
            HttpContext.Session.SetString("verifyCode", code);
            //記錄登入帳號
            HttpContext.Session.SetString("LoginAccount", viewModel.LoginAccount);
            
            TempData["IdMsg"] = "The Verification code had been sent to your Email! Please fill in the code within 5 minutes!";
            return View("ForgetPassword", viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public  IActionResult VerifyCodeResetPwd(ResetPwdViewModel viewModel)
        {
            if (HttpContext.Session.GetString("verifyCode") != viewModel.InputVerificationCode)
            {
                TempData["CodeWrongMsg"] = "Verification Code is wrong, please check again!";
                return View("ForgetPassword", viewModel);
            }
            
            return View("ModifyPwdWithoutOld");
        }
       [HttpPost]
       [AutoValidateAntiforgeryToken]
       public async Task<IActionResult> ModifyPwdWithoutOld(ResetPwdViewModel viewModel)
        {
            var LoginAccoint = HttpContext.Session.GetString("LoginAccount");
            var user = await _customerService.GetAccountAsync(LoginAccoint);
            user.HashPassword = new HashService().GetHashPwd(viewModel.NewPwd, user.CustomerId.ToString());
            await _customerService.ChangePassword(user);

            //更改完密碼即移除Session
            HttpContext.Session.Remove("LoginAccount");
            HttpContext.Session.Remove("verifyCode");

            return RedirectToAction("Index", "Login");
        }
    }
}
