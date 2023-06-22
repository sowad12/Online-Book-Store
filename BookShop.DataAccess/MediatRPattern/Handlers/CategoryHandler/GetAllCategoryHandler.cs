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
	public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, List<Category>>
	{
		private readonly IUnitOfWork obj;
        public GetAllCategoryHandler(IUnitOfWork obj)
        {
			this.obj = obj;
            
        }
        public async Task<List<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
		{
			return await obj.Category.GetAll();
		}
	}
}
