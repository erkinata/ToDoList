namespace ToDoList.Models
{
    public class CategoryListVM
    {
        public CategoryList? CategoryList { get; set; }

        public ICollection<CategoryList>? CategoryLists { get; set; }
    }
}
