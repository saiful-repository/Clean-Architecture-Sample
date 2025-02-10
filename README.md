Clean Architecture with .NET 8
This repository demonstrates the implementation of Clean Architecture using .NET 8. The project is structured to follow best practices, ensuring a maintainable, scalable, and testable architecture for building web applications and APIs.

Architecture Overview
The solution is divided into multiple layers, each with a specific responsibility to ensure a clear separation of concerns:

Domain Layer – Contains core business logic and entities.
Application Layer – Handles use cases, services, and application logic.
Infrastructure Layer – Manages database access, third-party services, and external dependencies.
API Layer (Web Layer) – Exposes endpoints, handles requests, and integrates other layers.

Tech Stack
.NET 8
Entity Framework Core
AutoMapper
Swagger/OpenAPI
Dependency Injection

Features
API Versioning – Supports multiple API versions for better backward compatibility.
JWT Authentication – Secure API endpoints using JSON Web Tokens.
