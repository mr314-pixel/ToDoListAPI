using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Models;
using ToDoListAPI.Repositories;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        readonly IToDoListRepository _toDoListRepository;

        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet("~/GetToDoItems")]
        public ActionResult<IEnumerable<ToDoItem>> GetToDoItems([FromQuery] List<int> toDoItemIds, [FromQuery] int toDoListId = 0)
        {
            return Ok(_toDoListRepository.GetToDoItems(toDoItemIds, toDoListId));
        }
    }
}
