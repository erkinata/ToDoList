using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoList.Models
{
    public class TaskListVM
    {
        public TaskList? TaskList { get; set; }

        public List<SelectListItem>? CategoryListItems { get; set; }     
       
        public ICollection<TaskList>? TaskLists {get; set; }               
    }
}
