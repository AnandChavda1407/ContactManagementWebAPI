Solution is build using Visual Studio 2017, SQL server 2012 and .Net Framework 4.6.1

Folder Structure:
Build    	- pre-compiled release package for the WebAPI. Can be deployed with change in connection string.
Source Code     - Contains source code including depending DLLs and test cases.

Source Code Structure -

ContactInfoManagement.DAL            -  Contains code related to DB opeations.
ContactInfoManagement.DAL.Test       -  Contains test cases.
ContactInfoManagement.Entities       -  Contains Entities and Interfaces.
ContactInfoManagement.WebAPI         -  Contains WebAPI opeations.

- WebAPI built with ASP.NET MVC WebAPI
- WebAPIs available for GET/POST/PUT/DELETE operations on Contacts.
- ORM framework(code first approach) implemented for ContactDetails.
- ContactInfoManagement.DAL is used to connect to DB(Please update the connectionstring)
- Repository pattern is used for the operations.
- Unit test cases available in ContactInfoManagement.DAL.Test project. Moq framework is used to mock the DB calls.
- Dependency injection implemented through constructor injection and IoC via Unity framework.

How to run the Application:
-There are two Ways.
	1. You can open the solution in visual studio and Press F5.The WebAPIs will be available to execute.
   	Please change the connection string in Web.Config and App.config of ContactInfoManagement.DAL.

	2.You can host the build in IIS and then Execute the WebAPIs.

Following are the APIs available in the solution:

Note: APIs expects Inputdata in JSON Format for the body parameters.

   1. GET API GetAllContacts will get all the contact information. [e.g http://localhost:PortNo/api/GetAllContacts]
   2. GET API GetContactById will get the contact information by Id. [e.g http://localhost:PortNo/api/GetContactById/{contactId}] 
   3. PUT API EditContact will be used to update contact information [e.g http://localhost:PortNo/api/EditContact/{contactid}]
      Provide contact details in the request body with updated values.
   4. PUT API ActiveInActiveContact will be used to active/inactive user.[e.g http://localhost:PortNo/api/ActiveInActiveContact/{contactid}/{status}]
      status value should be 0 to inactive user and 1 to active the user
   5. POST API AddNewContact will be used to add new contact in the database.[e.g http://localhost:PortNo/api/AddNewContact]
   6. DELETE API DeleteContact will be used to delete any contact from the database.[e.g http://localhost:PortNo/api/DeleteContact/5]