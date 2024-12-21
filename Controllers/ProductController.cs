using Curdoperation_Problem_.Dtos;
using Curdoperation_Problem_.Mapper;
using Curdoperation_Problem_.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curdoperation_Problem_.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly DemoContext _Context;
		public ProductController(DemoContext demoContext) 
		{
		          this._Context= demoContext;
		}
		[HttpGet]
		public IActionResult GEtAllProduct()
		{
			//var r=this._Context.Products.ToList();
			var r = this._Context.Products.Select(x => x.FromProductToProductDto());
			return Ok(r);
		}

		[HttpPost]
		public IActionResult CreateProduct([FromBody] ProductCreateDto rec)
		{
			if (rec == null)
				return BadRequest("No data is added");

			var categoryExists = _Context.Categories.Any(c => c.CategoryID == rec.CategoryID);

			if (!categoryExists)
				return BadRequest("Invalid CategoryID. The category does not exist.");

			// Map DTO to entity and save
			var model = rec.FromProductCreateDtoToProduct();
			_Context.Products.Add(model);
			_Context.SaveChanges();
			return CreatedAtAction("CreateProduct", model.FromProductToProductDto());
		}

		[HttpPut("{id}")]
		public IActionResult UpdateProduct([FromBody] ProductUpdateDto rec, [FromRoute] int id)
		{
			if (id == 0)
				return BadRequest("Invalid ID");

			if (rec == null)
				return BadRequest("No data is Updated");

			//var model = rec.FromProductUpdateDtoToProduct(id);

			var model = _Context.Products.Find(id);
			model.ProductName = rec.ProductName;
			model.CategoryID = rec.CategoryID;
			model.ProductName = rec.ProductName;
			model.Price = rec.Price;
			model.MfgName = rec.MfgName;
			this._Context.SaveChanges();
			return Ok(model);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteProduct([FromRoute] int id) 
		{
			if (id == 0)
				return BadRequest("Invalid ID");

			var model = _Context.Products.Find(id);
			_Context.Products.Remove(model);
			_Context.SaveChanges();
			return Ok(model);
		}



	}
}
