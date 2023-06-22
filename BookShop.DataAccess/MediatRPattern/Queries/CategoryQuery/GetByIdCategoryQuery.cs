using BookShop.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.MediatRPattern.Queries.CategoryQuery
{
	public class GetByIdCategoryQuery : IRequest< Category>
	{

		public int Id { get; set; } 
	}
}
