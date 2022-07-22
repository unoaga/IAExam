using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IAExamData.ViewModels
{
	public class ProductVM
	{
		[Required]
		public float Price { get; set; }
		[Required]
		public string ImgUrl { get; set; }
		[Required]
		public int Stock { get; set; }
		[Required]
		public Enums.OrdersEnums.Category Category { get; set; }
	}
}
