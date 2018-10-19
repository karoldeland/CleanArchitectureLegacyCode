using System.Collections.Generic;
using Scrum.ApplicationServices;
using Scrum.Domain;
using Scrum.Domain.Entities;

namespace Scrum.Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        private IBacklog _backlog;

        public TaskRepository(IBacklog backlog)
        {
            _backlog = backlog;
        }

        public IList<IStoryTask> GetHighPriorityTaskList()
        {
            return _backlog.Epics[0].Features[0].Stories[0].Tasks;
        }
    }
}