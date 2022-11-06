using Microsoft.AspNetCore.Mvc.RazorPages;
using Fat_DeliaGabriela_Lab2.Data; 
namespace Fat_DeliaGabriela_Lab2.Models
{
    public class BookCategoriesPageModel: PageModel

    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Fat_DeliaGabriela_Lab2Context context,
        Book book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(
            book.BookCategories.Select(c => c.CategoryId));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryId= cat.Id,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.Id)
                });
            }
        }
        public void UpdateBookCategories(Fat_DeliaGabriela_Lab2Context context,
        string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.BookCategories = new List<BookCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (bookToUpdate.BookCategories.Select(c => c.Category.Id));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.Id.ToString()))
                {
                    if (!bookCategories.Contains(cat.Id))
                    {
                        bookToUpdate.BookCategories.Add(
                        new BookCategory
                        {
                            BookId = bookToUpdate.Id, 
                            CategoryId = cat.Id
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.Id))
                    {
                        BookCategory courseToRemove
                        = bookToUpdate
                        .BookCategories
                        .SingleOrDefault(i => i.CategoryId == cat.Id);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
