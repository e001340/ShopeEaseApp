---

# 📦 Project Reflection & Q&A

## Project Title

**ShopEase E-Commerce Web Application**

## Describe your e-commerce app and its functionalities

ShopEase is a modern, full-stack e-commerce web application that allows users to browse products, add them to a shopping cart, and securely complete transactions. The app features a Blazor WebAssembly frontend for a responsive, interactive user experience and a .NET 8 Web API backend for robust business logic and data management. Key functionalities include product listing, cart management, user authentication with JWT, and persistent state across sessions. The solution is designed with Clean Architecture, ensuring modularity, testability, and scalability.

## What were the major challenges you faced, and how did you overcome them?

One major challenge was designing a clean, maintainable architecture that separates concerns across domain, application, infrastructure, and presentation layers. Integrating authentication and secure state management in a Blazor WebAssembly environment also required careful handling of JWT tokens and localStorage. Mapping between domain models and DTOs, and ensuring seamless communication between frontend and backend, was addressed using AutoMapper and MediatR. Database schema changes and migrations were managed with EF Core, and issues were resolved by adding design-time factories and updating migration strategies. Thorough unit testing and iterative debugging helped ensure reliability.

## How did you implement key components like business logic, UI/UX, and security?

Business logic was implemented in the Application layer using services, repositories, and CQRS handlers, with validation via FluentValidation. The UI/UX was built with Blazor components, styled for responsiveness and accessibility, and enhanced with ARIA attributes and semantic HTML. Security was enforced through ASP.NET Identity, JWT authentication, and [Authorize] attributes on protected API endpoints. Input validation and sanitization were applied throughout to prevent common vulnerabilities.

## What security measures did you implement?

Security measures include JWT-based authentication, role-based authorization, and secure password storage via ASP.NET Identity. All API endpoints that modify user or cart data are protected with [Authorize]. Input validation is enforced with FluentValidation, and sensitive data is never exposed to the client. The frontend stores tokens securely in localStorage and transmits them only over HTTPS. The app also uses parameterized queries and ORM best practices to prevent SQL injection.

## How did you manage state and optimize performance?

State management is handled using localStorage in the Blazor frontend to persist cart data and authentication tokens across sessions. The application uses efficient data binding and event callbacks for real-time UI updates. Backend performance is optimized by leveraging EF Core for data access, using asynchronous programming throughout, and minimizing API payloads with DTOs. The UI is responsive and lightweight, with CSS media queries and minimal JavaScript for fast load times. End-to-end testing and profiling were used to identify and resolve bottlenecks.
# ShopEase E-Commerce Web Application

## Project Overview

ShopEase is a full-stack e-commerce solution built with a Blazor WebAssembly front-end and a .NET 8 Web API back-end, following Clean Architecture principles. The project is structured with top-level `src` and `tests` folders to maintain separation of concerns, ensure maintainability, and support scalable, testable development.

Key backend technologies include Entity Framework with SQLite for data persistence and ASP.NET Identity with JWT token-based authentication for secure access control. The Web API will expose endpoints documented through OpenAPI (Swagger) for ease of integration and testing.

---
# 📁 Folder Structure

The project is organized for clarity, modularity, and scalability:

```
ShopEase/
├── src/
│   ├── ShopEase.Api/           # ASP.NET Core Web API (backend)
│   ├── ShopEase.Blazor/        # Blazor WebAssembly frontend
│   ├── ShopEase.Domain/        # Domain models and interfaces
│   ├── ShopEase.Application/   # Application logic, DTOs, services, validators
│   └── ShopEase.Infrastructure/# Data access, EF Core, repositories
├── tests/
│   └── ShopEase.Tests/         # xUnit test project
├── ShopEase.sln                # Solution file
└── README.md                   # Project documentation
```

Each layer is separated for maintainability and testability. See the step-by-step guide below for details on each folder's purpose.
---
## 🔧 Architecture & Design Patterns

- **CQRS Pattern via MediatR** to separate command and query responsibilities
- **AutoMapper** for seamless object-to-object mapping
- **FluentValidation** for enforcing input validation rules
- **Generic repositories and services** (`IRepository<T>`, `IService<T>`) alongside concrete implementations per domain entity
- **Clean layering** across domain, application, infrastructure, and presentation for modularity and testing

---

## 📘 Project Activities and Milestones

### 🔹 Activity 1: Business Logic & Domain Modeling

- Define domain models:
  - **Product:** includes ProductID, Name, Price, and Category
  - **Cart:** manages a list of Product items with methods like AddProduct, RemoveProduct, DisplayCartItems, and CalculateTotal
- Implement CRUD operations for Product and Cart through the API
- Integrate SQLite as the relational database backend
- Write unit tests for core business logic and repository behavior
- Use GitHub Copilot to support debugging and code improvements

### 🔹 Activity 2: Blazor Components for Product Listings

- Build a reusable component: `ProductCard.razor`
- Display dynamic product information
- Include an "Add to Cart" button with event-based data communication
- Use data binding and event callbacks to pass selected products to the cart
- Ensure proper component interaction and test with multiple products
- Use Copilot to refine component logic and performance

### 🔹 Activity 3: UI/UX and Responsive Design

