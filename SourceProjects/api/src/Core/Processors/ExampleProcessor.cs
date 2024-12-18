using Core.Interfaces;
using Core.Models;

namespace Core.Processors
{
    public class ExampleProcessor(IExampleRepo exampleRepo)
    {
        public async Task FindExampleModel(string forename, string surname, Action<ExampleModel> onFound, Action<string> onNotFound)
        {
            var data = await exampleRepo.GetExampleModel(forename,surname);

            if (data != null)
            {
                onFound(data);
                return;
            }
            onNotFound("Unable to find an example model with those names");
        }
    }
}
