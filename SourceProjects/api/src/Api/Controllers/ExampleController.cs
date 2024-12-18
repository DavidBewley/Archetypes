using Core.Processors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    //Example controller with a listener pattern
    //Processor is DI and the repo is DI in that processor

    public class ExampleController(ExampleProcessor exampleProcessor) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ActionResult response = NotFound();

            await exampleProcessor.FindExampleModel(
                "John",
                "Smith",
                onFound: exampleModel => Ok(exampleModel),
                onNotFound: message => NotFound(message)
            );

            return response;
        }
    }
}
