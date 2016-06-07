

SocketOutput Class
==================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput`








Syntax
------

.. code-block:: csharp

    public class SocketOutput : ISocketOutput








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput.SocketOutput(Microsoft.AspNetCore.Server.Kestrel.KestrelThread, Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool, Microsoft.AspNetCore.Server.Kestrel.Http.Connection, System.String, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IThreadPool, System.Collections.Generic.Queue<Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq>)
    
        
    
        
        :type thread: Microsoft.AspNetCore.Server.Kestrel.KestrelThread
    
        
        :type socket: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        :type memory: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool
    
        
        :type connection: Microsoft.AspNetCore.Server.Kestrel.Http.Connection
    
        
        :type connectionId: System.String
    
        
        :type log: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        :type threadPool: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IThreadPool
    
        
        :type writeReqPool: System.Collections.Generic.Queue<System.Collections.Generic.Queue`1>{Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq<Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq>}
    
        
        .. code-block:: csharp
    
            public SocketOutput(KestrelThread thread, UvStreamHandle socket, MemoryPool memory, Connection connection, string connectionId, IKestrelTrace log, IThreadPool threadPool, Queue<UvWriteReq> writeReqPool)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput.MaxPooledWriteReqs
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int MaxPooledWriteReqs = 1024
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput.End(Microsoft.AspNetCore.Server.Kestrel.Http.ProduceEndType)
    
        
    
        
        :type endType: Microsoft.AspNetCore.Server.Kestrel.Http.ProduceEndType
    
        
        .. code-block:: csharp
    
            public void End(ProduceEndType endType)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput.Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput.Write(System.ArraySegment<System.Byte>, System.Boolean)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type chunk: System.Boolean
    
        
        .. code-block:: csharp
    
            void ISocketOutput.Write(ArraySegment<byte> buffer, bool chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput.Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput.WriteAsync(System.ArraySegment<System.Byte>, System.Boolean, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type chunk: System.Boolean
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task ISocketOutput.WriteAsync(ArraySegment<byte> buffer, bool chunk, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput.ProducingComplete(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type end: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public void ProducingComplete(MemoryPoolIterator end)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput.ProducingStart()
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public MemoryPoolIterator ProducingStart()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.SocketOutput.WriteAsync(System.ArraySegment<System.Byte>, System.Threading.CancellationToken, System.Boolean, System.Boolean, System.Boolean, System.Boolean)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type cancellationToken: System.Threading.CancellationToken
    
        
        :type chunk: System.Boolean
    
        
        :type socketShutdownSend: System.Boolean
    
        
        :type socketDisconnect: System.Boolean
    
        
        :type isSync: System.Boolean
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task WriteAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken, bool chunk = false, bool socketShutdownSend = false, bool socketDisconnect = false, bool isSync = false)
    

