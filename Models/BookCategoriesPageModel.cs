using Microsoft.AspNetCore.Mvc.RazorPages;
using Moisi_Olivia_Debora_Lab8.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moisi_Olivia_Debora_Lab8.Models
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Moisi_Olivia_Debora_Lab8Context context, Book book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(
                book.BookCategories.Select(c => c.BookID));

            AssignedCategoryDataList = new List<AssignedCategoryData>();

            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateBookCategories(Moisi_Olivia_Debora_Lab8Context context, string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.BookCategories = new List<BookCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>(
                bookToUpdate.BookCategories.Select(c => c.Category.ID));

            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.BookCategories.Add(
                            new BookCategory
                            {
                                BookID = bookToUpdate.ID,
                                CategoryID = cat.ID
                            });
                    }
                } 
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        BookCategory courseToRemove = bookToUpdate.BookCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
