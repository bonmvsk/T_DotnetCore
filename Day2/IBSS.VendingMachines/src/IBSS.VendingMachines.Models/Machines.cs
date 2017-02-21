using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBSS.VendingMachines.Models
{
		public class Machines
		{
				private decimal _totalAmount = 0m;

				public decimal TotalAmount
				{
						get { return _totalAmount; }
				}

				public void InsertCoin(decimal amount)
				{
						if (amount == 1)
						{
								throw new ArgumentException($"Sorry. {amount} Bath coin is not acception.", nameof(amount));
						};

						_totalAmount += amount;
				}

				public void Cancel()
				{
						_totalAmount = 0;
				}
		}
}
