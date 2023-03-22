# LibraryAPI
Simple API for book handling

Steps to launch the server without docker:
1) Open your Microsoft SQL Server Management Studio and connect to any server.
2) Right-click the "Databases" folder and choose "Restore database..".
3) Tick the "Device" button and add the "Library.bak" file located in a Data folder. It will create a Library database.

4) Now open \LibraryAPI\LibraryAPI\appsettings.json and in "ConnectionStrings", "DefaultConnection" change the "DESKTOP-SOC2VQI\\TELYONOKSQL" part with the server you have restored the database in.
5) Open command console, navigate to the root folder and run "dotnet build" command.
6) Navigate to the LibraryAPI folder and run "dotnet run" command.
7) Open http://localhost:5190/swagger/index.html 
