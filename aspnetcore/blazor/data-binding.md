---
title: ASP.NET Core Blazor data binding
author: guardrex
description: Learn about data binding scenarios for components and DOM elements in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/12/2020
no-loc: [Blazor, SignalR]
uid: blazor/data-binding
---
# ASP.NET Core Blazor data binding

By [Luke Latham](https://github.com/guardrex) and [Daniel Roth](https://github.com/danroth27)

Data binding to both components and DOM elements is accomplished with the [`@bind`](xref:mvc/views/razor#bind) attribute. The following example binds a `CurrentValue` property to the text box's value:

```razor
<input @bind="CurrentValue" />

@code {
    private string CurrentValue { get; set; }
}
```

When the text box loses focus, the property's value is updated.

The text box is updated in the UI only when the component is rendered, not in response to changing the property's value. Since components render themselves after event handler code executes, property updates are *usually* reflected in the UI immediately after an event handler is triggered.

Using `@bind` with the `CurrentValue` property (`<input @bind="CurrentValue" />`) is essentially equivalent to the following:

```razor
<input value="@CurrentValue"
    @onchange="@((ChangeEventArgs __e) => CurrentValue = 
        __e.Value.ToString())" />
        
@code {
    private string CurrentValue { get; set; }
}
```

When the component is rendered, the `value` of the input element comes from the `CurrentValue` property. When the user types in the text box and changes element focus, the `onchange` event is fired and the `CurrentValue` property is set to the changed value. In reality, the code generation is more complex because `@bind` handles cases where type conversions are performed. In principle, `@bind` associates the current value of an expression with a `value` attribute and handles changes using the registered handler.

In addition to handling `onchange` events with `@bind` syntax, a property or field can be bound using other events by specifying an [`@bind-value`](xref:mvc/views/razor#bind) attribute with an `event` parameter ([`@bind-value:event`](xref:mvc/views/razor#bind)). The following example binds the `CurrentValue` property for the `oninput` event:

```razor
<input @bind-value="CurrentValue" @bind-value:event="oninput" />

@code {
    private string CurrentValue { get; set; }
}
```

Unlike `onchange`, which fires when the element loses focus, `oninput` fires when the value of the text box changes.

`@bind-value` in the preceding example binds:

* The specified expression (`CurrentValue`) to the element's `value` attribute.
* A change event delegate to the event specified by `@bind-value:event`.

### Unparsable values

When a user provides an unparsable value to a databound element, the unparsable value is automatically reverted to its previous value when the bind event is triggered.

Consider the following scenario:

* An `<input>` element is bound to an `int` type with an initial value of `123`:

  ```razor
  <input @bind="MyProperty" />

  @code {
      [Parameter]
      public int MyProperty { get; set; } = 123;
  }
  ```
* The user updates the value of the element to `123.45` in the page and changes the element focus.

In the preceding scenario, the element's value is reverted to `123`. When the value `123.45` is rejected in favor of the original value of `123`, the user understands that their value wasn't accepted.

By default, binding applies to the element's `onchange` event (`@bind="{PROPERTY OR FIELD}"`). Use `@bind-value="{PROPERTY OR FIELD}" @bind-value:event={EVENT}` to set a different event. For the `oninput` event (`@bind-value:event="oninput"`), the reversion occurs after any keystroke that introduces an unparsable value. When targeting the `oninput` event with an `int`-bound type, a user is prevented from typing a `.` character. A `.` character is immediately removed, so the user receives immediate feedback that only whole numbers are permitted. There are scenarios where reverting the value on the `oninput` event isn't ideal, such as when the user should be allowed to clear an unparsable `<input>` value. Alternatives include:

* Don't use the `oninput` event. Use the default `onchange` event (`@bind="{PROPERTY OR FIELD}"`), where an invalid value isn't reverted until the element loses focus.
* Bind to a nullable type, such as `int?` or `string`, and provide custom logic to handle invalid entries.
* Use a [form validation component](xref:blazor/forms-validation), such as `InputNumber` or `InputDate`. Form validation components have built-in support to manage invalid inputs. Form validation components:
  * Permit the user to provide invalid input and receive validation errors on the associated `EditContext`.
  * Display validation errors in the UI without interfering with the user entering additional webform data.

### Format strings

Data binding works with <xref:System.DateTime> format strings using [`@bind:format`](xref:mvc/views/razor#bind). Other format expressions, such as currency or number formats, aren't available at this time.

```razor
<input @bind="StartDate" @bind:format="yyyy-MM-dd" />

@code {
    [Parameter]
    public DateTime StartDate { get; set; } = new DateTime(2020, 1, 1);
}
```

In the preceding code, the `<input>` element's field type (`type`) defaults to `text`. `@bind:format` is supported for binding the following .NET types:

* <xref:System.DateTime?displayProperty=fullName>
* <xref:System.DateTime?displayProperty=fullName>?
* <xref:System.DateTimeOffset?displayProperty=fullName>
* <xref:System.DateTimeOffset?displayProperty=fullName>?

The `@bind:format` attribute specifies the date format to apply to the `value` of the `<input>` element. The format is also used to parse the value when an `onchange` event occurs.

Specifying a format for the `date` field type isn't recommended because Blazor has built-in support to format dates. In spite of the recommendation, only use the `yyyy-MM-dd` date format for binding to work correctly if a format is supplied with the `date` field type:

```razor
<input type="date" @bind="StartDate" @bind:format="yyyy-MM-dd">
```

### Parent-to-child binding with component parameters

Binding recognizes component parameters, where `@bind-{property}` can bind a property value from a parent component down to a child component. Binding from a child to a parent is covered in the [Child-to-parent binding with chained bind](#child-to-parent-binding-with-chained-bind) section.

The following child component (`ChildComponent`) has a `Year` component parameter and `YearChanged` callback:

```razor
<h2>Child Component</h2>

<p>Year: @Year</p>

@code {
    [Parameter]
    public int Year { get; set; }

    [Parameter]
    public EventCallback<int> YearChanged { get; set; }
}
```

`EventCallback<T>` is explained in <xref:blazor/event-handling#eventcallback>.

The following parent component uses:

* `ChildComponent` and binds the `ParentYear` parameter from the parent to the `Year` parameter on the child component.
* The `onclick` event is used to trigger the `ChangeTheYear` method. For more information, see <xref:blazor/event-handling>.

```razor
@page "/ParentComponent"

<h1>Parent Component</h1>

<p>ParentYear: @ParentYear</p>

<ChildComponent @bind-Year="ParentYear" />

<button class="btn btn-primary" @onclick="ChangeTheYear">
    Change Year to 1986
</button>

@code {
    [Parameter]
    public int ParentYear { get; set; } = 1978;

    private void ChangeTheYear()
    {
        ParentYear = 1986;
    }
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

By convention, `<ChildComponent @bind-Year="ParentYear" />` is essentially equivalent to writing:

```razor
<ChildComponent @bind-Year="ParentYear" @bind-Year:event="YearChanged" />
```

In general, a property can be bound to a corresponding event handler using `@bind-property:event` attribute. For example, the property `MyProp` can be bound to `MyEventHandler` using the following two attributes:

```razor
<MyComponent @bind-MyProp="MyValue" @bind-MyProp:event="MyEventHandler" />
```

### Child-to-parent binding with chained bind

A common scenario is chaining a data-bound parameter to a page element in the component's output. This scenario is called a *chained bind* because multiple levels of binding occur simultaneously.

A chained bind can't be implemented with `@bind` syntax in the page's element. The event handler and value must be specified separately. A parent component, however, can use `@bind` syntax with the component's parameter.

The following `PasswordField` component (*PasswordField.razor*):

* Sets an `<input>` element's value to a `Password` property.
* Exposes changes of the `Password` property to a parent component with an [EventCallback](xref:blazor/event-handling#eventcallback).
* Uses the `onclick` event is used to trigger the `ToggleShowPassword` method. For more information, see <xref:blazor/event-handling>.

```razor
<h1>Child Component</h2>

Password: 

<input @oninput="OnPasswordChanged" 
       required 
       type="@(_showPassword ? "text" : "password")" 
       value="@Password" />

<button class="btn btn-primary" @onclick="ToggleShowPassword">
    Show password
</button>

@code {
    private bool _showPassword;

    [Parameter]
    public string Password { get; set; }

    [Parameter]
    public EventCallback<string> PasswordChanged { get; set; }

    private Task OnPasswordChanged(ChangeEventArgs e)
    {
        Password = e.Value.ToString();

        return PasswordChanged.InvokeAsync(Password);
    }

    private void ToggleShowPassword()
    {
        _showPassword = !_showPassword;
    }
}
```

The `PasswordField` component is used in another component:

```razor
@page "/ParentComponent"

<h1>Parent Component</h1>

<PasswordField @bind-Password="_password" />

@code {
    private string _password;
}
```

To perform checks or trap errors on the password in the preceding example:

* Create a backing field for `Password` (`_password` in the following example code).
* Perform the checks or trap errors in the `Password` setter.

The following example provides immediate feedback to the user if a space is used in the password's value:

```razor
@page "/ParentComponent"

<h1>Parent Component</h1>

Password: 

<input @oninput="OnPasswordChanged" 
       required 
       type="@(_showPassword ? "text" : "password")" 
       value="@Password" />

<button class="btn btn-primary" @onclick="ToggleShowPassword">
    Show password
</button>

<span class="text-danger">@_validationMessage</span>

@code {
    private bool _showPassword;
    private string _password;
    private string _validationMessage;

    [Parameter]
    public string Password
    {
        get { return _password ?? string.Empty; }
        set
        {
            if (_password != value)
            {
                if (value.Contains(' '))
                {
                    _validationMessage = "Spaces not allowed!";
                }
                else
                {
                    _password = value;
                    _validationMessage = string.Empty;
                }
            }
        }
    }

    [Parameter]
    public EventCallback<string> PasswordChanged { get; set; }

    private Task OnPasswordChanged(ChangeEventArgs e)
    {
        Password = e.Value.ToString();

        return PasswordChanged.InvokeAsync(Password);
    }

    private void ToggleShowPassword()
    {
        _showPassword = !_showPassword;
    }
}
```

### Radio buttons

For information on binding to radio buttons in a form, see <xref:blazor/forms-validation#work-with-radio-buttons>.
