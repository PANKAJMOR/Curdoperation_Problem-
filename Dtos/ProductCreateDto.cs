using Curdoperation_Problem_.Models;

namespace Curdoperation_Problem_.Dtos
{
	public class ProductCreateDto
	{
		public string ProductName { get; set; } 
		public string MfgName { get; set; } 
		public decimal Price { get; set; } 

		public int CategoryID { get; set; }

	

	}
}
