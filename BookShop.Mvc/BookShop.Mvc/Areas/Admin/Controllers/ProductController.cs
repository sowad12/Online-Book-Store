using BookShop.DataAccess.MediatRPattern.Commands.ProductCommand;
using BookShop.DataAccess.MediatRPattern.Queries.CategoryQuery;
using BookShop.DataAccess.MediatRPattern.Queries.ProductQuery;
using BookShop.DataAccess.Service.Interfaces;
using BookShop.Models;
using BookShop.Models.ViewModel;
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
		private readonly IWebHostEnvironment env;

		public ProductController(IMediator mediator,IUnitOfWork unitOfWork,IWebHostEnvironment env)
		{

			this.mediator = mediator;
			this.unitOfWork = unitOfWork;
			this.env = env;

		}

		public async Task<IActionResult> Index()
		{
		

			return View();
		}
		[HttpGet]
		public async Task<List<Product>> ProductList()
		{
			var data= await mediator.Send(new GetAllProductQuery());
			return data;
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
		public async Task<IActionResult> CreateAsync([FromForm]Product obj, IFormFile image)
		{
			
			if (ModelState.IsValid)
			{
				//access wwwroot folder
				string wwwRootPath = env.WebRootPath;
				var file = image;
				if (image != null)
				{
					//set new file name
					string fileName=Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName);
					
					//concat wwwRoot/images/ProductImages
					string ProductPath=Path.Combine(wwwRootPath, @"images\ProductImages");

					using (var fileStream = new FileStream(Path.Combine(ProductPath, fileName), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}
					obj.ImageUrl = @"images/ProductImages/"+fileName;
				}


				var result = await mediator.Send(new CreateProductCommand(obj.CategoryId, obj.Title, obj.Description, obj.ISBN, obj.Author, obj.Price,obj.ImageUrl));
				return Ok(result); // Return an HTTP 200 OK status code with the created product
			}

			return BadRequest("Invalid input data.");



		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)

		{
			var productData = await mediator.Send(new GetByIdProductQuery() { Id = id });

            var data = await mediator.Send(new GetAllCategoryQuery());

            IEnumerable<SelectListItem> CategoryList = data
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

            ViewBag.categoryList = CategoryList;

            return View(productData);
		}

		[HttpPut]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditAsync([FromForm] Product obj, IFormFile image)
		{
            
                //access wwwroot folder
                string wwwRootPath = env.WebRootPath;
                var file = image;

				if(file==null && obj.ImageUrl != null) {
                  var result= await mediator.Send(new UpdateProductCommand(obj.Id,obj.CategoryId, obj.Title, obj.Description, obj.ISBN, obj.Author, obj.Price, obj.ImageUrl));
                  return Ok(result);
                }
               else if (file != null)
                {
                    //set new file name
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    //concat wwwRoot/images/ProductImages
                    string ProductPath = Path.Combine(wwwRootPath, @"images/ProductImages");


                    if (!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, obj.ImageUrl);

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(ProductPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                 obj.ImageUrl = @"images/ProductImages/" + fileName;
                var result = await mediator.Send(new UpdateProductCommand(obj.Id, obj.CategoryId, obj.Title, obj.Description, obj.ISBN, obj.Author, obj.Price, obj.ImageUrl));
                return Ok(result);
                // return Ok(result);
            }





            return BadRequest("Nad Request");



        }

		[HttpDelete]
		public async Task<int> Delete(int id)
		{

			return await mediator.Send(new DeleteProductCommand(id));


		}

	}
}