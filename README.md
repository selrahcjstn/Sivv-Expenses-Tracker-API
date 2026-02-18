# Sivv - Expense Tracker API

Sivv is a comprehensive backend solution designed to modernize personal finance management. Beyond standard expense logging, the system is architected to handle complex shared financial scenarios, such as splitting bills among groups, and leverages AI logic for automated transaction categorization.

This repository serves as a practical implementation of enterprise-grade .NET development standards, prioritizing scalability, maintainability, and strict separation of concerns.

## Project Status

**Current Focus:** Backend API & Core Logic
**Note:** The frontend application for this project is currently under active development. This repository contains the server-side logic, database migrations, and API definitions.

## Architecture

The solution enforces **Clean Architecture** principles to maintain decoupling between the core business logic and external concerns.

* **Sivv.Domain:** The core of the system containing enterprise logic, entities, and enums. This layer has zero external dependencies.
* **Sivv.Application:** Orchestrates business logic using the CQRS (Command Query Responsibility Segregation) pattern. It defines the interfaces and use cases for the system.
* **Sivv.Infrastructure:** Implements the interfaces defined in the Application layer, handling database persistence, file systems, and external service integrations.
* **Sivv.Api:** The entry point for the application. It acts as a thin presentation layer that exposes RESTful endpoints and configures dependency injection.

## Technology Stack

* **Framework:** .NET 8 (ASP.NET Core Web API)
* **Database:** PostgreSQL
* **ORM:** Entity Framework Core
* **API Documentation:** OpenAPI / Swagger

## Key Patterns & Features

* **CQRS Pattern:** Implemented via MediatR to decouple read and write operations, ensuring high performance and clear separation of logic.
* **Domain-Driven Design (DDD):** Focuses on the core domain logic and domain model rather than the infrastructure.
* **Validation Pipeline:** Utilizes FluentValidation to enforce strict data integrity rules before processing commands.
* **Result Pattern:** Replaces traditional exception-based control flow with a functional Result pattern for predictable error handling.

## Future Development

* **Authentication:** Secure user identity management and JWT token generation.
* **Shared Expenses:** Logic for group management and splitting costs among multiple users.
* **AI Integration:** Service implementation for intelligent expense categorization based on transaction descriptions.
* **Reporting:** Aggregation queries for generating monthly financial summaries.
