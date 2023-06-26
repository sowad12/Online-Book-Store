using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookShop.Models
{
	public class Product
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }
		[Required]
		public string ISBN { get; set; }
		[Required]
		public string Author { get; set; }
		
		[Required]
	
		[Display(Name = "Price ")]
		public double Price { get; set; }

		[ValidateNever]
		public string ImageUrl { get; set; } = null;

		
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		[ValidateNever]
		public Category Category { get; set; }


	}
}
