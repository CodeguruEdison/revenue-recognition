Service Layer

How it Works

- Two kinds of "business logic":  domain logic and application logic
- Service Layer factors each kind into a separate layer
- Two implementation variations: domain facade, operation script
- Domain facade: thin facade over a Domain Model, no business logic in facade
- Operation script: thicker classes that implement application logic, but delegates domain logic to domain object classes
- Service Layer may be remotably invocable or not
- Remote invocation comes at extra cost (Data Transfer Objects), especially for complex Domain Model
- If remoting is needed, put Remote Facades og top of Service Layer
- Client needs dictates Service Layer operations
- Many operations will be CRUD, however, the implementation of these in Service Layer and Domain Model may not be trivial
- Small applications may need only one Service Layer
- Bigger applications may need a Service Layer per subsystem (vertical slice) or major partition of Domain Model

When to Use It

- There is more than one client of the business logic
- Complex responses in use cases involving multiple transactional resources
- Not needed with only one kind of client, e.g. user interface, and use case responses don't involve multiple transactional resources