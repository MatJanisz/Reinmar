using System;
using System.Collections.Generic;
using System.Text;

namespace Reinmar.DA.Interfaces
{
	public interface IPasswordHelper
	{
		string EncryptPassword(string password);
	}
}
