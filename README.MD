# Welcome to JlizBank

## Overview
This is a simulate Internet banking, which is called JlizBank.<br>
Here, you can create your own account to transfer money, view the balance, transaction details and so on.<br>
The famous singer 海雅谷木 once said JlizBank is very simple and convenient to use.<br>
So what are you waiting for?

<img src="/ImgForIntro/Home.png"/>
<iframe src="/ImgForIntro/JlizBankMvc.wmv"></iframe>



<hr>


### Built with
<ul>
	<li><a href='https://visualstudio.microsoft.com/zh-hant/vs/'>Visual Studio 2022</a></li>
	<li><a href='https://docs.microsoft.com/zh-tw/dotnet/core/whats-new/dotnet-core-3-1'>.NET Core 3.1</a></li>
	<li><a href='https://getbootstrap.com/docs/5.1/getting-started/introduction/'>Bootstrap 5.1.3 & Javascript</a></li>

</ul>

### NuGet Package
<ul>
	<li><a href='https://docs.microsoft.com/zh-tw/ef/core/'>Microsoft.EntityFrameworkCore, .Relational, .SqlServer (3 packages)</a></li>
	<li><a href='https://github.com/tanveery/recaptcha-net'>RecaptchaNet</a></li>
</ul>

### Database & Tools
<ul>
    <li><a href='https://docs.microsoft.com/zh-tw/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16'>SQL Server Management Studio (SSMS)</a></li>
	<li><a href='https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools'>EF Core Power Tools-To do Entity Framework</a></li>
</ul>

### Image Sources
<ul>
	<li><a href='https://pixabay.com/'>Pixbay</a></li>
</ul>

## Get Started
### 1.Prepare the data
<ul>
<li>Use SSMS</li>
<p>Please copy my variable name and data type to let C# easily to use.</p>
<img src="/ImgForIntro/ssms.png" width="50%" height="50%"/>

<li>Use EF Power tools</li>
<img src="/ImgForIntro/ef1.png" width="50%" height="50%"/>

<li>In appsettings.json</li>

```json
{
"ConnectionStrings": { "JlizBank": "Data Source=localhost;Initial Catalog=JlizBank;Persist Security Info=False;User ID=JC;Password=38405200;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;" }
}
```

<li>In startup.cs</li>

```Csharp
 public void ConfigureServices(IServiceCollection services)
{
		//Add context Service
	services.AddDbContext<JlizBankContext>(c=>c.UseSqlServer("name=ConnectionStrings:JlizBank"));
}

```

</ul>

<hr>

### 2.Dependence Injection

<ul>
<li>Create a project-Class Library to store an Interface and a class for following use</li>
</ul>

```CSharp
//Interface ICustomerService
    public interface ICustomerService
    {
        public Task<bool> CreateCustomerAsync(BankPersonalInfo personalInfo, BankAccount account);
        public Task<bool> CreateTransactionRecordsAsync(TransactionRecordsDetails details);
        public Task<BankPersonalInfo> GetPersonalInfoAsync(string CustomerId);
        public Task<BankAccount> GetAccountAsync(string LoginAccount);
		.................................................
	}

// class CustomerService
  public class CustomerService : ICustomerService
    {
        public Task<BankPersonalInfo> GetPersonalInfoAsync(string CustomerId)
        {
            var entity = _context.BankPersonalInfo.Where(b=>b.CustomerId.ToString()==CustomerId).FirstOrDefaultAsync();
            if (entity == null)
            {
                return null;
            }
            return entity;
        }
	}
	..................................................
```

<ul>
<li>In startup.cs</li>
</ul>

```Csharp
 public void ConfigureServices(IServiceCollection services)
{
		//Dependence Injection
         services.AddScoped<ICustomerService, CustomerService>();
}

```
<hr>

### 3.Register

<ul>
<li>Use regex in the input tag in View</li>

```html5
<label>Login Account: </label>
<input class="form-control" type="text" required placeholder="Required" asp-for="LoginAccount" pattern="^(?=.*\d)(?=.*\w)[\d\w]{5,15}$"/>
<div class="errorMsg" style="">5-15 characters, at least one letter and one number!</div>
```

<li>Use Css to show success or fail message</li>
<p></p>
<label>Error Result:</label>
<p></p>
<img src="/ImgForIntro/Error.png" width="400px" height="120px;"/>
<p></p>
<label>Success Result:</label>
<p></p>
<img src="/ImgForIntro/Success.png" width="400px" height="120px;"/>

</ul>

```html5
input[type=text]:valid, input[type=email]:valid, input[type=password]:valid{
        transition:0.2s;
        background-image: url("/Images/valid.png");
        background-size: 20px;
        background-repeat: no-repeat;
        background-position: 2% 50%;
        border-radius:6px;
 }
  input[type=text]:invalid:not(:focus):not(:placeholder-shown), input[type=email]:invalid:not(:focus):not(:placeholder-shown), input[type=password]:invalid:not(:focus):not(:placeholder-shown){
     background:pink;
 }
 input[type=text]:invalid:not(:placeholder-shown) ~ .errorMsg,  input[type=email]:invalid:not(:placeholder-shown) ~ .errorMsg,  input[type=password]:invalid:not(:placeholder-shown) ~ .errorMsg{
         max-height:60px;
         word-wrap:normal;
     }
  input[type=text],   input[type=email], input[type=password], input[type=date]{
      padding:10px 35px;
      border-radius:10px;
  }
    .errorMsg{
        transition:0.2s;
        background-image: url("/Images/Wrong.png");
        background-size: 20px;
        background-repeat: no-repeat;
        background-position: 0px 10px;
        font-size:14px;
      border-radius:6px;
      padding:5px 0 0 25px;
      max-height:0;
      transition:0.4s;
      overflow:hidden;
      color:red;
  }
```
<hr>

