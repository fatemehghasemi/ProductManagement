
# Product Management System

Product Management System is a comprehensive product pricing and configuration platform that allows businesses to manage products, pricing structures, materials, sizes, delivery options, and print specifications for printing and manufacturing operations.

## 🚀 Quick Start for New Developers

### Prerequisites
- .NET 9.0 SDK or later
- SQL Server or SQL Server Express
- Visual Studio 2022 or VS Code (optional)

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/product-management.git
cd ProductManagement
```

### 2. Database Setup

#### Configure Connection String
Update the connection string in `src/WebApi/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnectionString": "Server=localhost\\SQLEXPRESS;Database=ProductManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Connection String Options:**
- **SQL Server Express**: `Server=localhost\\SQLEXPRESS;Database=ProductManagementDB;Trusted_Connection=True;TrustServerCertificate=True;`
- **SQL Server**: `Server=localhost;Database=ProductManagementDB;Trusted_Connection=True;TrustServerCertificate=True;`
- **SQL Server with credentials**: `Server=localhost;Database=ProductManagementDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;`

### 3. Entity Framework Core Migrations

#### Install EF Core Tools (if not already installed)
```bash
dotnet tool install --global dotnet-ef
```

#### Verify EF Tools Installation
```bash
dotnet ef --version
```

#### Run Database Migrations
From the solution root directory (`ProductManagement/`):

```bash
# Apply existing migrations to create the database
dotnet ef database update --project src/Infrastructure --startup-project src/WebApi
```

#### Create New Migration (when you modify entities)
```bash
# Create a new migration
dotnet ef migrations add YourMigrationName --project src/Infrastructure --startup-project src/WebApi

# Apply the new migration
dotnet ef database update --project src/Infrastructure --startup-project src/WebApi
```

#### Other Useful EF Commands
```bash
# Remove the last migration (if not applied to database)
dotnet ef migrations remove --project src/Infrastructure --startup-project src/WebApi

# Generate SQL script from migrations
dotnet ef migrations script --project src/Infrastructure --startup-project src/WebApi

# Drop the entire database (⚠️ Use with caution!)
dotnet ef database drop --project src/Infrastructure --startup-project src/WebApi

# List all migrations
dotnet ef migrations list --project src/Infrastructure --startup-project src/WebApi
```

### 4. Build and Run the Application

#### Build the Solution
```bash
dotnet build
```

#### Run the API
```bash
dotnet run --project src/WebApi --urls "https://localhost:7000;http://localhost:5000"
```

#### Access the Application
- **Swagger UI**: https://localhost:7000
- **HTTP Endpoint**: http://localhost:5000

### 5. Database Schema Overview

The system uses the following main entities:

- **Product** – Main product entity with configuration options
- **ProductSize** – Available size variants
- **ProductMaterial** – Material options and specifications  
- **ProductMaterialAttribute** – Material attributes
- **ProductAdt** – Additional product features
- **ProductAdtType** – Types of additional features
- **ProductAdtPrice** – Pricing for additional features
- **ProductDeliver** – Delivery and shipping options
- **ProductDeliverSize** – Size-specific delivery options
- **ProductPrintKind** – Print type specifications
- **ProductPrice** – Comprehensive pricing matrix

## 🛠️ Technologies & Frameworks

### Core Technologies
- **.NET 9.0** - Latest .NET framework
- **C# 12** - Programming language with latest features
- **ASP.NET Core 9.0** - Web API framework
- **Entity Framework Core 8.0** - Object-relational mapping (ORM)
- **SQL Server** - Database management system

### Architecture & Patterns
- **Clean Architecture** - Layered architecture with dependency inversion
- **CQRS (Command Query Responsibility Segregation)** - Separate read/write operations
- **MediatR** - Mediator pattern implementation for decoupled request handling
- **Repository Pattern** - Data access abstraction layer
- **Factory Pattern** - Product creation with business rules
- **Strategy Pattern** - Flexible pricing calculation algorithms

### Validation & Mapping
- **FluentValidation** - Fluent interface for building validation rules
- **Mapster** - High-performance object mapping library

### API & Documentation
- **Swagger/OpenAPI** - API documentation and testing interface
- **Swashbuckle.AspNetCore** - Swagger implementation for ASP.NET Core

