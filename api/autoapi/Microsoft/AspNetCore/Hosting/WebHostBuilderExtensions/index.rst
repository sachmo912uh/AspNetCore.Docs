

WebHostBuilderExtensions Class
==============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class WebHostBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.CaptureStartupErrors(Microsoft.AspNetCore.Hosting.IWebHostBuilder, System.Boolean)
    
        
    
        
        Set whether startup errors should be captured in the configuration settings of the web host.
        When enabled, startup exceptions will be caught and an error page will be returned. If disabled, startup exceptions will be propagated.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param captureStartupErrors: <code>true</code> to use startup error page; otherwise <code>false</code>.
        
        :type captureStartupErrors: System.Boolean
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder CaptureStartupErrors(IWebHostBuilder hostBuilder, bool captureStartupErrors)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.Start(Microsoft.AspNetCore.Hosting.IWebHostBuilder, System.String[])
    
        
    
        
        Start the web host and listen on the speficied urls.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to start.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param urls: The urls the hosted application will listen on.
        
        :type urls: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Hosting.IWebHost
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHost Start(IWebHostBuilder hostBuilder, params string[] urls)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseConfiguration(Microsoft.AspNetCore.Hosting.IWebHostBuilder, Microsoft.Extensions.Configuration.IConfiguration)
    
        
    
        
        Use the given configuration settings on the web host.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param configuration: The :any:`Microsoft.Extensions.Configuration.IConfiguration` containing settings to be used.
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseConfiguration(IWebHostBuilder hostBuilder, IConfiguration configuration)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseContentRoot(Microsoft.AspNetCore.Hosting.IWebHostBuilder, System.String)
    
        
    
        
        Specify the content root directory to be used by the web host.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param contentRoot: Path to root directory of the application.
        
        :type contentRoot: System.String
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseContentRoot(IWebHostBuilder hostBuilder, string contentRoot)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseEnvironment(Microsoft.AspNetCore.Hosting.IWebHostBuilder, System.String)
    
        
    
        
        Specify the environment to be used by the web host.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param environment: The environment to host the application in.
        
        :type environment: System.String
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseEnvironment(IWebHostBuilder hostBuilder, string environment)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseServer(Microsoft.AspNetCore.Hosting.IWebHostBuilder, Microsoft.AspNetCore.Hosting.Server.IServer)
    
        
    
        
        Specify the server to be used by the web host.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param server: The :any:`Microsoft.AspNetCore.Hosting.Server.IServer` to be used.
        
        :type server: Microsoft.AspNetCore.Hosting.Server.IServer
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseServer(IWebHostBuilder hostBuilder, IServer server)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseServer(Microsoft.AspNetCore.Hosting.IWebHostBuilder, System.String)
    
        
    
        
        Specify the assembly containing the server to be used by the web host.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param assemblyName: The name of the assembly containing the server to be used.
        
        :type assemblyName: System.String
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseServer(IWebHostBuilder hostBuilder, string assemblyName)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup(Microsoft.AspNetCore.Hosting.IWebHostBuilder, System.String)
    
        
    
        
        Specify the assembly containing the startup type to be used by the web host.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param startupAssemblyName: The name of the assembly containing the startup type.
        
        :type startupAssemblyName: System.String
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseStartup(IWebHostBuilder hostBuilder, string startupAssemblyName)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup<TStartup>(Microsoft.AspNetCore.Hosting.IWebHostBuilder)
    
        
    
        
        Specify the startup type to be used by the web host.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseStartup<TStartup>(IWebHostBuilder hostBuilder)where TStartup : class
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseUrls(Microsoft.AspNetCore.Hosting.IWebHostBuilder, System.String[])
    
        
    
        
        Specify the urls the web host will listen on.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param urls: The urls the hosted application will listen on.
        
        :type urls: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseUrls(IWebHostBuilder hostBuilder, params string[] urls)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseWebRoot(Microsoft.AspNetCore.Hosting.IWebHostBuilder, System.String)
    
        
    
        
        Specify the webroot directory to be used by the web host.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param webRoot: Path to the root directory used by the web server.
        
        :type webRoot: System.String
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseWebRoot(IWebHostBuilder hostBuilder, string webRoot)
    

