---
title: Managing Application State | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 18cda488-0769-4cb9-82f6-4c6685f2045d
ms.technology: aspnet
ms.prod: aspnet-core
uid: fundamentals/app-state
---
# Managing Application State

>[!WARNING]
> This page documents version 1.0.0-rc1 and has not yet been updated for version 1.0.0

By [Steve Smith](http://ardalis.com)

In ASP.NET Core, application state can be managed in a variety of ways, depending on when and how the state is to be retrieved. This article provides a brief overview of several options, and focuses on installing and configuring Session state support in ASP.NET Core applications.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/app-state/sample)

## Application State Options

*Application state* refers to any data that is used to represent the current representation of the application. This includes both global and user-specific data. Previous versions of ASP.NET (and even ASP) have had built-in support for global `Application` and `Session` state stores, as well as a variety of other options.

> [!NOTE]
> The `Application` store had the same characteristics as the ASP.NET `Cache`, with fewer capabilities. In ASP.NET Core, `Application` no longer exists; applications written for previous versions of ASP.NET that are migrating to ASP.NET Core replace `Application` with a [Caching](../performance/caching/index.md) implementation.

Application developers are free to use different state storage providers depending on a variety of factors:

* How long does the data need to persist?

* How large is the data?

* What format is the data?

* Can it be serialized?

* How sensitive was the data? Could it be stored on the client?

Based on answers to these questions, application state in ASP.NET Core apps can be stored or managed in a variety of ways.

### HttpContext.Items

The `Items` collection is the best location to store data that is only needed while processing a given request. Its contents are discarded after each request. It is best used as a means of communicating between components or middleware that operate at different points in time during a request, and have no direct relationship with one another through which to pass parameters or return values. See [Working with HttpContext.Items](#working-with-httpcontext-items), below.

### QueryString and Post

State from one request can be provided to another request by adding values to the new request's query string or by POSTing the data. These techniques should not be used with sensitive data, because these techniques require that the data be sent to the client and then sent back to the server. It is also best used with small amounts of data. Query strings are especially useful for capturing state in a persistent manner, allowing links with embedded state to be created and sent via email or social networks, for use potentially far into the future. However, no assumption can be made about the user making the request, since URLs with query strings can easily be shared, and care must also be taken to avoid [Cross-Site Request Forgery (CSRF)](https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF)) attacks (for instance, even assuming only authenticated users are able to perform actions using query string based URLs, an attacker could trick a user into visiting such a URL while
already authenticated).

### Cookies

Very small pieces of state-related data can be stored in Cookies. These are sent with every request, and so the size should be kept to a minimum. Ideally, only an identifier should be used, with the actual data stored somewhere on the server, keyed to the identifier.

### Session

