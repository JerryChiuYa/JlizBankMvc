#pragma checksum "C:\Users\USER\source\gitTest\JlizBankMvc\JlizBankMvc\Views\Modify\ModifyPwdWithoutOld.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd0f3defed1277e22a65680741386d5a27a18ee9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Modify_ModifyPwdWithoutOld), @"mvc.1.0.view", @"/Views/Modify/ModifyPwdWithoutOld.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\USER\source\gitTest\JlizBankMvc\JlizBankMvc\Views\_ViewImports.cshtml"
using JlizBankMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\USER\source\gitTest\JlizBankMvc\JlizBankMvc\Views\_ViewImports.cshtml"
using JlizBankMvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd0f3defed1277e22a65680741386d5a27a18ee9", @"/Views/Modify/ModifyPwdWithoutOld.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55c5dda2ffd3f53a356d6cd265d7ece0cab25297", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Modify_ModifyPwdWithoutOld : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JlizBankMvc.Models.ResetPwdViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "password", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Required"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Pwd"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onkeyup", new global::Microsoft.AspNetCore.Html.HtmlString("CheckPwd()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Pwd2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-group"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Modify", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ModifyPwdWithoutOld", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formPwd"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\USER\source\gitTest\JlizBankMvc\JlizBankMvc\Views\Modify\ModifyPwdWithoutOld.cshtml"
  
    ViewData["Title"] = "ModifyPwdWithoutOld";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Fill in your new password</h2>

<style>
           .form-group{
         padding:2% 10% 2% 10%;
         margin:1% 25% 0 25%;
        border-radius:20px;
        background-color:white;
        width:50%;
        box-shadow:0px 0px 5px;
    }
      label{
        font-size:20px;
        font-weight:300;
         font-family: Itim, cursive;
    }
    h2{
        text-align:center;
        color:#3D7878;
        font-size:50px;
        font-weight:bold;
        font-family: Fondamento, cursive;
    }
    input,label,a{
        font-family: Itim, cursive;
    }
    .MyBtn{
        border-radius:10px;
        width:100%;
        margin:auto;
        background-color:#00FFFF;
        box-shadow:2px 2px 4px;
    }
    .MyBtn:hover{
        background-color:#00E3E3;
    }


  input[type=text],   input[type=email], input[type=password]{
      padding:10px 30px;
      border-radius:10px;
      width:400px;
  }
 .errorMsg{
        transition:0.2s;
        background-im");
            WriteLiteral(@"age: url(""/Images/Wrong.png"");
        background-size: 20px;
        background-repeat: no-repeat;
        background-position: 0px 10px;
        font-size:14px;
      padding:5px 0 0 25px;
      max-height:0;
      transition:0.4s;
      overflow:hidden;
      color:red;
  }

           .succuss{
        background-color:#02F78E;
         margin:3% 0 0 3%;
         color:#01814A;
         padding-left:9%;
        background-image: url(""/Images/valid.png"");
        background-size: 20px;
        background-repeat: no-repeat;
        background-position: 2% 8%;
        border-radius:6px;
  }
</style>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd0f3defed1277e22a65680741386d5a27a18ee99054", async() => {
                WriteLiteral("\r\n             <label>New Password: </label>\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bd0f3defed1277e22a65680741386d5a27a18ee99370", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 77 "C:\Users\USER\source\gitTest\JlizBankMvc\JlizBankMvc\Views\Modify\ModifyPwdWithoutOld.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.NewPwd);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <p></p>\r\n\r\n            <label>Confirm New Password: </label>\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bd0f3defed1277e22a65680741386d5a27a18ee911847", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 81 "C:\Users\USER\source\gitTest\JlizBankMvc\JlizBankMvc\Views\Modify\ModifyPwdWithoutOld.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CfmPwd);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

            <div class=""errorMsg"" id=""PwdMsg"">Password are not the same, please fill in again!</div>
            <div class=""errorMsg"" id=""PwdMsg2"">8-15 characters, at least one uppercase letter, one lowercase letter and one number</div>

<script>
        var Pwd=document.getElementById(""Pwd"");
        var Pwd2=document.getElementById(""Pwd2"");
        function PwdWrong(){
               $(""#Pwd"").css({""background-image"": """"});
               $(""#Pwd2"").css({""background-image"": """"});
               $(""#Pwd"").css({""background"": ""pink""});
               $(""#Pwd2"").css({""background"": ""pink""});
               Pwd.setCustomValidity('Please input the asked format!');
               Pwd2.setCustomValidity('Please input the asked format!');
        }
        function PwdCorrect(){
                $(""#Pwd"").css({""background"": ""url('/Images/valid.png')"", ""background-size"": ""20px"", 
                ""background-repeat"":""no-repeat"", ""background-position"": ""5px 12px"", ""transition"":""0.2s""});

          ");
                WriteLiteral(@"      $(""#Pwd2"").css({""background"": ""url('/Images/valid.png')"", ""background-size"": ""20px"", 
                ""background-repeat"":""no-repeat"", ""background-position"": ""5px 12px"", ""transition"":""0.2s""});
                
        }
        function CheckPwd()
        {
           var validate=/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[\da-zA-Z\W]{8,15}$/;

           if(Pwd.value !=Pwd2.value){
                    PwdWrong();
                    $(""#PwdMsg"").css({""max-height"" :""35px""});     
           }
           if(Pwd.value ==Pwd2.value){
               PwdCorrect();
               $(""#Pwd"").css({""background"": """"});
               $(""#Pwd2"").css({""background"": """"});
              $(""#PwdMsg"").css({""max-height"" :""0""});
           }
          if(!Pwd.value.match(validate) || !Pwd2.value.match(validate)){
                    PwdWrong();
                    $(""#PwdMsg2"").css({""max-height"" :""60px""});
                    
          }
          if(Pwd.value.match(validate) && Pwd.value ==Pwd2.value){
   ");
                WriteLiteral(@"           PwdCorrect();
              $(""#PwdMsg"").css({""max-height"" :""0""});
              $(""#PwdMsg2"").css({""max-height"" :""0""});
              Pwd.setCustomValidity('');
              Pwd2.setCustomValidity('');
          }
       
        }
    </script>

            <input type=""submit"" value=""Modify Password"" class=""MyBtn"" onclick=""Wait3s()"">
            <p></p>

            <script>
                function Wait3s(){     
                    var form=document.getElementById('formPwd');
                     setTimeout(function(){},5000);
                    if(form.checkValidity()){
                        document.getElementById('Msg').style.display=""unset"";
                        form.submit();
                  }
               }
            </script>
    <p class=""succuss"" style=""display:none"" id=""Msg"">Modify Password Sucess!</p>
 ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JlizBankMvc.Models.ResetPwdViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
