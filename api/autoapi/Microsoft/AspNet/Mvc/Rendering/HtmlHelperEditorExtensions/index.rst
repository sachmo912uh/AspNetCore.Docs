

HtmlHelperEditorExtensions Class
================================



.. contents:: 
   :local:



Summary
-------

Editor-related extensions for :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper` and :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper\`1`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions`








Syntax
------

.. code-block:: csharp

   public class HtmlHelperEditorExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/HtmlHelperEditorExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.Editor(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns HTML markup for the ``expression``, using an editor template. The template is found
        using the ``expression``'s :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model. May identify a single property or an
            that contains the properties to edit.
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Editor(IHtmlHelper htmlHelper, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.Editor(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns HTML markup for the ``expression``, using an editor template and specified
        additional view data. The template is found using the ``expression``'s 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model. May identify a single property or an
            that contains the properties to edit.
        
        :type expression: System.String
        
        
        :param additionalViewData: An anonymous  or
            that can contain additional view data that will be merged into the
            instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Editor(IHtmlHelper htmlHelper, string expression, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.Editor(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        Returns HTML markup for the ``expression``, using an editor template. The template is found
        using the ``templateName`` or the ``expression``'s 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model. May identify a single property or an
            that contains the properties to edit.
        
        :type expression: System.String
        
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Editor(IHtmlHelper htmlHelper, string expression, string templateName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.Editor(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        Returns HTML markup for the ``expression``, using an editor template and specified
        additional view data. The template is found using the ``templateName`` or the
        ``expression``'s :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model. May identify a single property or an
            that contains the properties to edit.
        
        :type expression: System.String
        
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
        
        
        :param additionalViewData: An anonymous  or
            that can contain additional view data that will be merged into the
            instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Editor(IHtmlHelper htmlHelper, string expression, string templateName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.Editor(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.String)
    
        
    
        Returns HTML markup for the ``expression``, using an editor template and specified HTML
        field name. The template is found using the ``templateName`` or the
        ``expression``'s :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param expression: Expression name, relative to the current model. May identify a single property or an
            that contains the properties to edit.
        
        :type expression: System.String
        
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
        
        
        :param htmlFieldName: A  used to disambiguate the names of HTML elements that are created for
            properties that have the same name.
        
        :type htmlFieldName: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent Editor(IHtmlHelper htmlHelper, string expression, string templateName, string htmlFieldName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper)
    
        
    
        Returns HTML markup for the current model, using an editor template. The template is found using the
        model's :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent EditorForModel(IHtmlHelper htmlHelper)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.Object)
    
        
    
        Returns HTML markup for the current model, using an editor template and specified additional view data. The
        template is found using the model's :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param additionalViewData: An anonymous  or
            that can contain additional view data that will be merged into the
            instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent EditorForModel(IHtmlHelper htmlHelper, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String)
    
        
    
        Returns HTML markup for the current model, using an editor template. The template is found using the
        ``templateName`` or the model's :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent EditorForModel(IHtmlHelper htmlHelper, string templateName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.Object)
    
        
    
        Returns HTML markup for the current model, using an editor template and specified additional view data. The
        template is found using the ``templateName`` or the model's 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
        
        
        :param additionalViewData: An anonymous  or
            that can contain additional view data that will be merged into the
            instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent EditorForModel(IHtmlHelper htmlHelper, string templateName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String)
    
        
    
        Returns HTML markup for the current model, using an editor template and specified HTML field name. The
        template is found using the ``templateName`` or the model's 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
        
        
        :param htmlFieldName: A  used to disambiguate the names of HTML elements that are created for
            properties that have the same name.
        
        :type htmlFieldName: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent EditorForModel(IHtmlHelper htmlHelper, string templateName, string htmlFieldName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper, System.String, System.String, System.Object)
    
        
    
        Returns HTML markup for the current model, using an editor template, specified HTML field name, and
        additional view data. The template is found using the ``templateName`` or the model's 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper
        
        
        :param templateName: The name of the template used to create the HTML markup.
        
        :type templateName: System.String
        
        
        :param htmlFieldName: A  used to disambiguate the names of HTML elements that are created for
            properties that have the same name.
        
        :type htmlFieldName: System.String
        
        
        :param additionalViewData: An anonymous  or
            that can contain additional view data that will be merged into the
            instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent EditorForModel(IHtmlHelper htmlHelper, string templateName, string htmlFieldName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.EditorFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>)
    
        
    
        Returns HTML markup for the ``expression``, using an editor template. The template is found
        using the ``expression``'s :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent EditorFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.EditorFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.Object)
    
        
    
        Returns HTML markup for the ``expression``, using an editor template and specified
        additional view data. The template is found using the ``expression``'s 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param additionalViewData: An anonymous  or
            that can contain additional view data that will be merged into the
            instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent EditorFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.EditorFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String)
    
        
    
        Returns HTML markup for the ``expression``, using an editor template. The template is found
        using the ``templateName`` or the ``expression``'s 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param templateName: The name of the template that is used to create the HTML markup.
        
        :type templateName: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent EditorFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string templateName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.EditorFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.Object)
    
        
    
        Returns HTML markup for the ``expression``, using an editor template and specified
        additional view data. The template is found using the ``templateName`` or the
        ``expression``'s :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param templateName: The name of the template that is used to create the HTML markup.
        
        :type templateName: System.String
        
        
        :param additionalViewData: An anonymous  or
            that can contain additional view data that will be merged into the
            instance created for the template.
        
        :type additionalViewData: System.Object
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent EditorFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string templateName, object additionalViewData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.HtmlHelperEditorExtensions.EditorFor<TModel, TResult>(Microsoft.AspNet.Mvc.Rendering.IHtmlHelper<TModel>, System.Linq.Expressions.Expression<System.Func<TModel, TResult>>, System.String, System.String)
    
        
    
        Returns HTML markup for the ``expression``, using an editor template and specified HTML
        field name. The template is found using the ``templateName`` or the
        ``expression``'s :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :param htmlHelper: The  instance this method extends.
        
        :type htmlHelper: Microsoft.AspNet.Mvc.Rendering.IHtmlHelper{{TModel}}
        
        
        :param expression: An expression to be evaluated against the current model.
        
        :type expression: System.Linq.Expressions.Expression{System.Func{{TModel},{TResult}}}
        
        
        :param templateName: The name of the template that is used to create the HTML markup.
        
        :type templateName: System.String
        
        
        :param htmlFieldName: A  used to disambiguate the names of HTML elements that are created for properties
            that have the same name.
        
        :type htmlFieldName: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :return: A new <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContent" /> containing the &lt;input&gt; element(s).
    
        
        .. code-block:: csharp
    
           public static IHtmlContent EditorFor<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string templateName, string htmlFieldName)
    

