

AnsiLogConsole Class
====================






For non-Windows platform consoles which understand the ANSI escape code sequences to represent color


Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Console.Internal`
Assemblies
    * Microsoft.Extensions.Logging.Console

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Console.Internal.AnsiLogConsole`








Syntax
------

.. code-block:: csharp

    public class AnsiLogConsole : IConsole








.. dn:class:: Microsoft.Extensions.Logging.Console.Internal.AnsiLogConsole
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Console.Internal.AnsiLogConsole

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Console.Internal.AnsiLogConsole
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Console.Internal.AnsiLogConsole.AnsiLogConsole(Microsoft.Extensions.Logging.Console.Internal.IAnsiSystemConsole)
    
        
    
        
        :type systemConsole: Microsoft.Extensions.Logging.Console.Internal.IAnsiSystemConsole
    
        
        .. code-block:: csharp
    
            public AnsiLogConsole(IAnsiSystemConsole systemConsole)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Console.Internal.AnsiLogConsole
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Console.Internal.AnsiLogConsole.Flush()
    
        
    
        
        .. code-block:: csharp
    
            public void Flush()
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.Internal.AnsiLogConsole.Write(System.String, System.Nullable<System.ConsoleColor>, System.Nullable<System.ConsoleColor>)
    
        
    
        
        :type message: System.String
    
        
        :type background: System.Nullable<System.Nullable`1>{System.ConsoleColor<System.ConsoleColor>}
    
        
        :type foreground: System.Nullable<System.Nullable`1>{System.ConsoleColor<System.ConsoleColor>}
    
        
        .. code-block:: csharp
    
            public void Write(string message, ConsoleColor? background, ConsoleColor? foreground)
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.Internal.AnsiLogConsole.WriteLine(System.String, System.Nullable<System.ConsoleColor>, System.Nullable<System.ConsoleColor>)
    
        
    
        
        :type message: System.String
    
        
        :type background: System.Nullable<System.Nullable`1>{System.ConsoleColor<System.ConsoleColor>}
    
        
        :type foreground: System.Nullable<System.Nullable`1>{System.ConsoleColor<System.ConsoleColor>}
    
        
        .. code-block:: csharp
    
            public void WriteLine(string message, ConsoleColor? background, ConsoleColor? foreground)
    

