using Microsoft.EntityFrameworkCore;
using Reinmar.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reinmar.DA.DataAccess
{
	public class ReinmarDbContext : DbContext
	{
		public ReinmarDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {}

		public DbSet<User> Users { get; set; }
		public DbSet<Package> Packages { get; set; }
		public DbSet<Status> Statuses { get; set; }
	}
}
