using Microsoft.AspNetCore.Mvc;
using Infrastructure.Aggregator;
using Application.Interfaces.Strategy;
using Application.Interfaces.Repositories;

namespace TodoWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly DeveloperAggregator _aggregator;
        private readonly IStrategy _strategy;
        private readonly IDeveloperRepository _developerRepository;
        private readonly ITasksRepository _taskRepository;
        public DeveloperController(DeveloperAggregator aggregator, IStrategy strategy, IDeveloperRepository developerRepository, ITasksRepository taskRepository)
        {
            _aggregator = aggregator;
            _strategy = strategy;
            _developerRepository = developerRepository;
            _taskRepository = taskRepository;
        }


        [HttpGet(Name = "GetDevelopers")]
        public async Task<IActionResult> Get()
        {
            var developers = await _aggregator.GetAllDevelopersAsync();
            var tasks = await _aggregator.GetAllTasksAsync();

            _strategy.AssignTasks(developers, tasks);
            var result = _strategy.CalculateAndPrintPlan();

            await _developerRepository.AddRangeAsync(developers);
            await _taskRepository.AddRangeAsync(tasks);

            return Ok(new { DeveloperReport = result.Item1, TotalWeeksReport = result.Item2 });
        }
    }
}
