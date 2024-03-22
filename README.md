﻿# Ventas Vehiculos full Stack App

In this repository you will find an SQL file with a query which describes the databse solution, .Net application and a REACT project that performs filtering and information display operations
Before starting you must check if you have a node version equal to or greater than 16 (do it with the "node -v" command) and an npm version equal to or greater than 9 (do it with the "npm -v" command)

1. Go to the link https://github.com/Bushogun/concessionaire-crudApp/archive/refs/heads/main.zip
2. Right click -> Extract here
3. Open folder "backend" in Visual Studio
4. Install dependencies with administrator of packages NuGet -> `'Microsoft.Entityframeworkcore.tools','Microsoft.Entityframeworkcore.design' and 'Microsoft.EntityFrameworkCore.SqlServer'`
5. Change the ConnectionString in file `'appsettings.json'` named "conexion"
6. Open SQLServer and run the file `"Script_BD_VentasVehiculos.sql"`
   
      OR
   
  Open SQLServer and create a new databse called `'VentasVehiculos'`
  In Visual Studio
  New NuGet Terminal and run the command:
  `Scaffold-DbContext "Server=_YourServerName_; DataBase=ToDoDB;Integrated Security=true TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models`
  and run the commands to migrate With entity Framework a database in SQL Server
  `"Add-Migration "Add-VentasVehiculos"`
  `"Update-Database"`

  
8. Open folder "frontend" in Visual Studio Code
9. New terminal (ctrl + shift + ñ)
10. Run the command "npm i"
11. Run the command "npm run dev"
12. Go to "http://localhost:5173/" on you browser

Now you can Add some sells to a Database :D

<p align="right">
  <img src="https://media.giphy.com/media/SvFocn0wNMx0iv2rYz/giphy.gif" alt="GIF Animado">
</p>
