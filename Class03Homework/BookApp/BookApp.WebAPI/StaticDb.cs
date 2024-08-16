using BookApp.WebAPI.Model;

namespace BookApp.WebAPI
{

    public static class StaticDb
    {
        public static List<Book> Books { get; } = new List<Book>
        {
            new Book { Id = 1, Author = "George Orwell", Title = "1984" },
            new Book { Id = 2, Author = "Harper Lee", Title = "To Kill a Mockingbird" },
            new Book { Id = 3, Author = "F. Scott Fitzgerald", Title = "The Great Gatsby" },
            new Book { Id = 4, Author = "J.R.R. Tolkien", Title = "The Lord of the Rings" },
            new Book { Id = 5, Author = "Jane Austen", Title = "Pride and Prejudice" },
            new Book { Id = 6, Author = "Mark Twain", Title = "The Adventures of Huckleberry Finn" },
            new Book { Id = 7, Author = "Herman Melville", Title = "Moby Dick" },
            new Book { Id = 8, Author = "Leo Tolstoy", Title = "War and Peace" },
            new Book { Id = 9, Author = "Charles Dickens", Title = "A Tale of Two Cities" },
            new Book { Id = 10, Author = "Emily Brontë", Title = "Wuthering Heights" },
            new Book { Id = 11, Author = "Gabriel García Márquez", Title = "One Hundred Years of Solitude" },
            new Book { Id = 12, Author = "Aldous Huxley", Title = "Brave New World" },
            new Book { Id = 13, Author = "Fyodor Dostoevsky", Title = "Crime and Punishment" },
            new Book { Id = 14, Author = "Ernest Hemingway", Title = "The Old Man and the Sea" }
        };
    }
}
