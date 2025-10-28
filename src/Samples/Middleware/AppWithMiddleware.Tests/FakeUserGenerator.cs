using Bogus;
using Bogus.DataSets;

namespace AppWithMiddleware.Tests;

public static class FakeUserGenerator
{
    /// <summary>
    /// Generates a single fake User object with populated data.
    /// </summary>
    /// <returns>A fully populated User object.</returns>
    public static User GenerateFakeUser()
    {
        // 1. Faker for the nested Order object
        var orderFaker = new Faker<Order>()
            .RuleFor(o => o.OrderId, f => f.IndexFaker + 100)
            .RuleFor(o => o.Quantity, f => f.Random.Number(1, 10))
            // Nullable type handled by using a probability (50% chance of being null)
            .RuleFor(o => o.LotNumber, f => f.Random.Int(1000, 9999).OrNull(f, 0.5f));

        // 2. Main Faker for the User object
        var userFaker = new Faker<User>()
            // Ensure ID is unique across generations if called multiple times, 
            // otherwise, IndexFaker is fine for a single batch
            .RuleFor(u => u.Id, f => Guid.NewGuid()) 
            
            // Define Gender first
            .RuleFor(u => u.Gender, f => f.PickRandom<Name.Gender>())

            // Use the generated Gender for consistent name fields (using the instance 'u')
            .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(u.Gender))
            .RuleFor(u => u.LastName, (f, u) => f.Name.LastName(u.Gender))
            .RuleFor(u => u.FullName, (f, u) => f.Name.FullName(u.Gender))

            // Use context to generate a natural email/username
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
            
            // Other data
            .RuleFor(u => u.SomethingUnique, f => f.Random.Replace("###-##-####")) // Example of using Replace
            .RuleFor(u => u.CartId, f => Guid.NewGuid())

            // Generate between 1 and 4 orders for this user
            .RuleFor(u => u.Orders, f => orderFaker.Generate(f.Random.Number(1, 4)));

        return userFaker.Generate();
    }
}

public class User
{
    public Guid Id { get; set; }
    public Name.Gender Gender { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string SomethingUnique { get; set; }
    public string Avatar { get; set; }
    public string UserName { get; set; }
    public Guid CartId { get; set; }
    public List<Order> Orders { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public int Quantity { get; set; }
    public int? LotNumber { get; set; }
}