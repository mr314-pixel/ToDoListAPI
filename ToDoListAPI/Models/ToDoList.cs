using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public List<ToDoItem>? Items { get; set; }
    }
}
