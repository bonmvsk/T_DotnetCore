using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBSS.VendingMachines.Models
{
		public class Machines
		{
				private decimal _totalAmount = 0m;
				private decimal[] _acceptableCoins;
				private string __acceptableCoinsText;

				public int Id { get; set; }

				public string Name { get; set; }

				public decimal TotalAmount
				{
						get { return _totalAmount; }
						private set
						{
								_totalAmount = value;
						}
				}

				/// <summary>
				/// กำหนดเรียญที่รับได้ในรูปแบบคอมม่าคั่น
				/// เช่น "1, 5, 10" หรือ "15,10"
				/// </summary>
				public string AcceptableCoinsText
				{
						get
						{
								return __acceptableCoinsText;
						}
						set
						{
								if (value == null) throw new ArgumentNullException(nameof(value));
								__acceptableCoinsText = value;
								decimal ds;
								_acceptableCoins = value
																		.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
																		.Select(s => decimal.TryParse(s, out ds) ? ds : -1)
																		.Where(d => d > 0)
																		.ToArray();
						}
				}

				public decimal[] AcceptableCoins => _acceptableCoins;

				public void InsertCoin(decimal amount)
				{
						if (!_acceptableCoins.Contains(amount)) // (amount == 1)
						{
								throw new ArgumentException($"Sorry. {amount} Bath coin is not acception.", nameof(amount));
						}

						_totalAmount += amount;
				}

				public void Cancel()
				{
						_totalAmount = 0m;
				}
		}
}
