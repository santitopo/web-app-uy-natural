Project done using 
- Angular (Front end)
- .NET core and Entity Framework (REST Api as Back end)
- SQL (Microsoft SQL Server)

### Relevant observations and patterns implemented

💡 Reflection pattern used to dynamically load (in execution time) file parsers that would allow the importation of batch files with touristic points and hotels.  <br />
💡 Dependency injection in the BE services and logic interfaces. This allowed us to reduce dependencies and favor mocking during automatic testing.<br />
💡 Repository pattern applied to allow inheritance of common operations for the Repository classes<br />
💡 Strategy pattern applied to abstract the price calculation logic for the reservations, making it easier to modify for new implementations.<br />
💡 GRASP and SOLID Principles applied. Read more about in the documentation<br />


### Preview of FE structure
<img width="822" alt="image" src="https://github.com/santitopo/web-app-uy-natural/assets/43559181/b226e202-ad04-4b1f-9569-7113c40848eb">

Submitted during the course Algorithms and Data Structures 2.
