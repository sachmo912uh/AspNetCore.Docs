

MessageBody Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody`








Syntax
------

.. code-block:: csharp

    public abstract class MessageBody








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody.RequestKeepAlive
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool RequestKeepAlive
            {
                get;
                protected set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody.MessageBody(Microsoft.AspNetCore.Server.Kestrel.Http.Frame)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Http.Frame
    
        
        .. code-block:: csharp
    
            protected MessageBody(Frame context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody.Consume(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Consume(CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody.For(System.String, Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestHeaders, Microsoft.AspNetCore.Server.Kestrel.Http.Frame)
    
        
    
        
        :type httpVersion: System.String
    
        
        :type headers: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestHeaders
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Http.Frame
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody
    
        
        .. code-block:: csharp
    
            public static MessageBody For(string httpVersion, FrameRequestHeaders headers, Frame context)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody.ReadAsync(System.ArraySegment<System.Byte>, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.ValueTask<System.Threading.Tasks.ValueTask`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public ValueTask<int> ReadAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody.ReadAsyncImplementation(System.ArraySegment<System.Byte>, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.ValueTask<System.Threading.Tasks.ValueTask`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public abstract ValueTask<int> ReadAsyncImplementation(ArraySegment<byte> buffer, CancellationToken cancellationToken)
    

