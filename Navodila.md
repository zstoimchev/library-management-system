# Library Management System

## Objective  
Build a simple Library Management System that allows users to manage books and authors.

---

## Requirements

### 1. **Backend (.NET 8)**:
- Build an API using **.NET 8** that includes the following endpoints:
  1. `GET /books`: Fetch a paginated list of books.
  2. `POST /books`: Add a new book.
  3. `PUT /books/{id}`: Update an existing book's details.
  4. `DELETE /books/{id}`: Delete a book by its ID.
  5. `GET /authors`: Fetch a list of all authors.
  6. `POST /authors`: Add a new author.
  7. **`GET /books/search?query=<query>`**: Search for books by title using a **similarity search** (e.g., fuzzy matching).
     - Example: Searching for "Harry Poter" should return results for "Harry Potter".

- Implement **data validation** for input fields (e.g., non-empty title, valid publication year).

---

### 2. **Frontend (React or Angular)**:
- Create a simple UI that interacts with the backend:
  1. A page to list all books with their authors (use pagination).
  2. A form to add or update a book (fields: title, publication year, author selection).
  3. A form to add a new author (fields: name, date of birth).
  4. A delete button for each book.
  5. A search bar to search for books by title (using the `/books/search` endpoint).
  
- Display meaningful error messages for validation errors (e.g., invalid data).

---

### 3. **Database**:
- Use either **PostgreSQL** or **SQLite** for storing data. The schema should have two tables:
  - `Books`:
    - `Id` (int, primary key)
    - `Title` (string, max 255)
    - `PublicationYear` (int)
    - `AuthorId` (foreign key)
  - `Authors`:
    - `Id` (int, primary key)
    - `Name` (string, max 255)
    - `DateOfBirth` (datetime)

---

### 4. **Performance Task**:
- Optimize the `GET /books` endpoint to handle a large dataset (e.g., 100,000 books) efficiently:
  - Implement **pagination** and test performance for different page sizes.
- Bonus: try to do similarity search in memory.
- Bonus: Cache the results of the `GET /authors` endpoint for improved performance.

---

### 5. **Optional Enhancements**:
- Add **unit tests** for critical parts of the backend logic (e.g., adding a book or author).
- Use React/Angular **state management** (e.g., Redux or RxJS) to manage frontend state.

---

## References for Getting Started

### 1. Installing .NET 8
- Official .NET 8 Download: [https://dotnet.microsoft.com/en-us/download/dotnet/8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

---

### 2. Setting up the first .NET 8 API Project
- Step-by-step guide for creating a new API project:  
  [https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)

---

### 3. Setting up PostgreSQL
- PostgreSQL Official Installer: [https://www.postgresql.org/download/](https://www.postgresql.org/download/)
- PostgreSQL Installation Guide:  
  [https://www.postgresqltutorial.com/postgresql-getting-started/install-postgresql/](https://www.postgresqltutorial.com/postgresql-getting-started/install-postgresql/)

---

### 4. Configuring PostgreSQL Connection String in .NET 8
- Connection string example:
  ```json
  "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Port=5432;Database=LibraryDB;Username=your_username;Password=your_password"
  }
  ```
---

### 5. Using SQLite (Optional Database)
- SQLite Official Download: [https://www.sqlite.org/download.html](https://www.sqlite.org/download.html)
- Configuring EF Core for SQLite:  
  [https://learn.microsoft.com/en-us/ef/core/providers/sqlite/](https://learn.microsoft.com/en-us/ef/core/providers/sqlite/)

---

### 6. Project Structure in .NET 8
- A typical **clean architecture project structure** for .NET applications:
  ```
  ├── Controllers/
  │   └── BooksController.cs
  │   └── AuthorsController.cs
  ├── Models/
  │   └── Book.cs
  │   └── Author.cs
  ├── Services/
  │   └── BookService.cs
  │   └── AuthorService.cs
  ├── Repositories/
  │   └── IBookRepository.cs
  │   └── BookRepository.cs
  │   └── IAuthorRepository.cs
  │   └── AuthorRepository.cs
  ├── Data/
  │   └── ApplicationDbContext.cs
  ├── Program.cs
  └── appsettings.json
  ```

- Reference for .NET Project Structure:  
  [https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)

---

### 7. Using Dependency Injection in .NET 8
- Add services to the DI container in `Program.cs`:
  ```csharp
  var builder = WebApplication.CreateBuilder(args);

  // Add services to the container
  builder.Services.AddDbContext<ApplicationDbContext>(options =>
      options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

  builder.Services.AddScoped<IBookRepository, BookRepository>();
  builder.Services.AddScoped<IBookService, BookService>();

  var app = builder.Build();

  // Configure the HTTP request pipeline
  app.UseHttpsRedirection();
  app.UseAuthorization();
  app.MapControllers();
  app.Run();
  ```
- Official Guide for Dependency Injection:  
  [https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0)

---

## Deliverables

1. A **GitHub repository** with the complete source code for the application.
2. A `README.md` file with:
   - Instructions for setting up the backend, frontend, and database.
   - Sample database schema or migration commands.
   - Example API requests for testing.
3. A brief explanation of how the **similarity search** and **performance optimization** were implemented.