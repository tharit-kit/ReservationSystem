using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ReservationSystem.Middlewares.Repository
{
    public interface IRepository<T> where T : class
    {
        public Task<ActionResult<IEnumerable<T>>> Get(List<Expression<Func<T, bool>>> conditions);
        public Task<ActionResult<T>> Create(T entity);
        public Task<IActionResult> Update(int id, T entity);
        public Task<IActionResult> Delete(int id);
    }
}
