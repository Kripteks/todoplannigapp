using Application.Interfaces.Services;
using Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure.Services
{
    public class TaskProvider3 : ITaskProvider
    {
        readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://run.mocky.io/v3/a7775176-a4c6-4c54-be06-caa440df6985";

        public TaskProvider3()
        {

        }
        public TaskProvider3(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<List<Developer>> GetDevelopers()
        {
            var response = await _httpClient.GetStringAsync(_apiUrl);

            var xDocument = XDocument.Parse(response);
            var developerElements = xDocument.Descendants("developer");

            var developerList = new List<Developer>();

            foreach (var element in developerElements)
            {
                var name = element.Element("dev_name")?.Value;
                var capacity = element.Element("capacity_per_hour")?.Value;

                developerList.Add(new Developer
                {
                    DeveloperName = name ?? string.Empty,
                    Capacity = string.IsNullOrEmpty(capacity) ? 0 : int.Parse(capacity)
                });
            }


            return developerList;
        }

        public async Task<List<Tasks>> GetTasks()
        {
            var response = await _httpClient.GetStringAsync(_apiUrl);

            var xDocument = XDocument.Parse(response);
            var developerElements = xDocument.Descendants("task");

            var taskList = new List<Tasks>();

            foreach (var element in developerElements)
            {
                var name = element.Element("name")?.Value;
                var duration = element.Element("duration")?.Value;
                var difficulty = element.Element("difficulty")?.Value;

                taskList.Add(new Tasks
                {
                    Name = name ?? string.Empty,
                    Duration = string.IsNullOrEmpty(duration) ? 0 : int.Parse(duration),
                    Difficulty = string.IsNullOrEmpty(difficulty) ? 0 : int.Parse(difficulty),
                });
            }
            return taskList;
        }
    }
}
