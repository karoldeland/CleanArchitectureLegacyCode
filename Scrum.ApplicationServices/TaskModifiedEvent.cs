namespace Scrum.ApplicationServices
{
    public class TaskModifiedEvent
    {
        public int TaskId { get; }

        public TaskModifiedEvent(int taskId)
        {
            TaskId = taskId;
        }

        public override string ToString()
        {
            return $"TaskModified with id : {TaskId}";
        }
    }
}