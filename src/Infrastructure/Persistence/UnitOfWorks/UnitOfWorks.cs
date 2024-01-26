using Application.Interfaces.Repositories;
using Application.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;

namespace Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IDeveloperRepository DeveloperRepository { get; }

        public ITasksRepository TasksRepository { get; }

        public UnitOfWork(AppDbContext context, IDeveloperRepository productRepository, ITasksRepository tasksRepository)
        {
            _context = context;
            DeveloperRepository = productRepository;
            TasksRepository = tasksRepository;
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();
        public async ValueTask DisposeAsync() { }
    }
}