Session storage relies on a cookie-based identifier to access data related to a given browser session (a series of requests from a particular browser and machine). You can't necessarily assume that a session is restricted to a single user, so be careful what kind of information you store in Session. It is a good place to store application state that is specific to a particular session but which doesn't need to be persisted permanently (or which can be reproduced as needed from a persistent store). See [Installing and Configuring Session](#installing-and-configuring-session), below for more details.

### Cache

Caching provides a means of storing and efficiently retrieving arbitrary application data based on developer-defined keys. It provides rules for expiring cached items based on time and other considerations. Learn more about [Caching](../performance/caching/index.md).

### Configuration

Configuration can be thought of as another form of application state storage, though typically it is read-only while the application is running. Learn more about [Configuration](configuration.md).

### Other Persistence

Any other form of persistent storage, whether using Entity Framework and a database or something like Azure Table Storage, can also be used to store application state, but these fall outside of what ASP.NET supports directly.

## Working with HttpContext.Items

The `HttpContext` abstraction provides support for a simple dictionary collection of type `IDictionary<object, object>`, called `Items`. This collection is available from the start of an *HttpRequest* and is discarded at the end of each request. You can access it by simply assigning a value to a keyed entry, or by requesting the value for a given key.

For example, some simple [Middleware](middleware.md) could add something to the `Items` collection:

```csharp
app.Use(async (context, next) =>
{
    // perform some verification
    context.Items["isVerified"] = true;
    await next.Invoke();
});
```

and later in the pipeline, another piece of middleware could access it:

```csharp
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Verified request? " + context.Items["isVerified"]);
});
```

> [!NOTE]
> Since keys into `Items` are simple strings, if you are developing middleware that needs to work across many applications, you may wish to prefix your keys with a unique identifier to avoid key collisions (e.g. "MyComponent.isVerified" instead of just "isVerified").

<a name=id1></a>

## Installing and Configuring Session

ASP.NET Core ships a session package that provides middleware for managing session state. You can install it by including a reference to the `Microsoft.AspNetCore.Session` package in your project.json file.

Once the package is installed, Session must be configured in your application's `Startup` class. Session is built on top of `IDistributedCache`, so you must configure this as well, otherwise you will receive an error.

> [!NOTE]
> If you do not configure at least one `IDistributedCache` implementation, you will get an exception stating "Unable to resolve service for type 'Microsoft.Extensions.Caching.Distributed.IDistributedCache' while attempting to activate 'Microsoft.AspNetCore.Session.DistributedSessionStore'."

ASP.NET ships with several implementations of `IDistributedCache`, including an in-memory option (to be used during development and testing only). To configure session using this in-memory option add the `Microsoft.Extensions.Caching.Memory` package in your project.json file and then add the following to `ConfigureServices`:

```csharp
services.AddDistributedMemoryCache();
services.AddSession();
```

Then, add the following to `Configure` **before** `app.UseMVC()` and you're ready to use session in your application code:

```csharp
app.UseSession();
   ```

You can reference Session from `HttpContext` once it is installed and configured.

> [!NOTE]
> If you attempt to access `Session` before `UseSession` has been called, you will get an `InvalidOperationException` exception stating that "Session has not been configured for this application or request."

>[!WARNING]
> If you attempt to create a new `Session` (i.e. no session cookie has been created yet) after you have already begun writing to the `Response` stream, you will get an `InvalidOperationException` as well, stating that "The session cannot be established after the response has started". This exception may not be displayed in the browser; you may need to view the web server log  to discover it, as shown below:

![Command window: The web server log is open showing the Invalid Operation Exception.](app-state/_static/session-after-response-error.png)

### Implementation Details

Session uses a cookie to track and disambiguate between requests from different browsers. By default this cookie is named ".AspNet.Session" and uses a path of "/". Further, by default this cookie does not specify a domain, and is not made available to client-side script on the page (because `CookieHttpOnly` defaults to `true`).

These defaults, as well as the default `IdleTimeout` (used on the server independent from the cookie), can be overridden when configuring `Session` by using `SessionOptions` as shown here:

```csharp
services.AddSession(options =>
{
  options.CookieName = ".AdventureWorks.Session";
  options.IdleTimeout = TimeSpan.FromSeconds(10);
});
```

The `IdleTimeout` is used by the server to determine how long a session can be idle before its contents are abandoned. Each request made to the site that passes through the Session middleware (regardless of whether Session is read from or written to within that middleware) will reset the timeout. Note that this is independent of the cookie's expiration.

> [!NOTE]
> `Session` is *non-locking*, so if two requests both attempt to modify the contents of session, the last one will win. Further, `Session` is implemented as a *coherent session*, which means that all of the contents are stored together. This means that if two requests are modifying different parts of the session (different keys), they may still impact each other.

### ISession

Once session is installed and configured, you refer to it via HttpContext, which exposes a property called `Session` of type `ISession`. You can use this interface to get and set values in `Session`, such as `byte[]`.

```csharp
public interface ISession
{
    bool IsAvailable { get; }
    string Id { get; }
    IEnumerable<string> Keys { get; }
    Task LoadAsync();
    Task CommitAsync();
    bool TryGetValue(string key, out byte[] value);
    void Set(string key, byte[] value);
    void Remove(string key);
    void Clear();
}
```

Because `Session` is built on top of `IDistributedCache`, you must always serialize the object instances being stored. Thus, the interface works with `byte[]` not simply `object`. However, there are extension methods that make working with simple types such as `String` and `Int32` easier, as well as making it easier to get a byte[] value from session.

```csharp
// session extension usage examples
context.Session.SetInt32("key1", 123);
int? val = context.Session.GetInt32("key1");
context.Session.SetString("key2", "value");
string stringVal = context.Session.GetString("key2");
byte[] result = context.Session.Get("key3");
```

If you're storing more complex objects, you will need to serialize the object to a `byte[]` in order to store them, and then deserialize them from `byte[]` when retrieving them.

## A Working Sample Using Session

The associated sample application demonstrates how to work with Session, including storing and retrieving simple types as well as custom objects. In order to see what happens when session expires, the sample has configured sessions to last just 10 seconds:

[!code-csharp[Main](../fundamentals/app-state/sample/src/AppState/Startup.cs?highlight=3,7&range=14-22)]

When you first navigate to the web server, it displays a screen indicating that no session has yet been established:

![Web application open in Microsoft Edge stating: Your session has not been established.](app-state/_static/no-session-established.png)

This default behavior is produced by the following middleware in Startup.cs, which runs when requests are made that do not already have an established session (note the highlighted sections):

[!code-csharp[Main](app-state/sample/src/AppState/Startup.cs?range=77-106&highlight=4,6,8-11,28-29)]

`GetOrCreateEntries` is a helper method that will retrieve a `RequestEntryCollection` instance from `Session` if it exists; otherwise, it creates the empty collection and returns that. The collection holds `RequestEntry` instances, which keep track of the different requests the user has made during the current session, and how many requests they've made for each path.

[!code-csharp[Main](app-state/sample/src/AppState/Model/RequestEntry.cs?range=3-7)]

[!code-csharp[Main](app-state/sample/src/AppState/Model/RequestEntryCollection.cs?range=7-28)]

Fetching the current instance of `RequestEntryCollection` is done via the `GetOrCreateEntries` helper method:

[!code-csharp[Main](../fundamentals/app-state/sample/src/AppState/Startup.cs?highlight=4,8,9&range=109-124)]

When the entry for the object exists in `Session`, it is retrieved as a `byte[]` type, and then deserialized using a `MemoryStream` and a `BinaryFormatter`, as shown above. If the object isn't in `Session`, the method returns a new instance of the `RequestEntryCollection`.

In the browser, clicking the Establish session hyperlink makes a request to the path "/session", and returns this result:

![Web application stating: Counting: You have made 1 requests to this application.](app-state/_static/session-established.png)

Refreshing the page results in the count incrementing; returning to the root of the site (after making a few more requests) results in this display, summarizing all of the requests that were made during the current session:

![Web application after making several requests stating that session path was requested four times, the index path was requested four times, and the site has been visited eight times.](app-state/_static/session-established-with-request-counts.png)

Establishing the session is done in the middleware that handles requests to "/session":

[!code-csharp[Main](../fundamentals/app-state/sample/src/AppState/Startup.cs?highlight=2,8,9,10,11,12,13,14&range=56-75)]

Requests to this path will get or create a `RequestEntryCollection`, will add the current path to it, and then will store it in session using the helper method `SaveEntries`, shown below:

[!code-csharp[Main](../fundamentals/app-state/sample/src/AppState/Startup.cs?highlight=6&range=126-132)]

`SaveEntries` demonstrates how to serialize a custom object into a `byte[]` for storage in `Session` using a `MemoryStream` and a `BinaryFormatter`.

The sample includes one more piece of middleware worth mentioning, which is mapped to the "/untracked" path. You can see its configuration here:

[!code-csharp[Main](../fundamentals/app-state/sample/src/AppState/Startup.cs?highlight=2,13&range=42-54)]

Note that this middleware is configured **before** the call to `app.UseSession()` is made (on line 13). Thus, the `Session` feature is not available to this middleware, and requests made to it do not reset the session `IdleTimeout`. You can confirm this behavior in the sample application by refreshing the untracked path several times within 10 seconds, and then return to the application root. You will find that your session has expired, despite no more than 10 seconds having passed between your requests to the application.
