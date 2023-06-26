﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models.ViewModel
{
       public class ProductVm
	{
		public Product Product { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> CategoryList { get; set; }

	}
}
