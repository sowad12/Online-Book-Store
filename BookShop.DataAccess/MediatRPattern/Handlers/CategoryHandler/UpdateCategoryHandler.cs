using BookShop.DataAccess.MediatRPattern.Commands.CategoryCommand;
using BookShop.DataAccess.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.MediatRPattern.Handlers.CategoryHandler
{
	public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, int>
	{
		private readonly IUnitOfWork obj;
		public UpdateCategoryHandler(IUnitOfWork obj)
        {
            this.obj= obj;
        }
        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = await obj.Category.GetById(request.Id);
			if (category == null) return default;
			category.Id = request.Id;
			category.Name = request.Name;	
			category.DisplayOrder = request.DisplayOrder;
			return await obj.Category.Update(category);

		}
	}
}
