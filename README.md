# LibraryAPI
Simple API for book handling
Steps to launch the server with docker:
1) Clone the repository on your drive
2) Open command console and inside the repository folder run "docker compose build"
3) Then run "docker compose up"
4) Open http://localhost:5000/swagger/index.html
5) Try out those requests! Some require logging in - use one these values:
- Email: vasya@mail.ru 
- Password: 1234
or
- Email: anya@gmail.com
- Password: 12345

User repository and user service are just prototypes and do not allow registration, hashing, or anything like that as user handling is not a focus of this app.
 
