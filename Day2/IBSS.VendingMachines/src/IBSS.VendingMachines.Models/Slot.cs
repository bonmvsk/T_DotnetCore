using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBSS.VendingMachines.Models
{
		public class Slot
		{
				private int m_quantity;

				[Key]
				public int Id { get; private set; }

				[Range(0, 999)]
				public int Quantity { get; set; }

				public Product Product { get; set; }
		}
}
