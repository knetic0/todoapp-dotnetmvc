using Microsoft.AspNetCore.Mvc;
using TodoApp.DataAccess;
using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    public class TodoController(ITodoDal todoDal) : Controller
    {
        private readonly ITodoDal _todoDal = todoDal;

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Todo>? todos = _todoDal.GetAll();
            return View(todos);
        }

        [HttpGet]
        public IActionResult AddTodo()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult AddTodo(AddTodoModel args)
        {
            Todo todo = new Todo()
            {
                Title = args.Title,
                Description = args.Description ?? string.Empty,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsDone = false,
            };

            _todoDal.Add(todo);

            return RedirectToAction("Index");
        }
    }
}
