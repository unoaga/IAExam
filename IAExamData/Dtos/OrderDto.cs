using System;
using System.Collections.Generic;
using System.Text;

namespace IAExamData.Dtos
{
	public class OrderDto
	{
		public OrderDto()
		{
			OrderProducts = new HashSet<OrderProductDto>();
		}
		public string Key { get; set; }

		public string Name { get; set; }
		public string Comments { get; set; }
		public DateTime OrderDateTime { get; set; }

		public Enums.OrdersEnums.Status Status { get; set; }
		public string StatusName { get; set; }
		public ICollection<OrderProductDto> OrderProducts { get; set; }
	}
}
