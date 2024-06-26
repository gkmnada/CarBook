# CarBook Project

## 📚 Introduction

Welcome to CarBook Project! This is an ASP.NET Core 8.0 API project designed with modern architecture and best practices in mind. This project utilizes the Onion Architecture to promote a clear separation of concerns and CQRS (Command Query Responsibility Segregation) to differentiate between read and write operations. Additionally, it incorporates MediatR for in-process messaging, SignalR for real-time communication, JWT (JSON Web Tokens) for secure authentication, and Fluent Validation for streamlined validation processes.


## 🛠️ Technologies Used
- ASP.NET Core 8.0: The latest framework for building high-performance APIs.
- Onion Architecture: Ensures a clean separation of concerns, making the codebase more maintainable.
- CQRS: Differentiates between read and write operations, enhancing scalability.
- MediatR: Simplifies in-process messaging for CQRS.
- SignalR: Enables real-time web functionality.
- JWT: Provides secure authentication mechanisms.
- Fluent Validation: Enhances validation with a fluent interface, making validation logic easy to write and maintain.


## 🚗 Project Purpose
The purpose of this project is to develop a car rental website where users can rent vehicles from a chosen location and time, and return them at another chosen location and time. Users can view details and features of the cars they want to rent and can choose to rent them on a daily, weekly, or monthly basis. The admin panel allows dynamic management of all data, including adding, updating, and deleting entries.


## 🔧 Project Structure
- Core: Contains domain entities, interfaces, and service contracts.
- Application: Implements CQRS, MediatR handlers, validation with Fluent Validation, and other application logic.
- Infrastructure: Contains the database context, entity configurations, and repository implementations.
- API: Contains controllers, middlewares, and SignalR hubs.


## 📡 Real-Time Communication
SignalR is used to enable real-time communication between the server and clients. This allows for instant updates and notifications, enhancing user experience.


## 🔒 Authentication
JWT (JSON Web Tokens) is implemented for secure authentication, ensuring that only authorized users can access the API.


## 🧹 Validation
Fluent Validation is used for validation of requests and business logic, providing a fluent and expressive way to define validation rules.


## ✨ Key Features
### User Functionality:

- Select pick-up and drop-off locations.
- Choose rental start and end times.
- View detailed information and features of available cars.
- Rent cars on a daily, weekly, or monthly basis.
- Real-time updates and notifications using SignalR.

### Admin Functionality:

- Dynamically add, update, and delete car data.
- Manage rental transactions and user information.


## 📄 License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.


## 🙏 Acknowledgements
Special thanks to the developers and contributors of the libraries and frameworks used in this project.


![1](https://github.com/gkmnada/CarBook/assets/102467855/3ba0128c-dc31-4120-8757-272846f399d2)

![2](https://github.com/gkmnada/CarBook/assets/102467855/a18588a6-4263-4198-8b77-55664eada57a)

![3](https://github.com/gkmnada/CarBook/assets/102467855/e2d411e5-32bd-473a-97a4-703550b990e8)

![4](https://github.com/gkmnada/CarBook/assets/102467855/e92af7ce-84cb-46f2-8c28-4b9c13d15159)

![5](https://github.com/gkmnada/CarBook/assets/102467855/ad036bb9-ffde-4d4d-bfdc-08bfa9a798ba)

![6](https://github.com/gkmnada/CarBook/assets/102467855/67500745-74d6-41d8-beb2-56ef5d3ddb3f)

![7](https://github.com/gkmnada/CarBook/assets/102467855/4acf2ca8-68f0-4348-95ff-80f03b2b91b0)

![8](https://github.com/gkmnada/CarBook/assets/102467855/38d750e2-606c-4f46-84ed-bbf0348bf336)

![9](https://github.com/gkmnada/CarBook/assets/102467855/d70c2616-a0d2-4a33-b884-0c0fcc3d3a8a)

![10](https://github.com/gkmnada/CarBook/assets/102467855/4d070489-f885-402f-9967-95f737453536)

![11](https://github.com/gkmnada/CarBook/assets/102467855/a25d1b78-3fbd-4783-986f-4cfecce8fe98)

![12](https://github.com/gkmnada/CarBook/assets/102467855/0a8caadf-c34e-424d-a342-3f8ebb10c1f1)

![13](https://github.com/gkmnada/CarBook/assets/102467855/66778bee-1053-4bd2-b7dc-16f8a41e45a1)

![14](https://github.com/gkmnada/CarBook/assets/102467855/e269bfbd-3dc4-4200-a96d-d7901b01f344)

![15](https://github.com/gkmnada/CarBook/assets/102467855/a60977c6-d01c-4b63-b40e-784f93e86ec8)

![16](https://github.com/gkmnada/CarBook/assets/102467855/980933c1-01d1-45f5-b710-6dcf55274871)

