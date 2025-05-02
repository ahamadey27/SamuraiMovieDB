# Project: Samurai Movie Portfolio Website

**Goal:** To create a basic web application using ASP.NET Core Razor Pages, EF Core, and SQLite to manage and display a database of samurai movies. This project serves as a portfolio piece demonstrating C#/.NET backend development skills, including database interaction, basic authentication, and CRUD operations.

# Components

## Environment/Hosting (Recommended Initial Setup)
- **Local Development Machine (Windows/macOS/Linux)**
  - .NET SDK (8.0 or higher)
  - IDE: Visual Studio / Visual Studio Code
  - Git for version control
- **Cloud Hosting:** Azure App Service (Free Tier recommended for initial deployment)
- **Database:** SQLite file (stored within the application's deployed files)

## Software Components (Recommended Technologies)

### Web Application Backend & Frontend
- **Framework:** ASP.NET Core Razor Pages
- **Language:** C#
- **Frontend Rendering:** Razor Syntax, HTML5, CSS (potentially Bootstrap via CDN)

### Database
- **Type:** Relational Database Management System (RDBMS)
- **Engine:** SQLite

### Data Access Layer
- **ORM:** Entity Framework Core (EF Core)
- **Provider:** `Microsoft.EntityFrameworkCore.Sqlite`

### Authentication & Authorization
- **Framework:** ASP.NET Core Identity
- **Storage:** EF Core Store (using the same SQLite database)

---

# Data Model (Database Schema)

## `Movies` Table
- `Id` (int, Primary Key, Auto-increment)
- `Name` (string, Required)
- `Year` (int, Required)
- `Director` (string, Nullable)
- `Color` (bool, Required - True=Color, False=B&W)
- `Description` (string, Nullable)
- **Unique Constraint:** On (`Name`, `Year`) combination

## ASP.NET Core Identity Tables
- Standard tables created by Identity (`AspNetUsers`, `AspNetRoles`, `AspNetUserClaims`, etc.) stored in the same SQLite database.

---

# Development Plan (MVP - Recommended Approach)

## Phase 1: Project Setup & Database Model
- [x] Initialize ASP.NET Core Razor Pages Project (.NET 8)
- [x] Set up basic project structure (Pages, Models, Data folders)
- [x] Define `Movie.cs` entity model class with validation attributes.
- [x] Integrating and Configuring EF Core with SQLite
- [x] Create `ApplicationDbContext` inheriting from `IdentityDbContext<IdentityUser>`.
- [x] Configure EF Core for SQLite connection in `appsettings.json` and `Program.cs`.
- [x] Add EF Core migrations to create the initial database schema (`Movies` table).
- [x] Apply migrations (`dotnet ef database update`).
- [x] Optional: Implement basic data seeding for initial movies.

## Phase 2: Public Viewing & Searching
- [x] Create/Modify Razor Page (`Index.cshtml`) to display all movies in an HTML table.
- [x] Implement data fetching logic in the PageModel (`Index.cshtml.cs`) using EF Core.
- [x] Add search form UI to the Index page (inputs for Name, Year, Director, Color, Description).
- [x] Implement server-side search logic in the PageModel to filter movies based on criteria.
- [x] Display filtered search results on the Index page.
- [x] Update the website landing page header to include:
- [x] "Samurai Movie Database" (static title, not a link).
- [x] "Search" (link to the search page).
- [x] "Contribute" (link to a page for contributing to the database).
- [x] Remove the "Privacy" link.
- [x] OPTIONAL Use Bootstrap classes (already included in your project) to make the form look clean and professional.

## Phase 3: Admin Authentication Setup
- [x] Add ASP.NET Core Identity services and EF Core store configuration in `Program.cs`.
- [x] Add EF Core migrations for Identity tables.
- [x] Apply Identity migrations.
- [x] Scaffold necessary Identity UI pages (Login, Logout, potentially Register initially for user creation).
- [x] Configure authentication and authorization middleware in `Program.cs`.
- [x] Implement strategy for creating the single admin user (e.g., seeding, temporary registration).
- [x] Secure admin credentials using User Secrets during development.

## Phase 4: Public CRUD Operations (No Authentication Required)
- [x] Create a "Contribute" Razor Page for adding movies.
  - Create a Razor Page (`Contribute.cshtml`) with a form for users to input movie details (e.g., Name, Year, Director, Color, Description).
  - Add logic in the `Contribute.cshtml.cs` PageModel to handle form submissions and save the new movie to the database.
- [x] Create an "Edit" Razor Page for updating movies.
  - Create a Razor Page (`Edit.cshtml`) with a form pre-filled with the details of the selected movie.
  - Add logic in the `Edit.cshtml.cs` PageModel to handle form submissions and update the movie in the database.
- [x] Create a "Delete" Razor Page for removing movies.
- [x] Create a Razor Page (`Delete.cshtml`) with a confirmation prompt for deleting a movie.
- [x] Add logic in the `Delete.cshtml.cs` PageModel to handle the deletion of a movie from the database.
- [x] Update navigation to include links to the "Contribute," "Edit," and "Delete" pages.
- [x] Add links to the appropriate places (e.g., the header or movie list) for easy navigation.

# Phase 5: Testing Checklist (MVP)
- [x] Project builds and runs locally without errors.
- [x] Initial database migration successfully creates `Movies` table schema.
- [x] Identity migration successfully creates Identity table schemas.
- [x] Public Index page displays seeded/all movies correctly.
- [x] Search functionality filters results accurately for:
    - [x] Name (partial match)
    - [x] Year (exact match)
    - [x] Director (partial match)
    - [x] Color (boolean match)
    - [x] Description (partial match)
    - [x] Combination of fields
    - [x] Empty search (shows all)
- [x] Admin user can log in successfully via the Login page.
- [x] Logged-out users are redirected when attempting to access `/Admin` pages.
- [x] Admin user can access `/Admin` pages.
- [x] Admin can create a new movie, and it appears on the public list.
- [x] Admin can edit an existing movie, and changes are reflected on the public list.
- [x] Admin can delete a movie, and it is removed from the public list.
- [x] Input validation prevents saving invalid data (e.g., missing Name/Year).

# Phase 6: Publish Website
- [ ] Prepare project for release build.
- [ ] Create Azure App Service (Free Tier) resource.
- [ ] Deploy application to Azure App Service.
- [ ] Apply EF Core migrations on Azure.
- [ ] Verify website functionality and data persistence on Azure.

# General Notes
---
- Password: SamuraiMovieDb1!
- Email: hamadey@gmail.com