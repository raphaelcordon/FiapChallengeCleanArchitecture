# FIAP Challenge: Clean Architecture

## Table of Contents

- [Introduction](#introduction)
- [Application](#application)
- [Instructions](#instructions)
- [Structure](#structure)
- [Functionalities](#functionalities)

---

## **INTRODUCTION**

FIAP is a prestigious Brazilian college.<br>
At the time this project was created, I was pursuing their technical postgraduate course in<br>
**Azure Architecture with .Net**.

This is a challenge proposed during the CLEAN ARCHITECTURE module as below:

### Challenge
- You received contact from an NGO (Non-Governmental Organization) that works with food distribution to other NGOs, according to what they request. 
- The NGO receives donations in packages, with various foods inside, stores them and then delivers these donations in other packages.
- For example, the Non-Governmental Organization you are in contact with may:
  - Receive a package with 200 kg of rice, 100 kg of beans and 300 cans of oil, and;
  - Receives a request from another NGO asking for the donation of 30 kg of rice, 10 kg of beans and 15 cans of oil. 
  - To do this, delivery must be made with other packages, as different separation will be required.

### Proposal
Create an architecture and application that:

- Register the receipt of packages, as well as separately register the products received according to weight or units;
- Register donation requests, with the quantities of products requested;
- Validate whether it is possible to fulfill requests;
- Issue a complete list of orders placed;
- Issue a list of the current status of food stocks;
- Deliver an order, removing quantities from stock and registering the delivery.

### Guidelines

- Start thinking about solving just one of the business rules (use case), and improve the architecture design according to the other use cases. Don't solve all the problems at once;
- Solve the problem always thinking about simplicity and meeting the use case. Do not define more than necessary;
- Think about the solution before implementing it; use architecture to guide code implementation.

---

## **APPLICATION**

- Framework net7.0
- Database: SQLite

---

## **INSTRUCTIONS**

- This is a study project.
- Manually run "dotnet ef database update" to locally create the database file.
- Run both, the **Application** and the **Presentation** apps.
- Application layer has a Swagger available. Further instructions  --->&nbsp; **[H E R E](src/Application/README.md)** &nbsp;<---

---

## **STRUCTURE**

### src
>- **Application**
   >    - API Services
   >    - Dtos
   >    - API Controllers

>- **Domain**
   >    - Entities
   >    - Enums
   >    - Interfaces

>- **Infrastructure**
   >    - Database
   >    - Mappings
   >    - Migrations

>- **Presentation**
   >    - Controllers
   >    - Models
   >    - Views

### tests
>- **tbd**
---

## **FUNCTIONALITIES**

### CRUD Main Entities
>- **Donors**
>- **Receivers**
>- **Food**

### CRUD Packages
>- **Packages Received**
   >    - With Donor Id
   >    - With List of Food Ids
>- **Packages Sent**
   >    - With Received Id
   >    - With List of Food Ids

---

