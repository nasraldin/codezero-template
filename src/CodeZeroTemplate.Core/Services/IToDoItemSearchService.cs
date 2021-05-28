using System.Collections.Generic;
using System.Threading.Tasks;
using CodeZero.Result;
using CodeZeroTemplate.Entities;

namespace CodeZeroTemplate.Core.Services
{
    public interface IToDoItemSearchService
    {
        Task<Result<ToDoItem>> GetNextIncompleteItemAsync();
        Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(string searchString);
    }
}