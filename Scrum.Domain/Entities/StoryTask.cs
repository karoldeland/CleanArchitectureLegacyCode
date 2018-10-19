namespace Scrum.Domain.Entities
{
    public class StoryTask : IStoryTask
    {
        public StoryTask(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}