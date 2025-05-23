
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
Edit the `appsettings.json` file in the root of your project (Although I recommend the name of the server on the machine):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MyAppDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## 🚀 Publish and Host with IIS

### 1. Publish the App
## 🖥️ GUI-Based Publishing Instructions

Follow these steps to publish the ASP.NET Core application using the Visual Studio GUI:

### 1. Build the Project
Open your solution in Visual Studio and make sure it builds without any errors.

### 2. Publish via GUI
- Right-click on the project in **Solution Explorer** and select **Publish**.
- Click **New Profile**.
- Select **Folder** and click **Next**.
- Choose a target folder (e.g., `C:\PublishOutput`) and click **Finish**.
- Click **Publish** to generate the published output.

### 3. Copy to IIS Site Folder
- Navigate to the output folder (e.g., `C:\PublishOutput`).
- Copy all contents of this folder to your IIS site’s physical path, typically something like:  
  `C:\inetpub\wwwroot\YourSite`.

### 4. Assign Correct Permissions
- Ensure that the **IIS Application Pool Identity** (e.g., `IIS APPPOOL\YourAppPoolName`) has **Read** and **Execute** permissions on your published site folder.

> ✅ **Tip**: You can set permissions by right-clicking the folder, selecting **Properties > Security > Edit**, and adding the appropriate user.


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

If using **Code First**, run the following to apply database schema in the package manager console:

```bash
Update-Database
```

Ensure that the **DefaultConnection** string is correctly pointing to your SQL Server.

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
