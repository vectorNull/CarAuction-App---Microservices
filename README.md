# CarAuction App - Microservices

## Tech Used

- .Net 7
- Entity Framework Core
- RabbitMQ with Mass Transit package
- IdentityServer (OpendID Connect and OAuth 2.0 standards)

![Microservices - CarAuction](https://github.com/vectorNull/CarAuction-App---Microservices/assets/50179896/1150f59e-eb46-4d24-9eb9-64820dca6203)

### RabbitMQ Fanout Pattern

![rabbitMq](https://github.com/vectorNull/CarAuction-App---Microservices/assets/50179896/e5125992-69b0-4c5b-a643-ad006c13b79f)

## Why Mass Transit?

- Message routing
- Exception Handling
- Dependency Injection
- Open Telemetry (OTEL) for activity tracking
- Test Harnessing

It also gives us some abrstraction in case we would like to switch to a different transport or service bus in the future, such as Azure Bus Service or Amazon SQS, without much hassle.

## Identity Server

- Created IdentityServer project that is a standalone server
- Uses the OpendID Connect and OAuth 2.0 standards

In a production environment, I would probably use something like AWS Cognito.
