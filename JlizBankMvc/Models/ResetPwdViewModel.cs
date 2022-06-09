namespace JlizBankMvc.Models
{
    public class ResetPwdViewModel
    {
        public string LoginAccount { get; set; }
        public string Email { get; set; }
        public string InputVerificationCode { get; set; }
        public string NewPwd { get; set; }
        public string CfmPwd { get; set; }

    }
}
