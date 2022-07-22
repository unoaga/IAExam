using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IAExamData.ViewModels
{
	public class OrderVM
	{
		public OrderVM()
		{
			OrderProducts = new HashSet<OrderProductVm>();
		}
		public string Key { get; set; }

		[Required]
		public string Name { get; set; }

		public string Comments { get; set; }



		public ICollection<OrderProductVm> OrderProducts { get; set; }
	}
}
