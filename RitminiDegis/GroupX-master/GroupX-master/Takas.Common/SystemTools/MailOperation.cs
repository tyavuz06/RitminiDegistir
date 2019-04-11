using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;


namespace Takas.Common
{
	public class MailOperations
	{
		public static async Task<bool> SendMailForSignUp(string subject, string body, string to)
		{
			string[] tof = to.Split(',');

			string smtpClient = SystemConstants.SystemConstannts.smtpClient;
			int smtpPort = SystemConstants.SystemConstannts.smtpPort;
			string displayName = SystemConstants.SystemConstannts.displayName;

			string SmtpCredentialUserName = SystemConstants.SystemConstannts.SmtpCredentialUserName;
			string SmtpCredentialPassword = SystemConstants.SystemConstannts.SmtpCredentialPassword;

			return await sendMail(smtpClient, smtpPort, new System.Net.NetworkCredential(SmtpCredentialUserName, SmtpCredentialPassword), displayName, tof, subject, body);
		}

		public static async Task<bool> sendMail(string host, int port, NetworkCredential senderInfo, string senderdisplayName,
							 string[] to, string subject, string body)
		{


			var mail = new MailMessage();
			//MailAddress bcc = new MailAddress("urenkanaatli@hotmail.com");
			//mail.Bcc.Add(bcc);
		//	mail.Headers.Add(SystemConstants.SystemConstannts.apiKey,SystemConstants.SystemConstannts.apiValue);

			mail.From = new MailAddress(senderInfo.UserName, senderdisplayName);


			foreach (var item in to)
			{
				mail.To.Add(item);
			}

			mail.Subject = subject;
			mail.IsBodyHtml = true;
			mail.Body = body;
			mail.IsBodyHtml = true;

			var smtp = new SmtpClient
			{
				Host = host,
				Port = port,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(senderInfo.UserName, senderInfo.Password)
			};


			try
			{
				smtp.Send(mail);
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}


	}
}