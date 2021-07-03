# Web-App-Database-Connection
A web application in C# used for communication purpose with a database. It can modify, add or delete rows.
The application has been made in ASP.NET using .NET Framework. The purpose of an app is not to look nice - rather giving an information how to connect to selected database.
# Description
Creating two tables in SQL Server in table designer looking like this:
![obraz](https://user-images.githubusercontent.com/71320683/124367017-389b5680-dc54-11eb-93e0-752a27026d96.png)

Then sample data has been inserted.
# Creating a new web client application
New client web app has been created in ASP.NET.

Connection to database has been established.

# Interface I
In this interface the idea is to focus on filtered selection and ordering games from GAMES table.

General restrictions:
1. Filter byRELEASE_DATE window (start date, end date),GAME_NAME containing a specific keyword and minimum SCORE.
2. Provide an option to buy a game from the filtered selection – SQL insert statement is generated in the following way: ORDER_ID –unique number, ORDER_DATE – current date, GAME_ID –selected gameidentifier, NET_AMOUNT – PRICE from GAMES table, DISCOUNT –if RELEASE_DATE is more than 3 years ago, a 20% discount is included, GROSS_AMOUNT –NET_AMOUNT less DISCOUNT plus 23% VAT tax

# Interface II
Developing a web interface for orders management:

1. Management panel for each row – UPDATE ROW | DELETE ROW
2. UPDATE ROW enables to change all details except ORDER_ID and save results tothe database
3. DELETE ROW allows for removal of selected rows from the database

# General info
It is better to use some try - catch blocks of code for checking whether the data format is correct, I have kind of omitted this in few cases.
For connecting to your own database you have to check the string in every SqlConnection. It was initially set to my own data, so I have changed it.
