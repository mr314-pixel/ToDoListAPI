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

        /// <summary>
        /// Get items in a to-do list.
        /// </summary>
        /// <param name="toDoItemIds">Filter items by a list of item IDs. An empty list will return all available items.</param>
        /// <param name="toDoListId">Filter items by to-do list ID.</param>
        /// <returns>List of matched items.</returns>
        [HttpGet("~/GetToDoItems")]
        public ActionResult<IEnumerable<ToDoItem>> GetToDoItems([FromQuery] List<int> toDoItemIds, [FromQuery] int toDoListId = 0)
        {
            return Ok(_toDoListRepository.GetToDoItems(toDoItemIds, toDoListId));
        }

        /// <summary>
        /// Create an item in a specific to-do list.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        /// <returns>The added item.</returns>
        [HttpPost("~/CreateToDoItem")]
        public ActionResult<ToDoItem> CreateToDoItem([FromQuery] ToDoItem_Post item)
        {
            return Ok(_toDoListRepository.CreateToDoItem(item));
        }

        /// <summary>
        /// Update an item.
        /// </summary>
        /// <param name="item">The item to be updated.</param>
        /// <returns>The updated item. Will throw an NotFound error if the item ID does not exist.</returns>
        [HttpPatch("~/UpdateToDoItem")]
        public ActionResult<ToDoItem> UpdateToDoItem([FromQuery] ToDoItem_Patch item)
        {
            var result = _toDoListRepository.UpdateToDoItem(item);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
