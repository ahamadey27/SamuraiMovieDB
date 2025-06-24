# Samurai Movie DB
A Curated Database of Classic Samurai Films: An ASP.NET Core Portfolio Project

## Project Overview
Samurai Movie DB is a full-stack web application built with ASP.NET Core Razor Pages. It provides a simple, elegant platform to manage and display a database of samurai movies. This project is designed to demonstrate core skills in .NET development, from database design and interaction to user authentication and deployment.

## Features
- User authentication for a single administrator role
- Full CRUD (Create, Read, Update, Delete) operations for movie entries (admin only)
- A public-facing, searchable catalog of all movies in the database
- Server-side filtering based on movie attributes like title, director, and year
- Secure and persistent data storage using a SQLite database
- Clean, server-rendered frontend using Razor Pages
- Ready for deployment to Azure or other cloud platforms

## How It Was Built
- **Backend:** ASP.NET Core, Entity Framework Core, ASP.NET Core Identity for authentication
- **Frontend:** Razor Pages (server-rendered), HTML5, CSS
- **Database:** SQLite (for easy local development)
- **Deployment:** Ready for Azure App Service

## Admin Access
This project is configured for a single administrator. The current development plan involves temporarily enabling registration to create the admin user and then disabling it.

---
Feel free to use this project in your portfolio or as a learning resource. For setup instructions, follow standard .NET project procedures: `dotnet restore`, `dotnet ef database update`, and `dotnet run`.