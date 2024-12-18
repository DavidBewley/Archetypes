using Core.Interfaces;

namespace Core.Processors
{
    public class ExampleProcessor(IExampleRepo exampleRepo)
    {
        private readonly IExampleRepo _exampleRepo = exampleRepo;

        public async Task Process()
        {
            var data = await _exampleRepo.GetExampleModel();

            //Do something here
        }
    }
}
