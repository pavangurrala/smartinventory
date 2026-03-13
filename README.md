SmartInventory Web API README

Below is a clean README you can use for your SmartInventory Web API project.

# SmartInventory Web API

SmartInventory Web API is a scalable backend service built with **ASP.NET Core Web API** for managing inventory, products, stock movements, and related business operations.  
The API is designed using clean architectural principles, supports containerized deployment using **Docker**, and is deployed to **Microsoft Azure** for cloud-based hosting and availability.

---

## Project Overview

SmartInventory is an inventory management backend that provides RESTful endpoints for:

- Product management
- Inventory tracking
- Stock updates
- Pagination and filtering
- Database persistence using SQL Server / Azure SQL
- Cloud deployment through Azure App Service
- CI/CD support with GitHub Actions
- Containerized deployment using Docker

This API is intended to serve as the backend for a web-based or mobile inventory management solution.

---

## Tech Stack

- **Backend Framework:** ASP.NET Core Web API
- **Language:** C#
- **Database:** SQL Server / Azure SQL Database
- **ORM:** Entity Framework Core
- **Cloud Platform:** Microsoft Azure
- **Containerization:** Docker
- **Container Registry:** Azure Container Registry (ACR)
- **Deployment Target:** Azure App Service (Linux)
- **CI/CD:** GitHub Actions
- **Documentation:** Swagger / OpenAPI

---

## Features

- RESTful API design
- CRUD operations for products and inventory records
- Pagination support for large datasets
- Entity Framework Core integration
- SQL query optimization support
- Health check endpoint for deployment verification
- Dockerized application for consistent deployments
- Azure-hosted production deployment
- Environment-based configuration support

---

## Solution Architecture

The SmartInventory Web API follows a layered backend structure:

- **Controllers**  
  Handle incoming HTTP requests and return responses

- **Services / Business Logic Layer**  
  Contains inventory rules, validations, and processing logic

- **Data Access Layer**  
  Uses Entity Framework Core for database interaction

- **Database**  
  SQL Server / Azure SQL stores product and inventory data

- **Deployment Layer**  
  Docker image pushed to Azure Container Registry and deployed to Azure App Service

---

## API Endpoints

### Products

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/products` | Get all products |
| GET | `/api/products/{id}` | Get product by ID |
| POST | `/api/products` | Add a new product |
| PUT | `/api/products/{id}` | Update an existing product |
| DELETE | `/api/products/{id}` | Delete a product |

### Health Check

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/health` | Verify API health/status |

### Example with Pagination

```http
GET /api/products?pageNumber=1&pageSize=10
Sample Product Payload
{
  "name": "Laptop",
  "category": "Electronics",
  "quantity": 10,
  "price": 899.99,
  "vendorName": "Tech Supplies Ltd",
  "location": "Dublin"
}
Local Development Setup
Prerequisites

Make sure you have the following installed:

.NET SDK 8.0

SQL Server or Azure SQL access

Docker Desktop

Visual Studio 2022 / VS Code

Git

Running the Application Locally
1. Clone the repository
git clone https://github.com/your-username/smartinventory-api.git
cd smartinventory-api
2. Restore dependencies
dotnet restore
3. Update database connection string

Set your database connection string in:

appsettings.json

Example:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=SmartInventoryDb;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
}
4. Apply migrations
dotnet ef database update
5. Run the API
dotnet run

The API will be available at:

https://localhost:5001
http://localhost:5000
Swagger Documentation

Once the application is running, Swagger UI can be accessed at:

https://localhost:5001/swagger

This provides interactive API documentation and allows endpoint testing directly from the browser.

Docker Setup
Build Docker image
docker build -t smartinventory-api .
Run Docker container
docker run -d -p 8080:8080 --name smartinventory-api smartinventory-api
Example Dockerfile Strategy

The application uses a multi-stage Docker build:

Build stage using .NET SDK image

Publish stage to compile release binaries

Runtime stage using lightweight ASP.NET runtime image

This approach helps reduce:

Final image size

Deployment time

Attack surface

Azure Deployment

The SmartInventory Web API is deployed to Microsoft Azure App Service using a Docker container.

Deployment Flow

Source code pushed to GitHub

GitHub Actions builds the application

Docker image is created

Image is pushed to Azure Container Registry

Azure App Service pulls the image from ACR

API runs in Azure with environment-based settings

Azure Services Used

Azure App Service (Linux)

Azure Container Registry

Azure SQL Database

App Settings / Connection Strings

Publish Profile / CI-CD integration

Environment Configuration

In Azure, sensitive values such as database connection strings should be stored in:

Azure App Service Configuration

Connection Strings

Application Settings

Do not hardcode production secrets in appsettings.json.

Example production settings:

ASPNETCORE_ENVIRONMENT=Production

ConnectionStrings__DefaultConnection=<Azure SQL Connection String>

Health Check Verification

To verify deployment status after release:

GET /api/health

Example production URL:

https://your-app-name.azurewebsites.net/api/health

This endpoint helps confirm that the API is running successfully after deployment.

Database Migrations

When schema changes are introduced, Entity Framework Core migrations can be created using:

dotnet ef migrations add InitialCreate
dotnet ef database update

For production, ensure migrations are reviewed carefully before applying them to Azure SQL.

CI/CD Pipeline Overview

A typical GitHub Actions pipeline for SmartInventory includes:

Restore NuGet packages

Build the project

Run tests

Build Docker image

Push image to Azure Container Registry

Deploy to Azure App Service

This ensures repeatable and automated deployments.

Error Handling and Validation

The API includes support for:

Request validation

Proper HTTP status codes

Structured error responses

Safe exception handling practices

Recommended future improvements:

Global exception middleware

Serilog / Application Insights logging

FluentValidation

Role-based authorization

Future Enhancements

Possible next improvements for SmartInventory Web API:

Authentication and Authorization with JWT

Role-based access control

Product search and advanced filtering

Stock in/out transaction history

Redis caching

Azure Key Vault integration

Application Insights monitoring

Unit and integration testing

Audit logging

Project Structure
SmartInventory.Api
│
├── Controllers
├── Models
├── DTOs
├── Services
├── Data
├── Migrations
├── Properties
├── appsettings.json
├── Program.cs
├── Dockerfile
└── SmartInventory.Api.csproj
Status

Project status: Designed, containerized, and deployed to Azure

This API demonstrates:

Enterprise-style backend design

Cloud deployment readiness

Practical use of ASP.NET Core, EF Core, Docker, and Azure

Author

Pavan Gurrala
Senior Backend Engineer – .NET Core | Azure | Enterprise Systems

License

This project is for learning, portfolio, and demonstration purposes.


If you want, I can also turn this into a more polished **GitHub-ready README with badges, architecture diagram section, and deployment screenshots placeholders**.
