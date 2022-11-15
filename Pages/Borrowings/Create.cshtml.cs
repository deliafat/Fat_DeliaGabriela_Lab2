using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fat_DeliaGabriela_Lab2.Data;
using Fat_DeliaGabriela_Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Fat_DeliaGabriela_Lab2.Pages.Borrowings
{
    public class CreateModel : PageModel
    {
        private readonly Fat_DeliaGabriela_Lab2.Data.Fat_DeliaGabriela_Lab2Context _context;

        public CreateModel(Fat_DeliaGabriela_Lab2.Data.Fat_DeliaGabriela_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Book.Include(b => b.Author).Select(x => new { x.Id, BookFullName = x.Title + " - " + x.Author.LastName + " " + x.Author.FirstName });
            ViewData["BookId"] = new SelectList(bookList, "Id", "BookFullName");
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}