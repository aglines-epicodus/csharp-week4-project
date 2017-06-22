# CSHARP WEEK 4 PROJECT Band Tracker

#### Friday independent project in CSharp and SQL

#### **By Andrew Glines for Epicodus**

## Description

This web application will allow a user to manipulate data surrounding bands and venues where they have played.

|Behavior| Input (User Action/Selection) |Description|
|---|:---:|:---:|


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
