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
    public class CardsInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardsInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CardsInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardsInfo.ToListAsync());
        }

        // GET: CardsInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardsInfo = await _context.CardsInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardsInfo == null)
            {
                return NotFound();
            }

            return View(cardsInfo);
        }

        // GET: CardsInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardsInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Type,Attribute,Typing,LevelOrRank,Archetype,TCGDate,OCGDate,Description,PendulumDescription,AttackPoints,DefencePoints,Limit,Id")] CardsInfo cardsInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardsInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardsInfo);
        }

        // GET: CardsInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardsInfo = await _context.CardsInfo.FindAsync(id);
            if (cardsInfo == null)
            {
                return NotFound();
            }
            return View(cardsInfo);
        }

        // POST: CardsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Type,Attribute,Typing,LevelOrRank,Archetype,TCGDate,OCGDate,Description,PendulumDescription,AttackPoints,DefencePoints,Limit,Id")] CardsInfo cardsInfo)
        {
            if (id != cardsInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardsInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardsInfoExists(cardsInfo.Id))
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
            return View(cardsInfo);
        }

        // GET: CardsInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardsInfo = await _context.CardsInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardsInfo == null)
            {
                return NotFound();
            }

            return View(cardsInfo);
        }

        // POST: CardsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardsInfo = await _context.CardsInfo.FindAsync(id);
            if (cardsInfo != null)
            {
                _context.CardsInfo.Remove(cardsInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardsInfoExists(int id)
        {
            return _context.CardsInfo.Any(e => e.Id == id);
        }
    }
}
