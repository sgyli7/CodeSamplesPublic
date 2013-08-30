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
public class Lesson32_CSharp_2_Delegates: MonoBehaviour 
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
		
		Debug.Log ("//	DELEGATES & MORE	///////////////////////");
		_doDemoCustomCocktailClass();
		
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
