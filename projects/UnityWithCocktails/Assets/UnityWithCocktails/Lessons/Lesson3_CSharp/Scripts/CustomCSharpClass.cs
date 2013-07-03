/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:                                            
 *                                                                      
 * The above copyright notice and this permission notice shall be       
 * included in all copies or substantial portions of the Software.      
 *                                                                      
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,      
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF   
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR    
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.                                      
 */
// Marks the right margin of code *******************************************************************


//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;
using System;

//--------------------------------------
//  Class
//--------------------------------------
public class CustomCSharpClass 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	// GETTER / SETTER
	
	// PUBLIC
	///<summary>
	//	@-quoting (at-quoting)
	//
	//	The advantage of @-quoting is that escape sequences are not processed, which 
	//		makes it easy to write, for example, a fully qualified file name:
	//
	///</summary>
	public string sampleAtQuoting = @"c:\Docs\Source\a.txt"; // rather than "c:\\Docs\\Source\\a.txt"
	
	///<summary>
	//	@Delegates
	//
	//	Define a custom package TYPE to handle one-to-many messaging, similar to Observer pattern.
	//
	///</summary>
	public delegate void onInitializedDelegate (string aMessage_str);
	
	///<summary>
	//	@Delegates
	//
	//	Define a custom package INSTANCE to handle one-to-many messaging, similar to Observer pattern.
	//
	///</summary>
	public onInitializedDelegate onInitialized;
	
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Constructor
	//		This runs when "CustomCSHarpClass customCSHarpClass = new CustomCSHarpClass();" is called
	///</summary>
	public CustomCSharpClass () 
	{
		Debug.Log ("CustomCSharpClass.constructor()");
		
	}
	
	///<summary>
	///	Destructor
	//		This runs when "customCSharpClass = null;" is called
	///</summary>
	~CustomCSharpClass () 
	{
		Debug.Log ("CustomCSharpClass.destructor()");
		onInitialized("CustomCSharpClass has been destructed.");
		
	}
	
	
	///<summary>
	///	Do basic initialization
	///</summary>
	public void initialize () 
	{
		onInitialized("CustomCSharpClass has been initialized.");
		
	}
	
	
	
	///<summary>
	///	Do some long process
	///</summary>
	public void doLongProcess (Action aDoLongProcessComplete ) 
	{
		//DO SOMETHING
		
		//REPORT ITS COMPLETE
		aDoLongProcessComplete();
		
	}
	
	
		
		
	// PUBLIC
	///<summary>
	//	Overloading
	//
	//		Declare one method name, but accept unique (and unlimited) combinations of arguments
	///</summary>
	public void overloadedMethod () 
	{
		Debug.Log ("overloadedMethod()");
		
	}
	
	///<summary>
	//	Overloading
	//
	//		Declare one method name, but accept unique (and unlimited) combinations of arguments
	///</summary>
	public void overloadedMethod (uint count_uint) 
	{
		Debug.Log ("overloadedMethod(): " + count_uint);
		
	}
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	// PRIVATE COROUTINE
	
	// PRIVATE INVOKE
	
	//--------------------------------------
	//  Events
	//--------------------------------------
}
