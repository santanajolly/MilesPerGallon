using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilesPerGallon.Data;
using MilesPerGallon.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilesPerGallon.Controllers
{
    public class InputsController : Controller
    {
        private readonly UserContext _context;

        public InputsController(UserContext context)
        {
            _context = context;
        }

        // GET: Inputs
        public async Task<IActionResult> Index(string searchString)
        {
            var inputs = from m in _context.Input
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                inputs = inputs.Where(s => s.LastName.Contains(searchString));
                inputs = inputs.Where(s => s.LastName.Contains(searchString));
                inputs = inputs.Where(s => s.CarModel.Contains(searchString));
            }

            return View(await _context.Input.ToListAsync());
        }

        // GET: Inputs/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var input = await _context.Input
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (input == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(input);
        //}

        // GET: Inputs/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,CarModel,MilesDriven,FillUpDate,GallonsFilled")] Input input)
        {
            if (ModelState.IsValid)
            {
                _context.Add(input);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(input);
        }

        // GET: Inputs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var input = await _context.Input.FindAsync(id);
            if (input == null)
            {
                return NotFound();
            }
            return View(input);
        }

        // POST: Inputs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,CarModel,MilesDriven,FillUpDate,GallonsFilled")] Input input)
        {
            if (id != input.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(input);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InputExists(input.Id))
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
            return View(input);
        }

        // GET: Inputs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var input = await _context.Input
                .FirstOrDefaultAsync(m => m.Id == id);
            if (input == null)
            {
                return NotFound();
            }

            return View(input);
        }

        // POST: Inputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var input = await _context.Input.FindAsync(id);
            _context.Input.Remove(input);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InputExists(int id)
        {
            return _context.Input.Any(e => e.Id == id);
        }
    }
}
