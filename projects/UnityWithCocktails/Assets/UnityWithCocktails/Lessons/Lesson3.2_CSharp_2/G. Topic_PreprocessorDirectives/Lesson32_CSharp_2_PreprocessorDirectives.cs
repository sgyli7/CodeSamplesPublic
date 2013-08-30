#define PLEASE_DO_THIS
//#define AND_MAYBE_DO_THIS



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
public class Lesson32_CSharp_2_PreprocessorDirectives: MonoBehaviour 
{

	//--------------------------------------
	//  Properties & Property/Variable Attributes
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
		
		Debug.Log ("\n");
		Debug.Log ("//	NATIVE CONDITIONAL COMPILATION	///////////////////////");
		_doDemoOf_PlatformDependentCompilation();
		
		
		Debug.Log ("\n");
		Debug.Log ("//	CUSTOM CONDITIONAL COMPILATION	///////////////////////");
		//(SEE LINE#1 OF THIS CLASS FILE, ABOVE)	
		#if PLEASE_DO_THIS
			_doDemoOf_CustomConditionalCompilation1();
		#endif
		
		#if AND_MAYBE_DO_THIS
			_doDemoOf_CustomConditionalCompilation2();
		#endif
		
		Debug.Log ("\n");
		Debug.Log ("//	CUSTOM CONDITIONAL COMPILATION	///////////////////////");
		_doDemoOf_Pragma();
		
		Debug.Log ("\n");
		Debug.Log ("//	CONDITIONAL DEVICE COMPILATION BY SCENES	///////////////////////");
		_doDemoOf_ConditionalDeviceCompilationByScenes();
		
		
		
		Debug.Log ("\n");

	}
	

	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	//******************************************************
	//******************************************************
	//**	CUSTOM CONDITIONAL COMPILATION
	//******************************************************
	//******************************************************
	
	// PRIVATE
	///<summary>
	///	DEMO
	///</summary>
	private void _doDemoOf_CustomConditionalCompilation1 () 
	{
		
		//SOME CODE...
		Debug.Log ("	CustomConditionalCompilation1");
		
	}
	
	///<summary>
	///	DEMO
	///</summary>
	private void _doDemoOf_CustomConditionalCompilation2 () 
	{
		
		//SOME CODE...
		Debug.Log ("	CustomConditionalCompilation2");
		
	}
	
	//******************************************************
	//******************************************************
	//		PLATFORM DEPENDENT COMPILATION	
	//
	//		REFERENCE: http://docs.unity3d.com/Documentation/Manual/PlatformDependentCompilation.html
	//
	//******************************************************
	//******************************************************
	
	// PRIVATE
	///<summary>
	///	DEMO
	///</summary>
	private void _doDemoOf_PlatformDependentCompilation () 
	{
			
	    #if UNITY_EDITOR
	      Debug.Log("Unity Editor");
	    #endif
	
	    #if UNITY_IPHONE
	      Debug.Log("Iphone");
	    #endif
	
	    #if UNITY_STANDALONE_OSX
		Debug.Log("Stand Alone OSX");
	    #endif
	
	    #if UNITY_STANDALONE_WIN
	      Debug.Log("Stand Alone Windows");
	    #endif
		
		#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
	    	Debug.Log("Native Build");
	    #else
	    	Debug.Log("Not a good idea to attempt filesystem access...");
	    #endif
		
	}
	
	//******************************************************
	//******************************************************
	//		PRAGMA
	//
	//		NOTE: Pragma is included here for completenes, 
	//		but it is relevant for UnityScript (not C#, so we will ignore it)
	//
	//		REFERENCE: http://forum.unity3d.com/threads/63114-What-is-pragma-implicit-and-pragma-downcast
	//
	//******************************************************
	//******************************************************
	
	// PRIVATE
	///<summary>
	///	DEMO
	///</summary>
	private void _doDemoOf_Pragma () 
	{
		//#pragma strict
    	//#pragma implicit
    	//#pragma downcast
		
	}
	
	

	//******************************************************
	//******************************************************
	//		Unity3D Conditional Device Compilation By Scenes
	//
	//		NOTE: VERY ADVANCED TECHNIQUE
	//
	//		REFERENCE: 	http://www.chrisdanielson.com/2011/04/29/unity3d-conditional-device-compilation-by-scenes/
	//
	//******************************************************
	//******************************************************
	
	// PRIVATE
	///<summary>
	///	DEMO
	///</summary>
	private void _doDemoOf_ConditionalDeviceCompilationByScenes () 
	{
		//READ REFERENCE ABOVE
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

