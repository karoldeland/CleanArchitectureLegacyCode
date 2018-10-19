using System.Collections.Generic;
using Scrum.Domain.Entities;

namespace Scrum.ApplicationServices
{
    public interface ITaskRepository
    {
        IList<IStoryTask> GetHighPriorityTaskList();
    }
}