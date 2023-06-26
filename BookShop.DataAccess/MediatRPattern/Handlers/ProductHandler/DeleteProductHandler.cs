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
	public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
	{
		private readonly IUnitOfWork obj;
        public DeleteProductHandler(IUnitOfWork obj)
        {
            this.obj=obj;
        }
        public Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			return obj.Product.Delete(request.Id);
		}
	}
}
