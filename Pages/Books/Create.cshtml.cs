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

namespace Fat_DeliaGabriela_Lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Fat_DeliaGabriela_Lab2.Data.Fat_DeliaGabriela_Lab2Context _context;

        public CreateModel(Fat_DeliaGabriela_Lab2.Data.Fat_DeliaGabriela_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherId"] = new SelectList(_context.Set<Publisher>(), "Id",
 "PublisherName");
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "FullName");

            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }
        [BindProperty]
        public Book Book { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryId = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Book>(
            newBook,
            "Book",
            i => i.Title, i => i.Author,
            i => i.Price, i => i.PublishingDate, i => i.PublisherId))
            {
                _context.Book.Add(newBook);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newBook);
            return Page();
        }
    }
}
