using BookShop.DataAccess.MediatRPattern.Commands.CategoryCommand;
using BookShop.DataAccess.MediatRPattern.Commands.ProductCommand;
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
	public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
	{
		private readonly IUnitOfWork obj;
        public CreateProductHandler(IUnitOfWork obj)
        {
            this.obj=obj;
        }
        public Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var product = new Product()
			{
				CategoryId = request.CategoryId,
				Title = request.Title,
				Description=request.Discription,
				ISBN=request.ISBN,
               Author = request.Author,
			   Price = request.Price,
			   ImageUrl = request.ImageUrl,


			};
			return obj.Product.Create(product);
		}
	}
}
