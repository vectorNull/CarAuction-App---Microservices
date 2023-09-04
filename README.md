# CarAuction App - Microservices

## Tech Used

- .Net 7
- Entity Framework Core
- RabbitMQ with Mass Transit package
- IdentityServer (OpendID Connect and OAuth 2.0 standards)

![Microservices - CarAuction](https://github.com/vectorNull/CarAuction-App---Microservices/assets/50179896/1150f59e-eb46-4d24-9eb9-64820dca6203)

### ![RabbitMQ](https://www.rabbitmq.com/) Fanout Pattern

![rabbitMq](https://github.com/vectorNull/CarAuction-App---Microservices/assets/50179896/e5125992-69b0-4c5b-a643-ad006c13b79f)

## Why ![Mass Transit](https://masstransit.io/)?

- Message routing
- Exception Handling
- Dependency Injection
- Open Telemetry (OTEL) for activity tracking
- Test Harnessing

It also gives us some abrstraction in case we would like to switch to a different transport or service bus in the future, such as Azure Bus Service or Amazon SQS, without much hassle.

## ![Identity Server](https://duendesoftware.com/products/identityserver)

- Created IdentityServer project that is a standalone server
- Uses the OpendID Connect and OAuth 2.0 standards

![OAuth 2 0 Workflow](https://github.com/vectorNull/CarAuction-App---Microservices/assets/50179896/d6c8b877-60f2-40db-bed8-95c478c01f69)

In a production environment, I would probably use something like AWS Cognito. I am only adding authentication to the auction service which allows users to create a new auction. Anonymous access will be allowed for other services.
