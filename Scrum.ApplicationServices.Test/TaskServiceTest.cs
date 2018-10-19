using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Scrum.Domain;
using Scrum.Domain.Entities;

namespace Scrum.ApplicationServices.Test
{
    [TestClass]
    public class TaskServiceTest
    {
        [TestMethod]
        public void GetHighPriorityTaskList_Initialized_ShoudReturnTask()
        {
            // Arrange
            var storyMock = new Mock<IStory>();
            storyMock.Setup(x => x.Tasks).Returns(() => new List<IStoryTask>() {new StoryTask(1)});

            var featureMock = new Mock<IFeature>();
            featureMock.Setup(x => x.Stories).Returns(() => new List<IStory>() {storyMock.Object});

            var epic = new Mock<IEpic>();
            epic.Setup(x => x.Features).Returns(() => new List<IFeature>() { featureMock.Object });

            var backlogMock = new Mock<IBacklog>();
            backlogMock.Setup(x => x.Epics).Returns(() => new List<IEpic>() {epic.Object});

            var sut = new TaskService(backlogMock.Object, new Mock<IEventPublisher>().Object);
            
            // Act
            var task = sut.GetHighPriorityTaskList();

            // Assert
            Assert.IsNotNull(task);
        }

        [TestMethod]
        public void GetHighPriorityTaskList_Initialized_ShoudReturnTaskLight()
        {
            // Arrange
            var mockRepository = new Mock<ITaskRepository>();
            mockRepository.Setup<IList<IStoryTask>>(x => x.GetHighPriorityTaskList()).Returns(() => new List<IStoryTask>() { new StoryTask(1) });
            var sut = new TaskService(new Mock<IEventPublisher>().Object, mockRepository.Object);

            // Act
            var task = sut.GetHighPriorityTaskListEx();

            // Assert
            Assert.IsNotNull(task);
        }
    }
}
