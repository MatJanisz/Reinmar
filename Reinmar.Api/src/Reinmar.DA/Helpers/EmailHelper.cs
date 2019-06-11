using Reinmar.DA.Helpers.Interfaces;
using Reinmar.DA.Models;
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
		public void SendEmail(string receiverEmail, Package package, string packageStatus, string sendingEvent)
		{
			var fromAddress = new MailAddress("ReinmarAppDelivery@gmail.com");
			var fromPassword = "Reinmar123!";
			var toAddress = new MailAddress(receiverEmail);
			string subject;
			StringBuilder body;

			subject = "Delivery status change";
			body = new StringBuilder("<div>Hello {email}," +
				"<br/><br/> Your package: {packageName} just has changed status to: {packageStatus}." +
				"<br/><br/>Best regards,<br/>Reinmar Team</div>");
			body = body.Replace("{email}", receiverEmail);
			body = body.Replace("{packageName}", package.OrderName);
			body = body.Replace("{packageStatus}", packageStatus);

			if (sendingEvent == "addReceiver")
			{
				subject = "Package Sent";
				body = new StringBuilder("<div>Hello {email}," +
					"<br/><br/> Your package: {packageName} just started journey to you. You can track your package using {packageCode} code." +
					"<br/><br/>Best regards,<br/>Reinmar Team</div>");
				body = body.Replace("{email}", receiverEmail);
				body = body.Replace("{packageName}", package.OrderName);
				body = body.Replace("{packageCode}", package.SitId);
			}
			if (sendingEvent == "addSender")
			{
				subject = "Package Sent";
				body = new StringBuilder("<div>Hello {email}," +
					"<br/><br/> Your package: {packageName} just started journey to receiver. You can track your package using {packageCode} code." +
					"<br/><br/>Best regards,<br/>Reinmar Team</div>");
				body = body.Replace("{email}", receiverEmail);
				body = body.Replace("{packageName}", package.OrderName);
				body = body.Replace("{packageCode}", package.SitId);
			}
			else if (sendingEvent == "finalReceiver")
			{
				subject = "Package Arrived";
				body = new StringBuilder("<div>Hello {email}," +
					"<br/><br/> Your package: {packageName} arrived to you. We hope you are satisfied with our service." +
					"<br/><br/>Best regards,<br/>Reinmar Team</div>");
				body = body.Replace("{email}", receiverEmail);
				body = body.Replace("{packageName}", package.OrderName);
			}
			else if (sendingEvent == "finalSender")
			{
				subject = "Package Arrived";
				body = new StringBuilder("<div>Hello {email}," +
					"<br/><br/> Your package: {packageName} arrived to receiver. We hope you are satisfied with our service." +
					"<br/><br/>Best regards,<br/>Reinmar Team</div>");
				body = body.Replace("{email}", receiverEmail);
				body = body.Replace("{packageName}", package.OrderName);
			}
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
