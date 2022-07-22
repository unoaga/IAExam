using System;
using System.Collections.Generic;
using System.Text;
using static IAExamData.Enums.StatusCodeResponse;

namespace IAExamData.Dtos
{
	public class ResponseService
	{
		public object Data { get; set; }
		 

		public HttpCode HttpCode { get; set; }
	}
}
