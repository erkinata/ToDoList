using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoList.Models
{
    public class CategoryTaskVM
    {
        public TaskList? TaskList { get; set; }

        public List<SelectListItem>? CategoryListItems { get; set; }     //select kutucuğundaki category nesneleri

        public ICollection<TaskList>? TaskLists { get; set; }                //tablo birleştirmek için ekledik

        public CategoryList? CategoryList { get; set; }

        public ICollection<CategoryList>? CategoryLists { get; set; }


    }
}
