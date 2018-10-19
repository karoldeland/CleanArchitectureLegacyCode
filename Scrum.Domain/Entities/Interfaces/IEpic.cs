using System.Collections.Generic;

namespace Scrum.Domain.Entities
{
    public interface IEpic
    {
        IList<IFeature> Features { get; set; }
        IList<IStoryTask> GetTaskList();
    }
}