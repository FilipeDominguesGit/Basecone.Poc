# Example microservice template for the POC

## Features

- DDD with clean architecture
- Repository and Unit of work patter using entity framework [ EfCore with in memory DB/MySql ]
- CQS using mediator pattern [ EfCore + Mediatr ]
	- Queries: Return a result and do not change the observable state of the system (are free of side effects).
	- Commands: Change the state of a system but do not return a value. [There some exeptions to the return value rule.]
- Domain event support [ Mediatr ]
- Automatic mapping between layers [ Automapper]
- Swagger support [ Swashbuckle ]
- Logging [ Serilog ]
- Db Migrations support [ Basecone.Poc.Migrations or command line ]
- MySql Support

## TODO
- Implement example worker
- Improve docker support
- Add examples with dapper and/or dbcontext instead of using the repository
- Add request validations with fluent validator
- Add Integration event support
- Add Healthcheks
- Add Jwt Auth
- Add Exception handler

## Aditional information

https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html

https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/

https://airbrake.io/blog/software-design/domain-driven-design

https://martinfowler.com/bliki/CommandQuerySeparation.html

https://github.com/dotnet-architecture/eShopOnContainers/tree/dev/src/Services/Ordering
