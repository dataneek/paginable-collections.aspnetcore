PaginableCollections.AspNetCore
====================

[![Build status](https://ci.appveyor.com/api/projects/status/8hedo7ja62gaq022?svg=true)](https://ci.appveyor.com/project/neekgreen/paginablecollections.aspnetcore)
[![NuGet](https://img.shields.io/nuget/v/paginablecollections.aspnetcore.svg)](https://www.nuget.org/packages/paginablecollections.aspnetcore) 
[![NuGet](https://img.shields.io/nuget/dt/paginablecollections.aspnetcore.svg)](https://www.nuget.org/packages/paginablecollections.aspnetcore) 

A light weight pagination framework for .NET and .NET Core - now with additional MVC6 support!

### How Do I Use It?
Configure MVC to use PaginableCollections.
````csharp
public void ConfigureServices(IServiceCollection services)
{
    // important stuff...
    
    services.AddMvc()
        .UsePaginableHeaders(u => u.UseCondensed());
        
    // important stuff...
}
````
### Installing PaginableCollections.AspNetCore

You should install [PaginableCollections.AspNetCore with NuGet](https://www.nuget.org/packages/paginablecollections.aspnetcore):

    Install-Package PaginableCollections.AspNetCore
    
This command will download and install PaginableCollections.AspNetCore. Let me know if you have questions!
