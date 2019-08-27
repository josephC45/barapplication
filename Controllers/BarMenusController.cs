using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bar.Models;

namespace Bar.Controllers
{
    public class BarMenusController : Controller
    {
        private readonly BarContext _context;

        public BarMenusController(BarContext context)
        {
            _context = context;
        }

        // GET: BarMenus
        public async Task<IActionResult> Index()
        {
            return View(await _context.BarMenu.ToListAsync());
        }

        // GET: BarMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barMenu = await _context.BarMenu
                .FirstOrDefaultAsync(m => m.ID == id);
            if (barMenu == null)
            {
                return NotFound();
            }

            return View(barMenu);
        }

        // GET: BarMenus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BarMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DrinkName,DrinkDescription,Price")] BarMenu barMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barMenu);
        }

        // GET: BarMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barMenu = await _context.BarMenu.FindAsync(id);
            if (barMenu == null)
            {
                return NotFound();
            }
            return View(barMenu);
        }

        // POST: BarMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DrinkName,DrinkDescription,Price")] BarMenu barMenu)
        {
            if (id != barMenu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarMenuExists(barMenu.ID))
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
            return View(barMenu);
        }

        // GET: BarMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barMenu = await _context.BarMenu
                .FirstOrDefaultAsync(m => m.ID == id);
            if (barMenu == null)
            {
                return NotFound();
            }

            return View(barMenu);
        }

        // POST: BarMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barMenu = await _context.BarMenu.FindAsync(id);
            _context.BarMenu.Remove(barMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarMenuExists(int id)
        {
            return _context.BarMenu.Any(e => e.ID == id);
        }
    }
}
