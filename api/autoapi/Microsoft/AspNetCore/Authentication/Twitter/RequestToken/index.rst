

RequestToken Class
==================






The Twitter request token obtained from the request token endpoint.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Twitter`
Assemblies
    * Microsoft.AspNetCore.Authentication.Twitter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Twitter.RequestToken`








Syntax
------

.. code-block:: csharp

    public class RequestToken








.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.RequestToken
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.RequestToken

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.RequestToken
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.RequestToken.CallbackConfirmed
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool CallbackConfirmed
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.RequestToken.Properties
    
        
    
        
        Gets or sets a property bag for common authentication properties.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.RequestToken.Token
    
        
    
        
        Gets or sets the Twitter request token.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Token
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.RequestToken.TokenSecret
    
        
    
        
        Gets or sets the Twitter token secret.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TokenSecret
            {
                get;
                set;
            }
    