### Development Tools
- **Microsoft.EntityFrameworkCore.Design** - EF Core design-time tools
- **Microsoft.EntityFrameworkCore.Tools** - Package Manager Console tools
- **Microsoft.AspNetCore.OpenApi** - OpenAPI specification support

### Database Features
- **Entity Framework Migrations** - Database schema versioning
- **Foreign Key Constraints** - Data integrity enforcement
- **Soft Delete Support** - Logical deletion with IsDelete flag
- **Relationship Mapping** - One-to-many and many-to-many relationships

### Cross-Cutting Concerns
- **Global Exception Handling** - Centralized error management
- **CORS Support** - Cross-origin resource sharing
- **Dependency Injection** - Built-in IoC container
- **Async/Await Pattern** - Asynchronous programming throughout

## 🏗️ Architecture & Design Patterns

### Clean Architecture Layers
- **Domain** - Entities, interfaces, business rules
- **Application** - Use cases, CQRS handlers, DTOs
- **Infrastructure** - Data access, external services
- **WebApi** - Controllers, middleware, configuration

### Implemented Design Patterns
- **Factory Pattern** - Product creation with business rules
- **Strategy Pattern** - Flexible pricing calculations
- **Repository Pattern** - Data access abstraction
- **CQRS Pattern** - Command Query Responsibility Segregation
- **Mediator Pattern** - Decoupled request handling

## 🧪 Testing the API

### Sample Endpoints

#### Create Product (Factory Pattern)
```http
POST /api/Product
Content-Type: application/json

{
  "productGroupId": 1,
  "workTypeId": 1,
  "productType": 1,
  "circulation": "1000-5000",
  "copyCount": "1-100",
  "pageCount": "4-16",
  "printSide": 2,
  "isCalculatePrice": true,
  "isCustomCirculation": true,
  "minCirculation": 1000,
  "maxCirculation": 5000,
  "sheetDimensionId": 1,
  "fileExtension": ".pdf,.ai,.eps",
  "isCmyk": true,
  "cutMargin": 3.0,
  "printMargin": 5.0,
  "isCheckFile": true
}
```

#### Calculate Product Price (Strategy Pattern)
```http
POST /api/Product/1/calculate-price
Content-Type: application/json

{
  "productSizeId": 1,
  "productMaterialId": 1,
  "productPrintKindId": 1,
  "circulation": 1000,
  "pageCount": 8,
  "copyCount": 50,
  "isDoubleSided": true,
  "preferredStrategy": "Standard"
}
```

#### Get All Products
```http
GET /api/Product?productGroupId=1
```

### Test Data
Complete test data examples are available in `api-test-data.json`.

## 🔧 Development Workflow

### Adding New Features

1. **Create Entity** (if needed) in `src/Domain/Entities/`
2. **Add Repository Interface** in `src/Domain/Interfaces/`
3. **Implement Repository** in `src/Infrastructure/Repositories/`
4. **Create CQRS Commands/Queries** in `src/Application/Features/`
5. **Add Controller** in `src/WebApi/Controllers/`
6. **Create Migration**:
   ```bash
   dotnet ef migrations add AddNewFeature --project src/Infrastructure --startup-project src/WebApi
   dotnet ef database update --project src/Infrastructure --startup-project src/WebApi
   ```

### Troubleshooting

#### Port Already in Use
If you get port conflicts, use different ports:
```bash
dotnet run --project src/WebApi --urls "https://localhost:8000;http://localhost:8001"
```

#### Database Connection Issues
1. Ensure SQL Server is running
2. Verify connection string
3. Check if database exists:
   ```bash
   dotnet ef database update --project src/Infrastructure --startup-project src/WebApi
   ```

#### Migration Issues
```bash
# Reset migrations (⚠️ Development only!)
dotnet ef database drop --project src/Infrastructure --startup-project src/WebApi
dotnet ef database update --project src/Infrastructure --startup-project src/WebApi
```

## 📚 Additional Resources

- **API Documentation**: Available at `/swagger` when running
- **Design Patterns**: See `DESIGN-PATTERNS.md` for detailed implementation
- **Migration Commands**: See `migration-commands.md` for quick reference
- **Project Structure**: See `PROJECT-STRUCTURE.md` for architecture details

## 🤝 Contributing

1. Create a feature branch
2. Make your changes
3. Add/update tests
4. Create migration if needed
5. Update documentation
6. Submit pull request

---

**Happy Coding! 🚀**