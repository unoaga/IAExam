using IAExamData.Entities;
using IAExamData.ViewModels;
using IAExamLogic.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; 
using System.Threading.Tasks;
using static IAExamData.Enums.OrdersEnums;

namespace IaExamApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : BaseController
	{
		private readonly ILogger<OrderController> _logger;
		private readonly IOrderService _orderService;
		public OrderController(ILogger<OrderController> logger, IOrderService orderService)
		{
			_logger = logger;
			_orderService = orderService;
		}
		 
		[HttpGet]
		public async Task<IActionResult> Get(string search, Status status)
		{
			return ResponseStatusCode(_orderService.Get(search, status));
		}



		[HttpGet("getbyid")]
		public async Task<IActionResult> Get(int id)
		{
			return ResponseStatusCode(_orderService.Get(id));
		}


		[HttpGet("getstatus")]
		public async Task<IActionResult> GetStatus()
		{
			return ResponseStatusCode(_orderService.GetStatus());
		}

	  
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] OrderVM order)
		{ 
			return ResponseStatusCode(_orderService.Add(order)); 
		}


		 

		[HttpPut("nextStep")]
		public async Task<IActionResult> NextStatus(int id)
		{
			return ResponseStatusCode(_orderService.NextStatus(id));
		}

		[HttpDelete]
		public async Task<IActionResult> Cancel(int id)
		{
			return ResponseStatusCode(_orderService.Cancel(id));
		}
	}
}
