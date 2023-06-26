using BookShop.DataAccess.MediatRPattern.Commands.ProductCommand;
using BookShop.DataAccess.MediatRPattern.Queries.CategoryQuery;
using BookShop.DataAccess.MediatRPattern.Queries.ProductQuery;
using BookShop.DataAccess.Service.Interfaces;
using BookShop.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Runtime.Remoting;


namespace BookShop.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private IMediator mediator;
		private readonly IUnitOfWork unitOfWork;

		public ProductController(IMediator mediator,IUnitOfWork unitOfWork)
		{

			this.mediator = mediator;
			this.unitOfWork = unitOfWork;

		}

		public async Task<IActionResult> Index()
		{
		

			return View();
		}
		[HttpGet]
		public async Task<List<Product>> ProductList()
		{

			return await mediator.Send(new GetAllProductQuery());
		}
		[HttpGet]
		public async Task<IActionResult> CreateAsync()
		{

			//var data = unitOfWork.Category.GetAll();
			//IEnumerable<SelectListItem> CategoryList =await  unitOfWork.Category.GetAll()
			//	.Select(x => new SelectListItem(
			//		Text = x.Name,
			//		Value = x.Id.ToString()
			//		)).ToList();
			var data = await mediator.Send(new GetAllCategoryQuery());

			IEnumerable<SelectListItem> CategoryList = data
				.Select(x => new SelectListItem
				{
					Text = x.Name,
					Value = x.Id.ToString()
				});
		
			ViewBag.categoryList = CategoryList;

			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateAsync([FromBody] Product obj)
		{
			//var data = await mediator.Send(new GetAllCategoryQuery());

			//IEnumerable<SelectListItem> CategoryList = data
			//	.Select(x => new SelectListItem
			//	{
			//		Text = x.Name,
			//		Value = x.Id.ToString()
			//	});

			//ViewBag.categoryList = CategoryList;

			//var model = new CreateProductCommand(obj.Name, obj.DisplayOrder);
			if (ModelState.IsValid)
			{
				var result = await mediator.Send(new CreateProductCommand(obj.CategoryId, obj.Title, obj.Description, obj.ISBN, obj.Author, obj.Price,obj.ImageUrl));
				return Ok(result); // Return an HTTP 200 OK status code with the created product
			}

			return BadRequest("Invalid input data.");



		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var data = await mediator.Send(new GetByIdProductQuery() { Id = id });

			return View(data);
		}

		[HttpPut]
		[ValidateAntiForgeryToken]
		public async Task<int> EditAsync([FromBody] Product obj)
		{

			//var model = new UpdateProductCommand(obj.Id, obj.Name, obj.DisplayOrder);
			return await mediator.Send(new UpdateProductCommand(obj.Id,obj.Title, obj.Description, obj.ISBN, obj.Author, obj.Price));


		}
		[HttpDelete]
		public async Task<int> Delete(int id)
		{

			return await mediator.Send(new DeleteProductCommand(id));


		}

	}
}