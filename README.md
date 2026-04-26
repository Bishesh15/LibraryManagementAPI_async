# Library Management System API

ASP.NET Core 8 Web API for managing library operations including books, authors, students, and book issues.

## Technology Stack

| Layer | Technology |
|---|---|
| Backend | ASP.NET Core 8 |
| Database | SQL Server |
| ORM | Entity Framework Core 8 |
| Documentation | Swagger / OpenAPI |
| Logging | Custom Utility Service |
| Architecture | Repository + Service Pattern |

## Project Structure

```
LibraryManagementAPI
 ┣ Controllers
 ┃ ┣ AuthorController.cs
 ┃ ┣ BookController.cs
 ┃ ┣ StudentController.cs
 ┃ ┣ UserController.cs
 ┃ ┗ BookIssueController.cs
 ┣ Models
 ┃ ┣ Author.cs
 ┃ ┣ Book.cs
 ┃ ┣ Student.cs
 ┃ ┣ User.cs
 ┃ ┗ BookIssue.cs
 ┣ Data
 ┃ ┗ LibraryDbContext.cs
 ┣ Repositories
 ┃ ┣ IAuthorRepository.cs
 ┃ ┣ AuthorRepository.cs
 ┃ ┣ IBookRepository.cs
 ┃ ┣ BookRepository.cs
 ┃ ┣ IStudentRepository.cs
 ┃ ┣ StudentRepository.cs
 ┃ ┣ IUserRepository.cs
 ┃ ┣ UserRepository.cs
 ┃ ┣ IBookIssueRepository.cs
 ┃ ┗ BookIssueRepository.cs
 ┣ Services
 ┃ ┣ IAuthorService.cs
 ┃ ┣ AuthorService.cs
 ┃ ┣ IBookService.cs
 ┃ ┣ BookService.cs
 ┃ ┣ IStudentService.cs
 ┃ ┣ StudentService.cs
 ┃ ┣ IUserService.cs
 ┃ ┣ UserService.cs
 ┃ ┣ IBookIssueService.cs
 ┃ ┗ BookIssueService.cs
 ┣ Utilities
 ┃ ┣ ILogService.cs
 ┃ ┗ LogService.cs
 ┣ appsettings.json
 ┗ Program.cs
```

## Prerequisites

- Visual Studio 2022
- .NET 8 SDK
- SQL Server
- SQL Server Management Studio (SSMS)
- Postman (for API testing)

## Getting Started

### 1. Clone the Repository
git clone https://github.com/yourusername/LibraryManagementAPI.git
cd LibraryManagementAPI

### 2. Configure Database
Open `appsettings.json` and update the connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Replace `YOUR_SERVER_NAME` with your SQL Server instance name (e.g. `localhost`, `.\SQLEXPRESS`)

### 3. Install Packages
Run in Package Manager Console:
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.0
dotnet add package Swashbuckle.AspNetCore

### 4. Run Database Migration
Run in Package Manager Console:
Add-Migration InitialCreate
Update-Database

### 5. Run the Project
Press `F5` in Visual Studio or run:
dotnet run

Swagger UI will be available at:
http://localhost:{port}/swagger

## API Endpoints

### User
| Method | Endpoint | Description |
|---|---|---|
| POST | /api/user/register | Register new user |
| POST | /api/user/login | Login user |

### Author
| Method | Endpoint | Description |
|---|---|---|
| GET | /api/author | Get all authors |
| GET | /api/author/{id} | Get author by ID |
| POST | /api/author | Add new author |
| PUT | /api/author | Update author |
| DELETE | /api/author/{id} | Delete author |

### Book
| Method | Endpoint | Description |
|---|---|---|
| GET | /api/book | Get all books |
| GET | /api/book/{id} | Get book by ID |
| POST | /api/book | Add new book |
| PUT | /api/book | Update book |
| DELETE | /api/book/{id} | Delete book |

### Student
| Method | Endpoint | Description |
|---|---|---|
| GET | /api/student | Get all students |
| GET | /api/student/{id} | Get student by ID |
| POST | /api/student | Add new student |
| PUT | /api/student | Update student |

### Book Issue
| Method | Endpoint | Description |
|---|---|---|
| GET | /api/bookissue | Get all issued books |
| POST | /api/bookissue | Issue a book |
| PUT | /api/bookissue/return/{issueId} | Return a book |

## Sample Postman Requests

### Register User
```json
POST /api/user/register
{
  "fullName": "Admin User",
  "email": "admin@gmail.com",
  "passwordHash": "admin123"
}
```

### Add Author
```json
POST /api/author
{
  "authorName": "John Doe",
  "bio": "Famous author"
}
```

### Add Book
```json
POST /api/book
{
  "title": "C# Programming",
  "isbn": "978-3-16-148410-0",
  "authorId": 1,
  "quantity": 10
}
```

### Add Student
```json
POST /api/student
{
  "fullName": "Ram Sharma",
  "email": "ram@gmail.com",
  "phone": "9800000000"
}
```

### Issue Book
```json
POST /api/bookissue
{
  "bookId": 1,
  "studentId": 1,
  "issueDate": "2026-04-21T00:00:00",
  "returnDate": null,
  "status": true
}
```

### Return Book
PUT /api/bookissue/return/1

## Database Tables

| Table | Description |
|---|---|
| Users | Stores user login credentials |
| Authors | Stores author information |
| Books | Stores book details with author reference |
| Students | Stores student information |
| BookIssues | Stores book issue and return records |

## Architecture
Controller (async)
↓
Service (async + logging)
↓
Repository (async)
↓
Entity Framework Core
↓
SQL Server

## Error Handling

All errors are caught in the Service layer and logged using the custom `LogService`:
```csharp
catch (Exception ex)
{
    _logService.SaveLog("Error message: " + ex.Message);
    throw;
}
```

Logs are visible in the Visual Studio Output window during development.

## Recommended Testing Order

1. Register User
2. Login User
3. Add Author
4. Add Book (requires AuthorId)
5. Add Student
6. Issue Book (requires BookId and StudentId)
7. Return Book (requires IssueId)
