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
- [ ] Add ASP.NET Core Identity services and EF Core store configuration in `Program.cs`.
- [ ] Scaffold necessary Identity UI pages (Login, Logout, potentially Register initially for user creation).
- [ ] Add EF Core migrations for Identity tables.
- [ ] Apply Identity migrations.
- [ ] Configure authentication and authorization middleware in `Program.cs`.
- [ ] Implement strategy for creating the single admin user (e.g., seeding, temporary registration).
- [ ] Secure admin credentials using User Secrets during development.

## Phase 4: Public CRUD Operations (No Authentication Required)
- [ ] Create a "Contribute" Razor Page for adding movies.
  - Create a Razor Page (`Contribute.cshtml`) with a form for users to input movie details (e.g., Name, Year, Director, Color, Description).
  - Add logic in the `Contribute.cshtml.cs` PageModel to handle form submissions and save the new movie to the database.
- [ ] Create an "Edit" Razor Page for updating movies.
  - Create a Razor Page (`Edit.cshtml`) with a form pre-filled with the details of the selected movie.
  - Add logic in the `Edit.cshtml.cs` PageModel to handle form submissions and update the movie in the database.
- [ ] Create a "Delete" Razor Page for removing movies.
  - Create a Razor Page (`Delete.cshtml`) with a confirmation prompt for deleting a movie.
  - Add logic in the `Delete.cshtml.cs` PageModel to handle the deletion of a movie from the database.
- [ ] Update navigation to include links to the "Contribute," "Edit," and "Delete" pages.
  - Add links to the appropriate places (e.g., the header or movie list) for easy navigation.

---

# Testing Checklist (MVP)
- [ ] Project builds and runs locally without errors.
- [ ] Initial database migration successfully creates `Movies` table schema.
- [ ] Identity migration successfully creates Identity table schemas.
- [ ] Public Index page displays seeded/all movies correctly.
- [ ] Search functionality filters results accurately for:
    - [ ] Name (partial match)
    - [ ] Year (exact match)
    - [ ] Director (partial match)
    - [ ] Color (boolean match)
    - [ ] Description (partial match)
    - [ ] Combination of fields
    - [ ] Empty search (shows all)
- [ ] Admin user can log in successfully via the Login page.
- [ ] Logged-out users are redirected when attempting to access `/Admin` pages.
- [ ] Admin user can access `/Admin` pages.
- [ ] Admin can create a new movie, and it appears on the public list.
- [ ] Admin can edit an existing movie, and changes are reflected on the public list.
- [ ] Admin can delete a movie, and it is removed from the public list.
- [ ] Input validation prevents saving invalid data (e.g., missing Name/Year).
- [ ] Basic deployment to Azure App Service Free Tier works (site is accessible).
- [ ] Data persists across application restarts on Azure (SQLite DB file is correctly handled).