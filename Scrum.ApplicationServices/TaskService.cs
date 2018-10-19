using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scrum.Domain;
using Scrum.Domain.Entities;

namespace Scrum.ApplicationServices
{
    public class TaskService
    {
        private readonly IBacklog _backlog;
        private readonly IEventPublisher _eventPublisher;
        private readonly ITaskRepository _taskRepository;

        public TaskService(IBacklog backlog, IEventPublisher eventPublisher)
        {
            _backlog = backlog;
            _eventPublisher = eventPublisher;
        }

        #region Repository

        public TaskService(IEventPublisher eventPublisher, ITaskRepository taskRepository)
        {
            _eventPublisher = eventPublisher;
            _taskRepository = taskRepository;
        }

        public IList<IStoryTask> GetHighPriorityTaskListEx()
        {
            return _taskRepository.GetHighPriorityTaskList();
        }

        #endregion

        public IList<IStoryTask> GetHighPriorityTaskList()
        {
            return _backlog.Epics[0].Features[0].Stories[0].Tasks;
        }
        
        public void SaveTask(IStoryTask task)
        {
            // Save task ...
            _backlog.Epics[0].Features[0].Stories[0].Tasks.Add(task);

            _eventPublisher.Publish(new TaskModifiedEvent(task.Id));
        }
    }
}
