using BookShop.DataAccess.MediatRPattern.Queries.ProductQuery;
using BookShop.DataAccess.Service.Interfaces;
using BookShop.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.MediatRPattern.Handlers.ProductHandler
{
	public class GetByIdProductHandler : IRequestHandler<GetByIdProductQuery, Product>
	{
		private readonly IUnitOfWork obj;
        public GetByIdProductHandler(IUnitOfWork obj)
        {
            this.obj=obj;
        }
        public Task<Product> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
		{
			return obj.Product.GetById(request.Id);
		}
	}
}
