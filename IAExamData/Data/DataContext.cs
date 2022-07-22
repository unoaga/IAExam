using IAExamData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static IAExamData.Enums.OrdersEnums;

namespace IAExamData.Data
{
	public class DataContext : IDataContext
	{
		public DataContext()
		{
			Products = new HashSet<Product>();
			Orders = new HashSet<Order>();
			CurrentProductId = 5;
			CurrentOrderId = 2;
			FillData();
		}
		//public static HashSet<Order> Orders;

		//public static HashSet<Product> Products;
		public HashSet<Order> Orders { get; set; }
		public HashSet<Product> Products { get; set; }
		public int CurrentOrderId { get; set; }
		public int CurrentProductId { get; set; }


		private void FillData() 
		{
			Products.Add(new Product
			{
				Id = 1,
				Name = "Burger",
				Price = 3.5f,
				Stock=20,
				Sold=0,
				Category =  Category.Food,
				ImgUrl = "https://st.depositphotos.com/1783579/54958/i/600/depositphotos_549589530-stock-photo-premium-quality-beef-burger-with.jpg"
			}) ;
			Products.Add(new Product
			{
				Id = 2,
				Name = "Pizza",
				Price = 6.8f,
				Stock = 22,
				Sold = 0,
				Category = Category.Food,
				ImgUrl = "https://st.depositphotos.com/1900347/4146/i/600/depositphotos_41466555-stock-photo-image-of-slice-of-pizza.jpg"
			});
			Products.Add(new Product
			{
				Id = 3,
				Name = "Wins",
				Stock = 30,
				Sold = 0,
				Price = 8.5f,
				Category = Category.Food,
				ImgUrl = "https://st.depositphotos.com/1692343/2350/i/600/depositphotos_23507259-stock-photo-hot-and-spicey-buffalo-chicken.jpg"
			});
			Products.Add(new Product
			{
				Id = 4,
				Name = "Soda",
				Price = 2f,
				Stock = 50,
				Sold = 0,
				Category = Category.Drink,
				ImgUrl = "https://st3.depositphotos.com/1063437/12721/i/450/depositphotos_127216454-stock-photo-bottles-of-assorted-global-soft.jpg"
			});
			Products.Add(new Product
			{
				Id = 5,
				Name = "Beer",
				Price = 3f,
				Stock = 30,
				Sold = 0,
				Category = Category.Drink,
				ImgUrl = "https://st2.depositphotos.com/1105977/5302/i/600/depositphotos_53024011-stock-photo-glass-and-bottle-of-beer.jpg"
			});

			var oderProducts = new HashSet<OrderProduct>();
			oderProducts.Add(new OrderProduct
			{
				CurrentPriceEachOne = 3f,
				IdOrder = 1,
				IdProduct = 1,
				Quantity = 4 
			});

			oderProducts.Add(new OrderProduct
			{
				CurrentPriceEachOne = 3.5f,
				IdOrder = 1,
				IdProduct = 5,
				Quantity = 2 
			});
			Orders.Add(new Order
			{
				Id = 1,
				Name = "Pedro Perez",
				OrderDateTime = DateTime.UtcNow,
				Status = Status.Completed,
				OrderProducts = (ICollection<OrderProduct>)oderProducts,
				Comments="Without onion"

			});


			var oderProducts2 = new HashSet<OrderProduct>();
			oderProducts2.Add(new OrderProduct
			{
				CurrentPriceEachOne = 3f,
				IdOrder = 2,
				IdProduct = 1,
				Quantity = 6 
			});

			oderProducts2.Add(new OrderProduct
			{
				CurrentPriceEachOne = 3.5f,
				IdOrder = 2,
				IdProduct = 5,
				Quantity = 3 
			});
			Orders.Add(new Order
			{
				Id = 2,
				Name = "Antonio Lara",
				OrderDateTime = DateTime.UtcNow,
				Status = Status.Pending,
				OrderProducts = (ICollection<OrderProduct>)oderProducts2,
				Comments = "Without mayonnaise"

			});
		}

	}
}
