TIL
===

TIL Framework

TIL Basics
__________

### Convert with TIL

###### Get int value from request

> using TIL.Extensions;
> ...
> int pageIndex = Request.QueryString["page"].GetValue<int>(); // Will throw and exception if 'page' is null or not int value
> ...
> int pageIndex = Request.QueryString["page"].GetValueOrDefault<int>(); // Returns 0 if 'page' is null or not an int value

###### Convert anonymous to query string

> using TIL.Extensions;
> var query = new { @page = 1, @limit = 2, @sort = "crated_on" }
> query.ToQueryString() // -> "page=1&limit=2&sort=created_on"

