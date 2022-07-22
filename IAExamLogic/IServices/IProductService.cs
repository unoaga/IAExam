using IAExamData.Dtos;
using IAExamData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static IAExamData.Enums.OrdersEnums;

namespace IAExamLogic.IServices
{
	public interface IProductService
	{
		ResponseService Add(Product order);

		ResponseService Delete(int id);

		ResponseService Get(string seach);

		ResponseService Get(int id);

		ResponseService Update( Product order);

		ResponseService AddToStock(int id, int quantity);
	}
}
