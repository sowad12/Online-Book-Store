using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.MediatRPattern.Commands.CategoryCommand
{
	public class UpdateCategoryCommand : IRequest<int>
	{
		public UpdateCategoryCommand(int id, string name, int displayorder)
		{
			Id = id;
			Name = name;
			DisplayOrder = displayorder;
			
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public int DisplayOrder { get; set; }
		
	}
}