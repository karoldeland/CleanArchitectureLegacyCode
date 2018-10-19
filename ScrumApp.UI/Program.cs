using System;
using System.Collections.Generic;
using Scrum.ApplicationServices;
using Scrum.Domain.Entities;

namespace ScrumApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var backlog = SeedBacklog();

            var eventHub = new EventHub();
            eventHub.Subscribe<TaskModifiedEvent>((taskModifiedEventObject) => Console.WriteLine(taskModifiedEventObject));

            var appService = new Scrum.ApplicationServices.TaskService(backlog, eventHub);

            appService.SaveTask(new StoryTask(1));

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static Backlog SeedBacklog()
        {
            return new Backlog()
            {
                Epics = new List<IEpic>()
                {
                    new Epic()
                    {
                        Features = new List<IFeature>()
                        {
                            new Feature()
                            {
                                Stories = new List<IStory>()
                                {
                                    new Story()
                                    {
                                        Tasks = new List<IStoryTask>()
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }

    internal class EventHub : IEventPublisher
    {
        private IDictionary<Type, Action<object>> _subscriptions  = new Dictionary<Type, Action<object>>();

        public void Publish<T>(T eventObject)
        {
            if (_subscriptions.ContainsKey(typeof(T)))
                _subscriptions[typeof(T)].Invoke(eventObject);
        }

        public void Subscribe<T>(Action<object> handler) where T : class

        {
            if (!_subscriptions.ContainsKey(typeof(T)))
                _subscriptions.Add(typeof(T), handler);
        }
    }
}
