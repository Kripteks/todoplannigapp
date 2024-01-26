using Application.Interfaces.Services;
using Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TaskProvider2 : ITaskProvider
    {
        readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://run.mocky.io/v3/dcefd558-2d11-4035-9e94-2d6ce27675e0";

        public TaskProvider2()
        {

        }
        public TaskProvider2(IHttpClientFactory httpClientFactory)
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
                    DeveloperName = item["Name"]?.Value<string>() ?? string.Empty,
                    Capacity = item["capacity"]?.Value<int>() ?? 0
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
                    DeveloperId = item["developerId"]?.Value<int>() ?? 0, // assigned_developer
                });
            }

            return taskList;
        }
    }
}
