# LibraryAPI
Simple API for book handling
Steps to launch the server with docker:
1) Clone the repository on your drive
2) Open command console and inside the repository folder run "docker compose build"
3) Then run "docker compose up"
4) Open http://localhost:5000/swagger/index.html
5) Try out those requests!
Some require logging in - use one of these values:
- Email: vasya@mail.ru 
- Password: 1234

or

- Email: anya@gmail.com
- Password: 12345

Important info:
1) User repository and user service are just prototypes and do not allow registration, hashing, or anything like that as user handling is not the focus of this app.
2) !! ISBN form: 0-1234-5678-9 or 123-0-1234-5678-9 !!
3) Response for failed book addition or update could be better with validation errors and user-made mistakes pointed out. I could fix it some way or another yet it is quite tricky and I would most likely make a wrong move and worsen the architecture.
4) May you encounter some kind of error or have a suggestion - feel free to curse me but, please, contact at any time: life270304@mail.ru
