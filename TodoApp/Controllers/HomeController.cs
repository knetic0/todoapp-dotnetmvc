using Microsoft.AspNetCore.Mvc;
using TodoApp.DataAccess;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class HomeController(ITodoDal todoDal) : Controller
    {
        private readonly ITodoDal _todoDal = todoDal;

        public IActionResult Index()
        {
            IEnumerable<Todo>? todos = _todoDal.GetAll(todo => todo.IsDone == false);
            return View(todos);
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
    }
}
