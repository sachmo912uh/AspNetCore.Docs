---
title: ASP.NET Core Blazor project structure
author: guardrex
description: Learn about ASP.NET Core Blazor app project structure.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 12/07/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/project-structure
---
# ASP.NET Core Blazor project structure

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

The following files and folders make up a Blazor app generated from a Blazor project template:

::: moniker range=">= aspnetcore-5.0"

* `Program.cs`: The app's entry point that sets up the:

  * ASP.NET Core [host](xref:fundamentals/host/generic-host) (Blazor Server)
  * WebAssembly host (Blazor WebAssembly): The code in this file is unique to apps created from the Blazor WebAssembly template (`blazorwasm`).
    * The `App` component is the root component of the app. The `App` component is specified as the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>` in `wwwroot/index.html`) to the root component collection (`builder.RootComponents.Add<App>("#app")`).
    * [Services](xref:blazor/fundamentals/dependency-injection) are added and configured (for example, `builder.Services.AddSingleton<IMyDependency, MyDependency>()`).

::: moniker-end

::: moniker range="< aspnetcore-5.0"

* `Program.cs`: The app's entry point that sets up the:

  * ASP.NET Core [host](xref:fundamentals/host/generic-host) (Blazor Server)
  * WebAssembly host (Blazor WebAssembly): The code in this file is unique to apps created from the Blazor WebAssembly template (`blazorwasm`).
    * The `App` component is the root component of the app. The `App` component is specified as the `app` DOM element (`<app>Loading...</app>` in `wwwroot/index.html`) to the root component collection (`builder.RootComponents.Add<App>("app")`).
    * [Services](xref:blazor/fundamentals/dependency-injection) are added and configured (for example, `builder.Services.AddSingleton<IMyDependency, MyDependency>()`).

::: moniker-end

* `Startup.cs` (Blazor Server): Contains the app's startup logic. The `Startup` class defines two methods:

  * `ConfigureServices`: Configures the app's [dependency injection (DI)](xref:fundamentals/dependency-injection) services. In Blazor Server apps, services are added by calling <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>, and the `WeatherForecastService` is added to the service container for use by the example `FetchData` component.
  * `Configure`: Configures the app's request handling pipeline:
    * <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> is called to set up an endpoint for the real-time connection with the browser. The connection is created with [SignalR](xref:signalr/introduction), which is a framework for adding real-time web functionality to apps.
    * [`MapFallbackToPage("/_Host")`](xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage*) is called to set up the root page of the app (`Pages/_Host.cshtml`) and enable navigation.

::: moniker range=">= aspnetcore-5.0"

* `wwwroot/index.html` (Blazor WebAssembly): The root page of the app implemented as an HTML page:
  * When any page of the app is initially requested, this page is rendered and returned in the response.
  * The page specifies where the root `App` component is rendered. The component is rendered at the location of the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>`).
  * The `_framework/blazor.webassembly.js` JavaScript file is loaded, which:
    * Downloads the .NET runtime, the app, and the app's dependencies.
    * Initializes the runtime to run the app.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

* `wwwroot/index.html` (Blazor WebAssembly): The root page of the app implemented as an HTML page:
  * When any page of the app is initially requested, this page is rendered and returned in the response.
  * The page specifies where the root `App` component is rendered. The component is rendered at the location of the `app` DOM element (`<app>Loading...</app>`).
  * The `_framework/blazor.webassembly.js` JavaScript file is loaded, which:
    * Downloads the .NET runtime, the app, and the app's dependencies.
    * Initializes the runtime to run the app.

::: moniker-end

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `Pages` folder: Contains the routable components/pages (`.razor`) that make up the Blazor app and the root Razor page of a Blazor Server app. The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following:
  * `_Host.cshtml` (Blazor Server): The root page of the app implemented as a Razor Page:
    * When any page of the app is initially requested, this page is rendered and returned in the response.
    * The `_framework/blazor.server.js` JavaScript file is loaded, which sets up the real-time SignalR connection between the browser and the server.
    * The Host page specifies where the root `App` component (`App.razor`) is rendered.
  * `Counter` component (`Pages/Counter.razor`): Implements the Counter page.
  * `Error` component (`Error.razor`, Blazor Server app only): Rendered when an unhandled exception occurs in the app.
  * `FetchData` component (`Pages/FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Pages/Index.razor`): Implements the Home page.
  
* `Properties/launchSettings.json`: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson).

::: moniker range=">= aspnetcore-5.0"

* `Shared` folder: Contains other UI components (`.razor`) used by the app:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/layouts).
  * `MainLayout.razor.css`: Stylesheet for the app's main layout.
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-component) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

* `Shared` folder: Contains other UI components (`.razor`) used by the app:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/layouts).
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-component) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  
::: moniker-end

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `Data` folder (Blazor Server): Contains the `WeatherForecast` class and implementation of the `WeatherForecastService` that provide example weather data to the app's `FetchData` component.

* `wwwroot`: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets.

* `appsettings.json`: Holds [configuration settings](xref:blazor/fundamentals/configuration) for the app. In a Blazor WebAssembly app, the app settings file is located in the `wwwroot` folder. In a Blazor Server app, the app settings file is located at the project root.
