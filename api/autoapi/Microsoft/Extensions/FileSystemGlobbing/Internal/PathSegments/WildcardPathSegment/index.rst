

WildcardPathSegment Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment`








Syntax
------

.. code-block:: csharp

   public class WildcardPathSegment : IPathSegment





GitHub
------

`View on GitHub <https://github.com/aspnet/filesystem/blob/master/src/Microsoft.Extensions.FileSystemGlobbing/Internal/PathSegments/WildcardPathSegment.cs>`_





.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment.WildcardPathSegment(System.String, System.Collections.Generic.List<System.String>, System.String, System.StringComparison)
    
        
        
        
        :type beginsWith: System.String
        
        
        :type contains: System.Collections.Generic.List{System.String}
        
        
        :type endsWith: System.String
        
        
        :type comparisonType: System.StringComparison
    
        
        .. code-block:: csharp
    
           public WildcardPathSegment(string beginsWith, List<string> contains, string endsWith, StringComparison comparisonType)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment.Match(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Match(string value)
    

Fields
------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment.MatchAll
    
        
    
        
        .. code-block:: csharp
    
           public static readonly WildcardPathSegment MatchAll
    

Properties
----------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment.BeginsWith
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string BeginsWith { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment.CanProduceStem
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool CanProduceStem { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment.Contains
    
        
        :rtype: System.Collections.Generic.List{System.String}
    
        
        .. code-block:: csharp
    
           public List<string> Contains { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.WildcardPathSegment.EndsWith
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string EndsWith { get; }
    

