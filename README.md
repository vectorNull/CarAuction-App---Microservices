# CarAuction App - Microservices

## Tech Used

- .Net 7
- Entity Framework Core
- RabbitMQ with Mass Transit package
- IdentityServer (OpendID Connect and OAuth 2.0 standards)
- React
- NextJS
- Flowbite React Component Library

![Microservices - CarAuction](https://github.com/vectorNull/CarAuction-App---Microservices/assets/50179896/1150f59e-eb46-4d24-9eb9-64820dca6203)

### ![RabbitMQ](https://www.rabbitmq.com/) Fanout Pattern

![rabbitMq](https://github.com/vectorNull/CarAuction-App---Microservices/assets/50179896/e5125992-69b0-4c5b-a643-ad006c13b79f)

## ![Mass Transit](https://masstransit.io/)

MassTransit is a powerful open-source distributed application framework for building distributed systems, event-driven microservices, and scalable messaging applications. It simplifies the development of robust and scalable message-based applications by providing a rich set of abstractions and tools for message routing, publishing, and consuming.

Key Features:

- Messaging Abstractions: MassTransit abstracts the complexities of messaging patterns, making it easy to send, receive, and process messages in your application. It supports publish-subscribe, request-response, and point-to-point messaging styles.

- Pluggable Transport: MassTransit is transport-agnostic, allowing you to choose the messaging transport that best suits your needs. It supports popular transports like RabbitMQ, Azure Service Bus, Amazon SQS, and more.

- Message Serialization: Seamlessly serialize and deserialize messages with built-in support for popular serialization formats, including JSON, XML, and custom formats.

- Middleware Pipeline: Extend and customize message processing with a flexible middleware pipeline. Add behaviors to handle cross-cutting concerns, logging, and error handling.

- Distributed Saga State Machines: Implement complex, long-running business processes with ease using MassTransit's built-in support for distributed sagas and state machines.

- Monitoring and Diagnostics: Gain insight into the health and performance of your messaging infrastructure with built-in diagnostics and monitoring tools.

Visit the ![MassTransit documentation](https://masstransit.io/documentation/concepts) for detailed guides, examples, and best practices on using MassTransit in your projects. For community support and discussions, join the MassTransit Google Group.

## ![Duende Identity Server](https://duendesoftware.com/products/identityserver)

Duende IdentityServer, formerly known as IdentityServer4, is a leading open-source identity and access management solution designed to secure modern applications and services. Developed by Duende Software, it offers a robust and highly customizable platform for implementing authentication, authorization, and Single Sign-On (SSO) capabilities within your applications. With Duende IdentityServer, you can efficiently manage user identities, protect your APIs, and ensure secure access control, all while adhering to industry standards.

![OAuth 2 0 Workflow](https://github.com/vectorNull/CarAuction-App---Microservices/assets/50179896/d6c8b877-60f2-40db-bed8-95c478c01f69)

Key Features:

- Identity and Access Management: Duende IdentityServer allows you to centralize user authentication and authorization, providing a unified solution for managing user identities, roles, and permissions.

- Open Standards: It fully supports industry standards like OAuth 2.0, OpenID Connect, and JWT, ensuring compatibility with a wide range of clients and services.

- Single Sign-On (SSO): Implement SSO effortlessly, enabling users to log in once and access multiple applications seamlessly, improving user experience and security.

- Customization: Duende IdentityServer is highly customizable, allowing you to tailor the authentication and authorization flows, UI, and behavior to match your specific application requirements.

- Multi-Factor Authentication (MFA): Enhance security with built-in support for multi-factor authentication, providing an extra layer of protection for your users.

- Scalability: Designed for high performance and scalability, Duende IdentityServer can handle authentication and authorization for large-scale applications and microservices.

- Logging and Monitoring: Gain insights into your identity and access management processes with comprehensive logging and monitoring features.

- Community and Support: Benefit from an active and supportive community, as well as professional support options from Duende Software for enterprise-grade deployments.

Duende IdentityServer is the ideal choice for organizations seeking a robust and extensible identity and access management solution. Whether you're building web applications, APIs, mobile apps, or microservices, Duende IdentityServer empowers you to implement secure and compliant authentication and authorization mechanisms with ease.

To get started with Duende IdentityServer and take control of your identity and access management needs, visit the official ![Duende IdentityServer website](https://duendesoftware.com/products/identityserver) for documentation, examples, and support resources. Elevate the security and user experience of your applications with Duende IdentityServer today.

In a production environment, I would probably use something like AWS Cognito. I am only adding authentication to the auction service which allows users to create a new auction. Anonymous access will be allowed for other services.

# What I did not cover in this project:
- Refresh tokens
- Forgot Password functionality
- Email confirmation
- Consent
- 2FA

I may come back and add that. However, my main focus was microservices architecture.

## ![YARP - Yet Another Reverse Proxy](https://microsoft.github.io/reverse-proxy/index.html)

YARP, short for "Yet Another Reverse Proxy," is a powerful and flexible open-source reverse proxy project developed by Microsoft. YARP is designed to simplify and enhance the management of HTTP and HTTP/2 traffic routing for your applications and services. Whether you're working with microservices, API gateways, or complex web applications, YARP provides a robust solution to efficiently handle incoming requests, distribute traffic, and manage authentication and security.

Key Features:

- Routing Control: YARP allows you to define custom routing rules, making it easy to direct traffic to the appropriate backend services based on URL patterns, headers, and other criteria.

- Load Balancing: It offers load balancing strategies to ensure even distribution of traffic among backend servers, improving application scalability and resilience.

- Middleware Pipeline: YARP supports a middleware pipeline, enabling you to inject custom logic and perform transformations on requests and responses.

- Security and Authentication: Easily implement authentication and authorization policies to safeguard your services, and leverage built-in security features to protect against common web vulnerabilities.

- High Performance: YARP is designed for high performance, minimizing latency and maximizing throughput to deliver responsive and reliable web services.

- Extensibility: Customize and extend YARP to meet your specific requirements through its modular architecture and extensible components.

YARP simplifies the complexity of managing reverse proxy functionality, making it an excellent choice for developers, DevOps teams, and system administrators looking to streamline and optimize their HTTP traffic routing. Whether you're building modern web applications, APIs, or microservices, Microsoft YARP is a versatile tool to enhance your infrastructure's performance, security, and flexibility.

Visit the official ![YARP GitHub repository](https://github.com/microsoft/reverse-proxy) for detailed documentation, examples, and community support. Get started with YARP today and take control of your reverse proxy needs with confidence.
