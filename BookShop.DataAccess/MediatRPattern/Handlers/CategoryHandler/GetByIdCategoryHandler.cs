using BookShop.DataAccess.MediatRPattern.Queries.CategoryQuery;
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
	public  class GetByIdCategoryHandler : IRequestHandler<GetByIdCategoryQuery, Category>
	{
		private readonly IUnitOfWork obj;
		public GetByIdCategoryHandler(IUnitOfWork obj)
        {
			this.obj = obj;
            
        }
        public Task<Category> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
		{
			return  obj.Category.GetById(request.Id);
		}
	}
}
