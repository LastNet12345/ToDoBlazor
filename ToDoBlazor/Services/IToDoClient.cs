using ToDoBlazor.Shared;

namespace ToDoBlazor.Services
{
    public interface IToDoClient
    {
        Task<IEnumerable<Item>> GetAsync();
    }
}