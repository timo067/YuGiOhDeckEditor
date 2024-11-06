using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using YuGiOhDeckEditor.Data;

namespace YuGiOhDeckEditor.Controllers
{
    public class BanListController : Controller
    {
        private static List<BanList> banLists = new List<BanList>(); // Replace with DB context or data storage

        // GET: BanList
        public IActionResult Index()
        {
            return View(banLists);
        }

        // GET: BanList/Details/5
        public IActionResult Details(int id)
        {
            var banList = banLists.FirstOrDefault(b => b.Id == id);
            if (banList == null) return NotFound();
            return View(banList);
        }
    }
}
