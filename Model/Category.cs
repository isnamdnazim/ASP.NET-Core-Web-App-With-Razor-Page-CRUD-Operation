using System.ComponentModel.DataAnnotations;

namespace RazorWebApplication.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Display Order")]
        [Range(1,100,ErrorMessage ="Display Order Must be in between 1 and 100.")]
        public int DisplayOrder { get; set; }

    }
}
