User Requirements :
1.	 a web application which demonstrates a system that integrates the entire offline Games Stores with the entire online Games (web sites) together.
2.	The Web application includes two layout:
        a.	First Layout: the User Layout and we will call it the Wall (all the Games news exists here).
        b.	Second Layout: the Editor Layout and we will call it the Factory (news are conducted and edited here).
3.	Editors are responsible for Writing and adding articles from the Factory (it is like an Editor profile) then after the acceptance of the admin, the article reflected to the Wall so the user could see it.
4.	Admin could add articles from the Factory (profile), and then article reflected to the Wall so the user could see it (no acceptance needed).
5.	An Admin that would be the chief editor that responsible for the acceptance and refuse 
6.	Editors, Admin and Users are authenticated to enter the Wall (no Login is needed).
7.	Editors and Admin are authenticated to Enter the Factory (Login is needed).
8.	Admins are authorized to edit the Wall.
9.	Users can leave comment on the website to share information or user reviews about any games.
10-	Make Your app is responsive.
11-	Bootstrap is required (Grid System)
12-     Implementation Must Meet your SRS-SDD. 

#Screen Shots

![alt text](https://github.com/taha7ussein007/GamesJournal/blob/master/scrShots/1.PNG)
![alt text](https://github.com/taha7ussein007/GamesJournal/blob/master/scrShots/2.PNG)
![alt text](https://github.com/taha7ussein007/GamesJournal/blob/master/scrShots/3.PNG)
![alt text](https://github.com/taha7ussein007/GamesJournal/blob/master/scrShots/4.PNG)
![alt text](https://github.com/taha7ussein007/GamesJournal/blob/master/scrShots/5.PNG)
![alt text](https://github.com/taha7ussein007/GamesJournal/blob/master/scrShots/6.PNG)
![alt text](https://github.com/taha7ussein007/GamesJournal/blob/master/scrShots/7.PNG)
![alt text](https://github.com/taha7ussein007/GamesJournal/blob/master/scrShots/8.PNG)
![alt text](https://github.com/taha7ussein007/GamesJournal/blob/master/scrShots/9.PNG)
![alt text](https://github.com/taha7ussein007/GamesJournal/blob/master/scrShots/10.PNG)
![alt text](https://github.com/taha7ussein007/GamesJournal/blob/master/scrShots/11.PNG)
![alt text](https://github.com/taha7ussein007/GamesJournal/blob/master/scrShots/12.PNG)

#How To Use:

- Put Database in your sql server.
- Configure your connectionStrings in BOL/App.Config 
<connectionStrings>
<add name="GamesJournalEntities" connectionString="metadata=res://*/GamesJournalModel.csdl|res://*/GamesJournalModel.ssdl|res://*/GamesJournalModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=^^^^^your server name here^^^^^^^;initial catalog=GamesJournal;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>

- Do the same thing again Configure your connectionStrings in GameJournal/Web.config

- #Engoy


