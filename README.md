# Welcome to EngageNet!
EngageNet is a dynamic networking platform designed to connect companies with individuals eager to volunteer for various events. Our mission is to bridge the gap between organizations seeking enthusiastic volunteers and individuals looking to engage in meaningful community initiatives.

### For Companies
On EngageNet, companies and organizations can register and easily post upcoming events where volunteers are needed. This platform serves as a powerful tool to manage your volunteer engagement, increase the visibility of your events, and actively participate in community building.

### For Volunteers
If you are someone looking to make a difference, EngageNet provides the perfect platform to find volunteering opportunities that align with your skills and interests. Our website facilitates connections with companies hosting events, helping you give back to the community, enhance your skills, and meet like-minded volunteers.

Our platform is inspired by the professional networking features of LinkedIn, adapted to focus specifically on volunteer opportunities and community engagement. Here, every connection and activity is a step toward community development and personal growth.

## Development Details
### Technologies Used
EngageNet is built using a combination of powerful technologies and frameworks to ensure a robust, scalable, and user-friendly experience. Here’s a breakdown of the core technologies used in our platform:

### Frontend
- **Angular:**  Our choice for the frontend framework is Angular, known for its ability to create dynamic single-page applications (SPAs). Angular's comprehensive ecosystem, including its dependency injection, routing, and template building capabilities, has enabled us to build a highly interactive and responsive interface for EngageNet.

### Backend
- **C# with ASP.NET:** The backend of EngageNet is developed using C# in conjunction with ASP.NET Core, which provides a scalable and efficient framework for building our server-side logic. This combination allows us to create a robust API that handles all backend operations, including data management and interaction with our PostgreSQL database.

### Database
- **PosrgreSQL:** We chose PostgreSQL for our relational database management system due to its advanced features, reliability, and strong performance with large datasets. PostgreSQL effectively supports our data persistence needs, ensuring data integrity and security.

### ORM
- **Entity Framework Core:** To interact with our database, we use Entity Framework Core, an object-relational mapper that allows us to work with our database using C# objects, eliminating the need for most of the data-access code. EF Core has streamlined our data handling processes, making CRUD operations seamless and efficient.
 
### Design Patterns and Architectural Choices
- **MediatR:** We have incorporated the MediatR library to implement the mediator design pattern, which helps in reducing the dependencies between our application's components. This pattern facilitates a clean separation of concerns and a more organized codebase by handling requests and responses via a single mediator object.
- **CQRS (Command Query Responsibility Segregation):** Our architecture utilizes the CQRS pattern to separate read and write operations, allowing for more scalable and maintainable code. This approach enhances performance and scalability by optimizing the data retrieval and update processes independently.
