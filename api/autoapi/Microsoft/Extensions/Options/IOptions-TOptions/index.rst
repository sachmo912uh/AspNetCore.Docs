

IOptions<TOptions> Interface
============================





Namespace
    :dn:ns:`Microsoft.Extensions.Options`
Assemblies
    * Microsoft.Extensions.Options

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IOptions<out TOptions>
        where TOptions : class, new ()








.. dn:interface:: Microsoft.Extensions.Options.IOptions`1
    :hidden:

.. dn:interface:: Microsoft.Extensions.Options.IOptions<TOptions>

Properties
----------

.. dn:interface:: Microsoft.Extensions.Options.IOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Options.IOptions<TOptions>.Value
    
        
        :rtype: TOptions
    
        
        .. code-block:: csharp
    
            TOptions Value
            {
                get;
            }
    

