using IAExamData.Entities;
using IAExamLogic.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; 
using System.Threading.Tasks;

namespace IaExamApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : BaseController
	{
		private readonly ILogger<ProductController> _logger;
		private readonly IProductService _productService;
		public ProductController(ILogger<ProductController> logger, IProductService productService)
		{
			_logger = logger;
			_productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> Get(string search)
		{
			
			return ResponseStatusCode(_productService.Get(search));
		}


		[HttpGet("getbyid")]
		public async Task<IActionResult> Get(int id)
		{
			return ResponseStatusCode(_productService.Get(id));
		}

		[HttpPost]
		public async Task<IActionResult> Post( [FromBody]Product product)
		{
			return ResponseStatusCode(_productService.Add(product));
		}


		[HttpPut]
		public async Task<IActionResult> Update([FromBody]Product product)
		{
			return ResponseStatusCode(_productService.Update(product));
		}

		[HttpPut("addtostock")]
		public async Task<IActionResult> AddToStock(int id, int quantity)
		{
			return ResponseStatusCode(_productService.AddToStock(id, quantity));
		}


		[HttpDelete]
		public async Task<IActionResult> Cancel(int id)
		{
			return ResponseStatusCode(_productService.Delete(id));
		}
	}
}
