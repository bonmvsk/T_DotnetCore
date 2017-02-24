using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBSS.VendingMachines.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using IBSS.VendingMachines.Data;
using Microsoft.EntityFrameworkCore;

namespace IBSS.VendingMachines.Controllers
{
		public class MachinesController : Controller
		{
				private MachineDB _db;

				public MachinesController(MachineDB db)
				{
						_db = db;
				}

				public async Task<IActionResult> Index(int? id)
				{
						Machine _machine;
						if (id == null)
						{
								_machine = _db.Machines
															.Include(m => m.Slots)
															.ThenInclude((Slot s) => s.Product)
															.FirstOrDefault();
								if (_machine != null) await Init(_machine.Id);
						}
						else
						{
								_machine = _db.Machines
															.Include(m => m.Slots)
															.ThenInclude((Slot s) => s.Product)
															.SingleOrDefault(p => p.Id == id);
								if (_machine != null) await Init(_machine.Id);
						}
						if (_machine == null) return NotFound();
						ViewBag.MachineId = new SelectList(_db.Machines, "Id", "Name", selectedValue: id);
						return View(_machine);
				}

				[HttpPost]
				public IActionResult AddCoin(int id, decimal amount)
				{
						try
						{
								var val = _db.Machines.SingleOrDefault(p => p.Id == id);
								if (val == null) return NotFound();
								val.InsertCoin(amount);
								_db.SaveChanges();
						}
						catch (Exception ex)
						{
								TempData["Error"] = ex.Message;
						}

						return RedirectToAction("Index", new { id = id });
				}

				[HttpPost]
				public IActionResult Cancel(int id)
				{
						var val = _db.Machines.SingleOrDefault(p => p.Id == id);
						if (val == null) return NotFound();
						val.Cancel();
						_db.SaveChanges();
						return RedirectToAction("Index", new { id = id });
				}

				public async Task<IActionResult> Init(int id)
				{
						var m = _db.Machines.Find(id);
						if (m == null) return Content($"Not found machine #{id}.");

						_db.Entry(m).Collection(x => x.Slots).Load();
						if (m.Slots.Any()) return Content("This machine had already initated.");

						var p1 = _db.Products.SingleOrDefault(p => p.Name == "Water");
						var p2 = _db.Products.SingleOrDefault(p => p.Name == "Pepsi");
						var p3 = _db.Products.SingleOrDefault(p => p.Name == "Coke");
						var p4 = _db.Products.SingleOrDefault(p => p.Name == "Singha");
						var p5 = _db.Products.SingleOrDefault(p => p.Name == "Red Bull");

						var s1 = new Slot { Quantity = 5, Product = p1 };
						var s2 = new Slot { Quantity = 5, Product = p2 };
						var s3 = new Slot { Quantity = 5, Product = p2 };
						var s4 = new Slot { Quantity = 5, Product = p3 };
						var s5 = new Slot { Quantity = 5, Product = p4 };
						var s6 = new Slot { Quantity = 5, Product = p5 };
						var s7 = new Slot { Quantity = 5, Product = null };
						var s8 = new Slot { Quantity = 5, Product = null };

						m.Slots.Add(s1);
						m.Slots.Add(s2);
						m.Slots.Add(s3);
						m.Slots.Add(s4);
						m.Slots.Add(s5);
						m.Slots.Add(s6);
						m.Slots.Add(s7);
						m.Slots.Add(s8);

						await _db.SaveChangesAsync();
						return Content("OK");
				}

				[HttpPost]
				public IActionResult Sell(int? id, int? slotId) {
						if (id == null || slotId == null) return NotFound();
						Machine _machine;
						_machine = _db.Machines
												  .Include(m => m.Slots)
													.ThenInclude((Slot s) => s.Product)
													.SingleOrDefault(p => p.Id == id);
													
						_machine.SellItem(slotId.Value);
						_db.SaveChanges();
						return RedirectToAction("Index", new { id = id });
				}
		}
}