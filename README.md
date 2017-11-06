PaginableCollections.AspNetCore
====================

[![Build status](https://ci.appveyor.com/api/projects/status/t9xr3cp9vuc739gq?svg=true)](https://ci.appveyor.com/project/neekgreen/paginablecollections-aspnetcore)
[![NuGet](https://img.shields.io/nuget/v/paginablecollections.aspnetcore.svg)](https://www.nuget.org/packages/paginablecollections.aspnetcore) 
[![NuGet](https://img.shields.io/nuget/dt/paginablecollections.aspnetcore.svg)](https://www.nuget.org/packages/paginablecollections.aspnetcore) 

A light weight pagination framework for .NET and .NET Core - now with additional MVC6 support!

### How Do I Use It?
Configure MVC to use PaginableCollections.
```csharp
public void ConfigureServices(IServiceCollection services)
{
    // important stuff...
    
    services.AddMvc()
        .UsePaginableHeaders(u => u.UseCondensed());
        
    // important stuff...
}
```
#### Condensed Headers
```
Content-Type →application/json; charset=utf-8
Date →Thu, 20 Jul 2017 04:31:01 GMT
Server →Kestrel
Transfer-Encoding →chunked
X-Paginable →{"itemCountPerPage":20,"pageNumber":1,"totalItemCount":14,"totalPageCount":1}
```
#### Expanded Headers
```
Content-Type →application/json; charset=utf-8
Date →Thu, 20 Jul 2017 04:35:13 GMT
Server →Kestrel
Transfer-Encoding →chunked
X-Paginable-ItemCountPerPage →20
X-Paginable-PageNumber →1
X-Paginable-TotalItemCount →14
X-Paginable-TotalPageCount →1
```

### Link Based Headers
```
<http://localhost/api/values/1/5>; rel="first"
<http://localhost/api/values/1/5>; rel="previous"
<http://localhost/api/values/2/5>; rel="current"
<http://localhost/api/values/3/5>; rel="next"
<http://localhost/api/values/4/5>; rel="last"
```

### Installing PaginableCollections.AspNetCore

You should install [PaginableCollections.AspNetCore with NuGet](https://www.nuget.org/packages/paginablecollections.aspnetcore):

    Install-Package PaginableCollections.AspNetCore
    
This command will download and install PaginableCollections.AspNetCore. Let me know if you have questions!
