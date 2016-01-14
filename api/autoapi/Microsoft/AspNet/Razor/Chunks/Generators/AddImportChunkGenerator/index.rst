

AddImportChunkGenerator Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.AddImportChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class AddImportChunkGenerator : SpanChunkGenerator, ISpanChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Chunks/Generators/AddImportChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.AddImportChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.AddImportChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.AddImportChunkGenerator.AddImportChunkGenerator(System.String)
    
        
        
        
        :type ns: System.String
    
        
        .. code-block:: csharp
    
           public AddImportChunkGenerator(string ns)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.AddImportChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.AddImportChunkGenerator.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.AddImportChunkGenerator.GenerateChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.AddImportChunkGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.AddImportChunkGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.AddImportChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.AddImportChunkGenerator.Namespace
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Namespace { get; }
    

