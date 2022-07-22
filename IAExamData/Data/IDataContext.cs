using IAExamData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAExamData.Data
{
	public interface IDataContext
	{
		 HashSet<Order> Orders { get; set; }
		 HashSet<Product> Products { get; set; }

		int CurrentOrderId { get; set; }

		int CurrentProductId { get; set; }
	}
}
