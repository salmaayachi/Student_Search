# Student Search WebApp

**Student Search WebApp** is a web application developed using ASP.NET Core and LINQ to manage and search student information efficiently. The application combines data from multiple sources, supports advanced filtering and sorting options, and provides data export functionalities.

## Features

- **Advanced Search:** Search for students by name or major. Supports global search and filtering by age range.
- **Dynamic Sorting:** Sort student lists by name or age, in ascending or descending order.
- **Multiple Data Sources:** Integrates data from both an in-memory list and a JSON file, demonstrating the ability to handle and combine multiple data sources.
- **JSON Export:** Export the current list of students to a JSON file for easy sharing and analysis.

## Project Structure

- **Controllers:** Handles the interaction between the user interface and the student data.
- **Models:** Defines the data structure and business logic for students.
- **Views:** Provides the user interface for searching, sorting, and displaying student information.
- **wwwroot:** Contains static files, including the JSON data file (`students.json`).

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/salmaayachi/StudentSearchWebApp.git
2.  ```bash
    cd StudentSearchWebApp
3. ```bash
   dotnet restore
5. ```bash
    dotnet run
