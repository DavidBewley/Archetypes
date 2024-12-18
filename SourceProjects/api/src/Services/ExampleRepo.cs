using Core.Interfaces;
using Core.Models;

namespace Services
{
    public class ExampleRepo : IExampleRepo
    {
        public Task<ExampleModel?> GetExampleModel(string forename, string surname)
        {
            throw new NotImplementedException();
        }
    }
}
