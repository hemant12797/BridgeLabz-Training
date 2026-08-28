# Backend Refresher Training — BridgeLabz

## Day 1 | DB Programming

### 💡 Topics Covered
* **DBMS vs. RDBMS:** Relational vs. Non-Relational databases and when to use each.
* **Tools:** MS SQL Server & T-SQL introduction.
* **RDBMS Fundamentals:** Core concepts of database structure and management.

### 🛠️ Tasks Completed
* **Setup:** Configured MS SQL Server environment.
* **Design:** Sketched ER Diagram for Health Clinic App (*Patients, Doctors, Appointments*).
* **Code:** Wrote and pushed schema creation SQL scripts.
  
  

  # Day 2 | DB Programming & Indexing

## 📌 Progress Overview
* **Day 2**  **Topic:** Advanced RDBMS & Query Optimization | **Status:** ✅ Done

---

### 💡 Topics Covered
* **Database Concepts:** Entities, Attributes, Relationships, Cardinality, and Keys.
* **Indexes:** Clustered, Non-Clustered, Unique, and Composite Indexes.
* **Database Normalization:** 1NF, 2NF, 3NF, and BCNF principles.

### 🛠️ Tasks Completed
1. **Schema Extension:** Added a `rooms` table and created a `doctor_room` relationship to map doctor room assignments.
2. **Query Performance Analysis:** Executed on 3 `appointments` queries (No Index, Single-Column Index, Composite Index) and analyzed `type` and `rows` metrics.
3. **Normalization Audit:** Verified `patient_phones` against 1NF, 2NF, and 3NF with written justifications for each step.
4. **Covering Index Optimization:** Created a covering index for `doctor_id`, `appointment_date`, and `status`, verifying index usage (`Using index` in `Extra`) via `EXPLAIN`.


# Day 3 | DB Programming – Joins, Stored Procedures & Triggers

## 📌 Progress Overview


* **Day 3** **Topic:** SQL Joins, Stored Procedures & Database Triggers | **Status:** ✅ Done

---

### 💡 Topics Covered

* **SQL Joins:** Inner Join, Left Join, Right Join, and Full Outer Join.
* **Stored Procedures:** Creating and executing parameterized stored procedures for database operations.
* **Database Triggers:** Understanding DML triggers (`INSERT`, `UPDATE`, `DELETE`) and their role in automating database actions.
* **Audit Logging:** Tracking data modifications using audit tables and triggers.

### 🛠️ Tasks Completed

1. **Joins Practice:** Implemented Joins queries on the Health Clinic database.
2. **Stored Procedures:** Created stored procedures for managing `Patients`, `Doctors`, `Appointments`, `Billing`, and `VisitHistory` records.
3. **Audit Log:** Designed and created an `AuditLog` table to record changes made to critical tables.
4. **Triggers:** Implemented `INSERT`, `UPDATE`, and `DELETE` triggers for the `Patients`, `Doctors`, and `Appointments` tables to automatically log changes into the `AuditLog` table.

# Day 4 | ADO.NET & Health Clinic App Completion

## 📌 Progress Overview

* **Day 4** **Topic:** ADO.NET & Health Clinic App Completion | **Status:** ✅ Done

---

### 💡 Topics Covered

* **ADO.NET Basics:** Connected and Disconnected Architecture.
* **SQL Server Connectivity:** Connecting a .NET application with MS SQL Server using ADO.NET.
* **CRUD Operations:** Performing Create, Read, Update, and Delete operations using `SqlConnection`, `SqlCommand`, `SqlDataReader`, and `SqlDataAdapter`.
* **Database Integration:** Integrating the finalized Health Clinic database with the console application.

### 🛠️ Tasks Completed

1. **Database Connectivity:** Connected the Health Clinic console application to MS SQL Server using ADO.NET.
2. **CRUD Implementation:** Implemented CRUD operations for Patients, Doctors, Appointments, Billing, and Visit History.
3. **ER Diagram Integration:** Mapped the finalized database schema with the application.

# Day 5 | Backend Basics – ASP.NET Core, WebAPI & RESTful Services

## 📌 Progress Overview

* **Day 5** **Topic:** ASP.NET Core, WebAPI & RESTful Services | **Status:** ✅ Done

---

### 💡 Topics Covered

* **ASP.NET Core:** Introduction to the ASP.NET Core framework and its architecture.
* **Web API:** Understanding Web APIs and how they enable communication between client and server.
* **RESTful Services:** REST principles, HTTP methods (GET, POST, PUT, DELETE), status codes, and API design.
* **Project Structure:** Overview of an ASP.NET Core Web API project, controllers, routing, and middleware.

### 🛠️ Tasks Completed

1. **Environment Setup:** Configured the ASP.NET Core development environment.
2. **Web API Project:** Scaffolded a basic ASP.NET Core Web API project.
3. **Controllers:** Created sample API controllers with RESTful endpoints.
4. **CRUD Endpoints:** Implemented basic CRUD operations using in-memory data.


# Day 6 | MVC Pattern & REST Request Handling

### 💡 Topics Covered

* MVC architecture: Model, View, and Controller.
* HTTP requests, responses, controllers, and routing.
* Basics of ASP.NET Core MVC.

### 🛠️ Tasks Completed

* Created a **Greeting App** using ASP.NET Core MVC.
* Implemented basic controllers, views, and routing.

---

# Day 7 | Minimal APIs

### 💡 Topics Covered

* Minimal APIs in ASP.NET Core.
* RESTful endpoints and HTTP methods.
* Request and response handling.

### 🛠️ Tasks Completed

