using Core.Interfaces;
using Core.Models;
using Core.Processors;
using Moq;

namespace ApiSpec
{
    public class ExampleSpec
    {
        public class ExampleBaseSpec : IAsyncLifetime
        {
            protected Mock<IExampleRepo> ExampleMock;
            protected ExampleModel ModelResult;
            protected string? NotFoundMessage;

            protected string InputForename;
            protected string InputSurname;

            public async Task InitializeAsync()
            {
                ExampleMock = new Mock<IExampleRepo>();
                ExampleMock
                    .Setup(er => er.GetExampleModel(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(new ExampleModel());
                var processor = new ExampleProcessor(ExampleMock.Object);

                InputForename = RandomData.Name();
                InputSurname = RandomData.Name();

                await processor.FindExampleModel(
                    InputForename,
                    InputSurname,
                    onFound: exampleModel => ModelResult = exampleModel,
                    onNotFound: message => NotFoundMessage = message);
            }

            public Task DisposeAsync()
                => Task.CompletedTask;
        }

        public class ExampleSpec_WhenProcessed : ExampleBaseSpec
        {
            [Fact]
            public void ProcessorCallsRepo()
                => ExampleMock.Verify(er => er.GetExampleModel(InputForename, InputSurname), Times.Once);
        }
    }
}