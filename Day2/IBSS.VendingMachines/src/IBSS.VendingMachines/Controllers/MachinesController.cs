using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBSS.VendingMachines.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using IBSS.VendingMachines.Data;

namespace IBSS.VendingMachines.Controllers
{
		public class MachinesController : Controller
		{
				private MachineDB _db;

				public MachinesController(MachineDB db)
				{
						_db = db;
				}

				public IActionResult Index(int? id)
				{
						Machines _machine;
						if (id == null)
						{
								_machine = _db.Machines.FirstOrDefault();
						}
						else
						{
								_machine = _db.Machines.SingleOrDefault(p => p.Id == id);
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
		}
}