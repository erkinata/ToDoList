using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    
    public class CategoryListsController : Controller
    {
        private readonly ToDoListDbContext _context;

        public CategoryListsController(ToDoListDbContext context)  //Biz yazdık
        {
            _context = context;
        }

        // GET: CategoryLists
        public async Task<IActionResult> Index()
        {
            CategoryListVM categoryListVM=new CategoryListVM();
            categoryListVM.CategoryLists =await _context.CategoryList.ToListAsync();
            return View(categoryListVM);

        }

        // GET: CategoryLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryList = await _context.CategoryList
                .FirstOrDefaultAsync(m => m.CategoryListId == id);
            if (categoryList == null)
            {
                return NotFound();
            }

            return View(categoryList);
        }

        // GET: CategoryLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CategoryListVM categoryListVM)
        {
            if (ModelState.IsValid)
            {
                CategoryList categoryList = new CategoryList();
                categoryList.CategoryName = categoryListVM.CategoryList.CategoryName;
                _context.Add(categoryList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryListVM);
        }

        // GET: CategoryLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryList = await _context.CategoryList.FindAsync(id);
            if (categoryList == null)
            {
                return NotFound();
            }
            return View(categoryList);
        }


        public  IActionResult GetCategoryList(int categoryListId)
        {
           

            var categoryList =  _context.CategoryList.Find(categoryListId);
           
            return Json(categoryList);
        }




        // POST: CategoryLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryListId,CategoryName")] CategoryList categoryList)
        {
            if (id != categoryList.CategoryListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryListExists(categoryList.CategoryListId))
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
            return View(categoryList);
        }


        public IActionResult Update(CategoryListVM categoryListVM)
        {
            var categoryList = _context.CategoryList.Find(categoryListVM.CategoryList.CategoryListId);
            categoryList.CategoryName = categoryListVM.CategoryList.CategoryName;

            _context.CategoryList.Update(categoryList);
            _context.SaveChanges();

            return RedirectToAction("Index","CategoryLists");
        }






        // GET: CategoryLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryList = await _context.CategoryList
                .FirstOrDefaultAsync(m => m.CategoryListId == id);
            if (categoryList == null)
            {
                return NotFound();
            }

            return View(categoryList);
        }

        // POST: CategoryLists/Delete/5
        [Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryList = await _context.CategoryList.FindAsync(id);
            if (categoryList != null)
            {
                _context.CategoryList.Remove(categoryList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryListExists(int id)
        {
            return _context.CategoryList.Any(e => e.CategoryListId == id);
        }
    }
}
