using System.ComponentModel.DataAnnotations;

namespace Curdoperation_Problem_.Models
{
	public class Category
	{
		[Key]
		public int CategoryID {  get; set; }
		public string CategoryName { get; set; }
		public virtual List<Product> Products { get; set; }

	}
}
