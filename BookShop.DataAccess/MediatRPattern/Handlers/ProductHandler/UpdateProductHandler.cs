using BookShop.DataAccess.MediatRPattern.Commands.ProductCommand;
using BookShop.DataAccess.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.MediatRPattern.Handlers.ProductHandler
{
	public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
	{
		private readonly IUnitOfWork obj;
        public UpdateProductHandler(IUnitOfWork obj)
        {
            this.obj = obj;
        }
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var product = await obj.Product.GetById(request.Id);
			if (product == null) return default;
			product.Id = request.Id;
			product.Title = request.Title;
			product.Description = request.Discription;
			product.ISBN = request.ISBN;
			product.Author = request.Author;
			product.Price = request.Price;

			return await obj.Product.Update(product);
		}
	}
}