- Style components using `site.css` for improved readability and layout consistency
- Implement responsive design with CSS media queries to support various screen sizes
- Enhance accessibility: high contrast, keyboard navigation, and semantic HTML
- Use Copilot to review and enhance UI/UX design and accessibility

### 🔹 Activity 4: Security and Authentication

- Implement ASP.NET Identity with JWT-based authentication
- Protect API endpoints so only authenticated users can perform cart operations
- Sanitize inputs and apply FluentValidation to prevent common attacks (e.g., SQL injection, XSS)
- Utilize Copilot to review for security flaws and suggest best practices
- Secure frontend API calls by passing and validating JWT tokens

### 🔹 Activity 5: State Management and Finalization

- Implement state persistence using localStorage or sessionStorage to retain cart data across sessions
- Validate the complete user journey: login, product listing, add/remove cart items, and session continuity
- Conduct end-to-end testing across all application layers
- Optimize for performance and finalize for peer review and portfolio presentation

---

## ✅ Conclusion

The ShopEase application is designed as a modern, secure, and maintainable e-commerce solution built with the latest .NET 8 stack. By leveraging Clean Architecture and key design patterns, the project promotes scalability, code clarity, and modular development. Upon completion, ShopEase will be a polished, peer-review-ready application demonstrating real-world full-stack development practices with secure authentication, responsive UI, and state management.

---

## 🚀 Step-by-Step Commands to Implement ShopEase in VS Code

### 1. Create Solution & Folder Structure

```sh
mkdir ShopEase && cd ShopEase
mkdir src tests
dotnet new sln -n ShopEase
dotnet new webapi -n ShopEase.Api -o src/ShopEase.Api
dotnet new classlib -n ShopEase.Domain -o src/ShopEase.Domain
dotnet new classlib -n ShopEase.Application -o src/ShopEase.Application
dotnet new classlib -n ShopEase.Infrastructure -o src/ShopEase.Infrastructure
dotnet new blazorwasm -n ShopEase.Blazor -o src/ShopEase.Blazor
dotnet new xunit -n ShopEase.Tests -o tests/ShopEase.Tests
dotnet sln add src/ShopEase.*
dotnet sln add tests/ShopEase.Tests
dotnet add src/ShopEase.Api reference src/ShopEase.Application src/ShopEase.Infrastructure src/ShopEase.Domain
dotnet add src/ShopEase.Application reference src/ShopEase.Domain
dotnet add src/ShopEase.Infrastructure reference src/ShopEase.Domain
dotnet add tests/ShopEase.Tests reference src/ShopEase.Application src/ShopEase.Infrastructure src/ShopEase.Domain
```

### 2. Install Required NuGet Packages

```sh
dotnet add src/ShopEase.Application package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add src/ShopEase.Application package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add src/ShopEase.Application package FluentValidation
dotnet add src/ShopEase.Infrastructure package Microsoft.EntityFrameworkCore.Sqlite
dotnet add src/ShopEase.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet add src/ShopEase.Infrastructure package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add src/ShopEase.Api package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add src/ShopEase.Api package Swashbuckle.AspNetCore
dotnet add tests/ShopEase.Tests package Moq
dotnet add tests/ShopEase.Tests package FluentAssertions
```

### 3. Domain Modeling & Business Logic

- Create `Product` and `Cart` models in `src/ShopEase.Domain/Entities`.
- Implement repositories and services in `src/ShopEase.Application` and `src/ShopEase.Infrastructure`.
- Use MediatR for CQRS handlers.
- Use AutoMapper for DTO mapping.
- Use FluentValidation for input validation.

### 4. Database Setup & Migrations

```sh
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate --project src/ShopEase.Infrastructure --startup-project src/ShopEase.Api
dotnet ef database update --project src/ShopEase.Infrastructure --startup-project src/ShopEase.Api
```

### 5. API & Swagger

- Implement Product and Cart CRUD endpoints in `ShopEase.Api`.
- Enable Swagger in `Program.cs`:

```csharp
// ...existing code...
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ...existing code...
```

- Run API:

```sh
dotnet run --project src/ShopEase.Api
```

- Open Swagger UI at `https://localhost:5001/swagger`.

### 6. Authentication & Security

- Configure ASP.NET Identity and JWT in `ShopEase.Api`.
- Protect endpoints with `[Authorize]`.
- Use FluentValidation for DTOs.
- Sanitize all inputs.

### 7. Blazor Frontend

- Build `ProductCard.razor` and cart components in `src/ShopEase.Blazor/Components`.
- Use HttpClient to call API endpoints.
- Implement authentication using JWT (store token in localStorage).
- Use data binding and event callbacks for cart actions.

### 8. Styling & Responsive Design

- Edit `src/ShopEase.Blazor/wwwroot/css/site.css` for styles and media queries.
- Use semantic HTML and ARIA attributes for accessibility.

### 9. State Management

- Use localStorage/sessionStorage in Blazor for cart persistence.
- Validate user journey: login, product listing, cart actions.

### 10. Testing

```sh
dotnet test tests/ShopEase.Tests
```

- Write unit tests for business logic, repositories, and API endpoints.

### 11. Debug & Refine

- Use VS Code breakpoints and debugger (`F5`).
- Use Copilot for code suggestions and improvements.

### 12. Finalization

- Optimize code and UI.
- Conduct peer review.
- Prepare for portfolio/demo.

---

**Tip:** Use VS Code Source Control panel