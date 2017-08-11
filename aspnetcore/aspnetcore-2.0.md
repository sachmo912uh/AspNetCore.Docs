---
title: What's new in ASP.NET Core 2.0
author: rick-anderson
description: What's new in ASP.NET Core 2.0
keywords: ASP.NET Core, release notes, what's new
ms.author: riande
manager: wpickett
ms.date: 07/10/2017
ms.topic: article
ms.assetid: 08c9f457-9c24-40f9-a08b-47dc251e4cec
ms.technology: aspnet
ms.prod: aspnet-core
uid: aspnetcore-2.0
---

# What's new in ASP.NET Core 2.0 Preview

> [!NOTE]
> ASP.NET Core 2.0 is in preview, and some of the documentation for it has not yet been written. This document links to GitHub issues for articles that are planned but not yet published. For information about how to install ASP.NET 2.0 Preview 2, see [Introducing ASP.NET Core 2.0 Preview 2](https://blogs.msdn.microsoft.com/webdev/2017/06/28/introducing-asp-net-core-2-0-preview-2/)

Here are some of the most significant updates in ASP.NET Core 2.0:

- [Razor Pages](xref:mvc/razor-pages/index)
- [ASP.NET Core metapackage](#aspnet-core-metapackage)
- [.NET Standard 2.0](#net-standard-20)
- [Configuration update](#configuration-update)
- [Logging update](#logging-update)
- [Authentication update](#authentication-update)
- [Identity update](#identity-update)
- [SPA templates](#spa-templates)
- [Kestrel improvements](#kestrel-improvements)
- [WebListener renamed to HttpSys](#weblistener-renamed-to-httpsys)
- [Enhanced HTTP header support](#enhanced-http-header-support)
- [Hosting startup and Application Insights](#hosting-startup-and-application-insights)
- [Automatic use of anti-forgery tokens](#automatic-use-of-anti-forgery-tokens)
- [Automatic precompilation](#automatic-precompilation)
- [Razor support for C# 7.1](#razor-support-for-c-71)

For the complete list of changes, see the [ASP.NET Core Release Notes](https://github.com/aspnet/Home/releases/).

<!--
For guidance on how to migrate ASP.NET Core 1.x applications to ASP.NET Core 2.0, see [Migrate from 1.x to 2.0](https://github.com/aspnet/Docs/issues/3548).
-->

## ASP.NET Core metapackage

A new ASP.NET Core metapackage includes all of the packages made and supported by the ASP.NET Core and Entity Framework Core teams, along with their internal and 3rd-party dependencies. You no longer need to choose individual ASP.NET Core features by package. All features are included in the [Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All) package. The default templates use this package.

The version number of the `Microsoft.AspNetCore.All` metapackage represents the latest ASP.NET Core version (aligned with the .NET Core version).

Applications that use the `Microsoft.AspNetCore.All` metapackage automatically take advantage of the new .NET Core Runtime Store. The Runtime Store will contain all the runtime assets needed to run ASP.NET Core 2.0 applications. When you use the `Microsoft.AspNetCore.All` metapackage, no assets from the referenced ASP.NET Core NuGet packages are deployed with the application because they already reside on the target system. The assets in the Runtime Store are also precompiled to improve application startup-time.

If there are features you don’t use in your application, the new package trimming features will exclude those binaries in the published application output.

For information about the status of planned documentation, see the following GitHub issues:
   
* [Metapackage issue](https://github.com/aspnet/Docs/issues/3449)
* [Runtime Store issue](https://github.com/aspnet/Docs/issues/3667)
* [Package trimming issue](https://github.com/dotnet/docs/issues/1745)

## .NET Standard 2.0

The ASP.NET Core 2.0 packages target .NET Standard 2.0. The packages can be referenced by other .NET Standard 2.0 libraries, and they can run on .NET Standard 2.0-compliant implementations of .NET, including .NET Core 2.0 and .NET Framework 4.6.1. 

The `Microsoft.AspNetCore.All` metapackage targets .NET Core 2.0 only, because it is intended to be used with the .NET Core 2.0 Runtime Store.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3449).

## Configuration update

An `IConfiguration` instance is added to the services container by default in ASP.NET Core 2.0. `IConfiguration` in the services container makes it easier for applications to retrieve configuration values from the container.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3387).

## Logging update

In ASP.NET 2.0, logging is incorporated into the dependency injection (DI) system by default. You add providers and configure filtering in the *Program.cs* file instead of in the *Startup.cs* file. And the default `ILoggerFactory` supports filtering in a way that lets you use one flexible approach for both cross-provider filtering and specific-provider filtering. For more information, see [Introduction to Logging](xref:fundamentals/logging).

## Authentication update

A new authentication model makes it easier to configure authentication for an application using DI.

New templates are available for configuring authentication for web apps and web APIs using [Azure AD B2C]
(https://azure.microsoft.com/services/active-directory-b2c/).

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3054).

## Identity update

We've made it easier to build secure web APIs using Identity in ASP.NET Core 2.0. You can acquire access tokens for accessing your web APIs using the [Microsoft Authentication Library (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client).

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3668).

## SPA templates

Single Page Application (SPA) project templates for Angular, Aurelia, Knockout.js, React.js, and React.js with Redux are available. The Angular template has been updated to Angular 4. The Angular and React templates are available by default; for information about how to get the other templates, see [Creating a new SPA project](xref:client-side/spa-services#creating-a-new-project). For information about how to build a SPA in ASP.NET Core, see [Using JavaScriptServices for Creating Single Page Applications](xref:client-side/spa-services).

## Kestrel improvements

The Kestrel web server has new features that make it more suitable as an Internet-facing server. We’ve added a number of server constraint configuration options in the `KestrelServerOptions` class’s new `Limits` property. You can now add limits for the following:

- Maximum client connections
- Maximum request body size
- Minimum request body data rate

For more information, see [Introduction to Kestrel](xref:fundamentals/servers/kestrel).

## WebListener renamed to HttpSys

The packages `Microsoft.AspNetCore.Server.WebListener` and `Microsoft.Net.Http.Server` have been merged into a new package `Microsoft.AspNetCore.Server.HttpSys`. The namespaces have been updated to match.

For more information, see [Introduction to HttpSys](xref:fundamentals/servers/httpsys).

## Enhanced HTTP header support

When using MVC to transmit a `FileStreamResult` or a `FileContentResult`, you now have the option to set an `ETag` or a `LastModified` date on the content you transmit. You can set these values on the returned content with code similar to the following:

```csharp
var data = Encoding.UTF8.GetBytes("This is a sample text from a binary array");
var entityTag = new EntityTagHeaderValue("\"MyCalculatedEtagValue\"");
return File(data, "text/plain", "downloadName.txt", lastModified: DateTime.UtcNow.AddSeconds(-5), entityTag: entityTag);
```

The file returned to your visitors will be decorated with the appropriate HTTP headers for the `ETag` and `LastModified` values.

If an application visitor requests content with a Range Request header, ASP.NET will recognize that and handle that header. If the requested content can be partially delivered, ASP.NET will appropriately skip and return just the requested set of bytes.  You do not need to write any special handlers into your methods to adapt or handle this feature; it is automatically handled for you.

## Hosting startup and Application Insights

Hosting environments can now inject extra package dependencies and execute code during application startup, without the application needing to explicitly take a dependency or call any methods. This feature can be used to enable certain environments to "light-up" features unique to that environment without the application needing to know ahead of time. 

In ASP.NET Core 2.0, this feature is used to automatically enable Application Insights diagnostics when debugging in Visual Studio and (after opting in) when running in Azure App Services. As a result, the project templates no longer add Application Insights packages and code by default.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3389).

## Automatic use of anti-forgery tokens

ASP.NET Core has always helped HTMLEncode your content by default, but with the new version we’re taking an extra step to help prevent cross-site request forgery (XSRF) attacks: ASP.NET Core will now emit anti-forgery tokens by default and validate them on form POST actions and pages without extra configuration.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3688).

## Automatic precompilation

Razor view pre-compilation is enabled during publish by default, reducing the publish output size and application startup time.

For information about the status of planned documentation, see the [GitHub issue](https://github.com/aspnet/Docs/issues/3547).

## Razor support for C# 7.1

The Razor engine has been updated to work with the new Roslyn compiler. That includes support for C# 7.1 features like Default Expressions, Inferred Tuple Names, and Pattern-Matching with Generics.  To use C #7.1 in your project, add the following property in your project file and then reload the solution:

```xml
<LangVersion>latest</LangVersion>
```

For information about the status of C# 7.1 features, see [the Roslyn GitHub repository](https://github.com/dotnet/roslyn/blob/master/docs/Language%20Feature%20Status.md).

## Additional Information

- [ASP.NET Core Release Notes](https://github.com/aspnet/Home/releases/)
- If you’d like to connect with the ASP.NET Core development team’s progress and plans, tune in to the weekly [ASP.NET Community Standup](https://live.asp.net/).
