

ConsoleLogScope Class
=====================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Console`
Assemblies
    * Microsoft.Extensions.Logging.Console

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Console.ConsoleLogScope`








Syntax
------

.. code-block:: csharp

    public class ConsoleLogScope








.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLogScope
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLogScope

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLogScope
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Console.ConsoleLogScope.Current
    
        
        :rtype: Microsoft.Extensions.Logging.Console.ConsoleLogScope
    
        
        .. code-block:: csharp
    
            public static ConsoleLogScope Current
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Logging.Console.ConsoleLogScope.Parent
    
        
        :rtype: Microsoft.Extensions.Logging.Console.ConsoleLogScope
    
        
        .. code-block:: csharp
    
            public ConsoleLogScope Parent
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLogScope
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Console.ConsoleLogScope.Push(System.String, System.Object)
    
        
    
        
        :type name: System.String
    
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public static IDisposable Push(string name, object state)
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.ConsoleLogScope.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

