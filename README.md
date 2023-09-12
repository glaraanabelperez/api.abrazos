# Abrazos App web Api

This is the web app for ...  

## Technologies and structure

The app utilizes React.js, Redux and Material-UI on the frontend, and .Net, Entity Framework on the backend and Sql server. 
It follows a common folder structure, with a separation between the Web API and the client. 

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

    
  ├── client/
  │   ├── public/
  │   ├── src/
  │   │   ├── components/
  │   │   ├── pages/
  │   │   ├── redux/
  │   │   ├── utils/
  │   │   ├── App.jsx
  │   │   ├── main.css
  │   │   ├── main.jsx
  │   ├── index.html
  │   └── package.json
  ├── package.json
  └── README.md
```


<!-- DER  -->

#### API

<!-- TODO: what is an API? -->

The api folder contains all the backend-related code and configurations. Here's a breakdown of its contents:

- Controllers: It holds the controller files contains the endpoints to the application. Each controller corresponds to a specific models
 and to conect to especify service.
- Persistence contains the conexion to databse and the persistence to the data in database using EntityFramwork.
- Models contains data in the form of domain-specific objects and properties for persistence and the DTO to transport the data betwen process.
- utils: Helper functions used across different parts of the codebase.

#### CLIENT

<!-- TODO: what is a CLIENT? -->

The client folder contains the frontend codebase built using React, Redux, and MUI. Here's an overview of the folder structure:

- public: The public folder holds the static assets of the React application.
- src: The src folder is where the main source code resides. It includes:
   - components: Contains the reusable components. The components are organized based on their function, such as "Platforms," "Protocols," "Workspaces," "Buttons," and "NavBar." This organization helps to maintain a clear separation of concerns and allows for easier navigation and management of the components.
   - pages: Holds the components that represent individual pages or views of the application.
   - Redux: Contains the Redux configuration, as well as the actions and reducers.
   - utils: This folder contains helper or reusable functions used across the application.
   - App.jsx: This file sets the Routes for the frontend.
   - main.jsx: This file is the entry point for the React app. 
- index.html: This file serves as the entry point for the application and is the main HTML file that is loaded by the web browser.
- vite.config.js: This is the configuration file for the Vite development server and build process. 

## Main features

### Users

Users with dancer permissions, can create your profile and sign up for classes and find a dance partner and
manage registrations and in some cases enable them.
Users with event creator permissions, can create events such as milongas classes, seminars and meetings.

### Events

Show the list available events


### Prerequisites

BackEnd
FrontEnd

### 1. Clone the repo


### 2. Install all dependencies 


### 3. Start the database

In the repository there is the database script to be executed.
 

### 5. Start the app

## Development team

- Silvina Varela: FullStack Developer, Project Manager, and Team Leader. Key roles: 
    - Backend development: Responsible for implementing the server-side functionalities, designing and setting up the API and the database.
    - Prototype design: utilized Figma to design the project's prototype.
    - Configuration of the React app: responsible for setting up the project structure, and managing the overall frontend architecture.
    - Frontend development: primarily focused on developing the Platform Creation Form (which enables users to effortlessly create new platforms) and the Workspace Preview and Editor (which implements the d3.js library in order to provide the user with a visual representation of the workspace, allowing them to interactively manipulate platforms, insert and empty content, visualize the robot's position, and send requests to the robot controller).
    - Project Management and Team Leadership: Additionally, assumed the role of Project Manager and Team Leader, overseeing the project's progress, coordinating tasks and deadlines, and providing support to the development team.

- Lara Garcia: FullStack Developer: .Net, Angular, Sql Server, 
    
