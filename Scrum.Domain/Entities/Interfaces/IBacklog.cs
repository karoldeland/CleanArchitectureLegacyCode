using System.Collections.Generic;
using Scrum.Domain.Entities;

namespace Scrum.Domain
{
    public interface IBacklog
    {
        void AddTask(IStoryTask task);
        IList<IStoryTask> GetTaskList();
        IList<IEpic> Epics { get; set; }
    }
}