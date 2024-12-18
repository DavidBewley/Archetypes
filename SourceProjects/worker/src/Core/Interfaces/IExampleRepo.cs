using Core.Models;

namespace Core.Interfaces
{
    public interface IExampleRepo
    {
        public Task<ExampleModel> GetExampleModel();
    }
}
