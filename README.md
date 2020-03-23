# Example microservice template for the POC

## Features

- DDD with clean architecture
- Repository and Unit of work patter using entity framework [ EFcore with in memory DB ]
- CQS using mediator pattern [ Mediatr ]
	- Queries: Return a result and do not change the observable state of the system (are free of side effects).
	- Commands: Change the state of a system but do not return a value. [ there some exeptions to the return value rule. ]
- Domain event support [ Mediatr ]
- Automatic mapping between layers [ Automapper]
- Swagger support

## TODO
- Implement example worker
- Improve docker support
- Add examples with dapper and/or dbcontext instead of using the repository
- Add request validations with fluent validator
- Add migration runner
- Add support to integration events
- Add Healthcheks
- Add Jwt Auth
- Add Exception handler