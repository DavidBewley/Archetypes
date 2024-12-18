using Core.Interfaces;
using Core.Models;
using Core.Processors;
using Moq;

namespace AppSpec
{
    public class ExampleSpec
    {
        public class ExampleBaseSpec : IAsyncLifetime
        {
            protected Mock<IExampleRepo> ExampleMock;

            public async Task InitializeAsync()
            {
                ExampleMock = new Mock<IExampleRepo>();
                ExampleMock
                    .Setup(er => er.GetExampleModel())
                    .ReturnsAsync(new ExampleModel());
                var processor = new ExampleProcessor(ExampleMock.Object);

                await processor.Process();
            }

            public Task DisposeAsync()
                => Task.CompletedTask;
        }

        public class ExampleSpec_WhenProcessed : ExampleBaseSpec
        {
            [Fact]
            public void ProcessorCallsRepo() 
                => ExampleMock.Verify(er => er.GetExampleModel(), Times.Once);
        }
    }
}