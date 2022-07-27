using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApplication.Data;
using RazorWebApplication.Model;
namespace RazorWebApplication.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
     
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.category.Find(id);
            //Category = _db.category.FirstOrDefault(u=> u.Id ==id);
            //Category = _db.category.SingleOrDefault(u=> u.Id==id);
            //Category = _db.category.Where(u=> u.Id==id).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost(Category category)
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display Order Cannot exactly match the Name!");
            }
            if (ModelState.IsValid)
            {
                _db.category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
