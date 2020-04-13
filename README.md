# ParksApi

#### State and National Parks Service 04/12/2020

#### By Andrew Philott

## Description

An application that allows users to create, read, update, and delete parks throughout the United States. Users can filter parks by region, name, state, and/or if parks are state or national.

## Futher Exploration

Cors:
The method AddCors() allows for the configuration of cross origin resource sharing. AllowAnyOrigin() enables the MVC application (localhost:5001) to communicate with the API (localhost:4000). AllowAnyMethod() enables the user to perform all Http methods (GET, POST, PUT, DELETE) on the API. AllowAnyHeader means that the API is able to process all HTTP formatted requests.
JWT:
Generated a JWT token on the server side after authenticating a user so that the API wouldn't be susceptible to hackers trying to inject malicious information into the database for the user.

\*Note I have taken JWT authentication out at the moment because I'm unsure as to how I can save the session for MVC and add the token to all headers.

### Installation and Configuration:

- Download .NET application version 3.1
- Download MySql version 8.15
- Clone the repository on Github
- Open the terminal on your desktop
- \$git clone "insert your cloned URL here"
- Change directory to the ParksApi directory, within Parks.Solution
- \$dotnet restore
- \$dotnet ef migrations add Initial
- \$dotnet ef database update
- \$dotnet watch run
- Open seperate terminal
- Change directory to the ParksClient directory, within Parks.Solution
- \$dotnet restore
- \$dotnet watch run
- Call the api using Postman or by running the web application

<details>
  <summary>Click to expand!</summary>
MVC
| Route Name | URL Path | HTTP Method | Purpose |
| :--------- | :------- | :---------- | :------- |
| Index | / | GET | Homepage: displays welcome message & link to review parks |

| Index | /parks | GET | Displays list of all parks |

| Create | /parks/create | GET | Offers a form to create a park |

| Create | /parks | POST | Create a new park object |

| Details | /parks/:id | GET | Displays details of a specific park |

| Edit | /parks/edit/:id | GET | Displays details of a specific park |

| Search | /parks/search | Get | Offers filered list of parks |

| Remove | /parks/:id | POST | Deletes a specific park |

API
| HTTP Method | URL Path | Purpose |
| :--------- | :------- | :------- |

| GET | /parks | Retrieve all parks |

| GET | /parks/{id} | Retrieve a park by it's id |

| GET | /parks/{name} | Retrieve a list of parks by name |

| GET | /parks/{isNational} | Retrieve a list of parks by name |

| Create | /parks/create | Offers a form to create a park |

| Create | /parks | Create a new park object |

| Details | /parks/:id | Displays details of a specific park |

| Search | /parks/search | Offers filered list of parks |

| Remove | /parks/:id | Deletes a specific park |

</details>

## Known Bugs

No bugs

## Support and contact details

For feedback, questions and/or ideas, please email <andrewphilpott92@gmail.com>

## Technologies Used

- .NET Core
- C#
- ASP.NET Core MVC
- Entity Framework
- MySQL Workbench
- CSS
- HTML

### License

This software is licensed under the MIT license.

Copyright (c) 2020 **Andrew Philott**
