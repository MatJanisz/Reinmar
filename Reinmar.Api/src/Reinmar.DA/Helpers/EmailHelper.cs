using Reinmar.DA.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Reinmar.DA.Helpers
{
	public class EmailHelper : IEmailHelper
	{
		public void SendEmail(string receiverEmail, string packageName, string packageStatus)
		{
			var fromAddress = new MailAddress("ReinmarAppDelivery@gmail.com");
			var fromPassword = "Reinmar123!";
			var toAddress = new MailAddress(receiverEmail);

			string subject = "Delivery status change";
			StringBuilder body = new StringBuilder("<div>Hello {email}," +
				"<br/><br/> Your package: {packageName} just has changed status to: {packageStatus}." +
				"<br/><br/>Best regards,<br/>Reinmar Team</div>");
			body = body.Replace("{email}", receiverEmail);
			body = body.Replace("{packageName}", packageName);
			body = body.Replace("{packageStatus}", packageStatus);

			System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

			};

			using (var message = new MailMessage(fromAddress, toAddress)
			{
				Subject = subject,
				Body = body.ToString(),
				IsBodyHtml = true,
			})

			try { smtp.Send(message); }
				catch { }
		}
	}
}
