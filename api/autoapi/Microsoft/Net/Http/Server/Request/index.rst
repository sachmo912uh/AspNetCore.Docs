

Request Class
=============





Namespace
    :dn:ns:`Microsoft.Net.Http.Server`
Assemblies
    * Microsoft.Net.Http.Server

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Server.Request`








Syntax
------

.. code-block:: csharp

    public sealed class Request








.. dn:class:: Microsoft.Net.Http.Server.Request
    :hidden:

.. dn:class:: Microsoft.Net.Http.Server.Request

Properties
----------

.. dn:class:: Microsoft.Net.Http.Server.Request
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Server.Request.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream Body
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.ConnectionId
    
        
        :rtype: System.UInt64
    
        
        .. code-block:: csharp
    
            public ulong ConnectionId
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.ContentLength
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        .. code-block:: csharp
    
            public long ? ContentLength
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.ContentType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentType
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.HasEntityBody
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasEntityBody
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.Headers
    
        
        :rtype: Microsoft.Net.Http.Server.HeaderCollection
    
        
        .. code-block:: csharp
    
            public HeaderCollection Headers
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.IsHeadMethod
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsHeadMethod
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.IsSecureConnection
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsSecureConnection
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.LocalIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
            public IPAddress LocalIpAddress
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.LocalPort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int LocalPort
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Method
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Path
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.PathBase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PathBase
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.ProtocolVersion
    
        
        :rtype: System.Version
    
        
        .. code-block:: csharp
    
            public Version ProtocolVersion
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.QueryString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string QueryString
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.RemoteIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
            public IPAddress RemoteIpAddress
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.RemotePort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int RemotePort
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.Request.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Scheme
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Server.Request
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Server.Request.GetClientCertificateAsync(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Cryptography.X509Certificates.X509Certificate2<System.Security.Cryptography.X509Certificates.X509Certificate2>}
    
        
        .. code-block:: csharp
    
            public Task<X509Certificate2> GetClientCertificateAsync(CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.Net.Http.Server.Request.GetProvidedTokenBindingId()
    
        
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] GetProvidedTokenBindingId()
    
    .. dn:method:: Microsoft.Net.Http.Server.Request.GetReferredTokenBindingId()
    
        
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] GetReferredTokenBindingId()
    

