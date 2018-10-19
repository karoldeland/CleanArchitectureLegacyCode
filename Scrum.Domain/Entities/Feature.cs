using System.Collections.Generic;
using System.Linq;

namespace Scrum.Domain.Entities
{
    public class Feature : IFeature
    {
        public IList<IStory> Stories { get; set; }
                
        public IList<IStoryTask> GetTaskList()
        {
            return Stories.SelectMany(story => story.GetTaskList()).ToList();
        }
    }
}