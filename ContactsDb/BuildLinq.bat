REM Create Contacts.Linq.cs based on Contacts SQL database
SqlMetal.exe /conn:"Server=(local);Database=Contacts;Trusted_Connection=True;" /pluralize /sprocs /views /functions /serialization:unidirectional /code:Contacts.Linq.cs /namespace:Contacts.Linq /context:ContactsDataContext

REM Create a SQL script that will rebuild your Contacts SQL database from scratch
REM "c:\program files\Microsoft SQL Server\90\Tools\Publishing\1.4\sqlpubwiz.exe" script -C "Data Source=YourServer;Initial Catalog=YourDatabase;User Id=YourUserId;Password=yourPassword" scripts\createTablesandData.sql -targetserver 2008 -f 