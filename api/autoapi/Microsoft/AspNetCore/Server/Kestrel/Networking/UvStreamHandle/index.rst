

UvStreamHandle Class
====================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvHandle`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle`








Syntax
------

.. code-block:: csharp

    public abstract class UvStreamHandle : UvHandle, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle.Connection
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Http.Connection
    
        
        .. code-block:: csharp
    
            public Connection Connection
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle.UvStreamHandle(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            protected UvStreamHandle(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle.Accept(Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle)
    
        
    
        
        :type handle: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            public void Accept(UvStreamHandle handle)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle.Listen(System.Int32, System.Action<Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle, System.Int32, System.Exception, System.Object>, System.Object)
    
        
    
        
        :type backlog: System.Int32
    
        
        :type callback: System.Action<System.Action`4>{Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle<Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle>, System.Int32<System.Int32>, System.Exception<System.Exception>, System.Object<System.Object>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void Listen(int backlog, Action<UvStreamHandle, int, Exception, object> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle.ReadStart(System.Func<Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle, System.Int32, System.Object, Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv.uv_buf_t>, System.Action<Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle, System.Int32, System.Object>, System.Object)
    
        
    
        
        :type allocCallback: System.Func<System.Func`4>{Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle<Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle>, System.Int32<System.Int32>, System.Object<System.Object>, Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv.uv_buf_t<Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv.uv_buf_t>}
    
        
        :type readCallback: System.Action<System.Action`3>{Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle<Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle>, System.Int32<System.Int32>, System.Object<System.Object>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void ReadStart(Func<UvStreamHandle, int, object, Libuv.uv_buf_t> allocCallback, Action<UvStreamHandle, int, object> readCallback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle.ReadStop()
    
        
    
        
        .. code-block:: csharp
    
            public void ReadStop()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle.ReleaseHandle()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool ReleaseHandle()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle.TryWrite(Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv.uv_buf_t)
    
        
    
        
        :type buf: Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv.uv_buf_t
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int TryWrite(Libuv.uv_buf_t buf)
    

