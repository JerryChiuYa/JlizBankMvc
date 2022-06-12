using JlizBankEntity.EfServices;
using JlizBankEntity.JlizEntity;
using JlizBankMvc.Models;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JlizBankMvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICustomerService _customer;

        public LoginController(ICustomerService customer)
        {
            _customer = customer;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> VerifyUser(LoginViewModel model)
        {

            //reCAPCHA V2驗證
            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
            if (string.IsNullOrEmpty(recaptchaHelper.Response))
            {
                TempData["RecaptchaMsg"] = "Please click the above botton to verify !";
                return View("Index");
            }
            RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
            if (!recaptchaResult.Success)
            {
                ModelState.AddModelError("", "Incorrect captcha answer!");
                TempData["RecaptchaMsg"] = "Catch you robot!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (model == null || string.IsNullOrEmpty(model.LoginAccount) || string.IsNullOrEmpty(model.Password))
                {
                    return RedirectToAction("Index", model);
                }

                var user = await _customer.GetAccountAsync(model.LoginAccount);
                if (user == null)
                {
                    TempData["LoginInfo"] = "The account or password is wrong, please fill in again!";
                    return RedirectToAction("Index", model);
                }


                var hashPwd = new HashService().GetHashPwd(model.Password, user.CustomerId.ToString().ToUpper());
                if (hashPwd != user.HashPassword)
                {
                    TempData["LoginInfo"] = "The account or password is wrong, please fill in again!";
                    return RedirectToAction("Index", model);
                }

                
                //Url.IsLocalUrl("外部網站");

                //帳密驗證成功,將資訊存入Claim
                var personalInfo = await _customer.GetPersonalInfoAsync(user.CustomerId.ToString());

                Claim[] claims = new[] { new Claim(ClaimTypes.NameIdentifier, user.CustomerId.ToString()), new Claim(ClaimTypes.GivenName, user.LoginAccount), new Claim(ClaimTypes.Name, personalInfo.UserName) };
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            //驗證帳號是否存在DB
            var existAccount = _customer.GetAccountAsync(viewModel.LoginAccount);
            if (existAccount!=null)
            {
                ViewBag.wrong = "This account already exists in the system!";
                return View();
            }
            var personalInfo = new BankPersonalInfo();
            personalInfo.CustomerId = Guid.NewGuid();
            personalInfo.UserName = viewModel.UserName;
            personalInfo.Birthday = viewModel.Birthday;
  

            personalInfo.Phone = viewModel.Phone;
            personalInfo.Mobile = viewModel.Mobile;
            personalInfo.Email = viewModel.Email;
            personalInfo.Address = viewModel.Address;
            personalInfo.IdentityNum = viewModel.IdentityNum;
            personalInfo.InitDate = DateTime.Now;

            var bankInfo = new BankAccount();
            bankInfo.CustomerId = personalInfo.CustomerId;
            bankInfo.AccountBalance = 0;
            bankInfo.LoginAccount = viewModel.LoginAccount;
            var hashService = new HashService();
            bankInfo.HashPassword = hashService.GetHashPwd(viewModel.Password, personalInfo.CustomerId.ToString());
            bankInfo.InitDate = personalInfo.InitDate;

            //銀行帳號隨機產生,不得與原有帳號重複
            Random random=new Random();
            int accountNum;
            while (true)
            {
                accountNum = random.Next(10000000, 99999999);
                var existAcc = await _customer.GetAccountUseNumAsync(accountNum.ToString());
                if (existAcc == null)
                {
                    break;
                }
            }
            bankInfo.AccountNum = accountNum.ToString();

            //數位帳戶 & 網路銀行皆有分行
            bankInfo.BankId = "101";
            bankInfo.BankName = "傑力士台北分行";

            await _customer.CreateCustomerAsync(personalInfo, bankInfo);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
