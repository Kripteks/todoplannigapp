using Application.Interfaces.Services;
using Domain.Entities;

namespace Infrastructure.Strategy;

public class TaskProviderStrategy
{
    private readonly ITaskProvider _taskProvider;

    public TaskProviderStrategy()
    {
        
    }
    public TaskProviderStrategy(ITaskProvider taskProvider)
    {
        _taskProvider = taskProvider;
    }

    public Task<List<Developer>> GetDevelopers()
    {
        return _taskProvider.GetDevelopers();
    }

    public Task<List<Tasks>> GetTasks()
    {
        return _taskProvider.GetTasks();
    }
}