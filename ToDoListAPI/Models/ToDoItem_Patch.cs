namespace ToDoListAPI.Models
{
    public class ToDoItem_Patch
    {
        public int Id { get; set; }

        public bool IsUpdatingTitle { get; set; }
        public string? Title { get; set; }

        public bool IsUpdatingDescription { get; set; }
        public string? Description { get; set; }

        public bool IsUpdatingCompletedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
