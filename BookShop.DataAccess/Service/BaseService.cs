using BookShop.DataAccess.Data;
using BookShop.DataAccess.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Service
{
	public class BaseService<T> : IBase<T> where T : class
	{
		private readonly ApplicationDbContext context;
		DbSet<T> db;
        public BaseService(ApplicationDbContext context)
        {
            this.context = context;
			this.db = context.Set<T>();
		}
      
		public async Task<T> Create(T obj)
		{
			var data = await db.AddAsync(obj);
			await context.SaveChangesAsync();
			return data.Entity;
		}

		public Task<int> Delete(int id)
		{
			var data = db.Find(id);

			 db.Remove(data);
			context.SaveChanges();
			return db.CountAsync() ;

		}

		public async Task<List<T>> GetAll()
		{
			return await db.ToListAsync();
		}

		public async Task<T> GetById(int  id)
		{
			return await db.FindAsync(id);
		}

		public void Save()
		{
			context.SaveChanges();
		}

		public async Task<int> Update(T obj)
		{
			db.Update(obj);
			context.SaveChanges();
			return await db.CountAsync();
		}
	}
}
