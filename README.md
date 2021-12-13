# Semesterprojekt 3. Semester - NordkraftPMS
This repository has been developed in cooperation with
[Nordkraft](https://nordkraft.dk/forside.aspx).

<div id="top"></div>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/MadsBalslev/P3">
    <img src="./frontend/wwwroot/favicon_nordkraft.ico" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">NordkraftPMS</h3>

  <p align="center">
    The goal of this webapplication was to create a system for Nordkraft, to manage, upload, display and schedule different posters.
To ensure the different institutions do not interfere with each other, a user- and institution system has been implemented.
Therefore an authentication system is also in place.
    <br />
    <a href="https://github.com/MadsBalslev/P3"><strong>Explore the docs »</strong></a>
    <br />
    <br />
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

The goal of this webapplication was to create a system for Nordkraft, to manage, upload, display and schedule different posters.
To ensure the different institutions do not interfere with each other, a user- and institution system has been implemented.
Therefore an authentication system is also in place.

<p align="right">(<a href="#top">back to top</a>)</p>



### Built With

* [MariaDB 10.1.19](https://mariadb.org/mariadb-10-1-19-release-now-available/)
* [ASP.NET CORE 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites
The project is divided into a frontend and server folder. To install the neccesary packages `cd` into each folder and run:
```sh
dotnet restore
```



### Installation

1. Clone the repo:
   ```sh
   git clone https://github.com/MadsBalslev/P3.git
   ```
2. Install prequisites mentioned above.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage
Start by running the .sql file from `P3/database/db.sql` in MariaDB.
The default login is host:localhost, user:root and password:123.
(You can change these yourself later) and update them in  the connection string in `server/appsettings.json`.

After installing ALL the prequisites, open two(2) terminals, one in `P3/frontend` and the other in `P3/server`.
Proceed to write, in both terminals:
```sh
dotnet run
```

Now that the frontend and backend are up and running, you can go to localhost:8080 and login with the default sys-admin user, admin/admin.

You can now proceed to use the system.

#### Changing ports
The ports on which the server and frontend is run can be changed in each folders `properties/launchsettings.json`-file. 
This can also be changed to be `0.0.0.0:PORT` to open up for incomming requests not comming from the localhost.

For the frontend the `ApiBaseAddress` in `appsettings.json` to the IP and Port of the server.

The changes to the server PORT must also be applied to the `frontend/wwwroot/js/SlideGenerator.js`-file, which handles the API call to the server.

<p align="right">(<a href="#top">back to top</a>)</p>




<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTACT -->
## Contact
Project Link: [https://github.com/MadsBalslev/P3](https://github.com/MadsBalslev/P3)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments
### Guidance
* Christian Hove from [Nordkraft](https://nordkraft.dk/)
* [Florian Echtler](https://vbn.aau.dk/en/persons/149493)

### Development
* [Simon M. P. Andersen](https://github.com/uglenDX)
* [Nicolai Bruun Nielsen](https://github.com/Mightyhaha)
* [Casper Ståhl](https://github.com/CasperStaahl)
* [Patrick Bertelsen](https://github.com/pberte20)
* [Frederik Møller](https://github.com/Frederikmoeller)
* [Mads P. Balslev](https://github.com/MadsBalslev)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/MadsBalslev/P3.svg?style=for-the-badge
[contributors-url]: https://github.com/MadsBalslev/P3/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/MadsBalslev/P3.svg?style=for-the-badge
[forks-url]: https://github.com/MadsBalslev/P3/network/members
[stars-shield]: https://img.shields.io/github/stars/MadsBalslev/P3.svg?style=for-the-badge
[stars-url]: https://github.com/MadsBalslev/P3/stargazers
[issues-shield]: https://img.shields.io/github/issues/MadsBalslev/P3.svg?style=for-the-badge
[issues-url]: https://github.com/MadsBalslev/P3/issues
[license-shield]: https://img.shields.io/github/license/MadsBalslev/P3.svg?style=for-the-badge
[license-url]: https://github.com/MadsBalslev/P3/main/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/linkedin_username
[product-screenshot]: images/screenshot.png
