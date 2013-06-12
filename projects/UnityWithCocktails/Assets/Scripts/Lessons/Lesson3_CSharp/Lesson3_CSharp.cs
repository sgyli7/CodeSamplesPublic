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
using System.Collections;

//--------------------------------------
//  Class
//--------------------------------------
public class Lesson3_CSharp : MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	///<summary>
	///	Store instance of testing class
	///</summary>
	private CustomCSharpClass _customCSharpClass;
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		_doDemoOfCustomCSharpClass();
		Debug.Log ("/////////////////////////");
		Debug.Log ("/////////////////////////");
		_doDemoOfPartialClass();
		Debug.Log ("/////////////////////////");
		Debug.Log ("/////////////////////////");
		_doDemoOfGenericClass();
		Debug.Log ("/////////////////////////");
		Debug.Log ("/////////////////////////");
		_doDemoOfSingleton();
	}
	
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	///<summary>
	///	DEMO
	///</summary>
	private void _doDemoOfCustomCSharpClass () 
	{
		// DECLARE
		_customCSharpClass = new CustomCSharpClass ();
		
		// USE
		Debug.Log ("customCSharpClass: " + _customCSharpClass);
		
		// 	@-QUOTING
		Debug.Log("customCSharpClass.sampleAtQuoting : "+ _customCSharpClass.sampleAtQuoting);
		
		//	DELEGATES
		_customCSharpClass.onInitialized += onInitialized;
		_customCSharpClass.initialize();
		
		//	ACTIONS 
		//		(with Lamda)
		_customCSharpClass.doLongProcess(
			() => 
			{
				Debug.Log("doLongProcess Complete");
			}
			);
		
		//		(with Callback)
		_customCSharpClass.doLongProcess(_onLongProcessComplete);
		
		//	METHOD OVERLOADING
		_customCSharpClass.overloadedMethod();
		_customCSharpClass.overloadedMethod(10);
		
			
		//DESTRUCTOR
		_customCSharpClass = null;
	
	}
	
	// PRIVATE
	///<summary>
	///	DEMO
	///</summary>
	private void _doDemoOfPartialClass () 
	{
		// DECLARE
		PartialClass partialClass = new PartialClass ();
		
		// USE
		partialClass.sampleMethod2();
		partialClass.sampleMethod3();
		Debug.Log ("partialClass: " + partialClass);
		
		
	}
	
	
	// PRIVATE
	///<summary>
	///	DEMO
	///</summary>
	private void _doDemoOfGenericClass () 
	{
		// DECLARE
		CustomGenericClass<uint> customGenericClass = new CustomGenericClass<uint> (1);
		
		// USE
		Debug.Log ("customGenericClass: " + customGenericClass.internalStorage);
		customGenericClass.updateInternalStorage (42);
		Debug.Log ("customGenericClass: " + customGenericClass.internalStorage);
		
		
	}
	
	// PRIVATE
	///<summary>
	///	DEMO
	///</summary>
	private void _doDemoOfSingleton () 
	{
		// USE
		CustomSingleton.Instance.countUp();
		CustomSingleton.Instance.countUp();
		CustomSingleton.Instance.countUp();
		Debug.Log ("CustomSingleton.getCount()" + CustomSingleton.Instance.getCount());
		
	}
	
	// PRIVATE STATIC
	
	// PRIVATE COROUTINE
	
	// PRIVATE INVOKE
	
	//--------------------------------------
	//  Events 
	//		(This is a loose term for -- handling incoming messaging)
	//
	//--------------------------------------
	///<summary>
	///	Handles "onInitialized" 
	///</summary>
	public void onInitialized (string aMessage_str)
	{
		Debug.Log ("onInitialized() : " + aMessage_str);
		
		//STOP OBSERVING
		_customCSharpClass.onInitialized -= onInitialized;
		
		
	}
	
	///<summary>
	///	Handles "doLongProcess" completion
	///</summary>
	public void _onLongProcessComplete() 
	{
		Debug.Log ("_onLongProcessComplete()");
	}
}
