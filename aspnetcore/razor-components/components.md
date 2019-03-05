---
title: Create and use Razor Components
author: guardrex
description: Learn how to create and use Razor Components, including how to bind to data, handle events, and manage component life cycles.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/13/2019
uid: razor-components/components
---
# Create and use Razor Components

By [Luke Latham](https://github.com/guardrex), [Daniel Roth](https://github.com/danroth27), and [Morné Zaayman](https://github.com/MorneZaayman)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/razor-components/common/samples/) ([how to download](xref:index#how-to-download-a-sample)). See the [Get started](xref:razor-components/get-started) topic for prerequisites.

Razor Components apps are built using *components*. A component is a self-contained chunk of user interface (UI), such as a page, dialog, or form. A component includes HTML markup and the processing logic required to inject data or respond to UI events. Components are flexible and lightweight. They can be nested, reused, and shared among projects.

## Component classes

Components are typically implemented in *.cshtml* files using a combination of C# and HTML markup. The UI for a component is defined using HTML. Dynamic rendering logic (for example, loops, conditionals, expressions) is added using an embedded C# syntax called [Razor](xref:mvc/views/razor). When a Razor Components app is compiled, the HTML markup and C# rendering logic are converted into a component class. The name of the generated class matches the name of the file.

Members of the component class are defined in a `@functions` block (more than one `@functions` block is permissible). In the `@functions` block, component state (properties, fields) is specified along with methods for event handling or for defining other component logic.

Component members can then be used as part of the component's rendering logic using C# expressions that start with `@`. For example, a C# field is rendered by prefixing `@` to the field name. The following example evaluates and renders:

* `_headingFontStyle` to the CSS property value for `font-style`.
* `_headingText` to the content of the `<h1>` element.

```cshtml
<h1 style="font-style:@_headingFontStyle">@_headingText</h1>

@functions {
    private string _headingFontStyle = "italic";
    private string _headingText = "Put on your new Blazor!";
}
```

After the component is initially rendered, the component regenerates its render tree in response to events. Razor Components then compares the new render tree against the previous one and applies any modifications to the browser's Document Object Model (DOM).

## Using components

Components can include other components by declaring them using HTML element syntax. The markup for using a component looks like an HTML tag where the name of the tag is the component type.

The following markup renders a `HeadingComponent` (*HeadingComponent.cshtml*) instance:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/Index.cshtml?name=snippet_HeadingComponent)]

## Component parameters

Components can have *component parameters*, which are defined using *non-public* properties on the component class decorated with `[Parameter]`. Use attributes to specify arguments for a component in markup.

In the following example, the `ParentComponent` sets the value of the `Title` property of the `ChildComponent`:

*ParentComponent.cshtml*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/ParentComponent.cshtml?name=snippet_ParentComponent&highlight=5)]

*ChildComponent.cshtml*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/ChildComponent.cshtml?highlight=7-8)]

## Child content

Components can set the content of another component. The assigning component provides the content between the tags that specify the receiving component. For example, a `ParentComponent` can provide content for rendering by a Child component by placing the content inside `<ChildComponent>` tags.

*ParentComponent.cshtml*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/ParentComponent.cshtml?name=snippet_ParentComponent&highlight=6-7)]

The Child component has a `ChildContent` property that represents a `RenderFragment`. The value of `ChildContent` is positioned in the child component's markup where the content should be rendered. In the following example, the value of `ChildContent` is received from the parent component and rendered inside the Bootstrap panel's `panel-body`.

*ChildComponent.cshtml*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/ChildComponent.cshtml?highlight=3,10-11)]

> [!NOTE]
> The property receiving the `RenderFragment` content must be named `ChildContent` by convention.

## Data binding

Data binding to both components and DOM elements is accomplished with the `bind` attribute. The following example binds the `ItalicsCheck` property to the check box's checked state:

```cshtml
<input type="checkbox" class="form-check-input" id="italicsCheck" 
    bind="@_italicsCheck" />
```

When the check box is selected and cleared, the property's value is updated to `true` and `false`, respectively.

The check box is updated in the UI only when the component is rendered, not in response to changing the property's value. Since components render themselves after event handler code executes, property updates are usually reflected in the UI immediately.

Using `bind` with a `CurrentValue` property (`<input bind="@CurrentValue" />`) is essentially equivalent to the following:

