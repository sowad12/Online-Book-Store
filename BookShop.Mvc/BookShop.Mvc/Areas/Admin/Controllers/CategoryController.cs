using BookShop.DataAccess.Data;
using BookShop.DataAccess.MediatRPattern.Commands.CategoryCommand;
using BookShop.DataAccess.MediatRPattern.Queries.CategoryQuery;
using BookShop.DataAccess.Service.Interfaces;
using BookShop.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
    {

        private IMediator mediator;

        public CategoryController(IMediator mediator)
        {

            this.mediator = mediator;

        }

        public async Task<IActionResult> Index()
        {
			var data= await mediator.Send(new GetAllCategoryQuery());

			return View();
        }
        [HttpGet]
        public async Task<List<Category>> CategoryList()
        {

            return await mediator.Send(new GetAllCategoryQuery());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Category> CreateAsync([FromBody] Category obj)
        {

            //var model = new CreateCategoryCommand(obj.Name, obj.DisplayOrder);
            return await mediator.Send(new CreateCategoryCommand(obj.Name, obj.DisplayOrder));


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await mediator.Send(new GetByIdCategoryQuery() { Id = id });

            return View(data);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<int> EditAsync([FromBody] Category obj)
        {

            //var model = new UpdateCategoryCommand(obj.Id, obj.Name, obj.DisplayOrder);
            return await mediator.Send(new UpdateCategoryCommand(obj.Id, obj.Name, obj.DisplayOrder));


        }
        [HttpDelete]
        public async Task<int> Delete(int id)
        {

            return await mediator.Send(new DeleteCategoryCommand(id));


        }

    }
}