using BookShop.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.MediatRPattern.Commands.CategoryCommand
{
	public  class CreateCategoryCommand:IRequest<Category>
	{
		public CreateCategoryCommand(string  Name, int DisplayOrder)
		{
			
			this.Name = Name;
			this.DisplayOrder = DisplayOrder;
		}
		public string Name { get; set; }
		public int DisplayOrder { get; set; }
		
	}
}
