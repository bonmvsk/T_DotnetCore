using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IBSS.VendingMachines.Models
{
    public class Product
    {
				public int Id { get; set; }

				[Required, StringLength(100)]
				public string Name { get; set; }

				[Range(0,999)]
				public decimal Price { get; set; }

				[StringLength(1024)]
				public string PictureUrl { get; set; }

		}
}
