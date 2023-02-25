using classTwoTodo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace classTwoTodo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

  
    public class TodosController : ControllerBase
    {
        public List<TodoItems> todos = new List<TodoItems>()
        {
        new TodoItems("001","Task one",false,"user001"),
        new TodoItems("002","Task two",false,"user002"),
        new TodoItems("003","Task three",true,"user003")
        };
        [HttpGet("Get Todos"),Authorize]
        // [HttpGet("Get Todos"),Authorize(Roles ="Admin")]
        public List<TodoItems> getAllTodos()
        {
            return todos;
        }

    }
}
