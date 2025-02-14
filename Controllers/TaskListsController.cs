using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TaskListsController : Controller
    {
        private readonly ToDoListDbContext _context;

        public TaskListsController(ToDoListDbContext context)
        {
            _context = context;
        }

        // GET: TaskLists
        public async Task<IActionResult> Index()                //YAZDIK

        {
            TaskListVM taskListVM = new TaskListVM();
            taskListVM.TaskLists= await _context.TaskList.Include(t=> t.CategoryList).ToListAsync();

            return View(taskListVM);
        }



        // GET: TaskLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskList = await _context.TaskList
                .FirstOrDefaultAsync(m => m.TaskListId == id);
            if (taskList == null)
            {
                return NotFound();
            }

            return View(taskList);
        }

        // GET: TaskLists/Create
        public IActionResult Create()                  //-YAZDIK-

        {
            TaskListVM taskListVM = new();
            taskListVM.CategoryListItems = GetCategoryNameList();

            return View(taskListVM);
        }

        private List<SelectListItem> GetCategoryNameList()         //-------YAZDIK
        {
            var GetCategoryNameList = _context.CategoryList.Select(i => new SelectListItem
            {
                Text = i.CategoryName,
                Value = i.CategoryListId.ToString()
            }).ToList();                    // Order by ekelenebilir
            return GetCategoryNameList;
                }

        //-----------------------------------------------------------------------------------------------------------------------------------------------

        // POST: TaskLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskListId,RegisterDate,CategoryListId,TaskName,TaskDescription,TaskStatus")] TaskList taskList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskList);
        }

        // GET: TaskLists/Edit/5
        public async Task<IActionResult> Edit(int? id)              //
        {
            if (id == null)
            {
                return NotFound();
            }
            TaskListVM taskListVM = new TaskListVM();
            taskListVM.CategoryListItems = GetCategoryNameList();
            taskListVM.TaskList = await _context.TaskList.FindAsync(id);
            if (taskListVM.TaskList == null)
            {
                return NotFound();
            }
            return View(taskListVM);
        }

        // POST: TaskLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskListVM taskListVM)
        {
            if (ModelState.IsValid)
            {
                TaskList taskList = await _context.TaskList.FindAsync(id);

                taskList.CategoryListId = taskListVM.TaskList.CategoryListId;
                 taskList.TaskName = taskListVM.TaskList.TaskName;
                 taskList.TaskDescription = taskListVM.TaskList.TaskDescription;
                 taskList.TaskStatus = taskListVM.TaskList.TaskStatus;



                try
                {
                    _context.Update(taskList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskListExists(taskListVM.TaskList.TaskListId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taskListVM);
        }

        // GET: TaskLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskList = await _context.TaskList
                .FirstOrDefaultAsync(m => m.TaskListId == id);
            if (taskList == null)
            {
                return NotFound();
            }

            return View(taskList);
        }

        // POST: TaskLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskList = await _context.TaskList.FindAsync(id);
            if (taskList != null)
            {
                _context.TaskList.Remove(taskList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskListExists(int id)
        {
            return _context.TaskList.Any(e => e.TaskListId == id);
        }
    }
}
