using System;
using System.Net;
using System.Net.Mail;

namespace JlizBankMvc.Models
{
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
					//需要向google申請密碼
					smtp.Credentials = new NetworkCredential("jerry384052@gmail.com", "xiwjmiggmzfbodvr");
					smtp.Host = "smtp.gmail.com";
					smtp.Port = 587;
					smtp.EnableSsl = true;
					smtp.Send(mailMessage);
				}
			}
			return verifyCode;
		}

	}
}



