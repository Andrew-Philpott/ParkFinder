# ParksApi

#### State and National Parks Service 04/03/2020

#### By Andrew Philott

## Description

An API that allows users to GET and POST reviews about various state and national parks

## Specs

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
| Route Name | URL Path | HTTP Method | Purpose |
| :--------- | :------- | :---------- | :------- |
| Index | / | GET | Homepage: displays welcome message & link to review parks |

| Index | /parks | GET | Displays list of all parks |

| Create | /parks/create | GET | Offers a form to create a park |

| Create | /parks | POST | Create a new park object |

| Details | /parks/:id | GET | Displays details of a specific park |

| Search | /parks/search | Get | Offers filered list of parks |

| Remove | /parks/:id | POST | Deletes a specific park |

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
