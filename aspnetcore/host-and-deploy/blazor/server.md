---
title: Host and deploy ASP.NET Core Blazor Server
author: guardrex
description: Learn how to host and deploy a Blazor Server app using ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 12/18/2019
no-loc: [Blazor, SignalR]
uid: host-and-deploy/blazor/server
---
# Host and deploy Blazor Server

By [Luke Latham](https://github.com/guardrex), [Rainer Stropek](https://www.timecockpit.com), and [Daniel Roth](https://github.com/danroth27)

## Host configuration values

[Blazor Server apps](xref:blazor/hosting-models#blazor-server) can accept [Generic Host configuration values](xref:fundamentals/host/generic-host#host-configuration).

## Deployment

Using the [Blazor Server hosting model](xref:blazor/hosting-models#blazor-server), Blazor is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection.

A web server capable of hosting an ASP.NET Core app is required. Visual Studio includes the **Blazor Server App** project template (`blazorserverside` template when using the [dotnet new](/dotnet/core/tools/dotnet-new) command).

## Scalability

Plan a deployment to make the best use of the available infrastructure for a Blazor Server app. See the following resources to address Blazor Server app scalability:

* [Fundamentals of Blazor Server apps](xref:blazor/hosting-models#blazor-server)
* <xref:security/blazor/server>

### Deployment server

When considering the scalability of a single server (scale up), the memory available to an app is likely the first resource that the app will exhaust as user demands increase. The available memory on the server affects the:

* Number of active circuits that a server can support.
* UI latency on the client.

For guidance on building secure and scalable Blazor server apps, see <xref:security/blazor/server>.

Each circuit uses approximately 250 KB of memory for a minimal *Hello World*-style app. The size of a circuit depends on the app's code and the state maintenance requirements associated with each component. We recommend that you measure resource demands during development for your app and infrastructure, but the following baseline can be a starting point in planning your deployment target: If you expect your app to support 5,000 concurrent users, consider budgeting at least 1.3 GB of server memory to the app (or ~273 KB per user).

### SignalR configuration

Blazor Server apps use ASP.NET Core SignalR to communicate with the browser. [SignalR's hosting and scaling conditions](xref:signalr/publish-to-azure-web-app) apply to Blazor Server apps.

Blazor works best when using WebSockets as the SignalR transport due to lower latency, reliability, and [security](xref:signalr/security). Long Polling is used by SignalR when WebSockets isn't available or when the app is explicitly configured to use Long Polling. When deploying to Azure App Service, configure the app to use WebSockets in the Azure portal settings for the service. For details on configuring the app for Azure App Service, see the [SignalR publishing guidelines](xref:signalr/publish-to-azure-web-app).

#### Azure SignalR Service

We recommend using the [Azure SignalR Service](/azure/azure-signalr) for Blazor Server apps. The service allows for scaling up a Blazor Server app to a large number of concurrent SignalR connections. In addition, the SignalR service's global reach and high-performance data centers significantly aid in reducing latency due to geography. To configure an app (and optionally provision) the Azure SignalR Service:

1. Enable the service to support *sticky sessions*, where clients are [redirected back to the same server when prerendering](xref:blazor/hosting-models#reconnection-to-the-same-server). Set the `ServerStickyMode` option or configuration value to `Required`. Typically, an app creates the configuration using **one** of the following approaches:

   * `Startup.ConfigureServices`:
  
     ```csharp
     services.AddSignalR().AddAzureSignalR(options =>
     {
         options.ServerStickyMode = 
             Microsoft.Azure.SignalR.ServerStickyMode.Required;
     });
     ```

   * Configuration (use **one** of the following approaches):
  
     * *appsettings.json*:

       ```json
       "Azure:SignalR:ServerStickyMode": "Required"
       ```

     * The app service's **Configuration** > **Application settings** in the Azure portal (**Name**: `Azure:SignalR:ServerStickyMode`, **Value**: `Required`).

1. Create an Azure Apps publish profile in Visual Studio for the Blazor Server app.
1. Add the **Azure SignalR Service** dependency to the profile. If the Azure subscription doesn't have a pre-existing Azure SignalR Service instance to assign to the app, select **Create a new Azure SignalR Service instance** to provision a new service instance.
1. Publish the app to Azure.

#### IIS

When using IIS, sticky sessions are enabled with Application Request Routing. For more information, see [HTTP Load Balancing using Application Request Routing](/iis/extensions/configuring-application-request-routing-arr/http-load-balancing-using-application-request-routing).

#### Kubernetes

Create an ingress definition with the following [Kubernetes annotations for sticky sessions](https://kubernetes.github.io/ingress-nginx/examples/affinity/cookie/):

```yaml
apiVersion: extensions/v1beta1
kind: Ingress
metadata:
  name: <ingress-name>
  annotations:
    nginx.ingress.kubernetes.io/affinity: "cookie"
    nginx.ingress.kubernetes.io/session-cookie-name: "affinity"
    nginx.ingress.kubernetes.io/session-cookie-expires: "14400"
    nginx.ingress.kubernetes.io/session-cookie-max-age: "14400"
```

### Measure network latency

[JS interop](xref:blazor/javascript-interop) can be used to measure network latency, as the following example demonstrates:

```razor
@inject IJSRuntime JS

@if (latency is null)
{
    <span>Calculating...</span>
}
else
{
    <span>@(latency.Value.TotalMilliseconds)ms</span>
}

@code
{
    private DateTime startTime;
    private TimeSpan? latency;

    protected override async Task OnInitializedAsync()
    {
        startTime = DateTime.UtcNow;
        var _ = await JS.InvokeAsync<string>("toString");
        latency = DateTime.UtcNow - startTime;
    }
}
```

For a reasonable UI experience, we recommend a sustained UI latency of 250ms or less.