```cshtml
<input value="@CurrentValue" 
    onchange="@((UIChangeEventArgs __e) => CurrentValue = __e.Value)" />
```

When the component is rendered, the `value` of the input element comes from the `CurrentValue` property. When the user types in the text box, the `onchange` event is fired and the `CurrentValue` property is set to the changed value. In reality, the code generation is a little more complex because `bind` handles a few cases where type conversions are performed. In principle, `bind` associates the current value of an expression with a `value` attribute and handles changes using the registered handler.

In addition to `onchange`, the property can be bound using other events like `oninput` by being more explicit about what to bind to:

```cshtml
<input type="text" bind-value-oninput="@CurrentValue" />
```

Unlike `onchange`, `oninput` fires for every character that is input into the text box.

**Format strings**

Data binding works with <xref:System.DateTime> format strings. Other format expressions, such as currency or number formats, aren't available at this time.

```cshtml
<input bind="@StartDate" format-value="yyyy-MM-dd" />

@functions {
    [Parameter]
    private DateTime StartDate { get; set; } = new DateTime(2020, 1, 1);
}
```

The `format-value` attribute specifies the date format to apply to the `value` of the `input` element. The format is also used to parse the value when an `onchange` event occurs.

**Component parameters**

Binding also recognizes component parameters, where `bind-{property}` can bind a property value across components.

The following component uses `ChildComponent` and binds the `ParentYear` parameter from the parent to the `Year` parameter on the child component:

Parent component:

```cshtml
@page "/ParentComponent"

<h1>Parent Component</h1>

<p>ParentYear: @ParentYear</p>

<ChildComponent bind-Year="@ParentYear" />

<button class="btn btn-primary" onclick="@ChangeTheYear">
    Change Year to 1986
</button>

@functions {
    [Parameter]
    private int ParentYear { get; set; } = 1978;

    void ChangeTheYear()
    {
        ParentYear = 1986;
    }
}
```

Child component:

```cshtml
<h2>Child Component</h2>

<p>Year: @Year</p>

@functions {
    [Parameter]
    private int Year { get; set; }

    [Parameter]
    private Action<int> YearChanged { get; set; }
}
```

Loading the `ParentComponent` produces the following markup:

```html
<h1>Parent Component</h1>

<p>ParentYear: 1978</p>

<h2>Child Component</h2>

<p>Year: 1978</p>
```

If the value of the `ParentYear` property is changed by selecting the button in the `ParentComponent`, the `Year` property of the `ChildComponent` is updated. The new value of `Year` is rendered in the UI when the `ParentComponent` is rerendered:

```html
<h1>Parent Component</h1>

<p>ParentYear: 1986</p>

<h2>Child Component</h2>

<p>Year: 1986</p>
```

The `Year` parameter is bindable because it has a companion `YearChanged` event that matches the type of the `Year` parameter.

By convention, `<ChildComponent bind-Year="@ParentYear" />` is essentially equivalent to writing,

```cshtml
    <ChildComponent bind-Year-YearChanged="@ParentYear" />
```

In general, a property can be bound to a corresponding event handler using `bind-property-event` attribute.

## Event handling

Razor Components provide event handling features. For an HTML element attribute named `on<event>` (for example, `onclick`, `onsubmit`) with a delegate-typed value, Razor Components treats the attribute's value as an event handler. The attribute's name always starts with `on`.

The following code calls the `UpdateHeading` method when the button is selected in the UI:

```cshtml
<button class="btn btn-primary" onclick="@UpdateHeading">
    Update heading
</button>

@functions {
    void UpdateHeading(UIMouseEventArgs e)
    {
        ...
    }
}
```

The following code calls the `CheckboxChanged` method when the check box is changed in the UI:

```cshtml
<input type="checkbox" class="form-check-input" onchange="@CheckboxChanged" />

@functions {
    void CheckboxChanged()
    {
        ...
    }
}
```

Event handlers can also be asynchronous and return a <xref:System.Threading.Tasks.Task>. There's no need to manually call `StateHasChanged()`. Exceptions are logged when they occur.

```cshtml
<button class="btn btn-primary" onclick="@UpdateHeading">
    Update heading
</button>

@functions {
    async Task UpdateHeading(UIMouseEventArgs e)
    {
        ...
    }
}
```

For some events, event-specific event argument types are permitted. If access to one of these event types isn't necessary, it isn't required in the method call.

