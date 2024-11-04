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
    public class DeckInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeckInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeckInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeckInfo.ToListAsync());
        }

        // GET: DeckInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deckInfo = await _context.DeckInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deckInfo == null)
            {
                return NotFound();
            }

            return View(deckInfo);
        }

        // GET: DeckInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeckInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,OwnerId,Description,DateCreated,UpdatedDeck,Id")] DeckInfo deckInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deckInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deckInfo);
        }

        // GET: DeckInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deckInfo = await _context.DeckInfo.FindAsync(id);
            if (deckInfo == null)
            {
                return NotFound();
            }
            return View(deckInfo);
        }

        // POST: DeckInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,OwnerId,Description,DateCreated,UpdatedDeck,Id")] DeckInfo deckInfo)
        {
            if (id != deckInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deckInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeckInfoExists(deckInfo.Id))
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
            return View(deckInfo);
        }

        // GET: DeckInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deckInfo = await _context.DeckInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deckInfo == null)
            {
                return NotFound();
            }

            return View(deckInfo);
        }

        // POST: DeckInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deckInfo = await _context.DeckInfo.FindAsync(id);
            if (deckInfo != null)
            {
                _context.DeckInfo.Remove(deckInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeckInfoExists(int id)
        {
            return _context.DeckInfo.Any(e => e.Id == id);
        }
    }
}
