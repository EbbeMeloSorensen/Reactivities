24-06-2022

This project was made as a copy of the Reactivities folder in the ASP.NET Git project when I realized that it eased deployment to Heruko to have it in a Git project of its own.

There are some issues with the database that is seeded with users but not with activities - this resembles the situation where I decided to remove the Bio attribute from the User class because it caused trouble with writing to the database. 

Notice that there is no appsettings.json file, since it is not supposed to be comitted to Git, so I lost it when I nuked the repository at some point