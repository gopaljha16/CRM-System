
# FreelanceCRM — ASP.NET Core MVC CRM System

A simple CRM (Customer Relationship Management) web application built using:

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* Bootstrap 5

## ✨ Features

* Manage Leads, Contacts, and Sales Reports
* View Dashboard with aggregated data
* Email service integration (basic setup)
* Simple and clean UI using Bootstrap

## ✅ Technologies Used

* ASP.NET Core MVC (Version 8)
* Entity Framework Core
* Microsoft SQL Server
* Bootstrap 5
* Razor Views

## 🚀 How to Run Locally

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/gopaljha16/CRM-System
   cd FreelanceCRM
   ```

2. **Configure the Database Connection String:**

   Update `appsettings.json` with your local SQL Server connection string:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=FreelanceCRM;Trusted_Connection=True;"
   }
   ```

3. **Apply Migrations and Create Database:**

   Open Package Manager Console:

   ```bash
   Update-Database
   ```

4. **Run the Application:**

   Press `F5` in Visual Studio or use:

   ```bash
   dotnet run
   ```

5. **Access the App:**

   Navigate to:
   `https://localhost:5001`
   or
   `http://localhost:5000`

---

## 💻 Project Structure

```
├── Controllers
├── Data
├── Models
├── Services
├── Views
├── wwwroot
├── appsettings.json
├── Program.cs
```

---

## 🌐 Deployment Options

* IIS Deployment using Web Deploy
* Azure App Service
* Render.com / Fly.io with Docker

---



