TIL
===

TIL Framework

##TIL Basics

### Convert with TIL

###### Get int value from request

```csharp
using TIL.Extensions;
...
int pageIndex = Request.QueryString["page"].GetValue<int>(); // Will throw and exception if 'page' is null or not int value
int pageIndex = Request.QueryString["page"].GetValueOrDefault<int>(); // Returns 0 if 'page' is null or not an int value
```

###### Convert anonymous to query string

```csharp
using TIL.Extensions;
...
var query = new { @page = 1, @limit = 2, @sort = "created_on" }
query.ToQueryString() // Produce string "page=1&limit=2&sort=created_on"
```
