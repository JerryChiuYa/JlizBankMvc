using System;

namespace JlizBankMvc.Models
{
    public class RegisterViewModel
    {
        public Guid CustomerId { get; set; }
        public string IdentityNum { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string AccountBalance { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string LoginAccount { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
    }
}
