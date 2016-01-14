

Enumerator Struct
=================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public struct Enumerator : IEnumerator<StringSegment>, IDisposable, IEnumerator





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Internal/PathTokenizer.cs>`_





.. dn:structure:: Microsoft.AspNet.Routing.Internal.PathTokenizer.Enumerator

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Routing.Internal.PathTokenizer.Enumerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Internal.PathTokenizer.Enumerator.Enumerator(Microsoft.AspNet.Routing.Internal.PathTokenizer)
    
        
        
        
        :type tokenizer: Microsoft.AspNet.Routing.Internal.PathTokenizer
    
        
        .. code-block:: csharp
    
           public Enumerator(PathTokenizer tokenizer)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Routing.Internal.PathTokenizer.Enumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Internal.PathTokenizer.Enumerator.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Routing.Internal.PathTokenizer.Enumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNet.Routing.Internal.PathTokenizer.Enumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
           public void Reset()
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Routing.Internal.PathTokenizer.Enumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Internal.PathTokenizer.Enumerator.Current
    
        
        :rtype: Microsoft.Extensions.Primitives.StringSegment
    
        
        .. code-block:: csharp
    
           public StringSegment Current { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Internal.PathTokenizer.Enumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           object IEnumerator.Current { get; }
    

