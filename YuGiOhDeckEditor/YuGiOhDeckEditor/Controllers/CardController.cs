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
    public class CardController : Controller
    {
        private static List<CardsInfo> cards = new List<CardsInfo>(); // Replace with DB context or data storage

        // GET: Card
        public IActionResult Index()
        {
            return View(cards);
        }

        // GET: Card/Details/5
        public IActionResult Details(int id)
        {
            var card = cards.FirstOrDefault(c => c.Id == id);
            if (card == null) return NotFound();
            return View(card);
        }
    }
}
