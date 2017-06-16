# _Band Tracker_

#### _Follow your favorite bands, and see where they've played. 6/16/17_

#### By _**Guy Anderson**_

## Description

_A not-so-useful app that will tell the user where bands have played. User will be able to choose to see all venues or bands in our database. Choosing an individual venue, will display all the bands that have played there. Choosing a band, will display all the venues that band has played at. Because we believe in the integrity of our users, the app will allow users to create, update, and delete venues from our database. Users will also be allowed to add their own garage band to our database._

## Setup/Installation Requirements

* Go to Github repository page.
* Click the "download or clone" button and copy the link
* In your computers terminal type "git clone" & paste the copied link.
* Open SSMS
* Select File > Open > bandTracker and select Scrips.sql file.
* ========CREATE DATABASE [hair_salon]=================
* Save the file.
* Click Execute.
* Verify that the database has been created and the schema and/or data imported. (good luck!)
* Run dnu restore in terminal
* Run dnx kestrel in terminal
* Open browser, type localhost:5004 for url
* Prepare to be amazed!

## Specs
| Behavior | Input | Output |
|---|---|---|
| Program will have a form entry for venues | text / Mom's Garage | Mom's Garage |
| Program will have a form entry for bands | Guitar Hero | Guitar Hero |
| Program will display a list of all current venues | None | Mom's Garage |
| Program will display a list of all current bands | None | Guitar Hero |
| User will be able to assign bands to venues, and venues to bands | drop down selection for venue - add band | See below |
| User will be able to click on a venue to see a list of bands that have played there | Click / Mom's Garage | Guitar Hero |
| User will be able to click on a band to see a list of venues they that have played at | Click / Guitar Hero | Mom's Garage |
| User will be able to remove all venues | Delete | You have no venues to show! |
| User will be able to remove venue 1 at a time | Delete | Success! |
| User will be able to update a venue name | Mom's Garage | Dad's Garage |

## Known Bugs

_._


## Technologies Used

_C#, Nancy, razor, SQL, SSMS_

### License

Copyright (c) 2017 **_FunGuy Entertainment_**
