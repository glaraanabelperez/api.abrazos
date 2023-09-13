### Abrazos App web Api

This is the web app for ...  

### Technologies and structure

The app utilizes 
.Net, Entity Framework on the backend and Sql server. 

It follows a common folder structure:
```
project-root/
  ├── api/
  │   ├── Models
  │   ├── Persistence
  │       ├── Persisstence.DataBase
  │           ├── Configurationes
  │           ├── DbContext.cs
  │   ├── Api.Abrazos
  │       ├── Controllers
  │       ├── AppSettings.json
  │       ├── Program.cs
  │       ├── AbrazosApi.cs

```

<!-- DER  -->

#### API

<!-- TODO: what is an API? -->

The api folder contains all the backend-related code and configurations. Here's a breakdown of its contents:

- Controllers: It holds the controller files contains the endpoints to the application. Each controller corresponds to a specific models
 and to conect to especify service.
- Persistence contains the conexion to databse and the persistence to the data in database using EntityFramwork.
- Models contains data in the form of domain-specific objects and properties for persistence and the DTO to transport the data betwen process.


### Users

Users with dancer permissions, can create your profile and sign up for classes and find a dance partner and
manage registrations and in some cases enable them.
Users with event creator permissions, can create events such as milongas classes, seminars and meetings.

### Events

Show the list available events


### Prerequisites

.net 6.0
Sql Server

### Start the database

In the repository there is the database script to be executed.
 

## Development team

- Silvina Varela: FullStack Developer, Project Manager, and Team Leader. Key roles: 
    - Backend development: Responsible for implementing the server-side functionalities, designing and setting up the API and the database.
    - Prototype design: utilized Figma to design the project's prototype.
    - Configuration of the React app: responsible for setting up the project structure, and managing the overall frontend architecture.
    - Frontend development: primarily focused on developing the Platform Creation Form (which enables users to effortlessly create new platforms) and the Workspace Preview and Editor (which implements the d3.js library in order to provide the user with a visual representation of the workspace, allowing them to interactively manipulate platforms, insert and empty content, visualize the robot's position, and send requests to the robot controller).
    - Project Management and Team Leadership: Additionally, assumed the role of Project Manager and Team Leader, overseeing the project's progress, coordinating tasks and deadlines, and providing support to the development team.

- Lara Garcia: FullStack Developer: 
    -  Desarrollo en (C#, JAVA)
    -  Framworks: .Net, Angular
    -  BBDD: Sql Server, ORM EntityFramwork.
    -  Nociones general: Oracle,  Postgress, Nodjs (MongoDB, ODM Mongoose), PHP (Laravel, ORM Eloquent).
    -  Backend development: Epidata Grupo Cepas (Desarrollo Microservicios implementando CQRS, MediaTR... ), BCRA, Informatica Solutions, Woopi (Microservicio, implementando IRepository)
