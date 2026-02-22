# EventReserve

## Overview

EventReserve is a simple event reservation system built using ASP.NET Core (.NET 9) and Clean Architecture principles.

The system allows users to:

- Create a reservation
- Update a reservation
- Delete a reservation

Data is stored in memory

## Architecture

The solution follows Clean Architecture with the following layers:

- **Domain** – Core business entity (Reservation)
- **Application** – Use cases and repository abstraction
- **Infrastructure** – In-memory repository implementation
- **API** – HTTP layer and dependency injection
- **Tests** – Unit tests for application logic

Dependencies flow inward toward the Domain layer.

## Design Decisions

- The domain entity encapsulates its state and enforces basic validation.
- The application layer depends on abstractions, not concrete implementations.
- The infrastructure layer implements repository contracts.
- The API layer remains thin and contains no business logic.
- In-memory storage is used to satisfy the requirement of no external persistence.
- The solution intentionally avoids overengineering and keeps the model minimal.

## How to Run the Application

From the root folder:

```bash
dotnet build
dotnet run --project EventReserve.Api
```

Then navigate to:

https://localhost:{port}/swagger

## How to Run Tests

From the root folder:

```bash
dotnet test
```

## Notes

This implementation focuses on clarity, separation of concerns, and adherence to SOLID principles.