### 4.Login
<img src="/ImgForIntro/Login.png" width="50%" height="50%"/>

##### Use reCAPTCHA V2 to prevent robots

<ul><li>In startup.cs</li></ul>

```Csharp
using Recaptcha.Web.Configuration;
//..................
//In the ConfigureServices method
//..................
public void ConfigureServices(IServiceCollection services){
//..................
	RecaptchaConfigurationManager.SetConfiguration(Configuration);
}
```
<ul><li>In appsettings.json</li></ul>

```json
{
  "RecaptchaSiteKey": "Your RecaptchaSiteKey",
  "RecaptchaSecretKey": "Your RecaptchaSecretKey"
}
```

<ul><li>In the LoginController</li></ul>

```Csharp
//import namespace
using Recaptcha.Web;
using Recaptcha.Web.Mvc;
//........................
[HttpPost]
[AutoValidateAntiforgeryToken]
public async Task<IActionResult> VerifyUser(LoginViewModel model)
{
	//reCAPCHA V2 Verify
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
}
```
<ul><li>In the View-Render the reCAPTCHA</li></ul>

```html5
	@Html.RecaptchaApiScript()
	@Html.RecaptchaWidget(renderApiScript:false)
```
<hr>

### 5.Authentication with Cookies

<ul>
<li>In startup.cs</li>

```Csharp
//import namespace
using Microsoft.AspNetCore.Authentication.Cookies;
//...............
//In the method of ConfigureServices
  public void ConfigureServices(IServiceCollection services)
{
	 services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o =>
	 {
		 o.LoginPath = new PathString("/Login/Index");
		 o.LogoutPath = new PathString("/Login/Logout");
		 o.ExpireTimeSpan = TimeSpan.FromMinutes(10);
		 o.SlidingExpiration = true;
	 });
}
//In the method of Configure
 public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
 {
 //..................................................................................
	 app.UseAuthentication(); //Add this method before app.UseAuthorization()
	 app.UseAuthorization();
 }
```
<li>In LoginController</li>

```Csharp
 [HttpPost]
 [AutoValidateAntiforgeryToken]
 public async Task<IActionResult> VerifyUser(LoginViewModel model)
 {
 //...............................................................................
	 //When we authentucate the identity, save the info to Claims for following functions
	 var personalInfo = await _customer.GetPersonalInfoAsync(user.CustomerId.ToString());

	Claim[] claims = new[] { new Claim(ClaimTypes.NameIdentifier, user.CustomerId.ToString()), new Claim(ClaimTypes.GivenName, user.LoginAccount), new Claim(ClaimTypes.Name, personalInfo.UserName) };
	ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
	ClaimsPrincipal principal = new ClaimsPrincipal(identity);

	await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
 }
```
</ul>

<hr>

### 6.Transfer Money
<img src="/ImgForIntro/Transfer.png" width="50%" height="50%"/>
<ul>
		<li>Use Smtp to send the verification code</li>
        <ul><li>In startup.cs</li></ul>

```Csharp
public class SendCodeMailService
{
	public string GetVerificationCode(string Email)
	{
	//Generate the random code
	string codes = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
	Random random = new Random();
	string verifyCode = string.Empty;
	for (int i = 0; i < 8; i++)
		{
		int index = random.Next(codes.Length);
		verifyCode += codes[index];
		}
	//Send Email
	using (MailMessage mailMessage = new MailMessage())
	{
		//Set receiver
		mailMessage.From = new MailAddress("jerry384052@gmail.com");
		//Receiver
		mailMessage.To.Add(Email);
		mailMessage.Subject = "Jliz Internet Bank-Reset Password--VerificationCode";
		mailMessage.Body = $"Your code are {verifyCode}";

	//Use SMTP to send Email
	using (SmtpClient smtp = new SmtpClient())
	{
		smtp.Credentials = new NetworkCredential("jerry384052@gmail.com", "xiwjmiggmzfbodvr");
		smtp.Host = "smtp.gmail.com";
		smtp.Port = 25;
		smtp.EnableSsl = true;
		smtp.Send(mailMessage);
	}
}
		return verifyCode;
	}

}
```
<hr>

### Other functions
<ul>
<li>Balance review</li>
<p></p>
<img src="/ImgForIntro/balance.png" width="50%" height="50%"/>
<li>Transaction details</li>
<p></p>
<img src="/ImgForIntro/transaction.png" width="50%" height="50%"/>
<li>Modify your personal infomation</li>
<p></p>
<img src="/ImgForIntro/personalinfo.png" width="50%" height="50%"/>
<li>Modify your password</li>
<p></p>
<img src="/ImgForIntro/modifyPwd.png" width="50%" height="50%"/>
<li>Forget your password</li>
<p></p>
<img src="/ImgForIntro/forgetPwd.png" width="50%" height="50%"/>
</ul>
