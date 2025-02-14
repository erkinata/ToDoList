using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.ViewComponents
{
    public class TaskListsViewComponent :ViewComponent
    {
        private readonly ToDoListDbContext _context;

        public TaskListsViewComponent(ToDoListDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(string categoryListId)
        {
            CategoryTaskVM vm = new CategoryTaskVM();


            var taskList = _context.TaskList.Where(m => m.CategoryListId == int.Parse(categoryListId)).ToList();
            vm.TaskLists = taskList;

            return View(vm);
        }

    }
}
