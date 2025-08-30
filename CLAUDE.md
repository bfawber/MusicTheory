# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Structure

This is a .NET 8 music theory application with a clean architecture pattern:

- **MusicTheory.Api** - ASP.NET Core Web API with Swagger integration
- **MusicTheory.Common** - Core business logic and domain models
- **MusicTheory.Tests.Unit** - xUnit test project

The `MusicTheory.Common` project is organized by features:
- `Core/` - Data structures and extensions
- `Features/` - Domain-specific features (Accidentals, Intervals, Notes, Quiz, Scales)
- Each feature has its own namespace and contains services, models, and interfaces

## Development Commands

### Build and Run
```bash
# Build the entire solution
dotnet build

# Run the API project
dotnet run --project src/MusicTheory.Api

# Build specific projects
dotnet build src/MusicTheory.Api
dotnet build src/MusicTheory.Common
```

### Testing
```bash
# Run all unit tests
dotnet test

# Run tests in a specific project
dotnet test tests/MusicTheory.Tests.Unit

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## Architecture Patterns

### Dependency Injection
The API uses constructor-based dependency injection. All services are registered as singletons in `Program.cs`:
- Services follow interface-based patterns (IService/Service)
- Factories are used for object creation (INoteFactory, IIntervalFactory)
- Quiz services handle business logic for generating questions

### Feature-Based Organization
Code is organized by musical features rather than technical layers:
- `Intervals/` - Interval calculation and creation
- `Accidentals/` - Sharp/flat handling
- `Scales/` - Scale construction and analysis
- `Quiz/` - Quiz question generation
- `Notes/` - Note creation and manipulation

### Code Style
- Uses file-scoped namespaces (enforced by .editorconfig)
- Tab indentation for C# files
- Nullable reference types enabled
- Implicit usings enabled

## Key Services

- **IIntervalService** - Core interval calculation logic
- **IIntervalQuizService** - Generates interval quiz questions
- **IAccidentalsService** - Handles musical accidentals
- **INoteFactory/IIntervalFactory** - Object creation patterns
- **MajorScaleBuilder** - Scale construction

## API Endpoints

The API currently exposes:
- `GET /interval` - Returns interval quiz questions with configurable options
  - `includeAbove` (default: true) - Include intervals above the root
  - `includeBelow` (default: false) - Include intervals below the root