24-06-2022

This project was made as a copy of the Reactivities folder in the ASP.NET Git project when I realized that it eased deployment to Heruko to have it in a Git project of its own.

There are some issues with the database that is seeded with users but not with activities - this resembles the situation where I decided to remove the Bio attribute from the User class because it caused trouble with writing to the database. 

Notice that there is no appsettings.json file, since it is not supposed to be comitted to Git, so I lost it when I nuked the repository at some point

26-06-2022

Update 1: I cleaned up 

Update 2: I looked into the log for generating and seeding the database and spotted an error related to mixing different datetime formats, which apparently causes problems, because the postgres database only accepts UTC time... I therefore replaced all occurrences of Datetime.Now with DateTime.UtcNow and afterwards the seeding of the database with activities succeeded. Afterwards, the database was populated succesfully.

However, I observed that only some activities were shown, and I had trouble figuring out why. It seems that activities are only shown when the DATE of the activity is later than the current date.

This reflects that date filtering is actually employed when populating the activities list. You got the impression that this wasn't the case, because you had trouble letting the user change the date by means of the calendar control, but this presumably just means that the current date is used for filtering no matter what the user does.

Todo:

* Figure out why the current date is used for filtering
* Get the date filtering from lesson 245 to work
* Get the "Bio" challenge from section 18 to work
* Get the  "Events view" challenge from lesson 248 to work
* Write detailed guide for running local
* Write detailed guide for deploying to Heroku
* Write a test protocol