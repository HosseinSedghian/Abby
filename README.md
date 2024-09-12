# Abby

## Project Overview

Abby is a web application designed to manage restaurant operations. It provides functionalities for managing categories, food types, menu items, shopping carts, and orders. The application is built using ASP.NET Core and Entity Framework Core.

## Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/HosseinSedghian/Abby.git
   cd Abby
   ```

2. **Set up the database:**
   - Update the connection string in `appsettings.json` to point to your database.
   - Apply migrations to create the database schema:
     ```bash
     dotnet ef database update
     ```

3. **Run the application:**
   ```bash
   dotnet run
   ```

## Modules

### Abby.DataAccess
This module contains the data access layer of the application. It includes the following components:
- **AppDbContext:** The database context class that manages the database connection and entity sets.
- **DbInitializer:** A class responsible for initializing the database with default data.
- **Repositories:** Implementations of the repository pattern for various entities such as Category, FoodType, MenuItem, etc.

### Abby.Models
This module contains the domain models of the application. It includes classes such as:
- **ApplicationUser:** Represents a user in the application.
- **Category:** Represents a category of items.
- **FoodType:** Represents a type of food.
- **MenuItem:** Represents a menu item.
- **ShoppingCart:** Represents a shopping cart.
- **OrderHeader:** Represents the header of an order.
- **OrderDetail:** Represents the details of an order.

### Abby.Utility
This module contains utility classes and constants used throughout the application. It includes:
- **SD:** A static class containing constants for roles and other application-specific values.
- **EmailSender:** A class for sending emails.

### Abby.Web
This module contains the web layer of the application. It includes:
- **Pages:** Razor Pages for various functionalities such as managing categories, food types, menu items, shopping carts, and orders.
- **ViewComponents:** View components for reusable UI elements.
- **wwwroot:** Static files such as CSS, JavaScript, and images.

### Abby.Tests
This module contains the test cases for the application. It includes:
- **DbInitializerTests:** Tests for the `DbInitializer` class.
- **RepositoryTests:** Tests for the repository pattern.
- **ModelsTests:** Tests for the models.
