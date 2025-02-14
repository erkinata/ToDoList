using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoList.Models
{
    public class CategoryTaskVM
    {
        public TaskList? TaskList { get; set; }

        public List<SelectListItem>? CategoryListItems { get; set; }     

        public ICollection<TaskList>? TaskLists { get; set; }                

        public CategoryList? CategoryList { get; set; }

        public ICollection<CategoryList>? CategoryLists { get; set; }


    }
}
