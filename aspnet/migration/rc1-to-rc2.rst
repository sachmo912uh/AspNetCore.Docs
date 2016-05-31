Migrating from ASP.NET 5 RC1 to ASP.NET Core
============================================

By `Rachel Appel`_

.. contents:: Sections:
  :local:
  :depth: 1  

Overview
--------

This migration guide covers migrating an ASP.NET 5 RC1 application to ASP.NET Core.

ASP.NET 5 RC1 apps were based on the .NET Execution Environment (DNX) and made use of DNX specific features. ASP.NET Core RC2 is based on .NET Core, so you must first migrate your application to the new .NET Core project model. See `migrating from DNX to .NET Core CLI <http://dotnet.github.io/docs/core-concepts/dnx-migration.html>`_ for more information.

For information regarding a complete list of breaking changes in RC2 for ASP.NET Core, see the `ASP.NET Core Announcements page <https://github.com/aspnet/announcements/issues?q=is%3Aopen+is%3Aissue+milestone%3A1.0.0-rc2>`_

For information on migrating Entity Framework 7 to Entity Framework Core, see the `EF Migration document <https://docs.efproject.net/en/latest/miscellaneous/rc1-rc2-upgrade.html>`_

Specify the .NET Core SDK version
---------------------------------

You must update the SDK version in ``global.json``, as this file is used to configure the version of the .NET Core SDK to use during development.

.. code-block:: json

  {
    "projects": [ "src", "test" ],
    "sdk": {
      "version": "1.0.0-preview1-002702"
    }
  }

Namespace and package ID changes
---------------------------------- 

ASP.NET 5 was renamed to ASP.NET Core 1.0. Also, MVC and Identity are now part of ASP.NET Core. ASP.NET MVC 6 is now ASP.NET Core MVC. ASP.NET Identity 3 is now ASP.NET Core Identity.

All Microsoft.AspNet.\* packages and namespaces are renamed to Microsoft.AspNetCore.\*. 
The EntityFramework.\* packages and namespaces are changing to Microsoft.EntityFrameworkCore.\*.
All ASP.NET Core package versions are now 1.0.0-\*.
Microsoft.Data.Entity.* is now Microsoft.EntityFrameworkCore.*

Creating your web application host
----------------------------------

Since ASP.NET Core apps are just console apps, you must define an entry point for your application in ``Program.Main()`` that sets up a web host. Then tell the host to start listening. Below is an example of the startup code for the built-in `Web Application` template in Visual Studio.

.. code-block:: c#

  public class Program
  {
    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();

        host.Run();
    }
  }

The application base path is now called the content root. 

The web root of your application is no longer specified in your project.json file. It is instead defined when setting up the web host and defaults to wwwroot. Call the ``UseWebRoot`` method to specify a web root folder. Alternatively you can enable specifying the web root folder in configuration by calling the ``UseConfiguration`` method. Similarly the server URLs that your application listens on can be specified using the ``UseUrls`` method or through configuration.

Additionally, you must turn on server garbage collection in ``project.json`` or, ``app.config`` when running ASP.NET projects on the full .NET framework.

.. code-block:: json

  {
    "runtimeOptions": {
      "configProperties": {
        "System.GC.Server": true
      }
    }
  }

The default server URL and port are ``localhost:5000``. You can find more information about Garbage Collection configuration at: https://github.com/aspnet/Announcements/issues/175

All classes prefixed with WebApplication have been renamed to WebHost. This includes:

===========================    =========================
RC1                            RC2
===========================    =========================
IWebApplicationBuilder         IWebHostBuilder
WebApplicationBuilder          WebHostBuilder
IWebApplication                IWebHost
WebApplication                 WebHost
WebApplicationOptions          WebHostOptions
WebApplicationDefaults         WebHostDefaults
WebApplicationService          WebHostService
WebApplicationConfiguration    WebHostConfiguration
===========================    =========================

The ``commands`` section of ``project.json`` has been removed completely. Use ``dotnet run`` or ``dotnet <dllname>`` instead.

Hosting Configuration 
---------------------
You enable configuration for your web application host by calling the ``UseConfiguration()`` method on ``WebHostBuilder`` and passing a configuration instance. The following configuration values can be specified:

- application
- startupAssembly
- detailedErrors
- server
- webroot
- captureStartupErrors
- server.urls
- contentRoot

To configure hosting using environmental variables, you must add them as a configuration source, and optionally specify a prefix. In RC2, you can use whatever prefix you want. You should add it explicitly by calling:

.. code-block:: c#

  new ConfigurationBuilder.AddEnvironmentVariables("ANY_PREFIX_YOU_WANT_").Build(); 
  
However, there is an exception. You must set the environment key using ASPNETCORE_ENVIRONMENT. This is picked up by default by the WebHostBuilder, unlike the other variables. We still support ASPNET_ENV and Hosting:Environment in RC2, but the user will see a message indicating these values are deprecated.

