using ToDoListAPI.Models;

namespace ToDoListAPI.Repositories
{
    public interface IToDoListRepository
    {
        public List<ToDoItem> GetToDoItems(List<int>? toDoItemIds, int toDoListId);
        public ToDoItem CreateToDoItem(ToDoItem_Post item);
        public ToDoItem? UpdateToDoItem(ToDoItem_Patch item);
    }
}
