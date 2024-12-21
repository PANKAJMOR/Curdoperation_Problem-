using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curdoperation_Problem_.Models
{
	public class Product
	{
		[Key]
		public int ProductID {  get; set; }
		public string ProductName { get; set; }
		public string MfgName { get; set; }
		public decimal Price {  get; set; }

		[ForeignKey("Category")]
		public int CategoryID {  get; set; }
		public virtual Category Category { get; set; }


	}
}
