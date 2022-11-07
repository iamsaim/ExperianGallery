# Experian Gallery Technical Assesment

This solution is developed using .NET 6. 
Onion architecture is used to develop the system and the solution contains different layers which are following:

#### Starting from the inner most layer to the outer most


### Experian.Gallery.Application

This project contains Contants, Contracts, DTOs, exception handling and middlewares.

### Experian.Gallery.Infrastructure

This project contains API caller class, implementation of interfaces and extension methods for startup.cs class

### Experian.Gallery.WebApp

This project contains API controller with API versioning. and logs folder which saves all logs in a text file.

### Experian.Gallery.Test

This project contains unit testing for the code. MOQ is used for mocking the dependencies in the code.

#### Working logic

When you call the API to fetch data. It calls both Albums and photos API asynchronously and saves data in memory cache to cut off expensive api call. cache has some expiration time so it could refresh data. I have developed two APIs. One to retrive all data and other will get data based on user Id.

#### Demo Video

https://www.loom.com/share/e0c3ad9cce07415bbe0b025ae5c80beb

### If I had more time

If I had more time then I would have completed all the unit testing and I would have done caching using API headers.
