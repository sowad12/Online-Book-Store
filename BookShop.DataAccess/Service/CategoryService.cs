using BookShop.DataAccess.Data;
using BookShop.DataAccess.Service.Interfaces;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Service
{
	public class CategoryService: BaseService<Category>, ICategory
	{
		private ApplicationDbContext db;

		public CategoryService(ApplicationDbContext db):base(db) 
		{
		//this.db = db;
		}

		
		

		
	}
}
