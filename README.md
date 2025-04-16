# Library Management System

The **Library Management System** is a web application designed to manage books and authors efficiently. Built with **.NET 8**, **React**, and **PostgreSQL**, it provides a simple interface for:
- Adding, viewing, and deleting books
- Managing author information
- Searching books with fuzzy matching

## Setup Instructions

### 1. Clone the repository
```bash
git clone https://github.com/zstoimchev/library-management-system.git LibraryManagement
cd LibraryManagement
```

### Install Dependencies

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL 15+](https://www.postgresql.org/download/)
- [Node.js 18+](https://nodejs.org/)

### 2. Set up the Database

Update the database connection string in LibraryManagementApi/LibraryManagementApi/appsettings.json
```bash
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=database_name;Username=username;Password=password"
}
```
Apply database migrations to create the **Authors** and **Books** tables:
```c#
cd LibraryManagementApi/LibraryManagementApi
dotnet ef database update
```

### 3. Start the backend (.NET 8)
```c#
dotnet restore
dotnet run
```
The API will run at http://localhost:5000

### 4. Start the Frontend (React)

```bash
cd ../../library-client
npm install
npm start
```
The frontend will open at http://localhost:3000

## How to Use

Navigate to `http://localhost:3000` in your browser to access the application.
1. **Add Authors**:
   - Go to the "Add Authors" tab.
   - Enter the author's name and date of birth.
   - Click "Save" to add the author.

2. **Add Books**:
   - Navigate to the "Add Book" tab.
   - Enter the book’s title, publication year, and select an author from the dropdown.
   - Click "Save" to add the book.

3. **Search Books**:
   - Use the search bar to find books by title.
   - **Note**: Fuzzy matching is still being improved and may not handle all edge cases.

## API Examples 
- GET `/books?pageNumber=1&pageSize=10` - List all books (paginated)
- POST `/books` - Add new book
- GET `/books/search?query=harry` - Search books


## Project Structure
```
/LibraryManagementApi - .NET API code
/library-client - React app
```

