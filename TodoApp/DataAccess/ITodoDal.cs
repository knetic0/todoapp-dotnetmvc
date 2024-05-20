using System.Linq.Expressions;
using TodoApp.Models;

namespace TodoApp.DataAccess
{
    public interface ITodoDal
    {
        void Add(Todo todo);

        Todo Delete(Todo todo);
        
        IEnumerable<Todo>? GetAll(Expression<Func<Todo, bool>>? filter = null);
        
        Todo Get(Expression<Func<Todo, bool>> filter);
        
        Todo Update(Todo todo);
    }
}
