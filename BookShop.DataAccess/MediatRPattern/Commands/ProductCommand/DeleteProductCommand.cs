using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.MediatRPattern.Commands.ProductCommand
{
	public class DeleteProductCommand:IRequest<int>
	{
        public DeleteProductCommand(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
