using Curdoperation_Problem_.Dtos;
using Curdoperation_Problem_.Models;
using System.Runtime.CompilerServices;

namespace Curdoperation_Problem_.Mapper
{
	public static class ProductMapper
	{
		public static ProductDto FromProductToProductDto(this Product rec) 
		{
			return new ProductDto()
			{
				CategoryID = rec.CategoryID,
				ProductName = rec.ProductName,
				MfgName = rec.MfgName,
				Price = rec.Price,
				ProductID = rec.ProductID,
			};
		}

		public static Product FromProductCreateDtoToProduct(this ProductCreateDto rec) 
		{
			return new Product()
			{
		       
				CategoryID= rec.CategoryID,
				ProductName = rec.ProductName,
				Price = rec.Price,
				MfgName = rec.MfgName,
			};
		}

		//public static Product FromProductUpdateDtoToProduct(this ProductUpdateDto rec,int id)
		//{
			
			
		//   var model = _Context.Products.Find(id);
		//	model.ProductName = rec.ProductName;
		//	model.CategoryID = rec.CategoryID;
		//	model.ProductName = rec.ProductName;
		//	model.Price = rec.Price;
		//	model.MfgName = rec.MfgName;

		//	return new Product()
		//	{

		//		CategoryID = model.CategoryID,
		//		ProductName = model.ProductName,
		//		Price = model.Price,
		//		MfgName = model.MfgName,
		//	};

		//}
	}
}
