# Clean Architecture with .NET 8  

This repository demonstrates the implementation of **Clean Architecture** using **.NET 8**. The project follows best practices to ensure a **maintainable, scalable, and testable** architecture for building web applications or APIs.  

## Architecture Overview  
The project is structured into multiple layers, ensuring a clear **separation of concerns**:  

- **Domain Layer** – Contains business logic and entities.  
- **Application Layer** – Contains use cases, interfaces, and DTOs.  
- **Infrastructure Layer** – Implements persistence, authentication, and external integrations.  
- **API Layer (Web Layer)** – Exposes endpoints and handles request processing.  

## Tech Stack  
- **.NET 8**  
- **Entity Framework Core**  
- **AutoMapper**  
- **Swagger/OpenAPI**  
- **Dependency Injection**  

## Features  
- **JWT Authentication** – Secure API endpoints using JSON Web Tokens (Token generation and credential verification).  
- **API Versioning** – Supports multiple API versions for better backward compatibility.  
- **CRUD Operations** – Implements Create, Read, Update, and Delete operations via API endpoints.  
