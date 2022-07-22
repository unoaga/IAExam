using IAExamData.Dtos;
using IAExamData.Entities;
using IAExamData.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using static IAExamData.Enums.OrdersEnums;
using static IAExamData.Enums.StatusCodeResponse;

namespace IAExamLogic.IServices
{
	public interface IOrderService
	{
		ResponseService Add(OrderVM order);

		ResponseService Cancel(int id);

		ResponseService Get(string seach, Status status);

		ResponseService Get(int id);

		ResponseService GetStatus();
		ResponseService Update(OrderVM order);

		ResponseService NextStatus(int id);

	}
}
