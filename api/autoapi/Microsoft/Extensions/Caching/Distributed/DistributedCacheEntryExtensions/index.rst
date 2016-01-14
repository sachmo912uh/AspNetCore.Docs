

DistributedCacheEntryExtensions Class
=====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryExtensions`








Syntax
------

.. code-block:: csharp

   public class DistributedCacheEntryExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/caching/blob/master/src/Microsoft.Extensions.Caching.Abstractions/DistributedCacheEntryExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryExtensions.SetAbsoluteExpiration(Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions, System.DateTimeOffset)
    
        
    
        Sets an absolute expiration date for the cache entry.
    
        
        
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        
        
        :type absolute: System.DateTimeOffset
        :rtype: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
    
        
        .. code-block:: csharp
    
           public static DistributedCacheEntryOptions SetAbsoluteExpiration(DistributedCacheEntryOptions options, DateTimeOffset absolute)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryExtensions.SetAbsoluteExpiration(Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions, System.TimeSpan)
    
        
    
        Sets an absolute expiration time, relative to now.
    
        
        
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        
        
        :type relative: System.TimeSpan
        :rtype: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
    
        
        .. code-block:: csharp
    
           public static DistributedCacheEntryOptions SetAbsoluteExpiration(DistributedCacheEntryOptions options, TimeSpan relative)
    
    .. dn:method:: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryExtensions.SetSlidingExpiration(Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions, System.TimeSpan)
    
        
    
        Sets how long the cache entry can be inactive (e.g. not accessed) before it will be removed.
        This will not extend the entry lifetime beyond the absolute expiration (if set).
    
        
        
        
        :type options: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        
        
        :type offset: System.TimeSpan
        :rtype: Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
    
        
        .. code-block:: csharp
    
           public static DistributedCacheEntryOptions SetSlidingExpiration(DistributedCacheEntryOptions options, TimeSpan offset)
    

