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

<h2 id="colab">🤝 Collaborators</h2>

Special thank you for all people that contributed for this project.

<table>
  <tr>
    <td align="center">
      <a href="#">
        <img src="https://avatars.githubusercontent.com/u/61896274?v=4" width="100px;" alt="Fernanda Kipper Profile Picture"/><br>
        <sub>
          <b>Fernanda Kipper</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="#">
        <img src="https://t.ctcdn.com.br/n7eZ74KAcU3iYwnQ89-ul9txVxc=/400x400/smart/filters:format(webp)/i490769.jpeg" width="100px;" alt="Elon Musk Picture"/><br>
        <sub>
          <b>Elon Musk</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="#">
        <img src="https://miro.medium.com/max/360/0*1SkS3mSorArvY9kS.jpg" width="100px;" alt="Foto do Steve Jobs"/><br>
        <sub>
          <b>Steve Jobs</b>
        </sub>
      </a>
    </td>
  </tr>
</table>

<h2 id="contribute">📫 Contribute</h2>

Here you will explain how other developers can contribute to your project. For example, explaining how can create their branches, which patterns to follow and how to open an pull request

1. `git clone https://github.com/Fernanda-Kipper/text-editor.git`
2. `git checkout -b feature/NAME`
3. Follow commit patterns
4. Open a Pull Request explaining the problem solved or feature made, if exists, append screenshot of visual modifications and wait for the review!

<h3>Documentations that might help</h3>

[📝 How to create a Pull Request](https://www.atlassian.com/br/git/tutorials/making-a-pull-request)

[💾 Commit pattern](https://gist.github.com/joshbuchea/6f47e86d2510bce28f8e7f42ae84c716)
