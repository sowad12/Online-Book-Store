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
	public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, int>
	{
		private readonly IUnitOfWork obj;
        public DeleteCategoryHandler(IUnitOfWork obj)
        {
            this.obj = obj;	
        }
        public Task<int> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
		{
			return obj.Category.Delete(request.Id);
		}
	}
}
