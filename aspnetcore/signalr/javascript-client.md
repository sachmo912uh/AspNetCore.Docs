---
title: ASP.NET Core SignalR JavaScript client
author: bradygaster
description: Overview of ASP.NET Core SignalR JavaScript client.
monikerRange: '>= aspnetcore-2.1'
ms.author: bradyg
ms.custom: mvc
ms.date: 03/14/2019
uid: signalr/javascript-client
---
# ASP.NET Core SignalR JavaScript client

By [Rachel Appel](http://twitter.com/rachelappel)

The ASP.NET Core SignalR JavaScript client library enables developers to call server-side hub code.

[View or download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/signalr/javascript-client/sample) ([how to download](xref:index#how-to-download-a-sample))

## Install the SignalR client package

The SignalR JavaScript client library is delivered as an [npm](https://www.npmjs.com/) package. If you're using Visual Studio, run `npm install` from the **Package Manager Console** while in the root folder. For Visual Studio Code, run the command from the **Integrated Terminal**.

  ```console
  npm init -y
  npm install @aspnet/signalr
  ```

npm installs the package contents in the *node_modules\\@aspnet\signalr\dist\browser* folder. Create a new folder named *signalr* under the *wwwroot\\lib* folder. Copy the *signalr.js* file to the *wwwroot\lib\signalr* folder.

## Use the SignalR JavaScript client

Reference the SignalR JavaScript client in the `<script>` element.

```html
<script src="~/lib/signalr/signalr.js"></script>
```

## Connect to a hub

The following code creates and starts a connection. The hub's name is case insensitive.

[!code-javascript[Call hub methods](javascript-client/sample/wwwroot/js/chat.js?range=9-13,43-45)]

### Cross-origin connections

Typically, browsers load connections from the same domain as the requested page. However, there are occasions when a connection to another domain is required.

To prevent a malicious site from reading sensitive data from another site, [cross-origin connections](xref:security/cors) are disabled by default. To allow a cross-origin request, enable it in the `Startup` class.

[!code-csharp[Cross-origin connections](javascript-client/sample/Startup.cs?highlight=29-35,56)]

## Call hub methods from client

JavaScript clients call public methods on hubs via the [invoke](/javascript/api/%40aspnet/signalr/hubconnection#invoke) method of the [HubConnection](/javascript/api/%40aspnet/signalr/hubconnection). The `invoke` method accepts two arguments:

* The name of the hub method. In the following example, the method name on the hub is `SendMessage`.
* Any arguments defined in the hub method. In the following example, the argument name is `message`. The example code uses arrow function syntax that is supported in current versions of all major browsers except Internet Explorer.

  [!code-javascript[Call hub methods](javascript-client/sample/wwwroot/js/chat.js?range=24)]

> [!NOTE]
> If you're using Azure SignalR Service in *Serverless mode*, you cannot call hub methods from a client. For more information, see the [SignalR Service documentation](/azure/azure-signalr/signalr-concept-serverless-development-config).

## Call client methods from hub

To receive messages from the hub, define a method using the [on](/javascript/api/%40aspnet/signalr/hubconnection#on) method of the `HubConnection`.

* The name of the JavaScript client method. In the following example, the method name is `ReceiveMessage`.
* Arguments the hub passes to the method. In the following example, the argument value is `message`.

[!code-javascript[Receive calls from hub](javascript-client/sample/wwwroot/js/chat.js?range=14-19)]

The preceding code in `connection.on` runs when server-side code calls it using the [SendAsync](/dotnet/api/microsoft.aspnetcore.signalr.clientproxyextensions.sendasync) method.

[!code-csharp[Call client-side](javascript-client/sample/hubs/chathub.cs?range=8-11)]

SignalR determines which client method to call by matching the method name and arguments defined in `SendAsync` and `connection.on`.

> [!NOTE]
> As a best practice, call the [start](/javascript/api/%40aspnet/signalr/hubconnection#start) method on the `HubConnection` after `on`. Doing so ensures your handlers are registered before any messages are received.

## Error handling and logging

Chain a `catch` method to the end of the `start` method to handle client-side errors. Use `console.error` to output errors to the browser's console.

[!code-javascript[Error handling](javascript-client/sample/wwwroot/js/chat.js?range=49-51)]

Setup client-side log tracing by passing a logger and type of event to log when the connection is made. Messages are logged with the specified log level and higher. Available log levels are as follows:

* `signalR.LogLevel.Error` &ndash; Error messages. Logs `Error` messages only.
* `signalR.LogLevel.Warning` &ndash; Warning messages about potential errors. Logs `Warning`, and `Error` messages.
* `signalR.LogLevel.Information` &ndash; Status messages without errors. Logs `Information`, `Warning`, and `Error` messages.
* `signalR.LogLevel.Trace` &ndash; Trace messages. Logs everything, including data transported between hub and client.

Use the [configureLogging](/javascript/api/%40aspnet/signalr/hubconnectionbuilder#configurelogging) method on [HubConnectionBuilder](/javascript/api/%40aspnet/signalr/hubconnectionbuilder) to configure the log level. Messages are logged to the browser console.

[!code-javascript[Logging levels](javascript-client/sample/wwwroot/js/chat.js?range=9-12)]

## Reconnect clients

The JavaScript client for SignalR doesn't automatically reconnect. You must write code that will reconnect your client manually. The following code demonstrates a typical reconnection approach:

1. A function (in this case, the `start` function) is created to start the connection.
1. Call the `start` function in the connection's `onclose` event handler.

[!code-javascript[Reconnect the JavaScript client](javascript-client/sample/wwwroot/js/chat.js?range=28-40)]

A real-world implementation would use an exponential back-off or retry a specified number of times before giving up. 

## Additional resources

* [JavaScript API reference](/javascript/api/?view=signalr-js-latest)
* [JavaScript tutorial](xref:tutorials/signalr)
* [WebPack and TypeScript tutorial](xref:tutorials/signalr-typescript-webpack)
* [Hubs](xref:signalr/hubs)
* [.NET client](xref:signalr/dotnet-client)
* [Publish to Azure](xref:signalr/publish-to-azure-web-app)
* [Cross-Origin Requests (CORS)](xref:security/cors)
* [Azure SignalR Service serverless documentation](/azure/azure-signalr/signalr-concept-serverless-development-config)
