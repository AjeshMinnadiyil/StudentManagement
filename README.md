# Student Management System

An ASP.NET Core MVC web application for managing student records and departments with authentication and role-based authorization.

## Features

- Student CRUD operations
- Student and Department relationship
- Search students by name or email
- Department dropdown selection
- Pagination and form validation
- User registration, login, and logout
- Role-based authorization (Admin and User)
- Admin-only Create, Edit, and Delete operations
- Automatic demo account creation
- Entity Framework Core migrations

## Technologies Used

- C#
- ASP.NET Core MVC
- .NET 10
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- Razor Views, HTML, CSS, and Bootstrap

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/AjeshMinnadiyil/StudentManagement.git
```

### 2. Configure the Database

Update the `DefaultConnection` connection string in `appsettings.json` to match your SQL Server instance.

### 3. Apply Database Migrations

Run this command in the Package Manager Console:

```powershell
Update-Database
```

### 4. Run the Application

Open the project in Visual Studio and run it, or use:

```bash
dotnet run
```

## Demo Accounts

| Role | Email | Password |
|---|---|---|
| Admin | `admin@example.com` | `Admin@12345` |
| User | `user@example.com` | `User@12345` |

*Demo accounts work only if the account-seeding code is enabled and runs successfully.*

## Author

**Ajesh Minnadiyil**

GitHub: [AjeshMinnadiyil](https://github.com/AjeshMinnadiyil)
