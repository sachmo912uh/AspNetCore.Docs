

BodyModelBinderProvider Class
=============================






An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider` for deserializing the request body using a formatter.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinderProvider`








Syntax
------

.. code-block:: csharp

    public class BodyModelBinderProvider : IModelBinderProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinderProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinderProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinderProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinderProvider.BodyModelBinderProvider(Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinderProvider`\.
    
        
    
        
        :param readerFactory: The :any:`Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory`\.
        
        :type readerFactory: Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory
    
        
        .. code-block:: csharp
    
            public BodyModelBinderProvider(IHttpRequestStreamReaderFactory readerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinderProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinderProvider.GetBinder(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    
        
        .. code-block:: csharp
    
            public IModelBinder GetBinder(ModelBinderProviderContext context)
    

