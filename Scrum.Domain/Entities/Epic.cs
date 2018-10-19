using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Domain.Entities
{
    public class Epic : IEpic
    {
        public IList<IFeature> Features { get; set; }

        public IList<IStoryTask> GetTaskList()
        {
            // Query all tasks in object graph
            return Features.SelectMany(feature => feature.GetTaskList()).ToList();
        }
    }
}
