using IAExamData.Dtos;
using Microsoft.AspNetCore.Mvc;
using static IAExamData.Enums.StatusCodeResponse;

namespace IaExamApi.Controllers
{
	public class BaseController: ControllerBase
	{
		protected IActionResult ResponseStatusCode(ResponseService  value)
		{
			switch (value.HttpCode)
			{
				case  HttpCode.Ok:
					return Ok(value.Data);
				case HttpCode.BadRequest:
					return BadRequest(value.Data);
				case HttpCode.NotFound:
					return NotFound(value.Data);
				default:
					return StatusCode((int)value.HttpCode, value.Data);
			}
			 
		}


		protected IActionResult ResponseStatusCode(object data, HttpCode httpCode)
		{
			switch (httpCode)
			{
				case HttpCode.Ok:
					return Ok(data);
				case HttpCode.BadRequest:
					return BadRequest(data);
				case HttpCode.NotFound:
					return NotFound(data);
				default:
					return StatusCode((int)httpCode, data);
			}

		}
	}
}
