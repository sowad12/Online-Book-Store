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
	public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<Product>>
	{
		private readonly IUnitOfWork obj;
        public GetAllProductHandler(IUnitOfWork obj)
        {
           this.obj = obj;
        }
        public Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
		{
			return obj.Product.GetAll();
		}
	}
}
