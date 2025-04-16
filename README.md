# Library Management System

## Overview
A basic Library Management System that lets you to:
- Add, view, and delete books
- Manage authors
- Search for books (fuzzy matching even though it needs improvements)

## Setup Instructions

### 1. Clone the repository
```bash
git clone https://github.com/zstoimchev/library-management-system.git LibraryManagement
cd LibraryManagement
```

### 2. Install Dependencies
1. .NET SDK (version 8.0)
2. PostgreSQL (latest version)
3. Node (latest version)

### 3. Set up the Database
#### Update the appsettings.json file with your PostgreSQL credentials:
```bash
cd LibraryManagementApi/LibraryManagementApi
nano appsettings.json
```
In appsettings.json, add your configuration string. For example:
```bash
"ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=database_name;Username=username;Password=password"
    }
```
#### Apply Migrations:
```c#
dotnet ef database update
```
This will create the following tables: **Authors** and **Books**

### 4. Start the backend (.NET 8)
```c#
dotnet restore
dotnet run
```

### 5. Start the Frontend (React)
```bash
cd ../../library-client
npm install
npm start
```
Open browser at localhost:3000

## How to Use
Open your browser and navigate to ***localhost:3000***.
1. First add authors in the add authors tab
2. After that proceed adding book, entering title, publication year and author
3. Search books using the search bar (fuzzy matching, but still needs to be improved)

## API Examples 
- GET `/books?pageNumber=1&pageSize=10` - List all books (paginated)
- POST `/books` - Add new book
- GET `/books/search?query=harry` - Search books

## Project Structure
```
/LibraryManagementApi - .NET API code
/library-client - React app
```

