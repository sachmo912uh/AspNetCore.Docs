

UvWriteReq Class
================






Summary description for UvWriteRequest


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Networking`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Runtime.ConstrainedExecution.CriticalFinalizerObject`
* :dn:cls:`System.Runtime.InteropServices.SafeHandle`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvRequest`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq`








Syntax
------

.. code-block:: csharp

    public class UvWriteReq : UvRequest, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq.UvWriteReq(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            public UvWriteReq(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq.Init(Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle)
    
        
    
        
        :type loop: Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
            public void Init(UvLoopHandle loop)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq.Write(Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator, System.Int32, System.Action<Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq, System.Int32, System.Exception, System.Object>, System.Object)
    
        
    
        
        :type handle: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        :type start: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        :type end: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        :type nBuffers: System.Int32
    
        
        :type callback: System.Action<System.Action`4>{Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq<Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq>, System.Int32<System.Int32>, System.Exception<System.Exception>, System.Object<System.Object>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void Write(UvStreamHandle handle, MemoryPoolIterator start, MemoryPoolIterator end, int nBuffers, Action<UvWriteReq, int, Exception, object> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq.Write2(Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle, System.ArraySegment<System.ArraySegment<System.Byte>>, Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle, System.Action<Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq, System.Int32, System.Exception, System.Object>, System.Object)
    
        
    
        
        :type handle: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        :type bufs: System.ArraySegment<System.ArraySegment`1>{System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}}
    
        
        :type sendHandle: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        :type callback: System.Action<System.Action`4>{Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq<Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq>, System.Int32<System.Int32>, System.Exception<System.Exception>, System.Object<System.Object>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void Write2(UvStreamHandle handle, ArraySegment<ArraySegment<byte>> bufs, UvStreamHandle sendHandle, Action<UvWriteReq, int, Exception, object> callback, object state)
    

