using System;
using System.Collections.Generic;
using System.Text;

namespace IAExamData.Entities
{
	public partial class Order : EntityBase
	{
		public Order() 
		{
			OrderProducts = new HashSet<OrderProduct>();
		}
		public DateTime OrderDateTime { get; set; }
		public string Comments { get; set; }
		public float Total { get; set; }
		public Enums.OrdersEnums.Status Status { get; set; }

		public ICollection<OrderProduct> OrderProducts { get; set; }
	}


}
