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
				private static Machines _machine = new Machines();

				public IActionResult Index()
				{
						return View(_machine);
				}

				[HttpPost]
				public IActionResult AddCoin(decimal amount)
				{
						try
						{
								_machine.InsertCoin(amount);
						}
						catch (Exception ex)
						{
								TempData["Error"] = ex.Message;
						}

						return RedirectToAction("Index");
				}

				[HttpPost]
				public IActionResult Cancel() {
						_machine.Cancel();
						return RedirectToAction("Index");
				}
		}
}