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
    public class UserDecksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserDecksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserDecks
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserDecks.ToListAsync());
        }

        // GET: UserDecks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDecks = await _context.UserDecks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDecks == null)
            {
                return NotFound();
            }

            return View(userDecks);
        }

        // GET: UserDecks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDecks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,DeckId,Id")] UserDecks userDecks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDecks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userDecks);
        }

        // GET: UserDecks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDecks = await _context.UserDecks.FindAsync(id);
            if (userDecks == null)
            {
                return NotFound();
            }
            return View(userDecks);
        }

        // POST: UserDecks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,DeckId,Id")] UserDecks userDecks)
        {
            if (id != userDecks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDecks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDecksExists(userDecks.Id))
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
            return View(userDecks);
        }

        // GET: UserDecks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDecks = await _context.UserDecks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDecks == null)
            {
                return NotFound();
            }

            return View(userDecks);
        }

        // POST: UserDecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userDecks = await _context.UserDecks.FindAsync(id);
            if (userDecks != null)
            {
                _context.UserDecks.Remove(userDecks);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDecksExists(int id)
        {
            return _context.UserDecks.Any(e => e.Id == id);
        }
    }
}
