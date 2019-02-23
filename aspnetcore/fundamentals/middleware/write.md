---
title: Write custom ASP.NET Core middleware
author: rick-anderson
description: Learn how to write custom ASP.NET Core middleware.
ms.author: riande
ms.custom: mvc
ms.date: 02/14/2019
uid: fundamentals/middleware/write
---
# Write custom ASP.NET Core middleware

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Steve Smith](https://ardalis.com/)

Middleware is software that's assembled into an app pipeline to handle requests and responses. ASP.NET Core provides a rich set of built-in middleware components, but in some scenarios you might want to write a custom middleware.

## Middleware class

Middleware is generally encapsulated in a class and exposed with an extension method. Consider the following middleware, which sets the culture for the current request from a query string:

[!code-csharp[](index/snapshot/Culture/StartupCulture.cs?name=snippet1)]

The preceding sample code is used to demonstrate creating a middleware component. For ASP.NET Core's built-in localization support, see <xref:fundamentals/localization>.

You can test the middleware by passing in the culture. For example, `http://localhost:7997/?culture=no`.

The following code moves the middleware delegate to a class:

[!code-csharp[](index/snapshot/Culture/RequestCultureMiddleware.cs)]

::: moniker range="< aspnetcore-2.0"

The middleware `Task` method's name must be `Invoke`. In ASP.NET Core 2.0 or later, the name can be either `Invoke` or `InvokeAsync`.

::: moniker-end

## Middleware extension method

The following extension method exposes the middleware through <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder>:

[!code-csharp[](index/snapshot/Culture/RequestCultureMiddlewareExtensions.cs)]

The following code calls the middleware from `Startup.Configure`:

[!code-csharp[](index/snapshot/Culture/Startup.cs?name=snippet1&highlight=5)]

Middleware should follow the [Explicit Dependencies Principle](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#explicit-dependencies) by exposing its dependencies in its constructor. Middleware is constructed once per *application lifetime*. See the [Per-request dependencies](#per-request-dependencies) section if you need to share services with middleware within a request.

Middleware components can resolve their dependencies from [dependency injection (DI)](xref:fundamentals/dependency-injection) through constructor parameters. [UseMiddleware&lt;T&gt;](/dotnet/api/microsoft.aspnetcore.builder.usemiddlewareextensions.usemiddleware#Microsoft_AspNetCore_Builder_UseMiddlewareExtensions_UseMiddleware_Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Type_System_Object___) can also accept additional parameters directly.

## Per-request dependencies

Because middleware is constructed at app startup, not per-request, *scoped* lifetime services used by middleware constructors aren't shared with other dependency-injected types during each request. If you must share a *scoped* service between your middleware and other types, add these services to the `Invoke` method's signature. The `Invoke` method can accept additional parameters that are populated by DI:

```csharp
public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // IMyScopedService is injected into Invoke
    public async Task Invoke(HttpContext httpContext, IMyScopedService svc)
    {
        svc.MyProperty = 1000;
        await _next(httpContext);
    }
}
```

## Additional resources

* <xref:fundamentals/middleware/index>
* <xref:migration/http-modules>
* <xref:fundamentals/startup>
* <xref:fundamentals/request-features>
* <xref:fundamentals/middleware/extensibility>
* <xref:fundamentals/middleware/extensibility-third-party-container>
