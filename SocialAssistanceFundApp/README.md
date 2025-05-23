
# ASP.NET Core Application Deployment Guide (IIS Hosting)

This guide walks you through the steps required to reconfigure and deploy this ASP.NET Core application on a different machine using IIS. It includes setting up SQL Server, editing connection strings, installing required components, and seeding initial data.

---

## 🛠 Prerequisites

### 1. Install .NET Hosting Bundle (.NET 9)
Download and install the latest .NET 9 Hosting Bundle from the official [.NET download page](https://dotnet.microsoft.com/en-us/download). This installs the .NET Runtime, ASP.NET Core runtime, and IIS support.

### 2. Enable Required Windows Features
Open **Windows Features** and ensure the following are enabled:
- `.NET Framework 4.x`
- `Internet Information Services`
  - Web Management Tools
  - IIS Management Console
  - World Wide Web Services
    - Application Development Features (ASP.NET, .NET Extensibility)
    - Common HTTP Features
    - Security

### 3. Install SQL Server and SQL Server Management Studio (SSMS)
- Download and install [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Download and install [SSMS](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)

---

## ⚙️ Configuration

### 1. Update Connection Strings
Edit the `appsettings.json` file in the root of your project:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MyAppDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 🔐 If Using SQL Authentication

If your SQL Server instance uses SQL authentication instead of Windows authentication, update the connection string accordingly:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MyAppDb;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True;"
}
```

> ✅ **Note**: Replace `sa` and `yourStrong(!)Password` with your actual SQL Server login credentials.

---

## 🚀 Publish and Host with IIS

### 1. Publish the App
Use Visual Studio or the `dotnet` CLI to publish:

```bash
dotnet publish -c Release -o ./publish
```

### 2. Create Site in IIS
- Open **IIS Manager**
- Right-click **Sites > Add Website**
- Site name: `MyApp`
- Physical path: Browse to the `./publish` folder
- Binding: Choose a unique port (e.g., 8080) or use localhost with host name
- Start the site

### 3. Grant Permissions
Ensure that the IIS App Pool identity (e.g., `IIS AppPool\DefaultAppPool`) has read access to the published folder.

---

## 🧱 Apply EF Core Migrations

If using **Code First**, run the following to apply database schema:

```bash
dotnet ef database update
```

Ensure that the **DefaultConnection** string is correctly pointing to your SQL Server.

> 📝 You may also need to install EF CLI tools: `dotnet tool install --global dotnet-ef`

---

## 🗃 Seed Initial Data

After applying migrations, run the following SQL commands in SSMS to seed the address data:

```sql
INSERT INTO Counties (Code, Name) VALUES ('001', 'Nairobi');

INSERT INTO SubCounties (CountyId, Code, Name) VALUES (1, '001-001', 'Westlands');

INSERT INTO Locations (SubCountyId, Code, Name) VALUES (1, '001-001-001', 'Parklands');

INSERT INTO SubLocations (LocationId, Code, Name) VALUES (1, '001-001-001-001', 'Parklands Central');

INSERT INTO Villages (SubLocationID, Code, Name) VALUES (1, '001-001-001-001-001', 'Parklands Estate');
```

---

## ✅ Done!
Your ASP.NET Core application should now be running and accessible through IIS.
