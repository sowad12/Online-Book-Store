using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.MediatRPattern.Commands.CategoryCommand
{
	public class DeleteCategoryCommand:IRequest<int>
	{
	
        public DeleteCategoryCommand(int id)
        {
                Id = id;
        }
		public int Id { get; set; }
	}
}
