# CSHARP WEEK 4 PROJECT Band Tracker

#### Friday independent project in CSharp and SQL

#### **By Andrew Glines for Epicodus**

## Description

This web application will allow a user to manipulate data surrounding bands and venues where they have played.

|Behavior| Input (User Action/Selection) |Description|
|---|:---:|:---:|
| Create a band | Create band Amon Tobin | Add |
| Read band info | Click on band Amon Tobin| Find |
| Update a band | Find band Amon Tobin| Update |
| Delete a band | Delete band Amon Tobin| Delete |
| Add a venue. |Add venue: The Crocodile | Add  |
| Find a venue. |Find venue: The Crocodile | A find function. |
| Search for a venue. |Search venue: The Crocodile | A search function. |
| Delete a venue. |Delete venue: The Crocodile |  A delete function. |
| Update a venue |Find venue: The Crocodile, update to The Showbox | An update function. |
| View all venues. | Venues: The Crocodile, The Showbox | View the full list of venues in the database. |
| View a venue's bands. | venue: The Crocodile | View the full list of venues in the database. |
| Link a venue to a band. | venue: The Crocodile, band: Amon Tobin | A one to one database relationship. |
| Link a venue to several bands. | venue: The Crocodile, bands: Amon Tobin | A one to many database relationship. |


## Setup/Installation Requirements

Must have current version of .Net and Mono installed. Will require database file to work correctly, see download instructions below.

Copy all files and folders to your desktop or {git clone} the project using this link https://github.com/aglines-epicodus/csharp-week4-project.git.

To recreate the databases using SQLCMD in powershell on a windows operating system type:

* > create database band_tracker > go
* > create table bands (id INT IDENTITY(1,1), name VARCHAR(255)) > go
* > create table bands_venues_join (id INT IDENTITY(1,1), id_bands INT, id_venues INT) > go
* > create table venues (id INT IDENTITY(1,1), name VARCHAR(255))  > go

* > create database band_tracker_test> go
* > create table bands (id INT IDENTITY(1,1), name VARCHAR(255)) > go
* > create table bands_venues_join (id INT IDENTITY(1,1), id_bands INT, id_venues INT) > go
* > create table venues (id INT IDENTITY(1,1), name VARCHAR(255))  > go

To ensure functionality, populate both production and test databases with some data using the following commands:
* INSERT [dbo].[bands] ([id], [name]) VALUES (1, N'Amon Tobin')
* INSERT [dbo].[bands] ([id], [name]) VALUES (2, N'Magnetic Fields')
* INSERT [dbo].[bands] ([id], [name]) VALUES (3, N'Origin Master')
* INSERT [dbo].[bands_venues_join] ([id], [id_bands], [id_venues]) VALUES (1, 1, 1)
* INSERT [dbo].[bands_venues_join] ([id], [id_bands], [id_venues]) VALUES (2, 1, 2)
* INSERT [dbo].[bands_venues_join] ([id], [id_bands], [id_venues]) VALUES (3, 1, 3)
* INSERT [dbo].[bands_venues_join] ([id], [id_bands], [id_venues]) VALUES (4, 2, 1)
* INSERT [dbo].[bands_venues_join] ([id], [id_bands], [id_venues]) VALUES (5, 2, 2)
* INSERT [dbo].[bands_venues_join] ([id], [id_bands], [id_venues]) VALUES (6, 3, 1)
* INSERT [dbo].[venues] ([id], [name]) VALUES (1, N'The Showbox')
* INSERT [dbo].[venues] ([id], [name]) VALUES (2, N'The Crocodile')
* INSERT [dbo].[venues] ([id], [name]) VALUES (3, N'The Black Cat')

Navigate to the folder in your Windows powershell and run {dnu restore} to compile the file then run {dnx kestrel} to start the web server. In your web browser address bar, navigate to {//localhost:5004} to get to the home page.

## Known Bugs

* No known bugs.

## Support and contact details

If you have any issues or have questions, ideas, concerns, or contributions please contact the contributor through Github.

## Technologies Used

* C#
* Nancy
* Razor
* xUnit
* JSON
* HTML
* CSS
* Bootstrap

### License
This software is licensed under the MIT license.

Copyright (c) 2017 **Andrew Glines and Epicodus**
