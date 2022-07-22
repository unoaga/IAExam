using IAExamData.Data;
using IAExamData.Dtos;
using IAExamData.Entities;
using IAExamData.Enums;
using IAExamData.ViewModels;
using IAExamLogic.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static IAExamData.Enums.OrdersEnums;
using static IAExamData.Enums.StatusCodeResponse;

namespace IAExamLogic.Services
{
	public class OrderService : IOrderService
	{
		private readonly IDataContext _dataContext;
		public OrderService(IDataContext dataContext) 
		{
			_dataContext = dataContext;
		}
		public ResponseService Add(OrderVM order)
		{
			try
			{
				var products = _dataContext.Products.ToList();
				var (validStock, errors) = CheckOnStock(products, order);
				if (validStock)
				{
					float total = 0f;
					++_dataContext.CurrentOrderId;
					var newOrder = new Order
					{
						Id = _dataContext.CurrentOrderId,
						Name = order.Name,
						OrderDateTime = DateTime.UtcNow,
						Status = Status.Pending,
						Comments = order.Comments,
						OrderProducts = new List<OrderProduct>()
					};

					foreach (var item in order.OrderProducts)
					{
						var product = _dataContext.Products.FirstOrDefault(x => x.Id == item.IdProduct);

						var orderProduct = new OrderProduct
						{
							IdOrder = newOrder.Id, 
							IdProduct = item.IdProduct,
							Quantity = item.Quantity,
							CurrentPriceEachOne = product.Price,
							Subtotal = product.Price * item.Quantity
						};
						product.Stock -= item.Quantity;
						newOrder.OrderProducts.Add(orderProduct);
						total += orderProduct.Subtotal;
					}
					_dataContext.Orders.Add(newOrder);
					
					return Get(newOrder.Id);
				}
				else
				{
					return new ResponseService { Data = errors, HttpCode = HttpCode.BadRequest };
				}
			}
			catch(Exception e)
			{
				return new ResponseService { Data = e.Message, HttpCode = HttpCode.InternalError };
			}
	
		}

		public ResponseService Cancel(int id)
		{
			try
			{
				var element = _dataContext.Orders.FirstOrDefault(x => x.Id == id);
				if (element.Status == Status.Canceled || element.Status == Status.Delivered)
						return new ResponseService { Data = "Is allready canceled or delivered", HttpCode = HttpCode.BadRequest };

				element.Status = Status.Canceled;
				element.OrderProducts.ToList().ForEach(p => {
					var product = _dataContext.Products.FirstOrDefault(x => x.Id == p.IdProduct);
					if (product != null)
					{
						product.Stock += p.Quantity;
					}
				});
				return new ResponseService { Data = true, HttpCode = HttpCode.Ok };
			}
			catch (Exception e)
			{
				return new ResponseService { Data = e.Message, HttpCode = HttpCode.InternalError };
			}

		}

		public ResponseService  Get(string search,  Status status)
		{
			try
			{
				search = search ?? "";
				var products = _dataContext.Products.ToList();
				var orders = _dataContext.Orders.Where(x => x.Name.Contains(search) && x.Status == status)
					.Select(y => new OrderDto
					{
						Key = y.Id.ToString("D5"),
						Name = y.Name,
						OrderDateTime = y.OrderDateTime,
						Status = y.Status,
						Comments = y.Comments,
						StatusName = y.Status.ToString(),
						OrderProducts = (from p in y.OrderProducts.ToList()
										 join s in products on p.IdProduct equals s.Id into g
										 select new OrderProductDto
										 {
											 CurrentPriceEachOne = p.CurrentPriceEachOne, 
											 Quantity = p.Quantity,
											 IdProduct = p.IdProduct,
											 Product = g.Any() ? g.First().Name : ""
										 }
						).ToList()
					}).ToList();
				return  new ResponseService { Data = orders, HttpCode = HttpCode.Ok };  
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
				var products = _dataContext.Products.ToList();
				var order = _dataContext.Orders.FirstOrDefault(x => x.Id == id);
				if (order == null)
					return new ResponseService { Data = "Not Found", HttpCode = HttpCode.NotFound };
				var orderDto = new OrderDto
				{
					Key = order.Id.ToString("D5"),
					Name = order.Name,
					Comments = order.Comments,
					OrderDateTime = order.OrderDateTime,
					Status = order.Status,
					StatusName = order.Status.ToString(),
					OrderProducts = (from p in order.OrderProducts.ToList()
									 join s in products on p.IdProduct equals s.Id into g
									 select new OrderProductDto
									 {
										 CurrentPriceEachOne = p.CurrentPriceEachOne, 
										 Quantity = p.Quantity,
										 IdProduct = p.IdProduct,
										 Product = g.Any() ? g.First().Name : ""
									 }
						).ToList()
				};
				return new ResponseService { Data = orderDto, HttpCode = HttpCode.Ok };
			}
			catch (Exception e)
			{
				return new ResponseService { Data = e.Message, HttpCode = HttpCode.InternalError };
			}

		}

		public ResponseService GetStatus()
		{
			try
			{
				var status = ((Status[])Enum.GetValues(typeof(Status))).Select(c => new EntityBase() { Id = (int)c, Name = c.ToString() }).ToList();
				return new ResponseService { Data = status, HttpCode = HttpCode.Ok };
			}
			catch (Exception e)
			{
				return new ResponseService { Data = e.Message, HttpCode = HttpCode.InternalError };
			}

		}

		public ResponseService NextStatus(int id)
		{
			try
			{
				var element = _dataContext.Orders.FirstOrDefault(x => x.Id == id);
				if (element.Status == Status.Canceled || element.Status == Status.Delivered)
					return new ResponseService { Data = "Is allready canceled or delivered", HttpCode = HttpCode.BadRequest };

				element.Status = element.Status + 1;
				return new ResponseService { Data = id, HttpCode = HttpCode.Ok };
			}
			catch (Exception e)
			{
				return new ResponseService { Data = e.Message, HttpCode = HttpCode.InternalError };
			}
		
		}

		public ResponseService Update(OrderVM order)
		{
			var element = _dataContext.Orders.FirstOrDefault(x => x.Id == int.Parse(order.Key));
			 
		 
			return new ResponseService { Data = element,  HttpCode = HttpCode.Ok };
		}

		private (bool, string) CheckOnStock(List<Product> products,OrderVM order)
		{
			bool result = true; 
			List<string> errors = new List<string>();
			foreach (var item in order.OrderProducts)
			{
				var product = _dataContext.Products.FirstOrDefault(x => x.Id == item.IdProduct);
				if (product == null || product.Stock < item.Quantity)
				{
					result = false;
					if(product.Stock < item.Quantity)
						errors.Add($"There are only {product.Stock} {product.Name} in stock");

				}

			}
			return (result, String.Join(", ", errors)  );
		}
	 
	}
}
