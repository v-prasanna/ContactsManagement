# ContactsManagement
An ASP.NET Web API designed for maintaining contact information.

The ASP.NET Web API was created using Visual Studio 2017. There are 2 projects in the "ContactsManagement" solution:
1) ContactsManagement - This project contains the Controllers and exposes the Web API end points.
2) ContactsDBDataAccess - This project forms the data access backend layer. It interacts with the API through an ADO.NET Entity Data Model and Entity Framework.

The Web API is hosted in Microsoft Azure App Service. The Web API interacts with an SQL Azure database in the cloud.

ContactsManagement Project Folder Structure:
- App_Start/WebApiConfig.cs : Contains the route and authentication filter.
- App_Start/UnityConfig.cs : Dependency Injection has been implemented using Unity and the injectable classes are registered here.
- Controllers : Contains the Controllers.
- Security : Has a couple of classes that implements 'Basic Authentication' for the Web API.

ContactsDBDataAccess Project Folder Structure:
- Interfaces : This folder has the interfaces for the repository.
- Repositories : This folder contains the concrete implementation of the repository interfaces. There is a generic repository class called EntityBaseRepository which can be inherited and its functionality can be extended.
- ContactsDataModel.edmx - Has the entity data model.
- ContactsDataModel.Context.cs : Has the Database context class.
- ContactsDataModel.tt : The models can be found when you expand this node in the solution tree.

Dependency Injection:
-----------------------
Implemented using Unity.

Data Validation:
-----------------
I have implemented data validation in the models. The API will return ModelState with validation errors if the data passed to the Web API is invalid.

Error Handling:
----------------
The Web API returns appropriate HTTP Status codes whenever there are errors in the API.


Testing the Web API:
--------------------
You can make the following calls listed below to test the API. Please note: I have implemented Basic Authentication in the API. 
So, you will need to pass 'Authorization: Basic Y211c2VyOmV2b2xlbnQ=' in the header of the HTTP requests, otherwise the API will return 401 Unauthorized error. 
The parameter contains a username and password combination which is Base 64 encoded.

1) GET All Contacts Request:
-----------------------------
http://contactsmanagement.azurewebsites.net/api/Contacts
User-Agent: Fiddler
Host: contactsmanagement.azurewebsites.net
Accept: text/json
Authorization: Basic Y211c2VyOmV2b2xlbnQ=

2) GET Specific Contact Request (with ID=5):
--------------------------------------------
http://contactsmanagement.azurewebsites.net/api/Contacts/5

Request Header:
------------------
User-Agent: Fiddler
Host: contactsmanagement.azurewebsites.net
Accept: text/json
Authorization: Basic Y211c2VyOmV2b2xlbnQ=
------------------------------------------------------------------------------------------------------------------------


3) POST (To add a Contact):
----------------------------
http://contactsmanagement.azurewebsites.net/api/Contacts

Request Header:
------------------
User-Agent: Fiddler
Host: contactsmanagement.azurewebsites.net
Accept: text/json
Content-Type: text/json
Authorization: Basic Y211c2VyOmV2b2xlbnQ=

Request body:
------------------
{"FirstName":"Drake","LastName":"Powell","Email":"drake32@yahoo.com","PhoneNumber":"456-885-9989","Status":"Active"}
------------------------------------------------------------------------------------------------------------------------------------


4) PUT (To edit a contact/Inactivate a contact with ID=8):
------------------------------------------------------------
http://contactsmanagement.azurewebsites.net/api/Contacts/8

Request Header:
------------------
User-Agent: Fiddler
Host: contactsmanagement.azurewebsites.net
Accept: text/json
Content-Type: text/json
Authorization: Basic Y211c2VyOmV2b2xlbnQ=
Content-Length: 133

Request body:
------------------
{"ContactID":"8","FirstName":"Gary","LastName":"Cohen","Email":"gcohen@yahoo.com","PhoneNumber":"476-877-9989","Status":"Inactive"}
-------------------------------------------------------------------------------------------------------------------------------------------

5) DELETE (To delete a contact with ID=6):
-------------------------------------------
http://contactsmanagement.azurewebsites.net/api/Contacts/6

Request Header:
------------------
User-Agent: Fiddler
Host: contactsmanagement.azurewebsites.net
Accept: text/json
Authorization: Basic Y211c2VyOmV2b2xlbnQ=




Testing Failure Criteria:
-------------------------
1) Datamodel validation. This request returns a ModelState object with a summary of all the validation errors:
----------------------------------------------------------------------------------------------------------------
POST
-----
Request Header:
---------------
http://contactsmanagement.azurewebsites.net/api/Contacts
User-Agent: Fiddler 
Host: contactsmanagement.azurewebsites.net
Accept: text/json 
Content-Type: text/json 
Authorization: Basic Y211c2VyOmV2b2xlbnQ=
Content-Length: 104

Request Body:
-------------
{"FirstName":"","LastName":"P","Email":"drake#yahoo.com","PhoneNumber":"456-abc-9989","Status":"Active"}

2) Authentication Credentials not passed in request header
------------------------------------------------------------
DELETE:
Request Header:
http://contactsmanagement.azurewebsites.net/api/Contacts/100

Request Body:
User-Agent: Fiddler 
Host: contactsmanagement.azurewebsites.net
Accept: text/json

3) Resource not found (Attempting to delete a resourse that does not exist):
-----------------------------------------------------------------------------
DELETE:
-------
Request Header:
----------------
http://contactsmanagement.azurewebsites.net/api/Contacts/100
User-Agent: Fiddler 
Host: contactsmanagement.azurewebsites.net
Accept: text/json
Authorization: Basic Y211c2VyOmV2b2xlbnQ=
