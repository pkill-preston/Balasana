# Balasana

A RESTful ASP.NET Core Web API for managing employees, departments, promotions, and performance reviews within an organization.

## Features

### Employee Management

- Create employees
- Update employee information
- Delete employees
- View employee details
- Search employees

### Department Management

- Create departments
- Assign employees to departments
- List department members

### Position Management

- Create positions
- Assign positions to employees
- Track promotions

### Performance Reviews

- Create reviews
- View review history
- Calculate average ratings

### Authentication & Authorization

- JWT Authentication
- Role-based access control

Roles:

- Admin
- Manager
- Employee

### Logging

- Request logging
- Exception logging
- Authentication event logging

### Documentation

- Swagger / OpenAPI

### Testing

- Unit tests
- Mocked dependencies using Moq

---

## Tech Stack

### Backend

- ASP.NET Core 9
- Entity Framework Core
- PostgreSQL

### Testing

- xUnit
- Moq
- FluentAssertions

### Validation

- FluentValidation

### Logging

- Serilog

### Authentication

- JWT Bearer Authentication

---

## Architecture

```text
Controllers
    ↓
Services
    ↓
Repositories
    ↓
Database
```

Responsibilities:

### Controllers

Handle HTTP requests and responses.

### Services

Contain business rules and application logic.

### Repositories

Handle data access operations.

### DTOs

Transfer data between layers.

### Validators

Validate incoming requests.

---

## Project Structure

```text
CareerForge/
│
├── src/
│   └── CareerForge.Api/
│       ├── Controllers/
│       ├── Services/
│       ├── Repositories/
│       ├── Models/
│       ├── DTOs/
│       ├── Validators/
│       ├── Middleware/
│       ├── Configuration/
│       └── Program.cs
│
├── tests/
│   └── CareerForge.UnitTests/
│
├── .github/
│   └── workflows/
│
└── CareerForge.sln
```

---

## Business Rules

### Promotion Rules

- Employees under 18 cannot be promoted.
- Promotion requires an active position.
- Promotion must result in a salary increase.

### Salary Rules

- Salary cannot be negative.
- Salary increases are recorded in history.

### Department Rules

- Employee must belong to an existing department.
- Department names must be unique.

### Performance Review Rules

- Rating must be between 1 and 5.
- Reviews cannot be created for inactive employees.

---

## API Endpoints

### Authentication

| Method | Endpoint |
|----------|----------|
| POST | /api/auth/register |
| POST | /api/auth/login |

### Employees

| Method | Endpoint |
|----------|----------|
| GET | /api/employees |
| GET | /api/employees/{id} |
| POST | /api/employees |
| PUT | /api/employees/{id} |
| DELETE | /api/employees/{id} |

### Departments

| Method | Endpoint |
|----------|----------|
| GET | /api/departments |
| POST | /api/departments |

### Positions

| Method | Endpoint |
|----------|----------|
| GET | /api/positions |
| POST | /api/positions |

### Reviews

| Method | Endpoint |
|----------|----------|
| GET | /api/reviews |
| POST | /api/reviews |

---

## Getting Started

### Clone Repository

```bash
git clone git@github.com:your-user/careerforge-api.git
cd careerforge-api
```

### Restore Packages

```bash
dotnet restore
```

### Run Migrations

```bash
dotnet ef database update
```

### Start API

```bash
dotnet run --project src/CareerForge.Api
```

Swagger:

```text
https://localhost:5001/swagger
```

---

## Running Tests

```bash
dotnet test
```

---

## Commit Convention

This project follows Conventional Commits.

Examples:

```text
feat(employee): add employee creation endpoint

feat(auth): implement jwt authentication

fix(review): prevent invalid ratings

test(service): add employee service tests

docs(readme): update setup instructions

refactor(repository): simplify employee queries
```

---

## CI/CD

GitHub Actions automatically:

- Restore dependencies
- Build solution
- Run tests

on every push and pull request.

---

## Future Improvements

- Refresh Tokens
- Email Notifications
- Audit Logs
- Soft Deletes
- Docker Support
- Redis Caching
- CQRS
- MediatR
- Integration Tests
- OpenTelemetry

---

## License

MIT
