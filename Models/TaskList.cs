using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class TaskList
    {
        [Display(Name = "Task List ID")]
        public int TaskListId { get; set; }

        [Display(Name ="Register Date")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        [Display(Name ="Category Name")]
        public int CategoryListId { get; set; }

        [Display(Name= "Task Name")]

        public string? TaskName { get; set; }

        [Display(Name = "Task Description")]
        public string? TaskDescription { get; set; }

        [Display(Name = "Task Status")]
        public string TaskStatus { get; set; } = "Pending";

        public CategoryList? CategoryList { get; set; }             //tablo birleştirme

    }
}
