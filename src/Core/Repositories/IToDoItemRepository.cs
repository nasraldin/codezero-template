using System.Threading.Tasks;
using CodeZero.Data.Repositories;
using Entities;

namespace Core.Domain.Interfaces
{
    public interface IToDoItemRepository : IRepository<ToDoItem, int>
    {
        Task<ToDoItem> ListAsync();
    }
}