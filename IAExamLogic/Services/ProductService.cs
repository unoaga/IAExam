using IAExamData.Data;
using IAExamData.Dtos;
using IAExamData.Entities;
using IAExamData.Enums;
using IAExamLogic.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static IAExamData.Enums.OrdersEnums;
using static IAExamData.Enums.StatusCodeResponse;

namespace IAExamLogic.Services
{
	public class ProductService : IProductService
	{
		private readonly IDataContext _dataContext;
		public ProductService(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public ResponseService Add(Product product)
		{
			try
			{
				++_dataContext.CurrentProductId;
				product.Id = _dataContext.CurrentProductId;
				_dataContext.Products.Add(product);
				return new ResponseService { Data = product, HttpCode = HttpCode.Ok }; 
			}
			catch (Exception e)
			{
				return new ResponseService { Data = e.Message, HttpCode = HttpCode.InternalError };
			}
		
		}
 

		public ResponseService Delete(int id)
		{
			try
			{
				var element = _dataContext.Products.FirstOrDefault(x => x.Id == id);
				element.Deleted = true;
				return new ResponseService { Data = true, HttpCode = HttpCode.Ok };
			}
			catch (Exception e)
			{
				return new ResponseService { Data = e.Message, HttpCode = HttpCode.InternalError };
			}
		
		}

		public ResponseService Get(string search)
		{
			try
			{
				search = search ?? "";
				return new ResponseService {
					Data = _dataContext.Products.Where(x => x.Name.Contains(search) && !x.Deleted).ToHashSet(), 
					HttpCode = HttpCode.Ok }; 
			}
			catch (Exception e)
			{
				return new ResponseService { Data = e.Message, HttpCode = HttpCode.InternalError };
			}

		}

		public ResponseService Get(int id)
		{
			try
			{ 
				return new ResponseService
				{
					Data = _dataContext.Products.FirstOrDefault(x => x.Id == id),
					HttpCode = HttpCode.Ok
				};
			}
			catch (Exception e)
			{
				return new ResponseService { Data = e.Message, HttpCode = HttpCode.InternalError };
			}

		}

 

		public ResponseService Update( Product product)
		{
			try
			{
				var element = _dataContext.Products.FirstOrDefault(x => x.Id == product.Id);

				element.Name = product.Name;
				element.ImgUrl = product.ImgUrl;
				element.Price = product.Price;
				return new ResponseService { Data = element, HttpCode = HttpCode.Ok };
			}
			catch (Exception e)
			{
				return new ResponseService { Data = e.Message, HttpCode = HttpCode.InternalError };
			}
		
		}

		public ResponseService AddToStock(int id, int quantity)
		{
			try
			{
				var element = _dataContext.Products.FirstOrDefault(x => x.Id == id);

				element.Stock += quantity;
				return new ResponseService { Data = element, HttpCode = HttpCode.Ok };
			}
			catch (Exception e)
			{
				return new ResponseService { Data = e.Message, HttpCode = HttpCode.InternalError };
			}
		
		}
	}
}
