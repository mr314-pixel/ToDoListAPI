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
        public ToDoItem CreateToDoItem(ToDoItem_Post item)
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

        public ToDoItem? UpdateToDoItem(ToDoItem_Patch item)
        {
            using (var context = new ApiContext())
            {
                var itemList = context.ToDoItems.Where(s => s.Id == item.Id);
                if (itemList.Count() != 1)
                {
                    return null;
                }
                ToDoItem existingItem = itemList.First();
                if (item.IsUpdatingTitle)
                {
                    existingItem.Title = item.Title;
                }
                if (item.IsUpdatingDescription)
                {
                    existingItem.Description = item.Description;
                }
                if (item.IsUpdatingCompletedDate)
                {
                    existingItem.CompletedDate = item.CompletedDate;
                }
                context.SaveChanges();

                return existingItem;
            }
        }
    }
}
