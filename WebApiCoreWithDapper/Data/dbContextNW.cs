using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCoreWithDapper.Data
{
	public partial class dbContextNW : DbContext
	{
		public dbContextNW(DbContextOptions<dbContextNW> options) : base(options)
		{

		}


		public DbSet<Products> Products { get; set; }


	}
}