using BookShop.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.MediatRPattern.Queries.ProductQuery
{
	public class GetByIdProductQuery:IRequest<Product>
	{
		public int Id { get; set; }
	}
}
