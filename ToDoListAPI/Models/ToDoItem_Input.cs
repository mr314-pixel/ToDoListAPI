namespace ToDoListAPI.Models
{
    public class ToDoItem_Input
    {
        public int ToDoListId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
