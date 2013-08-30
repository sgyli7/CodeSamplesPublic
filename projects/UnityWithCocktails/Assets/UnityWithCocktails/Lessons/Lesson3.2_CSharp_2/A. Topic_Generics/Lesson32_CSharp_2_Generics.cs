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
public class Lesson31_CSharp_2_Generics: MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
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
		//	UNITY WITH COCKTAILS THEME: SHOTS
		//
		//*********************************************************************
		Debug.Log ("//	GENERIC	///////////////////////");
		_doDemoOfGenericClass();
		Debug.Log ("\n");
		Debug.Log ("//	GENERIC WITH WHERE	///////////////////////");
		_doDemoOfGenericClassWithWhere();
		Debug.Log ("\n");

	}
	
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	
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
		// DECLARE 1
		ShotGenericClass<uint> uintShotGenericClass = new ShotGenericClass<uint> (1); //TODO: I. Try to pass a float here. Compiler purposefully gives an error.
		
		// USE
		uintShotGenericClass.updateInternalStorage (42); //TODO: II. Try to pass a float here. Compiler purposefully gives an error.
		Debug.Log ("	uintShotGenericClass: " + uintShotGenericClass.millilitersDrank);
		
		// DECLARE 2
		ShotGenericClass<float> floatShotGenericClass = new ShotGenericClass<float> (1.1f);
		
		// USE
		floatShotGenericClass.updateInternalStorage (33.3f);
		Debug.Log ("	floatShotGenericClass: " + floatShotGenericClass.millilitersDrank);
	}
	
	
	// PRIVATE
	///<summary>
	///	DEMO
	//
	///</summary>
	private void _doDemoOfGenericClassWithWhere () 
	{
		// DECLARE
		ShotGenericClassWithWhere<BigShotAmount> stringShotGenericClassWithWhere = new ShotGenericClassWithWhere<BigShotAmount> ( new BigShotAmount( 99.99f) ); //TODO: I. Try to pass type <> other than string or float Compiler purposefully gives an error.
		
		// USE
		stringShotGenericClassWithWhere.updateInternalStorage ( new BigShotAmount ( 499.99f));
		Debug.Log ("	stringShotGenericClassWithWhere: " + stringShotGenericClassWithWhere.millilitersDrank);
		
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
