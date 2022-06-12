# Welcome to JlizBank
<img src="/ImgForIntro/Home.png"/>

### Built with
<ul>
	<li><a href='https://visualstudio.microsoft.com/zh-hant/vs/'>Visual Studio 2022</a></li>
	<li><a href='https://docs.microsoft.com/zh-tw/dotnet/core/whats-new/dotnet-core-3-1'>.NET Core 3.1</a></li>
</ul>

### NuGet Package
<ul>
	<li><a href='https://docs.microsoft.com/zh-tw/ef/core/'>Microsoft.EntityFrameworkCore, .Relational, .SqlServer (3 packages)</a></li>
	<li><a href='https://github.com/tanveery/recaptcha-net'>RecaptchaNet</a></li>
</ul>

### Database
<ul>
    <li><a href='https://docs.microsoft.com/zh-tw/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16'>SSMS</a></li>
	<li><a href='https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools'>EF Core Power Tools-To do Entity Framework</a></li>
</ul>

### Image Sources
<ul>
	<li><a href='https://pixabay.com/'>Pixbay</a></li>
</ul>

## Get Started
#### 1.Register

<ul>
<li>Use regex in the input tag</li>

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
### 2.Login
<img src="/ImgForIntro/Login.png" width="50%" height="50%"/>
<ul>
		<li>Use reCAPTCHA V2 to prevent robots</li>
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
	//reCAPCHA V2≈Á√“
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

### 3.Transfer Money
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

