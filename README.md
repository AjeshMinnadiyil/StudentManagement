# Student Management System

An ASP.NET Core MVC web application for managing student records and departments with authentication and role-based authorization.

## Overview

The Student Management System allows users to view and search student records, while administrators can create, edit, and delete student information.

The application uses ASP.NET Core Identity for authentication and authorization, Entity Framework Core for database operations, and SQL Server for data storage.

## Features

- Student CRUD operations (Create, Read, Update, Delete)
- Student and Department relationship
- Department dropdown selection
- Student search by name or email
- Pagination
- Form validation
- User registration and login
- Logout functionality
- ASP.NET Core Identity authentication
- Role-based authorization using Admin and User roles
- Admin-only Create, Edit, and Delete operations
- Automatic creation of demo roles and accounts when the application starts
- Entity Framework Core migrations

## Technologies Used

- C#
- ASP.NET Core MVC
- .NET 10
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- Razor Views
- HTML and CSS
- Git and GitHub

## Requirements

Before running the project, install:

- Visual Studio with the ASP.NET and web development workload
- .NET 10 SDK
- SQL Server or SQL Server LocalDB
- Entity Framework Core CLI tool

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/AjeshMinnadiyil/StudentManagement.git
```

Open the downloaded project folder.

### 2. Open the Project

Open `StudentManagement.csproj` in Visual Studio.

If a solution file (`.sln`) is available, you can open that instead.

### 3. Configure the Database

Open `appsettings.json` and update the `DefaultConnection` connection string to match your SQL Server instance.

Example using SQL Server LocalDB:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=StudentManagementDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

Keep any existing logging and other configuration sections in the file.

If you use SQL Server Express, update the server name to match your installed SQL Server instance.

### 4. Restore Dependencies

Open a terminal in the folder containing `StudentManagement.csproj` and run:

```bash
dotnet restore
```

### 5. Install Entity Framework Core CLI

If the `dotnet-ef` tool is not installed, run:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, you can skip this step.

### 6. Create or Update the Database

Run the existing Entity Framework Core migrations:

```bash
dotnet ef database update
```

This creates or updates the database schema, including the student, department, and Identity tables defined by the project's migrations.

### 7. Run the Application

Run the following command:

```bash
dotnet run
```

Open the local URL displayed in the terminal.

Alternatively, start the application from Visual Studio.

## Demo Login Credentials

The application is configured to create the `Admin` and `User` roles and their demo accounts when it starts, provided the database is available and the accounts do not already exist.

### Admin Account

- **Email:** `admin@example.com`
- **Password:** `Admin@12345`
- **Role:** Admin

### User Account

- **Email:** `user@example.com`
- **Password:** `User@12345`
- **Role:** User

These credentials are for local development and demonstration purposes only.

**Security warning:** Do not use these demo credentials in production. Anyone who can access a public repository can see them. Replace the demo account setup with secure configuration before deploying a real application.

## User Roles and Permissions

| Feature | Admin | User |
|---|---|---|
| View student list | Yes | Yes |
| Search students | Yes | Yes |
| Pagination | Yes | Yes |
| Create student | Yes | No |
| Edit student | Yes | No |
| Delete student | Yes | No |

Authorization is enforced on the server through role-based authorization attributes. Hiding buttons in the user interface alone is not sufficient for security.

## How Demo Accounts Are Created

On application startup:

1. The application checks whether the `Admin` and `User` roles exist.
2. Missing roles are created.
3. The application checks whether the demo accounts exist.
4. Missing accounts are created using ASP.NET Core Identity.
5. The appropriate role is assigned to each account.

Existing accounts are not recreated, and their passwords are not automatically reset.

A working SQL Server connection and an updated database are required for this process to succeed.

## Project Structure

```text
StudentManagement/
├── Areas/
│   └── Identity/
├── Controllers/
├── Data/
├── Migrations/
├── Models/
├── Views/
├── wwwroot/
├── appsettings.json
├── Program.cs
└── StudentManagement.csproj
```

The exact folder structure may vary slightly depending on the project version.

## Database Notes

- SQL Server is used for data storage.
- Entity Framework Core manages database access.
- Migrations are used to create and update the database schema.
- Existing student records and registered users are not included in migration files.
- If you need to transfer existing data between systems, use a database backup/restore or an appropriate data migration process.

## Troubleshooting

### Database Connection Error

- Verify that SQL Server or LocalDB is installed and running.
- Check the `DefaultConnection` connection string.
- Ensure the configured SQL Server instance exists.

### Demo Login Does Not Work

- Make sure database migrations have been applied.
- Confirm that the demo account exists in the `AspNetUsers` table.
- Confirm that the account has the expected role in `AspNetUserRoles`.
- If an account already existed, its password may differ from the demo password listed above.

### Entity Framework Command Not Found

Install the EF Core CLI tool:

```bash
dotnet tool install --global dotnet-ef
```

Ensure the tool version is compatible with the project's Entity Framework Core version.

## Security Notes

- Do not publish real passwords, API keys, or production secrets.
- Review connection strings before publishing.
- Use secure configuration for production deployments.
- Replace public demo credentials before deploying a production application.
- Never assign the Admin role automatically to every newly registered user.

## Future Improvements

- Department CRUD operations
- Dashboard and reporting
- Unit and integration tests
- Improved error handling and logging
- Deployment to a hosting provider

## Author

**Ajesh Minnadiyil**

GitHub: [AjeshMinnadiyil](https://github.com/AjeshMinnadiyil)

## License

No license has been specified yet.
