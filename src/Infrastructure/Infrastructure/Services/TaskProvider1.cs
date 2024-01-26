using Application.Interfaces.Services;
using Newtonsoft.Json.Linq;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class TaskProvider1 : ITaskProvider
    {
        readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://run.mocky.io/v3/0f7a9194-a5d8-4050-91a6-ab087c8a196b";

        public TaskProvider1()
        {
            
        }
        public TaskProvider1(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<List<Developer>> GetDevelopers()
        {
            var response = await _httpClient.GetStringAsync(_apiUrl);

            var developerJson = JObject.Parse(response)["developers"] as JArray;

            List<Developer> developerList = new();

            foreach (var item in developerJson)
            {
                developerList.Add(new Developer
                {
                    ID = item["Id"]?.Value<int>() ?? 0,
                    DeveloperName = item["name"]?.Value<string>() ?? string.Empty,
                    Capacity = item["hourly_capacity"]?.Value<int>() ?? 0
                });
            }

            return developerList;
        }

        public async Task<List<Tasks>> GetTasks()
        {
            var response = await _httpClient.GetStringAsync(_apiUrl);

            var developerJson = JObject.Parse(response)["tasks"] as JArray;

            List<Tasks> taskList = new();

            foreach (var item in developerJson)
            {
                taskList.Add(new Tasks
                {
                    ID = item["id"]?.Value<int>() ?? 0,
                    Name = item["name"]?.Value<string>() ?? string.Empty,
                    Duration = item["duration"]?.Value<int>() ?? 0,
                    Difficulty = item["difficulty"]?.Value<int>() ?? 0,
                    DeveloperId = item["developerId"]?.Value<int>() ?? 0,
                });
            }

            return taskList;
        }
    }
}