Hosting Service changes
-----------------------

You must modify code in the ``Startup`` class that uses ``IApplicationEnvironment`` to use ``IHostingEnvironment``:

Change:

.. code-block:: c# 

  public Startup(IApplicationEnvironment applicationEnvironment)
  {
     var builder = new ConfigurationBuilder()
       .SetBasePath(applicationEnvironment.ApplicationBasePath);
  }

To: 

.. code-block:: c#

  public Startup(IHostingEnvironment hostingEnvironment)
  {
     var builder = new ConfigurationBuilder()
      .SetBasePath(hostingEnvironment.ContentRootPath);
  }

 
Working with IIS
----------------

The package ID ``Microsoft.AspNetCore.IISPlatformHandler`` is now ``Microsoft.AspNetCore.Server.IISIntegration``.

HttpPlatformHandler was replaced by ASP.NET Core Module. The ``web.config`` created by the Publish IIS tool now configures IIS to use ASP.NET Core Module instead of HttpPlatformHandler to reverse-proxy requests to Kestrel.

The ASP.NET Core Module must be configured in ``web.config``:

.. code-block:: Xml
  
  <configuration>
    <system.webServer>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" 
		modules="AspNetCoreModule" resourceType="Unspecified"/>
      </handlers>
      <aspNetCore processPath="%LAUNCHER_PATH%" arguments="%LAUNCHER_ARGS%" 
	  stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" 
	  forwardWindowsAuthToken="false"/>
    </system.webServer>
  </configuration>

The Publish IIS tool can generate the correct ``web.config`` for you when you publish. See :doc:`/publishing/iis` for more details.

IIS integration middleware is now setup using ``WebHostBuilder`` in ``Program.Main()``, and is no longer called in the ``Configure()`` method of the ``Startup`` class. 

.. code-block:: c#

  public static void Main(string[] args)
  {
    var host = new WebHostBuilder().UseIISIntegration().Build();
  }
  

Web Deploy changes
^^^^^^^^^^^^^^^^^^^^^^^  

Delete ``RC1StarterWeb - Web Deploy-publish.ps1``. This is a script generated by VS for web deploy. There is a version for RC1 projects (dnx based) and a different script for RC2 projects (dotnet based) which are incompatible with each other. As such, when migrating to RC2, you need to delete the old script and let VS generate a new one to ensure web deploy works for the converted RC2 project.
  
  
Applicationhost.config
^^^^^^^^^^^^^^^^^^^^^^

If ``applicationhost.config`` was created with RC1 or early RC2 it will point to a wrong application folder. The ``applicationhost.config`` file will read ``wwwroot`` as the application folder and this is where IIS will look for ``web.config`` file. However, since the ``web.config`` file now goes in the ``approot``, IIS won't find the file and the user may not be able to start the appliation with IIS.

MVC
---

To compile views, set the ``preserveCompilationContext`` option in ``project.json`` to preserve the compilation context, as shown here:

