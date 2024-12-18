using Core.Interfaces;
using Core.Models;

namespace Services
{
    public class ExampleRepo : IExampleRepo
    {
        public Task<ExampleModel> GetExampleModel()
        {
            throw new NotImplementedException();
        }
    }
}
