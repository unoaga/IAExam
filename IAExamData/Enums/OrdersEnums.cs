using System;
using System.Collections.Generic;
using System.Text;

namespace IAExamData.Enums
{
	public class OrdersEnums
	{
		public enum Category 
		{ 
			Food=1,
			Drink
		}
		public enum Status
		{
			Pending=1,
			InProcess,
			Completed,
			Delivered,
			Canceled
		}

	}
}
