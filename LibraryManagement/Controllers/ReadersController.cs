using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class ReadersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Readers
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {

            ViewData["FullNameSortParam"] = sortOrder == "fullName_asc" ? "fullName_desc" : "fullName_asc";
            ViewData["EmailSortParam"] = sortOrder == "email_asc" ? "email_desc" : "email_asc";
            ViewData["CurrentSort"] = sortOrder;


            var readers = from r in _context.Readers.Include(r => r.MostRecentTakenBook) select r;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                readers = readers.Where(r => r.FullName.Contains(searchString) ||
                r.Email.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "fullName_desc":
                    readers = readers.OrderByDescending(r => r.FullName);
                    break;
                case "email_desc":
                    readers = readers.OrderByDescending(r => r.Email);
                    break;
                case "email_asc":
                    readers = readers.OrderBy(r => r.Email);
                    break;
                case "fullName_asc":
                    readers = readers.OrderBy(r => r.FullName);
                    break;
                default:
                    break;
            }

            int pageSize = 3;

            return View(await PaginatedList<Reader>.CreateAsync(readers.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Readers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Readers == null)
            {
                return NotFound();
            }

            var reader = await _context.Readers
                .Include(r => r.MostRecentTakenBook)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        // GET: Readers/Create
        public IActionResult Create()
        {
            ViewBag.Books = new SelectList(_context.Books, "Id", "Title");
            return View();
        }

        // POST: Readers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,DateOfBirth,MembershipDate,NumberOfBoughtBooks,MostRecentTakenBookId")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Books = new SelectList(_context.Books, "Id", "Title", reader.MostRecentTakenBookId);
            return View(reader);
        }

        // GET: Readers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Readers == null)
            {
                return NotFound();
            }

            var reader = await _context.Readers.FindAsync(id);
            if (reader == null)
            {
                return NotFound();
            }
            ViewBag.Books = new SelectList(_context.Books, "Id", "Title");
            return View(reader);
        }

        // POST: Readers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,DateOfBirth,MembershipDate,NumberOfBoughtBooks,MostRecentTakenBookId")] Reader reader)
        {
            if (id != reader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReaderExists(reader.Id))
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
            ViewBag.Books = new SelectList(_context.Books, "Id", "Title", reader.MostRecentTakenBookId);
            return View(reader);
        }

        // GET: Readers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Readers == null)
            {
                return NotFound();
            }

            var reader = await _context.Readers
                .Include(r => r.MostRecentTakenBook)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        // POST: Readers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Readers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Readers'  is null.");
            }
            var reader = await _context.Readers.FindAsync(id);
            if (reader != null)
            {
                _context.Readers.Remove(reader);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReaderExists(int id)
        {
            return (_context.Readers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
