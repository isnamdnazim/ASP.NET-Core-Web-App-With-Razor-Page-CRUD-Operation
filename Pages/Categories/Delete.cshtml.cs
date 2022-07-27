using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApplication.Data;
using RazorWebApplication.Model;
namespace RazorWebApplication.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
     
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
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
            
            
                var categoryFromDb = _db.category.Find(category.Id);
                if(categoryFromDb != null)
                {
                    _db.category.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "Category Deleted Successfully";
                    return RedirectToPage("Index");
                }
                
                
            
            return Page();
            
        }
    }
}
