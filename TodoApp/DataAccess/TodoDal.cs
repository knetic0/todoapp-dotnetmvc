using System.Linq.Expressions;
using TodoApp.Models;

namespace TodoApp.DataAccess
{
    public class TodoDal(TodoAppDbContext todoAppDbContext) : ITodoDal
    {
        private readonly TodoAppDbContext _todoAppDbContext = todoAppDbContext;

        public void Add(Todo todo)
        {
            _todoAppDbContext.Todos.Add(todo);
            _todoAppDbContext.SaveChanges();
        }

        public Todo Delete(Todo todo)
        {
            _todoAppDbContext.Todos.Remove(todo);
            _todoAppDbContext.SaveChanges();
            return todo;
        }

        public IEnumerable<Todo>? GetAll(Expression<Func<Todo, bool>>? filter = null)
        {
            return filter == null
                ? _todoAppDbContext.Todos.ToList()
                : _todoAppDbContext.Todos.Where(filter).ToList();
        }

        public Todo Get(Expression<Func<Todo, bool>> filter)
        {
            return _todoAppDbContext.Todos.Where(filter).Single();
        }

        public Todo Update(Todo todo)
        {
            Todo entityToUpdate = _todoAppDbContext.Todos.First(t => t.Id == todo.Id);

            entityToUpdate.Title = todo.Title;
            entityToUpdate.UpdatedDate = DateTime.Now;
            entityToUpdate.IsDone = todo.IsDone;
            entityToUpdate.Description = todo.Description;

            _todoAppDbContext.SaveChanges();

            return entityToUpdate;
        }
    }
}
