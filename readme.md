# Hair Salon App

#### Web app that allows user add clients and stylists, as well as update and delete them, 12/9/2016

#### By Ryan Peterson

## Description

This web app allows the user to add clients and stylists to a database.  The user can also update client/stylist info, as well as delete them from the database.

## Setup/Installation Requirements

* Download mono for windows/mac
* Install dnvm via command line/powershell
* Create database: CREATE DATABASE hair_salon; -> back up and restore as hair_salon_test for testing database.
* Create tables:
  * CREATE TABLE stylists(id INT IDENTITY(1,1), name VARCHAR(255));
  * CREATE TABLE clients(id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);
* Make sure to type in GO after every SQL command when creating db and tables
* Clone git repo at https://github.com/ryanpeterson08/nancy-word-finder
* In command line/powershell enter in 'dnx kestrel'
* Go to http://localhost:5004 in your browser


## Specs
| Input                            | Output                                                | Description                                      |
|----------------------------------|-------------------------------------------------------|--------------------------------------------------|
| List<stylist>                    | {"dave, "ryan", "susan"}                              | User can see a list of all the employees         |
| "ryan"                           | "name: ryan" List<client> {"george", "anne", "frank"} | User can click on employee and see details       |
| stylists.add("cody")             | {"dave, "ryan", "susan", "cody"}                      | User can add a stylist                           |
| clients.add("josie")             | "name: ryan" List {"george", "anne", "josie"}         | User can add to client list of specific stylists |
| stylist update ryan -> pete      | "name: pete" List {"george", "anne", "frank"}         | User can update stylist details                  |
| clients update frank -> franklin | "name: ryan" List {"george", "anne", "franklin"}      | User can update client details                   |
| stylists delete cody             | {"dave, "ryan", "susan"}                              | User can delete stylist                          |
| clients delete franklin          | "name: ryan" List {"george", "anne"}                  | User can delete client                           |

## Known Bugs

None

## Support and contact details

Email: ryanpeterson08@gmail.com

## Technologies Used

* HTML/CSS
* C#
* SQL
* MS SQL Server
* Nancy web framework

### License

Copyright (c) 2016 Ryan Peterson
