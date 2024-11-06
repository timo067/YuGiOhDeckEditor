using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using YuGiOhDeckEditor.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace YuGiOhDeckEditor.Controllers
{
    public class DeckController : Controller
    {
        //private readonly IDeckService _deckService;
        //private readonly ICardService _cardService;

        private static List<DeckInfo> decks = new List<DeckInfo>(); // Replace with your database context

        // GET: Deck
        public IActionResult Index()
        {
            return View(decks);
        }

        // GET: Deck/Details/5
        public IActionResult Details(int id)
        {
            var deck = decks.FirstOrDefault(d => d.Id == id);
            if (deck == null) return NotFound();
            return View(deck);
        }

        // GET: Deck/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deck/Create
        [HttpPost]
        public IActionResult Create(DeckInfo deckInfo)
        {
            if (ModelState.IsValid)
            {
                deckInfo.Id = decks.Count + 1; // Example: generate an Id
                decks.Add(deckInfo); // Save to memory or DB
                return RedirectToAction(nameof(Index));
            }
            return View(deckInfo);
        }

        // GET: Deck/Edit/5
        public IActionResult Edit(int id)
        {
            var deck = decks.FirstOrDefault(d => d.Id == id);
            if (deck == null) return NotFound();
            return View(deck);
        }

        // POST: Deck/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, DeckInfo deckInfo)
        {
            if (ModelState.IsValid)
            {
                var deck = decks.FirstOrDefault(d => d.Id == id);
                if (deck == null) return NotFound();

                deck.Name = deckInfo.Name;
                deck.Description = deckInfo.Description;
                deck.UpdatedDeck = deckInfo.UpdatedDeck; // Update other fields as needed
                return RedirectToAction(nameof(Index));
            }
            return View(deckInfo);
        }

        // GET: Deck/Delete/5
        public IActionResult Delete(int id)
        {
            var deck = decks.FirstOrDefault(d => d.Id == id);
            if (deck == null) return NotFound();
            return View(deck);
        }

        // POST: Deck/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var deck = decks.FirstOrDefault(d => d.Id == id);
            if (deck != null)
            {
                decks.Remove(deck);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
