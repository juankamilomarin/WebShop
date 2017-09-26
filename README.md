# WebShop

MVC application that has two data storage mechanisms: database (persistent) and memory

## Design and Implementation considerations

<b>Assumptions</b><br/>
I made some assumptions to keep things simple:

1. No security was implemented
2. The only template used in the project was the one provided by Visual Studio for MVC applications. Once used, I deleted some files and updated the rest according to the project needs
3. Although the idea is to show how the application is able to switch its data storage in real time, I didn't consider a mechanism to synchronize both of them. This would be part of future improvements.
4. When showing the products, I decided to list all the existent on the current storage mechanism. The option of filtering should be implemented as an improvement.

<br/><b>Dependency Injection</b><br/>
Ninject package was used for handling dependency injection. RegisterServices method was updated in NinjectWebCommon.cs class

<br/><b>Data access technology choice</b><br/>
I decided to use ADO.NET instead of EntityFramework on behalf of performance (although this could be argued by some of my peers). I used store procedures from the data base to get and update the data

<br/><b>Use of both controllers: MVC and Web API</b><br/>
There are three MVC controllers:
* Home: controller that routes to the home view
* Admin: controller that routes to admin view
* Product: controller that handles the creation of a new product an the listing of all the products

There are one Web API controller:
* Storage: this admin controller provides methods to set and switch the data storage mechanism, in real time.

<br/><b>Use of MemoryCache to store products and data storage type</b><br/>
I used MemoryCache class to store the products on memory and also the data storage type. No policy expiration was implemented (this should be analyzed with the business in a real scenario)

<br/><b>Project structure</b><br/>
The solution was diveded in different projects as follows:
* WebShop: MVC Web application containing controllores and views (this was the only project create from a template)
* WebShop.DataAccess: Contains the classes for accessing the data. Here you may find the repositories for both data storage mechanisms
* WebShop.Models: Contains the models used in the application
* WebShop.Services: Contains the services used in the applicaton. Here you may find the service that defines which specific repository to use depending on the current data storage mechanism
* WebShop.Test: Contains unit and integration tests for the rest of the projects. There are a couple of unit tests implemented and an integration test.
* WebShop.Utilities: Contains class utilities and extensions methods used in the application. Here you may find the extension method created for MemoryCache class to retrieve all the objects of type T.

## File/folder structure

1. Source: Visual Studio solution with all its resources
2. WebShopDb.sql: database creation sql
3. WebShopDb_Diagram.png: database schema diagram

## Installation

1. Download
2. Install the database using WebShopDb.sql file
3. Open the project on Visual Studio (2015+)
3. Run the application

## Contributor

Juan Camilo Marin
