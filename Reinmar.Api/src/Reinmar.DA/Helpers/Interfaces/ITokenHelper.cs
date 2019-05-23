using Reinmar.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reinmar.DA.Helpers
{
	public interface ITokenHelper
	{
		string CreateToken(string email);
	}
}
