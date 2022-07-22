using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IAExamData.ViewModels
{
	public class OrderProductVm
	{
		[Required]
		public int IdProduct { get; set; }

		[Required]
		public int Quantity { get; set; }
		 
	}
}
