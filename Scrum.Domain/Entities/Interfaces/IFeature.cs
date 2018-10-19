using System.Collections.Generic;

namespace Scrum.Domain.Entities
{
    public interface IFeature
    {
        IList<IStory> Stories { get; set; }
        IList<IStoryTask> GetTaskList();
    }
}