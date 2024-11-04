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
    public class DeckCardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeckCardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeckCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeckCard.ToListAsync());
        }

        // GET: DeckCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deckCard = await _context.DeckCard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deckCard == null)
            {
                return NotFound();
            }

            return View(deckCard);
        }

        // GET: DeckCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeckCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeckId,CardId,Quantity,Id")] DeckCard deckCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deckCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deckCard);
        }

        // GET: DeckCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deckCard = await _context.DeckCard.FindAsync(id);
            if (deckCard == null)
            {
                return NotFound();
            }
            return View(deckCard);
        }

        // POST: DeckCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeckId,CardId,Quantity,Id")] DeckCard deckCard)
        {
            if (id != deckCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deckCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeckCardExists(deckCard.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deckCard);
        }

        // GET: DeckCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deckCard = await _context.DeckCard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deckCard == null)
            {
                return NotFound();
            }

            return View(deckCard);
        }

        // POST: DeckCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deckCard = await _context.DeckCard.FindAsync(id);
            if (deckCard != null)
            {
                _context.DeckCard.Remove(deckCard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeckCardExists(int id)
        {
            return _context.DeckCard.Any(e => e.Id == id);
        }
    }
}
