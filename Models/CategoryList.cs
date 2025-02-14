using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class CategoryList
    {
        [Display(Name = "Category ID")]
        public int CategoryListId { get; set; }



        [Display(Name ="Category Name")]
        [Required(ErrorMessage ="Please enter {0} ")]
        public string? CategoryName { get; set; }



        public ICollection<TaskList> TaskList { get; set; }=new List<TaskList>();      





    }
}
