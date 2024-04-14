# .NET 8 Microservices Solution

## Overview
This solution comprises a suite of microservices, each dedicated to a specific domain within our application. 
Designed with domain-driven principles, they ensure modularity, ease of maintenance, and scalability.

## Prerequisites
Before running the .NET 8 solution, ensure the following prerequisites are met:

### Software Requirements
- **.NET 8 SDK**: Download and install from the .NET download page.
- **Visual Studio 2022 or later**: Download from the Visual Studio downloads page. Select the **.NET desktop development** workload.
- **SQL Server Express LocalDB**: Included with Visual Studio 2022 or downloadable from the SQL Server Express download page.

### LocalDB Setup
1. Open Command Prompt as an administrator.
2. Create a new LocalDB instance: `sqllocaldb create "MSSQLLocalDB"`.
3. Start the LocalDB instance: `sqllocaldb start "MSSQLLocalDB"`.

### Database Creation
1. Connect to LocalDB using SQL Server Management Studio or Visual Studio.
2. Execute: `CREATE DATABASE UsersDb;`
3. Execute: `CREATE DATABASE NotificationDb;`
4. Execute: `CREATE DATABASE LicenseDb;`

### Connection Strings
- In the solution, the connection strings are pointed to the LocalDB instance: Example : `Server=(localdb)\\MSSQLLocalDB;Database=UsersDb;Trusted_Connection=True;`


### Entity Framework Core (Optional) - Should ideally install when .NET Restore happens
- Install necessary NuGet packages.
- Apply migrations: `Update-Database` in Package Manager Console.
- Alternatively you can find the scripts to create the table unuder each DB here -  

### Running the Solution
1. Open the solution in Visual Studio.
2. Build the solution to restore dependencies and compile the project.
3. Run the application to start the microservices.

## Postman Collection
- Collection on postman requests is also shared in the common link shared on email.
- You can use it to test the solution on localhost

## License
This project is licensed under the MIT License - see the `LICENSE.md` file for details.