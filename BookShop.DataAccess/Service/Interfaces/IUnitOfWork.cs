using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Service.Interfaces
{
	public interface IUnitOfWork
	{
		 ICategory Category { get; }
	}
}
