using ConsoleTables;
using System.Text.Json;
using TodoConsoleApp;
using Application.Interfaces.Services;
using Infrastructure.Services;

Console.WriteLine("App Start");

var httpClient = new HttpClient();

try
{
    string url = "https://localhost:44350/api/Developer";

    HttpResponseMessage response = await httpClient.GetAsync(url);

    if (response.IsSuccessStatusCode)
    {
        string content = await response.Content.ReadAsStringAsync();

        RootObject rootObject = JsonSerializer.Deserialize<RootObject>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Console.WriteLine($"İşlerin tamamlanması için gereken toplam hafta sayısı: {rootObject.TotalWeeksReport}");
        Console.WriteLine();

        List<TableDto> tableDtos = new();

        foreach (var dev in rootObject.DeveloperReport)
        {
            foreach (var assignment in dev.Assignments)
            {
                tableDtos.Add(new TableDto() { DeveloperName = dev.DeveloperName, AssignedWeek = assignment.AssignedWeek, TaskName = assignment.Task.Name, HoursSpent = assignment.HoursSpent });
            }
        }

       
        ConsoleTable.From<TableDto>(tableDtos).Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.MarkDown);
    }
    else
    {
        Console.WriteLine("API'den veri çekme başarısız.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Hata: {ex.Message}");
}

Console.ReadLine();
