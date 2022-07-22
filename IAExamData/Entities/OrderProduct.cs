using System;
using System.Collections.Generic;
using System.Text;

namespace IAExamData.Entities
{
	public partial class OrderProduct
	{
		public int IdOrder { get; set; }

		public int IdProduct { get; set; }

		public int Quantity { get; set; }
		 

		public float CurrentPriceEachOne { get; set; }

		public float Subtotal { get; set; }
	}
}
