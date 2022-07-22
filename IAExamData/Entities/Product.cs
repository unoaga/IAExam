using System;
using System.Collections.Generic;
using System.Text;

namespace IAExamData.Entities
{
	public partial class Product: EntityBase
	{
		public float Price{ get; set; }
		public string ImgUrl { get; set; }
		public bool Deleted { get; set; }
		public int Stock { get; set; }
		public int Sold { get; set; } 
		public  Enums.OrdersEnums.Category Category { get; set; }
	}
}
