# Example MAUI Project with EFCore and Popups
My attempt to demo a production ready MAUI Android app with EFCore, popups, etc

# Features  
- MVVM  
- Familiar patterns (DI, etc)
- Data persistence  
- Standard configuration setup (appsettings.json) 
- Popups  

# Popups  
I'm using the [Maui Toolkit Popup](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/popup) to handle popups.  
There's some magic to more easily show, hide, and configure them.  

# Dependency Injection  
It feels a bit crazy, but I'm using the Microsoft DI and `appsettings.json` configuration.  

# EFCore  
This also feels a bit heavy, however after implementing it, it doesn't feel any heavier than anything else.  
There's not too many sharp edges discovered so far (using Sqlite) except for the external migration assembly.  

See [here](https://www.kaels-kabbage.com/posts/production-maui-app/) for more info.
