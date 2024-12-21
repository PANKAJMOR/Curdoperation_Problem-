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
		public IActionResult Create([FromBody] ProductCreateDto rec)
		{
			if (rec == null)
				return BadRequest("No data is added");

			//var categoryExists = _Context.Categories.Any(c => c.CategoryID == rec.CategoryID);
			
			//if (!categoryExists)
			//	return BadRequest("Invalid CategoryID. The category does not exist.");

			// Map DTO to entity and save
			var model = rec.FromProductCreateDtoToProduct();
			_Context.Products.Add(model);
			_Context.SaveChanges();
			return CreatedAtAction("Create", model.FromProductToProductDto());
		}

		[HttpPost]
		public IActionResult Created([FromBody] ProductCreateDto rec)
		{
			if (rec == null)
				return BadRequest("No data is added");

			// Log incoming data for debugging
			Console.WriteLine($"Received Product: {rec.ProductName}, CategoryID: {rec.CategoryID}");

			// Check if the Category exists
			var categoryExists = _Context.Categories.Any(c => c.CategoryID == rec.CategoryID);
			if (!categoryExists)
				return BadRequest("Invalid CategoryID. The category does not exist.");

			// Map DTO to Product entity
			var model = rec.FromProductCreateDtoToProduct();

			// Log the mapped model for debugging
			Console.WriteLine($"Mapped Product: {model.ProductName}, CategoryID: {model.CategoryID}");

			// Add and save the Product
			_Context.Products.Add(model);
			_Context.SaveChanges();

			// Return the created Product
			return CreatedAtAction("Create", model.FromProductToProductDto());
		}



	}
}
