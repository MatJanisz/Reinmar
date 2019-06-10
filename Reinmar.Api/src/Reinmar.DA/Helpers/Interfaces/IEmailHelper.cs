using Reinmar.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reinmar.DA.Helpers.Interfaces
{
	public interface IEmailHelper
	{
		void SendEmail(string receiverEmail, Package package, string packageStatus, string sendingEvent);
	}
}