The list of supported event arguments is:

* UIEventArgs
* UIChangeEventArgs
* UIKeyboardEventArgs
* UIMouseEventArgs

Lambda expressions can also be used:

```cshtml
<button onclick="@(e => Console.WriteLine("Hello, world!"))">Say hello</button>
```

It's often convenient to close over additional values, such as when iterating over a set of elements. The following example creates three buttons, each of which calls `UpdateHeading` passing an event argument (`UIMouseEventArgs`) and its button number (`buttonNumber`) when selected in the UI:

```cshtml
<h2>@message</h2>

@for (var i = 1; i < 4; i++)
{
    var buttonNumber = i;

    <button class="btn btn-primary"
            onclick="@(e => UpdateHeading(e, buttonNumber))">
        Button #@i
    </button>
}

@functions {
    string message = "Select a button to learn its position.";

    void UpdateHeading(UIMouseEventArgs e, int buttonNumber)
    {
        message = $"You selected Button #{buttonNumber} at " +
            "mouse position: {e.ClientX} X {e.ClientY}.";
    }
}
```

> [!NOTE]
> Do **not** use the loop variable (`i`) in a `for` loop directly in a lambda expression. Otherwise the same variable is used by all lambda expressions causing `i`'s value to be the same in all lambdas. Always capture its value in a local variable (`buttonNumber` in the preceding example) and then use it.

## Capture references to components

Component references provide a way get a reference to a component instance so that you can issue commands to that instance, such as `Show` or `Reset`. To capture a component reference, add a `ref` attribute to the child component and then define a field with the same name and the same type as the child component.

```cshtml
<MyLoginDialog ref="loginDialog" ... />

@functions {
    MyLoginDialog loginDialog;

    void OnSomething()
    {
        loginDialog.Show();
    }
}
```

When the component is rendered, the `loginDialog` field is populated with the `MyLoginDialog` child component instance. You can then invoke .NET methods on the component instance.

> [!IMPORTANT]
> The `loginDialog` variable is only populated after the component is rendered and its output includes the `MyLoginDialog` element. Until that point, there's nothing to reference. To manipulate components references after the component has finished rendering, use the `OnAfterRenderAsync` or `OnAfterRender` methods.

While capturing component references uses a similar syntax to [capturing element references](xref:razor-components/javascript-interop#capture-references-to-elements), it isn't a [JavaScript interop](xref:razor-components/javascript-interop) feature. Component references aren't passed to JavaScript code; they're only used in .NET code.

> [!NOTE]
> Do **not** use component references to mutate the state of child components. Instead, use normal declarative parameters to pass data to child components. This causes child components to rerender at the correct times automatically.

## Lifecycle methods

`OnInitAsync` and `OnInit` execute code to initialize the component. To perform an asynchronous operation, use `OnInitAsync` and the `await` keyword on the operation:

```csharp
protected override async Task OnInitAsync()
{
    await ...
}
```

For a synchronous operation, use `OnInit`:

```csharp
protected override void OnInit()
{
    ...
}
```

`OnParametersSetAsync` and `OnParametersSet` are called when a component has received parameters from its parent and the values are assigned to properties. These methods are executed after component initialization and then each time the component is rendered:

```csharp
protected override async Task OnParametersSetAsync()
{
    await ...
}
```

```csharp
protected override void OnParametersSet()
{
    ...
}
```

`OnAfterRenderAsync` and `OnAfterRender` are called after a component has finished rendering. Element and component references are populated at this point. Use this stage to perform additional initialization steps using the rendered content, such as activating third-party JavaScript libraries that operate on the rendered DOM elements.

```csharp
protected override async Task OnAfterRenderAsync()
{
    await ...
}
```

```csharp
protected override void OnAfterRender()
{
    ...
}
```

`SetParameters` can be overridden to execute code before parameters are set:

```csharp
public override void SetParameters(ParameterCollection parameters)
{
    ...

    base.SetParameters(parameters);
}
```

If `base.SetParameters` isn't invoked, the custom code can interpret the incoming parameters value in any way required. For example, the incoming parameters aren't required to be assigned to the properties on the class.

`ShouldRender` can be overridden to suppress refreshing of the UI. If the implementation returns `true`, the UI is refreshed. Even if `ShouldRender` is overridden, the component is always initially rendered.

```csharp
protected override bool ShouldRender()
{
    var renderUI = true;

    return renderUI;
}
```

## Component disposal with IDisposable

If a component implements <xref:System.IDisposable>, the [Dispose method](/dotnet/standard/garbage-collection/implementing-dispose) is called when the component is removed from the UI. The following component uses `@implements IDisposable` and the `Dispose` method:

```csharp
@using System
@implements IDisposable

...

@functions {
    public void Dispose()
    {
        ...
    }
}
```

## Routing

Routing in Razor Components is achieved by providing a route template to each accessible component in the app.

When a *.cshtml* file with an `@page` directive is compiled, the generated class is given a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> specifying the route template. At runtime, the router looks for component classes with a `RouteAttribute` and renders whichever component has a route template that matches the requested URL.

Multiple route templates can be applied to a component. The following component responds to requests for `/BlazorRoute` and `/DifferentBlazorRoute`:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/BlazorRoute.cshtml?name=snippet_BlazorRoute)]

