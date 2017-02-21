using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web03.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web03.Controllers
{
	public class CondoController : Controller
	{
		private static List<Room> s_rooms;

		static CondoController()
		{
			s_rooms = new List<Room>();
			s_rooms.Add(new Room() { Id = 123, CondoName = "ABC", Area = 32, RentalFee = 15000 });
			s_rooms.Add(new Room() { Id = 124, CondoName = "BBB", Area = 56, RentalFee = 27000 });
			s_rooms.Add(new Room() { Id = 125, CondoName = "CCC", Area = 28, RentalFee = 10000 });
		}
		//Get /Condo/Room
		//Get /Condo/Room/123
		public IActionResult Room(int Id)
		{
			if (s_rooms.Find(p => p.Id == Id) == null)
			{
				return NotFound();
			}
			return View(s_rooms);
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View(s_rooms);
		}

		[HttpPost]
		public IActionResult Reserved(int Id)
		{
			s_rooms.Find(p => p.Id == Id).Reserved();
			return RedirectToAction("Room", new { Id = Id });
		}

		[HttpPost]
		public IActionResult CancelReserved(int Id)
		{
			s_rooms.Find(p => p.Id == Id).CancelReserved();
			return RedirectToAction("Room", new { Id = Id });
		}
	}
}
