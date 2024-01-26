using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ITaskProvider
    {
        Task<List<Developer>> GetDevelopers();
        Task<List<Tasks>> GetTasks();
    }
}
