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
using System.Collections.Generic;
using custom_namespace;

//--------------------------------------
//  Class
//--------------------------------------
public class Lesson31_CSharp_1_Scope: MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	
	// PUBLIC
	/// <summary>
	/// The sample public_float.
	/// </summary>
	public float samplePublic_float = 10.5f;
	
	// PUBLIC STATIC
	
	// PRIVATE
	/// <summary>
	/// The _sample private_int.
	/// </summary>
	private float _samplePrivate_int = 4;
	
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{

		Debug.Log ("//	BASIC SCOPE	///////////////////////");
		_doDemoOfBasicScope();
		Debug.Log ("\n");
		Debug.Log ("//	NAMESPACE	///////////////////////");
		_doDemoOfNamespacing();
		Debug.Log ("\n");
		Debug.Log ("//	REF	///////////////////////");
		_doDemoOfRef();
		Debug.Log ("\n");
		Debug.Log ("//	OUT	///////////////////////");
		_doDemoOfOut();
		Debug.Log ("\n");
	}
	
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	//******************************************************
	//******************************************************
	//**	BASIC SCOPE
	//******************************************************
	//******************************************************
	
	///<summary>
	///	DEMO
	//
	///</summary>
	private void _doDemoOfBasicScope () 
	{
		
		//	OF COURSE WE CAN ACCESS PUBLIC & PRIVATE VARIABLES DECLARED ABOVE
		Debug.Log ("	Basic Scope1: " + _samplePrivate_int + " & " + samplePublic_float);
		
		//	WE CAN ACCESS A LOCAL VARIABLE
		string sampleLocalVariable_string = "I am local";
		Debug.Log ("	Basic Scope2: " + sampleLocalVariable_string);
		
		
		//	A. BUT IF WE DECLARE INSIDE A CONDITIONAL (OR OTHER STRUCTURE) 
		if (true) {
			string sampleLocalVariable2_string = "I am local";	
			Debug.Log ("	Basic Scope3: " + sampleLocalVariable2_string);	
		}
		
		//	B. THEN WE CANNOT ACCESS IT 'OUTSIDE' THAT STRUCTURE
		//	TODO: UNCOMMENT THIS AND SEE THE PURPOSEFUL COMPILER ERROR
		//Debug.Log ("	Basic Scope4: " + sampleLocalVariable2_string);
		
	}
	//******************************************************
	//******************************************************
	//**	NAMESPACING
	//******************************************************
	//******************************************************
	
	///<summary>
	///	DEMO
	//
	//	REFERENCE: URL (http://msdn.microsoft.com/en-us/library/0d941h9d.aspx);
	///</summary>
	private void _doDemoOfNamespacing () 
	{
		// SIMPLY TO ORGANIZE YOUR CODE AND PREVENT CLASS NAME COLLISIONS YOU
		//		CAN **OPTIONALLY** PUT 'namespace blah' atop a class declaration and then 'using blah;' 
		//		atop the class which wants to use blah
		NamespaceClass namespaceClass = new NamespaceClass();
		Debug.Log ("namespaceClass: " + namespaceClass);
		
	}
	
	//******************************************************
	//******************************************************
	//**	REF
	//
	//	NOTE: ref & out both allow parameters to be passed by reference
	//  HOWEVER: ref tells the compiler that the object is initialized before entering the function 
	//
	//******************************************************
	//******************************************************
	
	///<summary>
	///	DEMO
	//
	///</summary>
	private void _doDemoOfRef () 
	{
		//	NOTE: MUST BE DELCARED BEFORE THE 'ref' ACCEPTS IT
		List<string> list_strings = new List<string>();
		
		//	USE
		list_strings.Add("Original Zero Index");
		
		//	CALL
		_acceptInstanceByRef (ref list_strings);
		
		//	TEST
		Debug.Log ("	list_strings: " + list_strings[0]);
		
	}
	
	/// <summary>
	/// _accepts the instance by reference.
	/// 
	/// NOTE: 'ref' allows you to pass by reference, permanently affecting the 
	/// 		original instance
	/// 
	/// 
	/// </summary>
	private void _acceptInstanceByRef (ref List<string> aList_strings) 
	{
		aList_strings[0] = "New Zero Index";
	}
	
	
	//******************************************************
	//******************************************************
	//**	OUT
	//
	//	NOTE: ref & out both allow parameters to be passed by reference
	//  HOWEVER: out tells the compiler that the object will be initialized inside the function. 
	//
	//******************************************************
	//******************************************************

	///<summary>
	///	DEMO
	//
	///</summary>
	private void _doDemoOfOut () 
	{
		//	NOTE: DON'T GIVE IT A VALUE HERE, IT WILL BE DONE IN THE 'out' METHOD
		List<string> list_strings;
		
		//	CALL
		_acceptInstanceByOut (out list_strings);
		
		//	TEST
		Debug.Log ("	list_strings: " + list_strings[0]);
		
	}
	
	/// <summary>
	/// _accepts the instance by reference.
	/// 
	/// NOTE: 'out' allows you to pass by reference, permanently affecting the 
	/// 		original instance
	/// 
	/// 
	/// </summary>
	private void _acceptInstanceByOut (out List<string> aList_strings) 
	{
		aList_strings = new List<string>();
		aList_strings.Add ("New Zero Index");
	}
	
	
	
	// PRIVATE STATIC
	
	// PRIVATE COROUTINE
	
	// PRIVATE INVOKE
	
	//--------------------------------------
	//  Events 
	//		(This is a loose term for -- handling incoming messaging)
	//
	//--------------------------------------

}
