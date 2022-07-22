using System;
using System.Collections.Generic;
using System.Text;

namespace IAExamData.Dtos
{
	public class OrderProductDto
	{
		 

		public int IdProduct { get; set; }

		public string  Product { get; set; }

		public int Quantity { get; set; }
		 

		public float CurrentPriceEachOne { get; set; }
	}
}
