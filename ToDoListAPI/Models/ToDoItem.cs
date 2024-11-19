﻿namespace ToDoListAPI.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public int ToDoListId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}