## Route parameters

Components can receive route parameters from the route template provided in the `@page` directive. The router uses route parameters to populate the corresponding component parameters.

*RouteParameter.cshtml*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/RouteParameter.cshtml?name=snippet_RouteParameter)]

Optional parameters aren't supported, so two `@page` directives are applied in the example above. The first permits navigation to the component without a parameter. The second `@page` directive takes the `{text}` route parameter and assigns the value to the `Text` property.

## Base class inheritance for a "code-behind" experience

Component files (*.cshtml*) mix HTML markup and C# processing code in the same file. The `@inherits` directive can be used to provide Razor Components apps with a "code-behind" experience that separates component markup from processing code.

The [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/razor-components/common/samples/) shows how a component can inherit a base class, `BlazorRocksBase`, to provide the component's properties and methods.

*BlazorRocks.cshtml*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/BlazorRocks.cshtml?name=snippet_BlazorRocks)]

*BlazorRocksBase.cs*:

[!code-csharp[](common/samples/3.x/BlazorSample/Pages/BlazorRocksBase.cs)]

The base class should derive from `BlazorComponent`.

## Razor support

**Razor directives**

Razor directives are shown in the following table.

| Directive | Description |
| --------- | ----------- |
| [\@functions](xref:mvc/views/razor#section-5) | Adds a C# code block to a component. |
| `@implements` | Implements an interface for the generated component class. |
| [\@inherits](xref:mvc/views/razor#section-3) | Provides full control of the class that the component inherits. |
| [\@inject](xref:mvc/views/razor#section-4) | Enables service injection from the [service container](xref:fundamentals/dependency-injection). For more information, see [Dependency injection into views](xref:mvc/views/dependency-injection). |
| `@layout` | Specifies a layout component. Layout components are used to avoid code duplication and inconsistency. |
| [\@page](xref:razor-pages/index#razor-pages) | Specifies that the component should handle requests directly. The `@page` directive can be specified with a route and optional parameters. Unlike Razor Pages, the `@page` directive doesn't need to be the first directive at the top of the file. For more information, see [Routing](xref:razor-components/routing). |
| [\@using](xref:mvc/views/razor#using) | Adds the C# `using` directive to the generated component class. |
| [\@addTagHelper](xref:mvc/views/razor#tag-helpers) | Use `@addTagHelper` to use a component in a different assembly than the app's assembly. |

**Conditional attributes**

Attributes are conditionally rendered based on the .NET value. If the value is `false` or `null`,  the attribute isn't rendered. If the value is `true`, the attribute is rendered minimized.

In the following example, `IsCompleted` determines if `checked` is rendered in the control's markup:

```cshtml
<input type="checkbox" checked="@IsCompleted" />

@functions {
    [Parameter]
    private bool IsCompleted { get; set; }
}
```

If `IsCompleted` is `true`, the check box is rendered as:

```html
<input type="checkbox" checked />
```

If `IsCompleted` is `false`, the check box is rendered as:

```html
<input type="checkbox" />
```

**Additional information on Razor**

For more information on Razor, see the [Razor syntax reference](xref:mvc/views/razor).

## Raw HTML

Strings are normally rendered using DOM text nodes, which means that any markup they may contain is ignored and treated as literal text. To render raw HTML, wrap the HTML content in a `MarkupString` value. The value is parsed as HTML or SVG and inserted into the DOM.

> [!WARNING]
> Rendering raw HTML constructed from any untrusted source is a **security risk** and should be avoided!

The following example shows using the `MarkupString` type to add a block of static HTML content to the rendered output of a component:

```html
@((MarkupString)myMarkup)

@functions {
    string myMarkup = "<p class='markup'>This is a <em>markup string</em>.</p>";
}
```

## Templated components

Templated components are components that accept one or more UI templates as parameters, which can then be used as part of the component's rendering logic. Templated components allow you to author higher-level components that are more reusable than regular components. A couple of examples include:

* A table component that allows a user to specify templates for the table's header, rows, and footer.
* A list component that allows a user to specify a template for rendering items in a list.

### Template parameters

A templated component is defined by specifying one or more component parameters of type `RenderFragment` or `RenderFragment<T>`. A render fragment represents a segment of UI that is rendered by the component. A render fragment optionally takes a parameter that can be specified when the render fragment is invoked.

*Components/TableTemplate.cshtml*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Components/TableTemplate.cshtml)]

When using a templated component, the template parameters can be specified using child elements that match the names of the parameters (`TableHeader` and `RowTemplate` in the following example):

```cshtml
<TableTemplate Items="@pets">
    <TableHeader>
        <th>ID</th>
        <th>Name</th>
    </TableHeader>
    <RowTemplate>
        <td>@context.PetId</td>
        <td>@context.Name</td>
    </RowTemplate>
</TableTemplate>
```

### Template context parameters

Component arguments of type `RenderFragment<T>` passed as elements have an implicit parameter named `context` (for example from the preceding code sample, `@context.PetId`), but you can change the parameter name using the `Context` attribute on the child element. In the following example, the `RowTemplate` element's `Context` attribute specifies the `pet` parameter:

```cshtml
<TableTemplate Items="@pets">
    <TableHeader>
        <th>ID</th>
        <th>Name</th>
    </TableHeader>
    <RowTemplate Context="pet">
        <td>@pet.PetId</td>
        <td>@pet.Name</td>
    </RowTemplate>
</TableTemplate>
```

Alternatively, you can specify the `Context` attribute on the component element. The specified `Context` attribute applies to all specified template parameters. This can be useful when you want to specify the content parameter name for implicit child content (without any wrapping child element). In the following example, the `Context` attribute appears on the `TableTemplate` element and applies to all template parameters:

```cshtml
<TableTemplate Items="@pets" Context="pet">
    <TableHeader>
        <th>ID</th>
        <th>Name</th>
    </TableHeader>
    <RowTemplate>
        <td>@pet.PetId</td>
        <td>@pet.Name</td>
    </RowTemplate>
</TableTemplate>
```

### Generic-typed components

Templated components are often generically typed. For example, a generic List View Template component can be used to render `IEnumerable<T>` values. To define a generic component, use the `@typeparam` directive to specify type parameters.

*Components/ListViewTemplate.cshtml*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Components/ListViewTemplate.cshtml?highlight=1)]

When using generic-typed components, the type parameter is inferred if possible:

```cshtml
<ListViewTemplate Items="@pets">
    <ItemTemplate Context="pet">
        <li>@pet.Name</li>
    </ItemTemplate>
</ListViewTemplate>
```

Otherwise, the type parameter must be explicitly specified using an attribute that matches the name of the type parameter. In the following example, `TItem="Pet"` specifies the type:

```cshtml
<ListViewTemplate Items="@pets" TItem="Pet">
    <ItemTemplate Context="pet">
        <li>@pet.Name</li>
    </ItemTemplate>
</ListViewTemplate>
```

## Cascading values and parameters

In some scenarios, it's inconvenient to flow data from an ancestor component to a descendent component using [component parameters](#component-parameters), especially when there are several component layers. Cascading values and parameters solve this problem by providing a convenient way for an ancestor component to provide a value to all of its descendent components. Cascading values and parameters also provide an approach for components to coordinate.

### Theme example

In the following *Theme* example from the sample app, the `ThemeInfo` class specifies the theme information to flow down the component hierarchy so that all of the buttons within a given part of the app share the same style.

*UIThemeClasses/ThemeInfo.cs*:

```csharp
public class ThemeInfo
{
    public string ButtonClass { get; set; }
}
```

An ancestor component can provide a cascading value using the Cascading Value component. The Cascading Value component wraps a subtree of the component hierarchy and supplies a single value to all components within that subtree.

For example, the sample app specifies theme information (`ThemeInfo`) in one of the app's layouts as a cascading parameter for all components that make up the layout body of the `@Body` property. `ButtonClass` is assigned a value of `btn-success` in the layout component. Any descendent component can consume this property through the `ThemeInfo` cascading object.

*Shared/CascadingValuesParametersLayout.cshtml*:

```cshtml
@inherits LayoutComponentBase
@using BlazorSample.UIThemeClasses

<div class="container-fluid">
    <div class="row">
        <div class="col-sm-3">
            <NavMenu />
        </div>
        <div class="col-sm-9">
            <CascadingValue Value="@theme">
                <div class="content px-4">
                    @Body
                </div>
            </CascadingValue>
        </div>
    </div>
</div>

@functions {
    ThemeInfo theme = new ThemeInfo { ButtonClass = "btn-success" };
}
```

To make use of cascading values, components declare cascading parameters using the `[CascadingParameter]` attribute or based on a string name value:

```cshtml
<CascadingValue Value=@PermInfo Name="UserPermissions">...</CascadingValue>

[CascadingParameter(Name = "UserPermissions")] PermInfo Permissions { get; set; }
```

Binding with a string name value is relevant if you have multiple cascading values of the same type and need to differentiate them within the same subtree.

Cascading values are bound to cascading parameters by type.

In the sample app, the Cascading Values Parameters Theme component binds to the `ThemeInfo` cascading value to a cascading parameter. The parameter is used to set the CSS class for one of the buttons displayed by the component.

*Pages/CascadingValuesParametersTheme.cshtml*:

```cshtml
@page "/cascadingvaluesparameterstheme"
@layout CascadingValuesParametersLayout
@using BlazorSample.UIThemeClasses

<h1>Cascading Values & Parameters</h1>

<p>Current count: @currentCount</p>

<p>
    <button class="btn" onclick="@IncrementCount">
        Increment Counter (Unthemed)
    </button>
</p>

<p>
    <button class="btn @ThemeInfo.ButtonClass" onclick="@IncrementCount">
        Increment Counter (Themed)
    </button>
</p>

@functions {
    int currentCount = 0;

    [CascadingParameter] protected ThemeInfo ThemeInfo { get; set; }

    void IncrementCount()
    {
        currentCount++;
    }
}
```

### TabSet example

Cascading parameters also enable components to collaborate across the component hierarchy. For example, consider the following *TabSet* example in the sample app.

The sample app has an `ITab` interface that tabs implement:

[!code-cs[](common/samples/3.x/BlazorSample/UIInterfaces/ITab.cs)]

The Cascading Values Parameters TabSet component uses the Tab Set component, which contains several Tab components:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/CascadingValuesParametersTabSet.cshtml?name=snippet_TabSet)]

