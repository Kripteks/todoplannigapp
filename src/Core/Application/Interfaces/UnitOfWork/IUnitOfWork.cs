using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        public IDeveloperRepository DeveloperRepository { get; }
        public ITasksRepository TasksRepository { get; }
    }
}
