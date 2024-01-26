## Architectures & Patterns
- Onion Architecture
- Repository Design Pattern
- Strateggy
- Aggregator

## Paketler
- Swagger
- Microsoft EntityFramework Core
- Microsoft EntityFramework Core SQL Server
- Microsoft EntityFramework Core Tools
- Microsoft EntityFramework Core Design
- Microsoft Extensions Dependenjy Injection
- Newtonsoft Json
- ConsoleTables

## Klasör Yapısı
```bash
TodoPlaningProjects/
|-- Domain/
|   |-- Entities/
|   |-- Common/
|
|-- Application/
|   |-- Interfaces/
|   |-- Abstract/
|   |-- DTOs/
|
|-- Infrastructure/
|   |-- Abstract/
|   |-- Aggregator/
|   |-- Services/ 
|   |-- Strategy/
|
|-- Persistence/
|   |-- Configurations/
|   |-- Context/
|   |-- Migrations/
|   |-- Repositories/
|   |-- UnitOfWorks/
|
|-- Presentation/
    |-- TodoWebAPI/
    |-- TodoConsoleApp/
```

## Bilgi

Proje Onion Architecture design patterni ile geliştirilmiştir.Projede Web API ve Console App olmak üzere 2 proje bulunmaktadır.Web API içerisinde backend servisi geliştirilmiştir ve bu projeye bağlı farklı katmanlar bulunmaktadır. 
Console App içerisinde backend servisine istek atıp consol ekranında table yapısıyla listelenmektedir.Bu yüzden front-end için ayrı bir geliştirilme yapılmadı. 

MSSQL Server Windows uyumlu olduğundan dockerize işlemi yapılmadı, TodoWebAPI > appsetings.json > SQLConnection alanından db bilgilerinizi güncelleyebilirsiniz

## Kurulum

Gereksinimler:

1. [Docker](https://docs.docker.com/engine/install/) veya Mac için [Orbstack](https://orbstack.dev/download)
2. [Docker Compose](https://docs.docker.com/compose/install/)
3. [ASP .NET Core 7.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
4. MSSQL Server

## Komutlar
Package Console Manager üzerinden aşağıdaki komutları çalıştırabilirsiniz.
Uygulamayı çalıştırmak için;

```bash
docker build -t aspnetapp .
docker run -it --rm -p 5000:80 --name aspnetcore_sample aspnetapp
```
Migrationları oluşturmak için;

```bash
Add-Migration [name]
```

```bash
Update-Database
```
