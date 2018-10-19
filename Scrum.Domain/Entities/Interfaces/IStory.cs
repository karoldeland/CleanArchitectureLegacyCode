using System.Collections.Generic;

namespace Scrum.Domain.Entities
{
    public interface IStory
    {
        IList<IStoryTask> Tasks { get; set; }
        IList<IStoryTask> GetTaskList();
    }
}