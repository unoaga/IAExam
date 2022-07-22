using System;
using System.Collections.Generic;
using System.Text;

namespace IAExamData.Enums
{
	public class StatusCodeResponse
	{
		public enum  HttpCode
		{
			Ok = 200,
			BadRequest = 400,
			NotFound = 404,
			InternalError = 500 
		}
	}
}
