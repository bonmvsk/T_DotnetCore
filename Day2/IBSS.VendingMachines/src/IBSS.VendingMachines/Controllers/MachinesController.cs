using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBSS.VendingMachines.Models;

namespace IBSS.VendingMachines.Controllers
{
		public class MachinesController : Controller
		{
				private static List<Machines> s_machines = new List<Machines>();

				static MachinesController()
				{
						s_machines = new List<Machines>();
						s_machines.Add(new Machines() { Id = 1, AcceptableCoinsText = "5,10" });
						s_machines.Add(new Machines() { Id = 2, AcceptableCoinsText = "1,10" });
						s_machines.Add(new Machines() { Id = 3, AcceptableCoinsText = "1,5" });
				}

				public IActionResult Index(int? id)
				{
						if(id != null) {
								s_machines.Find(p => p.Id == id);
								return View(s_machines);
						}
						return View(s_machines);
				}

				[HttpPost]
				public IActionResult AddCoin(int id, decimal amount)
				{
						try
						{
								var val = s_machines.SingleOrDefault(p => p.Id == id);
								if (val == null) return NotFound();
								val.InsertCoin(amount);
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
						var val = s_machines.SingleOrDefault(p => p.Id == id);
						if (val == null) return NotFound();
						val.Cancel();
						return RedirectToAction("Index");
				}
		}
}