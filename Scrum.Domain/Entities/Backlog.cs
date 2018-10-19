using System.Collections.Generic;
using System.Linq;

namespace Scrum.Domain.Entities
{
    public class Backlog : IBacklog
    {
        public IList<IEpic> Epics { get; set; }

        public void AddTask(IStoryTask task)
        {
            // Navigate through the graph to add the task at the right place
        }

        public IList<IStoryTask> GetTaskList()
        {
            // Query all tasks in object graph
            return Epics.SelectMany(epic => epic.GetTaskList()).ToList();
        }
    }
}
