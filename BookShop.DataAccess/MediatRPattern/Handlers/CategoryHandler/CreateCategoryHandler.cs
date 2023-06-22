using BookShop.DataAccess.MediatRPattern.Commands.CategoryCommand;
using BookShop.DataAccess.Service.Interfaces;
using BookShop.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.MediatRPattern.Handlers.CategoryHandler
{
	public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Category>
	{
		private readonly IUnitOfWork obj;
        public CreateCategoryHandler(IUnitOfWork obj)
        {
            this.obj = obj;
        }

		public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = new Category()
			{
				Name = request.Name,
				DisplayOrder = request.DisplayOrder,
			};
		
			return await obj.Category.Create(category);
		}
	}
}
