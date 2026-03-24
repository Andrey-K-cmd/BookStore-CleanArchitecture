# BookStore-CleanArchitecture

A tutorial project on creating an API for a bookstore using Clean Architecture principles.

## Technology stack

*   **Runtime:** .NET 8
*   **Database:** PostgreSQL (Npgsql)
*   **ORM:** Entity Framework Core

## Project architecture

The project is divided into four logical layers:
* **Core (Domain):** Definition of business entities and repository interfaces. Has no external dependencies.
* **Application:** Business logic, contracts, mapping, and services. Works only with the Core.
* **Infrastructure:** Implementation of data access (DbContext), Identity settings, migrations, and third-party services.
* **API (Presentation):** Controllers, DI container setup, and Middleware.
