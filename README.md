# Library Management System

## Overview
A basic Library Management System that lets you:
- Add, view, and delete books
- Manage authors
- Search for books (fuzzy matching even though it needs improvements)

## Setup

### Backend (.NET 8)
1. Install .NET 8 SDK
2. Navigate into the backend folder
3. Run these commands:
```bash
dotnet restore
dotnet run
```

### Frontend (React)
1. Install Node.js
2. Navigate into the frontend folder
3. Run these commands:
```bash
npm install
npm start
```

### Database
1. Install PostgreSQL
2. Schema used:
    ```sql
        -- Authors table
        CREATE TABLE Authors (
            Id SERIAL PRIMARY KEY,
            Name VARCHAR(255) NOT NULL,
            DateOfBirth TIMESTAMP
        );

        -- Books table
        CREATE TABLE Books (
            Id SERIAL PRIMARY KEY,
            Title VARCHAR(255) NOT NULL,
            PublicationYear INTEGER NOT NULL,
            AuthorId INTEGER REFERENCES Authors(Id) ON DELETE CASCADE
        );

        -- Index for better performance on foreign key
        CREATE INDEX idx_books_authorid ON Books(AuthorId);
    ```

## How to Use
1. Add authors first
2. Then add books and assign authors
3. Use the search bar to find books (works even if you make small typos)

## API Examples
- GET `/books` - List all books
- POST `/books` - Add new book
- GET `/books/search?query=harry` - Search books

## Project Structure
```
/LibraryManagementApi - .NET API code
/library-client - React app
```

