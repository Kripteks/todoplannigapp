using Application.Interfaces.Services;
using Domain.Entities;

namespace Infrastructure.Aggregator
{
    public class DeveloperAggregator
    {
        private readonly IEnumerable<ITaskProvider> _providers;

        public DeveloperAggregator(IEnumerable<ITaskProvider> providers)
        {
            _providers = providers;
        }

        public async Task<List<Developer>> GetAllDevelopersAsync()
        {
            var developers = new List<Developer>();

            foreach (var provider in _providers)
            {
                foreach (var item in await provider.GetDevelopers())
                {
                    developers.Add(item);
                }
            }

            return developers;
        }

        public async Task<List<Tasks>> GetAllTasksAsync()
        {
            var tasksList = new List<Tasks>();

            foreach (var provider in _providers)
            {
                foreach (var item in await provider.GetTasks())
                {
                    tasksList.Add(item);
                }
            }

            return tasksList;
        }


    }
}
