### 24-06-2022

This project was made as a copy of the Reactivities folder in the ASP.NET Git project when I realized that it eased deployment to Heruko to have it in a Git project of its own.

There are some issues with the database that is seeded with users but not with activities - this resembles the situation where I decided to remove the Bio attribute from the User class because it caused trouble with writing to the database. 

Notice that there is no appsettings.json file, since it is not supposed to be comitted to Git, so I lost it when I nuked the repository at some point

### 26-06-2022

Update 1: I cleaned up the Domain project classes, to get rid of dotnet 6.0 warnings related to nullable properties. Thereby I also got a migration without warnings.

Update 2: I looked into the log for generating and seeding the database and spotted an error related to mixing different datetime formats, which apparently causes problems, because the postgres database only accepts UTC time... I therefore replaced all occurrences of Datetime.Now with DateTime.UtcNow and afterwards the seeding of the database with activities succeeded. Afterwards, the database was populated succesfully.

However, I observed that only some activities were shown, and I had trouble figuring out why. It seems that activities are only shown when the DATE of the activity is later than the current date.

This reflects that date filtering is actually employed when populating the activities list. You got the impression that this wasn't the case, because you had trouble letting the user change the date by means of the calendar control, but this presumably just means that the current date is used for filtering no matter what the user does.

### 27-06-2022

Update 2: I read the documentation of the react-calendar library and changed the construction in accordance with an example there. Then I realized that I apparently couldn't test my changes using the localhost:5000 url since that just takes the optimized build moved to the wwwroot folder.

Todo:

* Figure out why the current date is used for filtering - det styres vist i den der axiosParams funktion i ActivityFilters.tsx som passes med i kaldet til agent.Activities.list
* Get the date filtering from lesson 245 to work (done)
* Get the "Bio" challenge from section 18 to work
* Get the  "Events view" challenge from lesson 248 to work
* Write detailed guide for running local
* Write detailed guide for deploying to Heroku
* Write a test protocol

### Deploying to Heroku

1) Navigate to www.heroku in a web browser and log in
2) Create a new app with a globally unique name and choose Europe as the region
3) I terminal vinduet i VSCode: Naviger til Reactivities-folderen og eksekver: `heroku login`  så åbnes et browser vindue hvor man kan logge ind
4) Eksekver nu: `heroku git:remote -a meloreactivities`
5) I heroku tilføj ressourcen Heroku postgres til applikationen
6) I heroku sæt de nødvendige config variable
7) Sæt en build pack ved at eksekvere følgende ved command prompten i VS Code: `heroku buildpacks:set https://github.com/jincod/dotnetcore-buildpack` Bagefter figurerer det også åp Heroku web pagen
8) i VS Code command prompten, naviger hen til client-app folderen, og generer et optimized production build ved at eksekvere følgende: `npm run build`. Som post build event flytter den bygget hen i API folderen.
9) commit det hele til git, vel at mærke inklusiv det, der ligger i wwwroot-folderen
10) Eksekver: `git push heroku main` eller `git push heroku HEAD:master`
11) Åbn applikationen i https://meloreactivities.herokuapp.com