using IBSS.VendingMachines.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBSS.VendingMachines.Data
{
		public class MachineDB : DbContext
		{
				public DbSet<Machines> Machines { get; set; }
				public DbSet<Product> Products { get; set; }

				public MachineDB(DbContextOptions<MachineDB> options) : base(options)
				{
						//
				}

				protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
				{
						//optionsBuilder.UseSqlServer(@"Server=.\sql2016;
						//														  Database=IBSS_MachineDb;
						//															Integrated Security=True;");
				}
		}
}
