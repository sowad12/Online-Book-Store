using BookShop.DataAccess.Data;
using BookShop.DataAccess.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Service
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext db;
		
		public UnitOfWork(ApplicationDbContext db)
        {
			this.db = db;
			Category = new CategoryService(db);
			Product = new ProductService(db);
            
        }
		public ICategory Category { get; private set; }
		public IProduct Product { get; private set; }

		
	}
}
