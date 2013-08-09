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
using custom_namespace;

//--------------------------------------
//  Class
//--------------------------------------
public class Lesson31_CSharp_1_Classes_And_Generics : MonoBehaviour 
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
	private Cocktail _cocktail;
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		
		//*********************************************************************
		//
		//	UNITY WITH COCKTAILS THEME: COCKTAILS
		//
		//*********************************************************************
		
		Debug.Log ("//	CUSTOM	///////////////////////");
		_doDemoCustomCocktailClass();
		Debug.Log ("\n");
		Debug.Log ("//	PARTIAL	///////////////////////");
		_doDemoOfPartialClass();
		Debug.Log ("\n");
		Debug.Log ("//	GENERIC	///////////////////////");
		_doDemoOfGenericClass();
		Debug.Log ("\n");
		Debug.Log ("//	SINGLETON	///////////////////////");
		_doDemoOfSingleton();
		Debug.Log ("\n");
		Debug.Log ("//	STRUCT	///////////////////////");
		_doDemoOfStruct();
		Debug.Log ("\n");
		Debug.Log ("//	NAMESPACE	///////////////////////");
		_doDemoOfNamespacing();
		Debug.Log ("\n");
	
	
		Debug.Log ("//	DESTRUCTOR	///////////////////////");
		//DESTRUCTOR FOR '_customCSharpClass' IS AUTOMATICALLY CALLED AT THE END OF THIS METHOD (I.E. THE VERY NEXT LINE)
	}
	
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	///<summary>
	///	DEMO
	///</summary>
	private void _doDemoCustomCocktailClass () 
	{
		// DECLARE
		_cocktail = new Cocktail ();
		
		// USE
		Debug.Log ("_cocktail: " + _cocktail);
		
		// 	@-QUOTING
		Debug.Log("_cocktail.sampleAtQuoting : "+ _cocktail.sampleAtQuoting);
		
		
		//	DELEGATES
		//		Delegates are useful when you want to execute code AFTER a process is complete.
		_cocktail.onInitialized += onInitialized;
		_cocktail.initialize();
		
		
		//	1. IN-LINE METHOD DECLARATION
		//		(with Lamda) - write inline function
		_cocktail.doLongProcess(
			() => 
			{
				Debug.Log("doLongProcess Complete1");
			}
			);
		//
		_cocktail.doLongProcess(_onLongProcessComplete);
		
		
		//	2. IN-LINE METHOD DECLARATION
		//		(with Func) - write inline function, with return value
		Func <int, int, float> addAndDivideThem = (my1_int, my2_int) => (my1_int + my2_int)/2;
		float resultOfFunc_float = addAndDivideThem (11, 22);
		Debug.Log("Func<>: " + resultOfFunc_float);
		
		
		//	3. IN-LINE METHOD DECLARATION
		//		(with Predicate) - write inline functionn, (like Func but ALWAYS RETURNS BOOLEAN)
		Predicate <float> isGreaterThan5 = (my_float) => my_float > 5;
		bool resultOfPredicate_float = isGreaterThan5 (3);
		Debug.Log("Predicate<>: " + resultOfPredicate_float);
		
		
		//	4. IN-LINE METHOD DECLARATION
		//		(with Action) - write inline function, NEVER A RETURN VALUE
		Action<string, string> concatAndOutput = (my1_string, my2_string) => Debug.Log ("Action: " + my1_string + "," + my2_string);
		concatAndOutput ("Hello", "World");
		
		
		
		
		//	METHOD OVERLOADING
		_cocktail.overloadedMethod();
		_cocktail.overloadedMethod(10);
		
			
		//DESTRUCTOR
		_cocktail = null;
	
	}
	
	
	//******************************************************
	//******************************************************
	//**	PARTIAL CLASS
	//******************************************************
	//******************************************************
	
	// PRIVATE
	///<summary>
	///	DEMO
	//
	//	REFERENCE: URL (http://msdn.microsoft.com/en-us/library/vstudio/wa80x488.aspx);
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
	
	
	//******************************************************
	//******************************************************
	//**	GENERICS
	//******************************************************
	//******************************************************
	
	// PRIVATE
	///<summary>
	///	DEMO
	//
	//	REFERENCE: URL (http://msdn.microsoft.com/en-us/library/512aeb7t%28v=VS.80%29.aspx);
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
	
	
	
	//******************************************************
	//******************************************************
	//**	SINGLETON
	//******************************************************
	//******************************************************
	
	// PRIVATE
	///<summary>
	///	DEMO
	//
	//	REFERENCE: URL (http://msdn.microsoft.com/en-us/library/ff650316.aspx);
	///</summary>
	private void _doDemoOfSingleton () 
	{
		// USE
		CustomSingleton.Instance.countUp();
		CustomSingleton.Instance.countUp();
		CustomSingleton.Instance.countUp();
		Debug.Log ("CustomSingleton.getCount()" + CustomSingleton.Instance.getCount());
		
	}
	
	
	//******************************************************
	//******************************************************
	//**	STRUCT
	//******************************************************
	//******************************************************
	
	/// <summary>
	/// Demo struct.
	///  NOTE: These are like classes but meant for more 'temporary?' data structures without 'functionality' (methods)
	/// 
	///  NOTE: Seems to have a few differences from a class here on the 'inside' when declaring it
	/// 
	///  OPINION ONLINE: 	The only difference between a class and a struct in C++ is that structs have default public members 
	/// 					and bases and classes have default private members and bases. Both classes and structs can have a 
	/// 					mixture of public and private members, can use inheritance, and can have member functions.
	/// 					I would recommend using structs as plain-old-data structures without any class-like features, 
	/// 					and using classes as aggregate data structures with private data and member functions.
	//
	//	REFERENCE: URL (http://msdn.microsoft.com/en-us/library/ah19swz4%28v=VS.71%29.aspx);
	/// </summary>
	public struct DemoStruct
	{
		// PROPERTIES
		public int sample_int;
		public float sample_float;
		
		// CONSTRUCTORS
		public DemoStruct (int aSample_int)
	    {
			//INTERESTINGLY, COMPILER REQUIRES THAT *ALL* PROPERTIES MUST BE DECLARED IN CONSTRUCTOR
			sample_float  	= 10.1f;
	        sample_int 		= aSample_int;
			
			//
			_doInit();
	    }
		
		// METHODS
		private void _doInit()
		{
			//do something else...
		}
		
	}
	
	
	
	
	/// <summary>
	/// _dos the demo of struct.
	/// </summary>
	private void _doDemoOfStruct () 
	{
		
		//SEEMS TO BEHAVE VERY MUCH LIKE A CLASS FROM THE 'OUTSIDE'
		DemoStruct myDemoStruct = new DemoStruct ();
		myDemoStruct.sample_int = 10;
		
		Debug.Log ("_doDemoOfStruct() myDemoStruct: " + myDemoStruct);
		
	}
	
	
	
	//******************************************************
	//******************************************************
	//**	NAMESPACING
	//******************************************************
	//******************************************************
	
	// PRIVATE
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
		_cocktail.onInitialized -= onInitialized;
		
		
	}
	
	///<summary>
	///	Handles "doLongProcess" completion
	///</summary>
	public void _onLongProcessComplete() 
	{
		Debug.Log ("_onLongProcessComplete()2");
	}
}
