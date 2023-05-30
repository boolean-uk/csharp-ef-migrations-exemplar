# C# Entity Framework Migrations


1. Fork this repository
2. Clone your fork to your machine
3. Open the ef.intro.sln in Visual Studio
5. Note:  There are no controllers in this project!!  A current way of writing endpoints is in the EndPoint directory.
		  See How the AuthorApi.cs & BookApi.cs both are extension methods of the WebApplication class which 
		  is returned in the Program.cs from a builder.Build() call.  This way we can call this to initialize from the 
		  extension method.  See also how the data is populated via the Seed() method call.  Note how we are 
		  randomly generating names of both authors & books!

## Key Outcomes   

Understand how to apply Entity Framework migrations



## Exercise   

-Add the LibraryRepository.cs from the previous exercise.   
-Configure this project for a secure connecton to your Elephant SQL instance.   
-Configure this project for Entity Framework migrations and run an "Add-Migration InitialMigration" command to create a first migration.   
-Add the Author class from previous project.  Run a "Add-Migration AddedAuthor" to the project.   (this can be found in the Models, so add an existing item and look in there)    
-Add the Book class from previous project.  Run a "Add-Migration AddedBook" to the project.   (this can be found in the Models, so add an existing item and look in there)   

## Extension
-Add the Pushlisher model from the previous Extensions to this and "Add-Migration AddedPublisher"   
-Create a script-migration






