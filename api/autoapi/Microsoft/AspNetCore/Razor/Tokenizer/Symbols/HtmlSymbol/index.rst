

HtmlSymbol Class
================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol`








Syntax
------

.. code-block:: csharp

    public class HtmlSymbol : SymbolBase<HtmlSymbolType>, ISymbol








.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol.HtmlSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public HtmlSymbol(SourceLocation start, string content, HtmlSymbolType type)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol.HtmlSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            public HtmlSymbol(SourceLocation start, string content, HtmlSymbolType type, IReadOnlyList<RazorError> errors)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol.HtmlSymbol(System.Int32, System.Int32, System.Int32, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType)
    
        
    
        
        :type offset: System.Int32
    
        
        :type line: System.Int32
    
        
        :type column: System.Int32
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        .. code-block:: csharp
    
            public HtmlSymbol(int offset, int line, int column, string content, HtmlSymbolType type)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbol.HtmlSymbol(System.Int32, System.Int32, System.Int32, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type offset: System.Int32
    
        
        :type line: System.Int32
    
        
        :type column: System.Int32
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.HtmlSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            public HtmlSymbol(int offset, int line, int column, string content, HtmlSymbolType type, IReadOnlyList<RazorError> errors)
    

