# Test_Tech_Millon
This is a complete solution that uses **.NET Core** for the back-end (API). The project is designed as an example of clean architecture, and complement with TDD. it implemented **JWT Token** for secure API

## Project Structure

### Backend (API)
The backend project is developed in **.NET Core 8.0**. It provides a series of RESTful endpoints to interact with the database.

## Prerequisites
Before starting, make sure you have the following installed:
- [.NET Core SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)

## Project Setup
Follow these steps to set up and run the project on your local environment.

### Clone the Repository
```bash
git clone https://github.com/EdisonRuiz/Test_Tech_Millon
cd my-repository
```

#### Backend: .NET Core API
1. Navigate to the backend directory:
```bash
cd EdisonPelaez_Test_Millon
```

2. Restore the NuGet packages (From Visual Studio, 'Restore NuGet Packages') or use the following command:
```bash
dotnet restore
```
3. Run the project:
```bash
dotnet run
```
4. Dowloand file **BackUp DataBase.sql** and execute query in your SQL server 
![image](https://github.com/user-attachments/assets/d3bc6c28-13fd-45db-abe6-ded5763c4dfe)


5. Login Authentication
Credentials: User = **UserDevelop**   -- Password = **1596!233@@**

You must consume 'https://localhost:your_port/api/Authentication/Login' 
![image](https://github.com/user-attachments/assets/dd022d9a-75fb-42c2-b2cc-efcba2f8ed6a)

6. Copy clibboard
![image](https://github.com/user-attachments/assets/743453f5-fd29-49db-88cc-d88052c23c96)

Right now you can consume diferents request with Authorize
![image](https://github.com/user-attachments/assets/f593f785-93f1-4c2c-8f4a-81f60b34b5c8)


This version maintains the structure and instructions from the original while providing a clear guide for English-speaking users.
Launch API
![image](https://github.com/user-attachments/assets/d5adbba4-a359-40d4-858c-c8d99ec5aefd)
