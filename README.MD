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
<ol>
	<li>Register</li>
	<ul>
		<li>Use regex in the input tag</li>

```
<label>Login Account: </label>
<input class="form-control" type="text" required placeholder="Required" asp-for="LoginAccount" pattern="^(?=.*\d)(?=.*\w)[\d\w]{5,15}$"/>
<div class="errorMsg" style="">5-15 characters, at least one letter and one number!</div>
```

<li>Use Css to show success or fail message</li>

```
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
<label>Error Result:</label>
<p></p>
<img src="/ImgForIntro/Error.png" width="400px" height="120px;"/>

<label>Success Result:</label>
<p></p>
<img src="/ImgForIntro/Success.png" width="400px" height="120px;"/>

	</ul>
</ol>
