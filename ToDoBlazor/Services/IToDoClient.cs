using ToDoBlazor.Shared.Entities;

namespace ToDoBlazor.Services
{
    public interface IToDoClient
    {
        Task<IEnumerable<Item>> GetAsync();
    }
}