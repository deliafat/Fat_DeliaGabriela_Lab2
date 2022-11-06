using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fat_DeliaGabriela_Lab2.Data;
using Fat_DeliaGabriela_Lab2.Models;

namespace Fat_DeliaGabriela_Lab2.Pages.Categories
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
        ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id");
        ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public BookCategory BookCategory { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookCategory.Add(BookCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
