using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    
    public class TaskRepository : Repository<Tasks>, ITasksRepository
    {
        public TaskRepository(AppDbContext context) : base(context)
        {

        }
    }
}
