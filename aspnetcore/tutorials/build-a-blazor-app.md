---
title: Build a Blazor todo list app
author: guardrex
description: Build a Blazor app step-by-step.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 12/14/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: tutorials/build-a-blazor-app
---
# Build a Blazor todo list app

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

This tutorial shows you how to build and modify a Blazor app. You learn how to:

> [!div class="checklist"]
> * Create a todo list Blazor app project
> * Modify Razor components
> * Use event handling and data binding in components
> * Use routing in a Blazor app

At the end of this tutorial, you'll have a working todo list app.

## Prerequisites

::: moniker range=">= aspnetcore-5.0"

[!INCLUDE[](~/includes/5.0-SDK.md)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!INCLUDE[](~/includes/3.1-SDK.md)]

::: moniker-end

## Create a todo list Blazor app

1. Create a new Blazor app named `TodoList` in a command shell:

   ```dotnetcli
   dotnet new blazorserver -o TodoList
   ```

   The preceding command creates a folder named `TodoList` with the `-o|--output` option to hold the app. The `TodoList` folder is the *root folder* of the project. Change directories to the `TodoList` folder with the following command:

   ```dotnetcli
   cd TodoList
   ```

1. Add a new `Todo` Razor component to the app using the following command:

   ```dotnetcli
   dotnet new razorcomponent -n Todo -o Pages
   ```

   The `-n|--name` option in the preceding command specifies the name of the new Razor component. The new component is created in the project's `Pages` folder with the `-o|--output` option.

   > [!IMPORTANT]
   > Razor component file names require a capitalized first letter. Open the `Pages` folder and confirm that the `Todo` component file name starts with a capital letter `T`. The file name should be `Todo.razor`.

1. Open the `Todo` component in any file editor and add an `@page` Razor directive to the top of the file with a relative URL of `/todo`.

   `Pages/Todo.razor`:

   [!code-razor[](build-a-blazor-app/samples_snapshot/ToDo0.razor?highlight=1)]

   Save the `Pages/Todo.razor` file.

1. Add the `Todo` component to the navigation bar.

   The `NavMenu` component is used in the app's layout. Layouts are components that allow you to avoid duplication of content in an app. The `NavLink` component provides a cue in the app's UI when the component URL is loaded by the app.

   In the unordered list (`<ul>...</ul>`) of the `NavMenu` component, add the following list item (`<li>...</li>`) and `NavLink` component for the `Todo` component.

   In `Shared/NavMenu.razor`:

   [!code-razor[](build-a-blazor-app/samples_snapshot/NavMenu.razor?highlight=5-9)]

   Save the `Shared/NavMenu.razor` file.

1. Build and run the app by executing the [`dotnet watch run`](/aspnet/core/tutorials/dotnet-watch) command in the command shell from the `TodoList` folder. After the app is running, visit the new Todo page by selecting the **`Todo`** link in the app's navigation bar, which loads the page at `/todo`.

   Leave the app running the command shell. Each time a file is saved, the app is automatically rebuilt. The browser temporarily loses its connection to the app while compiling and restarting. The page in the browser is automatically reloaded when the connection is re-established.

1. Add a `TodoItem.cs` file to the root of the project (the `TodoList` folder) to hold a class that represents a todo item. Use the following C# code for the `TodoItem` class.

   `TodoItem.cs`:

   [!code-csharp[](build-a-blazor-app/samples_snapshot/TodoItem.cs)]

1. Return to the `Todo` component and perform the following tasks:

   * Add a field for the todo items in the `@code` block. The `Todo` component uses this field to maintain the state of the todo list.
   * Add unordered list markup and a `foreach` loop to render each todo item as a list item (`<li>`).

   `Pages/Todo.razor`:

   [!code-razor[](build-a-blazor-app/samples_snapshot/ToDo2.razor?highlight=5-10,13)]

1. The app requires UI elements for adding todo items to the list. Add a text input (`<input>`) and a button (`<button>`) below the unordered list (`<ul>...</ul>`):

   [!code-razor[](build-a-blazor-app/samples_snapshot/ToDo3.razor?highlight=12-13)]

1. Save the `TodoItem.cs` file and the updated `Pages/Todo.razor` file. In the command shell, the app is automatically rebuilt when the files are saved. The browser temporarily loses its connection to the app and then reloads the page when the connection is re-established.

1. When the **`Add todo`** button is selected, nothing happens because an event handler isn't attached to the button.

1. Add an `AddTodo` method to the `Todo` component and register the method for the button using the `@onclick` attribute. The `AddTodo` C# method is called when the button is selected:

   [!code-razor[](build-a-blazor-app/samples_snapshot/ToDo4.razor?highlight=2,7-10)]

1. To get the title of the new todo item, add a `newTodo` string field at the top of the `@code` block:

   [!code-razor[](build-a-blazor-app/samples_snapshot/ToDo5.razor?highlight=3)]

   Modify the text `<input>` element to bind `newTodo` with the `@bind` attribute:

   ```razor
   <input placeholder="Something todo" @bind="newTodo" />
   ```

1. Update the `AddTodo` method to add the `TodoItem` with the specified title to the list. Clear the value of the text input by setting `newTodo` to an empty string:

   [!code-razor[](build-a-blazor-app/samples_snapshot/ToDo6.razor?highlight=19-26)]

1. Save the `Pages/ToDo.razor` file. The app is automatically rebuilt in the command shell. The page reloads in the browser after the browser reconnects to the app.

1. The title text for each todo item can be made editable, and a check box can help the user keep track of completed items. Add a check box input for each todo item and bind its value to the `IsDone` property. Change `@todo.Title` to an `<input>` element bound to `todo.Title` with `@bind`:

   [!code-razor[](build-a-blazor-app/samples_snapshot/ToDo7.razor?highlight=4-7)]

1. Update the `<h3>` header to show a count of the number of todo items that aren't complete (`IsDone` is `false`).

   ```razor
   <h3>Todo (@todos.Count(todo => !todo.IsDone))</h3>
   ```

1. The completed `Todo` component (`Pages/Todo.razor`):

   [!code-razor[](build-a-blazor-app/samples_snapshot/Todo1.razor)]

1. Save the `Pages/ToDo.razor` file. The app is automatically rebuilt in the command shell. The page reloads in the browser after the browser reconnects to the app.

1. Add items, edit items, and mark todo items done to test the component.

1. When finished, shut down the app in the command shell. Many command shells accept the keyboard command <kbd>Ctrl</kbd>+<kbd>c</kbd> to stop an app.

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a todo list Blazor app project
> * Modify Razor components
> * Use event handling and data binding in components
> * Use routing in a Blazor app

Learn about tooling for ASP.NET Core Blazor:

> [!div class="nextstepaction"]
> <xref:blazor/tooling>
