using Acme.SimpleTaskApp.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAngular.Tasks;

namespace TestAngular.EntityFrameworkCore.Seed.Tasks
{
  
    public class DefaultTasksBuilder
    {
        private readonly TestAngularDbContext _context;
        private readonly int _tenantId;
        public DefaultTasksBuilder(TestAngularDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }
        public void Create()
        {
            var tasks = new List<Acme.SimpleTaskApp.Tasks.Task>
            {
                new Task( _tenantId, "task one","Do Something") {State = TaskState.Open},
                new Task( _tenantId, "task two","Do Something") {State = TaskState.Open},
                new Task( _tenantId, "task three","Do Something") {State = TaskState.Open},

            };
            foreach(var task in tasks)
            {
                var existingTask = _context.Tasks.IgnoreQueryFilters().FirstOrDefault(t => t.TenantId == task.TenantId && t.Title== task.Title);
                if(existingTask == null) { _context.Tasks.Add(task); }
            }
            _context.SaveChanges();
        }

    }
}
