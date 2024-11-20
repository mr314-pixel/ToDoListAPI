using ToDoListAPI.Models;

namespace ToDoListAPI.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        public List<ToDoItem> GetToDoItems(List<int> toDoItemId, int toDoListId)
        {
            using (var context = new ApiContext())
            {
                var toDoItems = context.ToDoItems
                    .Where(s => s.ToDoListId == toDoListId && (toDoItemId == null || !toDoItemId.Any() || toDoItemId.Contains(s.Id)))
                    .ToList();

                return toDoItems;
            }
        }

        // TODO: Create ToDoList object when a new ToDoListId is provided
        public ToDoItem CreateToDoItem(ToDoItem_Input item)
        {
            using (var context = new ApiContext())
            {
                ToDoItem newItem = new ToDoItem
                {
                    ToDoListId = item.ToDoListId,
                    Title = item.Title,
                    Description = item.Description,
                    CreatedDate = DateTime.UtcNow,
                    CompletedDate = item.CompletedDate
                };
                context.ToDoItems.Add(newItem);
                context.SaveChanges();

                return newItem;
            }
        }

        public ToDoItem UpdateToDoItem(ToDoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
