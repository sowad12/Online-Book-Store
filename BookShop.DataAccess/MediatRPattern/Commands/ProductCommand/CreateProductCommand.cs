using BookShop.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.MediatRPattern.Commands.ProductCommand
{
	public class CreateProductCommand:IRequest<Product>
	{
        public CreateProductCommand(int CategoryId,string Title,string Discription,string ISBN,string Author, double Price,string ImageUrl)
        {
            this.CategoryId=CategoryId;
            this.Title = Title;
            this.Discription = Discription;
            this.ISBN = ISBN;
            this.Author = Author;
            this.Price = Price;
            this.ImageUrl = ImageUrl;
        }
        public int CategoryId { get; set; } 
        public string Title { get; set; }   
        public string Discription { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }  
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
