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
```json
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=database_name;Username=username;Password=password"
}
```
Apply database migrations to create the **Authors** and **Books** tables:
```bash
cd LibraryManagementApi/LibraryManagementApi
dotnet ef database update
```

### 3. Start the backend (.NET 8)
```bash
dotnet restore
dotnet run
```
The API will run at http://localhost:5144

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
   - Click "Submit" to save the author.

2. **Add Books**:
   - Navigate to the "Add Book" tab.
   - Enter the book’s title, publication year, and select an author from the dropdown.
   - Click "Submit" to add the book.

3. **Search Books**:
   - Use the search bar to find books by title.
   - **Note**: Fuzzy matching is still being improved and may not handle all edge cases.


## API Examples
The backend API is accessible at `http://localhost:5144`. Below are example endpoints:

- **GET `/books?pageNumber=1&pageSize=10`**  
  Retrieves a paginated list of books.  
  **Response** (200 OK):
  ```json
  {
    "total": 25,
    "books": [
      { "id": 1, "title": "Harry Potter", "year": 1997, "author": "J.K. Rowling" },
      ...
    ]
  }
    ```

- **POST `/books`**  
  Adds a new book.  
  **Request**:  
  ```json
  {
    "title": "The Hobbit",
    "publicationYear": 1937,
    "authorId": 4
  }
  ```  
  **Response** (201 Created):  
  ```json
  {
    "id": 2,
    "title": "The Hobbit",
    "year": 1937,
    "authorId": 4
  }
  ```  
**Note**: Full API documentation is available at http://localhost:5144/swagger when the backend is running.


## Project Structure
```
/LibraryManagement
├── /LibraryManagementApi  # .NET API code
├── /library-client        # React app
├── /Readme.md             # Project overview and setup instructions
├──/Navodila.md            # Instructions for development
```