.. code-block:: json 

  {
  "buildOptions": {
    "emitEntryPoint": true,
    "preserveCompilationContext": true
  },

You no longer need to reference the Tag Helper package ``Microsoft.AspNetCore.Mvc.TagHelpers``, which was renamed to ``Microsoft.AspNetCore.Mvc.TagHelpers`` in RC2. The package is now referenced by MVC by default.

Controller and action results renamed
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The following methods on the ``Controller`` base class have been renamed.

==================================  ==================
RC1                                 RC2
==================================  ==================
HttpUnauthorized                    Unauthorized   
HttpNotFound (and its overloads)    NotFound
HttpBadRequest (and its overloads)  BadRequest
==================================  ==================

The following action result types have also been renamed. 

===================================================  ===================================================
RC1                                                  RC2
===================================================  ===================================================
Microsoft.AspNetCore.Mvc.HttpUnauthorizedResult      Microsoft.AspNetCore.Mvc.UnauthorizedResult
Microsoft.AspNetCore.Mvc.HttpOkResult                Microsoft.AspNetCore.Mvc.OkResult
Microsoft.AspNetCore.Mvc.HttpOkObjectResult          Microsoft.AspNetCore.Mvc.OkObjectResult
Microsoft.AspNetCore.Mvc.HttpNotFoundResult          Microsoft.AspNetCore.Mvc.NotFoundResult
Microsoft.AspNetCore.Mvc.HttpNotFoundObjectResult    Microsoft.AspNetCore.Mvc.NotFoundObjectResult
Microsoft.AspNetCore.Mvc.HttpStatusCodeResult        Microsoft.AspNetCore.Mvc.StatusCodeResult
===================================================  ===================================================

Changes in views
^^^^^^^^^^^^^^^^

Views now support relative paths. 

The Validation Summary Tag Helper has changed. 

RC1:

.. code-block:: html 

  <div asp-validation-summary="ValidationSummary.All" class="text-danger"></div> 

RC2:

.. code-block:: html

  <div asp-validation-summary="All" class="text-danger"></div>

ViewComponents changes
^^^^^^^^^^^^^^^^^^^^^^

The sync APIs have been removed.

To reduce ambiguity in ViewComponent method selection, we've modified the selection to only allow exactly one ``Invoke()`` or ``InvokeAsync()`` per ViewComponent.
``Component.Render()``, ``Component.RenderAsync()``, and ``Component.Invoke()`` have been removed.

``InvokeAsync()`` now takes an anonynmous object instead of separate parameters. To use the view component, call @Component.InvokeAsync("Name of view component", <parameters>) from a view. The parameters will be passed to the ``InvokeAsync()`` method. The following example demonstrates the ``InvokeAsync()`` method call with two parameters:

.. code-block:: c#  

  // RC1 signature 
  @Component.InvokeAsync("Test", "MyName", 15)  

  // RC2 signatures
  @Component.InvokeAsync("Test", new { name = "MyName", age = 15 })
 
  @Component.InvokeAsync("Test", new Dictionary<string, object> { ["name"] = "MyName", ["age"] = 15 })

  @Component.InvokeAsync<TestViewComponent>(new { name = "MyName", age = 15})

Updated controller discovery rules
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

There are changes that simplify controller discovery:

There is a new ``Controller`` attribute that can be used to mark a class and their descendants as controllers.
Classes whose name doesn't end in ``Controller`` and derive from a base class that ends in ``Controller`` are no longer considered controllers. In this scenario the ``[Controller]`` attribute must be applied to the ``Controller`` class itself or to the base class.

We now consider a type to be a controller if all of the following rules apply:

- The type is a public, concrete, non open generic class.
- [NonController] is not applied to any type of the hierarchy.
- The type name ends with ``Controller``, or if the ``[Controller]`` attribute is applied to the type or to one of its ancestors.
- It's important to note that if ``[NonController]`` is applied anywhere in the type hierarchy the discovery conventions will never consider that type or its descendants to be a controller. ``[NonController]`` takes precedence over ``[Controller]``.

Configuration
-------------

``IConfigurationSource`` has been introduced to represent the settings/configuration which is used to ``Build()`` an ``IConfigurationProvider``. It is no longer possible to access the provider instances from ``IConfigurationBuilder`` only the sources. This is intentional, but may cause loss of functionality as you can longer do things like explicitly call ``Load`` on the provider instances.

``FileConfigurationProvider`` base class has been introduced as a common root for JSON/XML/INI providers. This allows the ability to specify an ``IFileProvider`` on the source which will be used to read the file instead of explicitly using ``File.Open()``. The side effect of this change is that absolute paths are no longer supported. The file path must be relative to the base path of the ``IConfigurationBuilder``'s basepath or the ``IFileProvider``, if specified.

JSON configuration syntax change 
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

``ConfigurationRoot.ReloadOnChanged()`` is no longer available, it is added explicitly via ``ConfigurationBuilder.AddJsonFile()``.
	   
Logging
-------

Logging extensions have been simplified and clarified. ``Verbose`` has been renamed to ``Trace`` and has had its severity reduced to below ``Debug``. As a comparison before and after the change, the values of ``LogLevel`` are listed here with the most severe level at the top:

=============  =============
Old Levels	   New Levels
=============  =============
Critical	   Critical
Error	       Error
Warning	       Warning
Information	   Information
Verbose	       Debug
Debug	       Trace
=============  =============

``ILoggerFactory`` no longer contains ``AddConsole``.

Identity 
--------

The signatures for the following methods or properties have changed:

===============================================================  ===========================================
RC1                                                              RC2
===============================================================  ===========================================
ExternalLoginInfo.ExternalPrincipal                              ExternalLoginInfo.Principal
User.IsSignedIn()                                                SignInManager.IsSignedIn(User)
await UserManager.FindByIdAsync(HttpContext.User.GetUserId())    UserManager.GetUserAsync(HttpContext.User)
User.GetUserId()                                                 UserManager.GetUserId(User)
===============================================================  ===========================================

To use the Identity API in views, add the following directives to the view:

.. code-block:: c#  

  @using Microsoft.AspNetCore.Identity
  @inject SignInManager SignInManager
  @inject UserManager UserManager

Updating Launch Settings in Visual Studio
-----------------------------------------

Update ``launchSettings.json`` to remove web target and add the following:

.. code-block:: c# 

  "WebApplication1": {
     "commandName": "Project",
     "launchBrowser": true,
     "launchUrl": "http://localhost:5000",
     "environmentVariables": {
       "ASPNETCORE_ENVIRONMENT": "Development"
     }
  } 
