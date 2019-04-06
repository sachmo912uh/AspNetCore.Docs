---
title: Get started with Blazor
author: guardrex
description: Learn how to get started with Blazor by creating and modifying a Blazor project.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/03/2019
uid: spa/blazor/get-started
---
# Get started with Blazor

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/razor-components-preview-notice.md)]

# [Visual Studio](#tab/visual-studio)

Prerequisites:

[!INCLUDE[](~/includes/net-core-prereqs-vs-3.0.md)]

To create your first Blazor project in Visual Studio:

1. Install the latest [.NET Core 3.0 Preview SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0) release.
1. Enable Visual Studio to use preview SDKs:
   1. Open **Tools** > **Options** in the menu bar.
   1. Open the **Projects and Solutions** node. Open the **.NET Core** tab.
   1. Check the box for **Use previews of the .NET Core SDK**. Select **OK**.
1. Install the latest [Blazor extension](https://go.microsoft.com/fwlink/?linkid=870389) from the Visual Studio Marketplace. This step makes Blazor templates available to Visual Studio.
1. Make the Blazor templates available for use with the .NET Core CLI by running the following command in a command shell:

   ```console
   dotnet new -i Microsoft.AspNetCore.Blazor.Templates::0.9.0-preview3-19154-02
   ```
1. Create a new project.
1. Select **ASP.NET Core Web Application**. Select **Next**.
1. Provide a name in the **Project name** field. Confirm the **Location** entry is correct or provide a location for the project. Select **Create**.
1. Select the **Blazor** template.
1. Select **Create**.
1. Press **F5** to run the app.

Congratulations! You just ran your first Blazor app!

<!--

# [Visual Studio Code](#tab/visual-studio-code)

Prerequisites:

[!INCLUDE[](~/includes/net-core-prereqs-vsc-3.0.md)]

To create your first Blazor project in Visual Studio Code:

1. Execute the following command in a command shell:

   ```console
   dotnet new blazor -o WebApplication1
   ```

1. Open the *WebApplication1* folder in Visual Studio Code.

1. Visual Studio code offers to create assets to build and debug the app, which includes the *tasks.json* and *launch.json* files. Select **Yes** to add the assets.

1. Execute the app using the Visual Studio Code debugger.

1. In a browser, navigate to `https://localhost:5001`.

Congratulations! You just ran your first Blazor app!

# [Visual Studio for Mac](#tab/visual-studio-mac)

.NET Core 3.0 will be supported with Visual Studio for Mac version 8.0 or later. Visual Studio for Mac version 8.0 Preview isn't available at this time.

Use the [.NET Core CLI version of this topic](xref:razor-components/get-started?tabs=netcore-cli) on macOS.

[!INCLUDE[](~/includes/net-core-prereqs-mac-3.0.md)]

To create your first project Blazor project in Visual Studio for Mac:

1. Select **File** > **New Solution** or **New Project**.
1. In the sidebar, select **.NET Core** > **App**.
1. Select **Blazor** and select **Next**.
1. The **Target Framework** defaults to **.NET Core 3.0**. Select **Next**.
1. In the **Project Name** field, enter `WebApplication1`. Select **Create**.
1. Select **Run** > **Run Without Debugging** to run the app *without the debugger*. Running with the debugger isn't supported at this time.

Congratulations! You just ran your first Blazor app!
-->

# [.NET Core CLI](#tab/netcore-cli/)

Prerequisites:

* [.NET Core SDK 3.0 Preview](https://dotnet.microsoft.com/download/dotnet-core/3.0)

1. Add the Blazor templates by running the following command in a command shell:

   ```console
   dotnet new -i Microsoft.AspNetCore.Blazor.Templates::0.9.0-preview3-19154-02
   ```

1. Create your first Blazor project in a command shell:

   ```console
   dotnet new blazor -o WebApplication1
   cd WebApplication1
   dotnet run
   ```

1. In a browser, navigate to `https://localhost:5001`.

Congratulations! You just ran your first Blazor app!

---

## Blazor project

When the app is run, multiple pages are available from tabs in the sidebar:

* Home
* Counter
* Fetch data

On the Counter page, select the **Click me** button to increment the counter without a page refresh. Incrementing a counter in a webpage normally requires writing JavaScript, but Blazor provides a better approach using C#.

*Pages/Counter.cshtml*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Counter1.cshtml)]

A request for `/counter` in the browser, as specified by the `@page` directive at the top, causes the Counter component to render its content. Components render into an in-memory representation of the render tree that can then be used to update the UI in a flexible and efficient way.

Each time the **Click me** button is selected:

* The `onclick` event is fired.
* The `IncrementCount` method is called.
* The `currentCount` is incremented.
* The component is rendered again.

The runtime compares the new content to the previous content and only applies the changed content to the Document Object Model (DOM).

Add a component to another component using an HTML-like syntax. Component parameters are specified using attributes or child content. For example, a Counter component can be added to the app's homepage by adding a `<Counter />` element to the Index component.

In *Pages/Index.cshtml*, replace the Survey Prompt component with a Counter component:

[!code-cshtml[](get-started/samples_snapshot/3.x/Index1.cshtml?highlight=7)]

Run the app. The homepage has its own counter.

To add a parameter to the Counter component, update the component's `@functions` block:

* Add a property for `IncrementAmount` decorated with the `[Parameter]` attribute.
* Change the `IncrementCount` method to use the `IncrementAmount` when increasing the value of `currentCount`.

*Pages/Counter.cshtml*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Counter2.cshtml?highlight=4,8)]

Specify an `IncrementAmount` parameter in the Home component's `<Counter>` element using an attribute.

*Pages/Index.cshtml*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Index2.cshtml)]

Run the app. The homepage has its own counter that increments by ten each time the **Click me** button is selected.

## Next steps

<xref:tutorials/first-razor-components-app>
