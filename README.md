# nutcache-challenge-JuanLopes

The proposal was to develop a simple CRUD API using the best practices.


## Used Technologies

| Language          | Hexadecimal                                                       |
| ----------------- | ----------------------------------------------------------------  |
| C#                | ASP.NET under .NET 6.0                                            |
| C#                | Entity Framework Core 6.0.7                                       |
| C#                | XUnit for some tests                                              |
| JavaScript        | NodeJS                                                            |
| JavaScript        | React ^18.2.0                                                     |
| Database          | MySQL                                                             |


## Apêndice

How to implement:

- Edit the database connection in `NutcacheTest.Common > Config > Config.cs` and point to a MySQL Server;
- The application follows the Code First Standard, so it's not necessary create the database in server;
- Check if the server is running on port 7090;
- Open the `NutcacheTest.UI` and run the command `serve -s build` - note: if you don't have, please run the command `npm install -g serve`;

