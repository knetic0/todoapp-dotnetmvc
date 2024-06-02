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
        public IActionResult UpdateTodo(int id)
        {
            Todo todo = _todoDal.Get(todo => todo.Id == id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult UpdateTodo(Todo todo)
        {
            _todoDal.Update(todo);
            todo.UpdatedDate = DateTime.Now;
            return RedirectToAction("Index");
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

        [HttpPost]
        public IActionResult MarkTodoIsDone(int id)
        {
            Todo todo = _todoDal.Get(todo => todo.Id == id);
            todo.IsDone = true;
            todo.UpdatedDate = DateTime.Now;
            _todoDal.Update(todo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteTodo(int id)
        {
            Todo todo = _todoDal.Get(todo => todo.Id == id);
            _todoDal.Delete(todo);
            return RedirectToAction("Index");
        }
    }
}
