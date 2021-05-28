using System.Threading.Tasks;
using CodeZero.Data.Repositories;
using CodeZeroTemplate.Entities;

namespace CodeZeroTemplate.Core.Interfaces
{
    public interface IToDoItemRepository : IRepository<ToDoItem, int>
    {
        Task<ToDoItem> ListAsync();
    }
}