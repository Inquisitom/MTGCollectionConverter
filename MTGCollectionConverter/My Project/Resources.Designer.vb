﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.1
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("MTGCollectionConverter.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Tenth Edition,10E 
        '''Fourth Edition,4E 
        '''Fifth Edition,5E 
        '''6-th Edition,6E 
        '''Seventh Edition,7E 
        '''Eighth Edition,8E 
        '''Ninth Edition,9E 
        '''Alpha,A 
        '''Alternate Art:,AA 
        '''Alliances,AL 
        '''Shards of Alara,ALA 
        '''Arabian Nights,AN 
        '''Apocalypse,AP 
        '''Antiquities,AQ 
        '''Alara Reborn,ARB 
        '''Archmage,ARC 
        '''Astral,AS 
        '''Anthologies,AT 
        '''Ajani VS Nicol Bolas,AVG 
        '''Avacyn Restored,AVR 
        '''Beta,B 
        '''Beatdown,BD 
        '''Born of the Gods,BNG 
        '''Betrayers of Kamigawa,BOK 
        '''Battle Royale,BR 
        '''Box Topper,BT 
        '''Commander (2013 Edition),C13 
        '''Com [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property SETS() As String
            Get
                Return ResourceManager.GetString("SETS", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
