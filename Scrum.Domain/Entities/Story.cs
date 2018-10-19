using System.Collections.Generic;

namespace Scrum.Domain.Entities
{
    public class Story : IStory
    {
        public IList<IStoryTask> Tasks { get; set; }

        public IList<IStoryTask> GetTaskList()
        {
            return Tasks;
        }
    }
}