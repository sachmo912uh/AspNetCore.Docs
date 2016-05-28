

UvMemory Class
==============






Summary description for UvMemory


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








Syntax
------

.. code-block:: csharp

    public abstract class UvMemory : SafeHandle, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory.IsInvalid
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsInvalid
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory.Libuv
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv
    
        
        .. code-block:: csharp
    
            public Libuv Libuv
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory.ThreadId
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ThreadId
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory.UvMemory(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            protected UvMemory(IKestrelTrace logger)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory._log
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            protected readonly IKestrelTrace _log
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory._threadId
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            protected int _threadId
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory._uv
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv
    
        
        .. code-block:: csharp
    
            protected Libuv _uv
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory.CreateMemory(Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv, System.Int32, System.Int32)
    
        
    
        
        :type uv: Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv
    
        
        :type threadId: System.Int32
    
        
        :type size: System.Int32
    
        
        .. code-block:: csharp
    
            protected void CreateMemory(Libuv uv, int threadId, int size)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory.DestroyMemory(System.IntPtr)
    
        
    
        
        :type memory: System.IntPtr
    
        
        .. code-block:: csharp
    
            protected static void DestroyMemory(IntPtr memory)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory.DestroyMemory(System.IntPtr, System.IntPtr)
    
        
    
        
        :type memory: System.IntPtr
    
        
        :type gcHandlePtr: System.IntPtr
    
        
        .. code-block:: csharp
    
            protected static void DestroyMemory(IntPtr memory, IntPtr gcHandlePtr)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory.FromIntPtr<THandle>(System.IntPtr)
    
        
    
        
        :type handle: System.IntPtr
        :rtype: THandle
    
        
        .. code-block:: csharp
    
            public static THandle FromIntPtr<THandle>(IntPtr handle)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory.Validate(System.Boolean)
    
        
    
        
        :type closed: System.Boolean
    
        
        .. code-block:: csharp
    
            public void Validate(bool closed = false)
    

