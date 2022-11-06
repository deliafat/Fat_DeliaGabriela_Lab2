using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fat_DeliaGabriela_Lab2.Data;
using Fat_DeliaGabriela_Lab2.Models;

namespace Fat_DeliaGabriela_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Fat_DeliaGabriela_Lab2.Data.Fat_DeliaGabriela_Lab2Context _context;

        public IndexModel(Fat_DeliaGabriela_Lab2.Data.Fat_DeliaGabriela_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;

        public BookData BookD { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public async Task OnGetAsync(int? id, int? categoryId)
        {
            BookD = new BookData();

            BookD.Books = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
            if (id != null)
            {
                BookId = id.Value;
                Book book = BookD.Books
                .Where(i => i.Id == id.Value).Single();
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
        }
    }
}

    
