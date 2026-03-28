<h1 align="center" style="font-weight: bold;">Callisto Tickets 💻</h1>

<p align="center">
 <a href="#tech">Technologies</a> • 
 <a href="#started">Getting Started</a> • 
  <a href="#routes">API Endpoints</a> •
</p>

<p align="center">
    <b>This project is a ticket management API that allows users to create, track, and manage support requests within an organization. It includes features like user authentication, ticket assignment, status updates, and filtering by priority, team, and technician, helping streamline internal support workflows.</b>
</p>

<h2 id="technologies">💻 Technologies</h2>

- C#
- .NET
- ASP.NET
- REST API
- SQL Server
- Swagger
- Docker
- Entity Framework
- JWT Authentication

<h2 id="routes">📍 API Endpoints</h2>

Here you can list the main routes of your API, and what are their expected request bodies.
​
| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /user/{id}</kbd>     | retrieves user info see [response details](#get-auth-detail)
| <kbd>POST /login</kbd>     | authenticate user into the api see [request details](#post-auth-detail)

<h3 id="get-auth-detail">GET /user/{id}</h3>

**RESPONSE**
```json
{
  "id": 13,
  "companyId": 5,
  "company": {
    "id": 5,
    "name": "Callisto",
    "cnpj": "12345678000195",
    "email": "callisto@gmail.com",
    "phone": "32991234567",
    "address": "Além Paraíba",
    "createdAt": "2026-03-27T18:17:29.9448338"
  },
  "teamId": 5,
  "team": {
    "id": 5,
    "name": "Desenvolvimento",
    "isActive": true,
    "createdAt": "2026-03-27T18:26:30.5220691"
  },
  "name": {
    "firstName": "Ismael",
    "lastName": "Gabri",
    "notifications": {}
  },
  "email": {
    "address": "ismaelgabri.developer@gmail.com",
    "notifications": {}
  },
  "phone": {
    "cellPhone": "32991273641"
  },
  "passwordHash": "AQAAAAIAAYagAAAAEBHI4f1aDIYzpEoKKqrHWHnZHXx63Ftn6ZHK+Bq6uK2qHmu82Ru27oocs18vSuuiBw==",
  "profileImage": "data:image/jpeg;base64,/9j/4AAQSkZ",
  "role": 0,
  "entryDate": "0001-01-01T00:00:00",
  "updateDate": "2026-03-27T21:23:51.43",
  "lastLogin": null,
  "tickets": [],
  "notifications": null
}
```

<h3 id="post-auth-detail">POST /login</h3>

**REQUEST**
```json
{
  "username": "ismaelgabri.developer@gmail.com",
  "password": "ItWorksOnMyMachine12"
}
```

**RESPONSE**
```json
{
  "token": "OwoMRHsaQwyAgVoc3OXmL1JhMVUYXGGBbCTK0GBgiYitwQwjf0gVoBmkbuyy0pSi"
}
```
