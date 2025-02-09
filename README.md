# **README GuldbaggensGlosAppAssignment

# Vocabulary Form in Blazor

This is a Blazor Server application for creating and interacting with a vocabulary form. The form allows users to input translations for words, validates the answers, and provides feedback, with data saved directly to a database.

## Features
- Displays a vocabulary list with editable fields for user input.
- Validates answers and provides feedback directly in the UI.
- Tracks the number of correct answers.
- Saves user responses to a database using Entity Framework Core.
- Allows resetting the form to start over.

## Technologies
- **Blazor Server**: Framework for building interactive web UIs using C#.
- **Entity Framework Core**: For database interactions.
- **ASP.NET Core**: For backend integration.

## Installation
1. Clone the repository:
   git clone https://github.com/username/vocabulary-form-blazor.git
   cd vocabulary-form-blazor
2. Configure the database connection string in appsettings.json
3. Migration dotnet ef database update
4. Run the application: dotnet run
