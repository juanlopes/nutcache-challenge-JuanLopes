using NutcacheTest.Entities.Entity;

namespace NutcacheTest.UnitTests.Fixtures;

public static class UsersFixtures {
    public static List<User> GetTestUsers() => 
        new() {
            new() {
                Id = 1,
                Name = "Juan",
                BirthDate = DateOnly.Parse("April 04, 2000"),
                Gender = 'M',
                Email = "juanmatheuslopes@hotmail.com",
                CPF ="110.923.639-5",
                StartDate = DateOnly.Parse("October 27, 2022"),
                Team = 2
            }
        };

    public static List<User> GetEmptyTestUsers() => 
        new() {
        };
}