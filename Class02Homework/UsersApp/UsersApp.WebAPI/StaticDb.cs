namespace UsersApp.WebAPI
{
    public static class StaticDb
    {
        public static List<User> Users { get; set; } = new List<User>()
        {
            new User { Id = 1, FirstName = "Alice", LastName = "Johnson", Address = "123 Maple Street" },
        new User { Id = 2, FirstName = "Bob", LastName = "Smith", Address = "456 Oak Avenue" },
        new User { Id = 3, FirstName = "Charlie", LastName = "Brown", Address = "789 Pine Road" },
        new User { Id = 4, FirstName = "David", LastName = "Jones", Address = "321 Birch Boulevard" },
        new User { Id = 5, FirstName = "Emma", LastName = "Davis", Address = "654 Cedar Lane" },
        new User { Id = 6, FirstName = "Fiona", LastName = "Clark", Address = "987 Elm Street" },
        new User { Id = 7, FirstName = "George", LastName = "White", Address = "147 Spruce Circle" },
        new User { Id = 8, FirstName = "Hannah", LastName = "Martin", Address = "258 Walnut Drive" },
        new User { Id = 9, FirstName = "Ian", LastName = "Lee", Address = "369 Chestnut Way" },
        new User { Id = 10, FirstName = "Jack", LastName = "King", Address = "741 Redwood Court" },
        new User { Id = 11, FirstName = "Karen", LastName = "Lopez", Address = "852 Willow Avenue" },
        new User { Id = 12, FirstName = "Liam", LastName = "Morris", Address = "963 Palm Street" },
        new User { Id = 13, FirstName = "Mia", LastName = "Wilson", Address = "159 Maple Grove" },
        new User { Id = 14, FirstName = "Nathan", LastName = "Taylor", Address = "753 Oak Hollow" },
        new User { Id = 15, FirstName = "Olivia", LastName = "Anderson", Address = "456 Pine Meadow" },
        new User { Id = 16, FirstName = "Peter", LastName = "Thomas", Address = "678 Birch Path" },
        new User { Id = 17, FirstName = "Quinn", LastName = "Harris", Address = "890 Cedar Point" },
        new User { Id = 18, FirstName = "Rachel", LastName = "Young", Address = "112 Elm Bend" },
        new User { Id = 19, FirstName = "Samuel", LastName = "Wright", Address = "334 Spruce Ridge" },
        new User { Id = 20, FirstName = "Tina", LastName = "Hall", Address = "556 Walnut Lane" }
        };
    }
}