* Created a **Contacts App backend** using Minimal APIs.
* Implemented basic CRUD endpoints.

---

# Day 8 | Swagger & API Testing

### 💡 Topics Covered

* Swagger / OpenAPI documentation.
* API endpoint testing and response handling.
* Introduction to distributed architecture.

### 🛠️ Tasks Completed

* Integrated **Swagger** into the Contacts App.
* Tested and documented API endpoints using Swagger UI.

---

# Day 9 | Entity Framework Core

### 💡 Topics Covered

* ORM and Entity Framework Core.
* Entities, `DbContext`, and database operations.
* Dependency Injection in ASP.NET Core.

### 🛠️ Tasks Completed

* Converted the **Contacts App** to use Entity Framework Core.
* Implemented database-based CRUD operations.

---

# Day 10 | Entity Framework & N-Tier Architecture

### 💡 Topics Covered

* LINQ to Entities.
* Entity Framework Core with REST APIs.
* N-Tier / layered architecture.

### 🛠️ Tasks Completed

* Created **AddressBookWebApp** using Entity Framework Core.
* Implemented the application using **N-Tier Architecture**.
* Used LINQ for database querying and CRUD operations
* 
* 
# Day 11 | Entity Framework – Migrations & DbContext

### 💡 Topics Covered

* EF Core Migrations and database schema evolution.
* `DbContext` configuration and lifecycle.
* Database-first/code-first workflow with Entity Framework.

### 🛠️ Tasks Completed

* Used **EF Core Migrations** for database schema management.
* Configured `DbContext` for the Address Book applications.
* Completed backend database integration using EF Core.

---

# Day 12 | Advanced Backend Development – WebAPI REST Verbs & HttpClient

### 💡 Topics Covered

* REST verbs: GET, POST, PUT, PATCH, and DELETE.
* Action methods in ASP.NET Core Controllers.

### 🛠️ Tasks Completed

* Started the **Fundoo Notes App** backend.
* Implemented the **User Management Module**.
* Added user registration and login

---

# Day 13 | Advanced Backend Development – DI, Routing, Reverse Proxy & CORS

### 💡 Topics Covered

* Dependency Injection in ASP.NET Core.
* Routing configuration and Reverse Proxy concepts.
* CORS (Cross-Origin Resource Sharing).

### 🛠️ Tasks Completed

* Implemented the foundation of **Authentication & Authorization** in the Fundoo Notes App.
* Configured dependency injection and routing.
* Worked with CORS for API access.

---

# Day 14 | Advanced Backend Development – JWT Authentication & Authorization

### 💡 Topics Covered

* JWT-based authentication.
* Authentication vs. Authorization.
* Request/Response handling.

### 🛠️ Tasks Completed

* Completed **Authentication & Authorization** for the Fundoo Notes App.
* Implemented JWT-based user authentication.
* Added the **Notes Management Module** with create,update,get and delete operations.

---

# Day 15 | Advanced Backend Development – EF Core, CQRS & LINQ

### 💡 Topics Covered

* Advanced Entity Framework Core patterns..
* Advanced LINQ queries.

### 🛠️ Tasks Completed

* Implemented **Pin, Archive, and Trash** functionality in Fundoo Notes.
* Added **Search and Filter** functionality.
* Used LINQ for advanced data querying.

---

# Day 16 | Advanced Backend Development – Pub/Sub, Testing, Logging & API Docs

### 💡 Topics Covered

* Publish-Subscribe pattern for event-driven communication.
* Unit testing using MSTest.
* Logging with NLog.
* API testing with Postman and documentation with Swagger.

### 🛠️ Tasks Completed

* Added **Tags / Labels Management** to Fundoo Notes.
* Created unit tests using **MSTest**.
* Added API documentation using **Swagger**.
* Implemented logging for backend operations.

---

# Day 17 | Advanced Backend Development – Identity, Filters & Session Management

### 💡 Topics Covered

* Web API filters.
* StyleCop for code quality and consistency.
* Session management.
* Asynchronous processing using RabbitMQ.

### 🛠️ Tasks Completed

* Implemented the **Reminder & Notification Module** in Fundoo Notes.
* Used **RabbitMQ** for asynchronous background processing.


---

# Day 18 | Advanced Backend Development – REST API Security & Caching

### 💡 Topics Covered

* REST API security principles.
* Encryption, decryption, and hashing.
* Redis caching.
* Token caching and performance optimization.

### 🛠️ Tasks Completed

* Implemented **caching using Redis**.
* Improved API performance using caching.
* Consolidated and completed the **Fundoo Notes App backend**.
  
# Day 19 | Microservices – Monolith vs Microservices & .NET Microservices Fundamentals

### 💡 Topics Covered

* Monolithic vs. Microservices architecture and their trade-offs.
* .NET Microservices structure and service-to-service communication.
* Basics of designing independent microservices.

### 🛠️ Tasks Completed

* Started decomposing the **Fundoo Notes App** into microservices.
* Created separate **User Management** service.
* Explored communication between microservices.

---

# Day 20 | Microservices – Architecture & Cloud-Native .NET Apps

### 💡 Topics Covered

* Microservices architecture patterns.
* Cloud-native .NET application concepts.
* Deployment and scalability considerations for microservices.

### 🛠️ Tasks Completed

* Completed the **Fundoo Notes microservices**.
* Implemented separate services for **User Management(Authentication & Authorization) Notes Management( Search & Filter), Tags / Labels (Reminder & Notification)**.
* Integrated communication between the services.
* Completed the final demo of the **microservices-based Fundoo Notes application**.
