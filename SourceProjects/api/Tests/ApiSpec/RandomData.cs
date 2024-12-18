using Bogus;
using Core.Models;

namespace ApiSpec
{
    public static class RandomData
    {
        public static string Name()
            => new Faker().Name.FirstName();

        public static ExampleModel ExampleModel(Guid? id = null, string? forename = null, string? surname = null) => new Faker<ExampleModel>()
                .RuleFor(em => em.Id, id ?? Guid.NewGuid())
                .RuleFor(em => em.Forename, f => forename ?? f.Name.FirstName())
                .RuleFor(em => em.Surname, f => surname ?? f.Name.LastName());
    }
}
