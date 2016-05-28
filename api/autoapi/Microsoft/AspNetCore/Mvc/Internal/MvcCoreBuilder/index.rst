

MvcCoreBuilder Class
====================






Allows fine grained configuration of essential MVC services.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.MvcCoreBuilder`








Syntax
------

.. code-block:: csharp

    public class MvcCoreBuilder : IMvcCoreBuilder








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreBuilder

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreBuilder.PartManager
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    
        
        .. code-block:: csharp
    
            public ApplicationPartManager PartManager
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreBuilder.Services
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public IServiceCollection Services
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreBuilder.MvcCoreBuilder(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Mvc.Internal.MvcCoreBuilder` instance.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param manager: The :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` of the application.
        
        :type manager: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    
        
        .. code-block:: csharp
    
            public MvcCoreBuilder(IServiceCollection services, ApplicationPartManager manager)
    

