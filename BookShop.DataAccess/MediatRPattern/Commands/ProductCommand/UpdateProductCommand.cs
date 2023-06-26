using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.MediatRPattern.Commands.ProductCommand
{
	public class UpdateProductCommand:IRequest<int>
	{
        public UpdateProductCommand(int Id,string Title, string Discription, string ISBN, string Author, double Price)
        {
			this.Id = Id;
			this.Title = Title;
			this.Discription = Discription;
			this.ISBN = ISBN;
			this.Author = Author;
			this.Price = Price;
		}
		public int Id { get; set; }		
		public string Title { get; set; }
		public string Discription { get; set; }
		public string ISBN { get; set; }
		public string Author { get; set; }
		public double Price { get; set; }
	}
}