The child Tab components aren't explicitly passed as parameters to the Tab Set. Instead, the child Tab components are part of the child content of the Tab Set. However, the Tab Set still needs to know about each Tab component so that it can render the headers and the active tab. To enable this coordination without requiring additional code, the Tab Set component *can provide itself as a cascading value* that is then picked up by the descendent Tab components.

*Components/TabSet.cshtml*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Components/TabSet.cshtml)]

The descendent Tab components capture the containing Tab Set as a cascading parameter, so the Tab components add themselves to the Tab Set and coordinate on which tab is active.

*Components/Tab.cshtml*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Components/Tab.cshtml)]

## Razor templates

Render fragments can be defined using Razor template syntax. Razor templates are a way to define a UI snippet and assume the following format:

```cshtml
@<tag>...</tag>
```

The following example illustrates how to specify `RenderFragment` and `RenderFragment<T>` values.

*RazorTemplates.cshtml*:

```cshtml
@{
    RenderFragment template = @<p>The time is @DateTime.Now.</p>;
    RenderFragment<Pet> petTemplate = (pet) => @<p>Your pet's name is @pet.Name.</p>;
}
```

Render fragments defined using Razor templates can be passed as arguments to templated components or rendered directly. For example, the previous templates are directly rendered with the following Razor markup:

```cshtml
@template

@petTemplate(new Pet { Name = "Rex" })
```

Rendered output:

```
The time is 10/04/2018 01:26:52.

Your pet's name is Rex.
```
