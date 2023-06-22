using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Service.Interfaces
{
     public interface IBase<T> where T : class
	{
		Task<List<T>> GetAll();
		Task<T> GetById(int id);
		Task<T> Create(T obj);
		Task<int> Update(T obj);
		Task<int> Delete(int id);
		void Save();
	}
}
