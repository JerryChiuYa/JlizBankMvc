using System;
using System.Text;
using System.Security.Cryptography;

namespace JlizBankMvc.Models
{
    public class HashService
    {
        public string GetHashPwd(string Password, string CustomerId)
        {
            var result = string.Empty;
            using (var shaService = new SHA256CryptoServiceProvider())
            {
                var bytes = Encoding.UTF8.GetBytes(Password + CustomerId.ToUpper());
                var hash = shaService.ComputeHash(bytes);
                result = Convert.ToBase64String(hash);

            }
            return result;
        }
    }
}
