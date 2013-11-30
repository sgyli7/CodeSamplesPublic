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
using System.Collections;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngineInternal;
     

//--------------------------------------
//  Class
//--------------------------------------
public static class Debug
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
		
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	///<summary>
	///	Determines if debugging occurs
	///</summary>
	public static bool isDebugBuild = true;
	
	///<summary>
	///	By default Unity's Debug.Log shows extra lines added to every Debug.Log() console output.
	//    ********
	//    ********
	//    ******** The purpose of this class is to reduce console output to ONE line each. Solely for readabilities sake.
	//    ********
	//    ******** THIS IS PURELY COSMETIC
	///</summary>
	private static string hr = "\n\n-------------------------------------------------------------------------------";
      
	
	// PRIVATE STATIC
	
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	// PUBLIC
	
	// PUBLIC STATIC
	public static void Log (object message)
	{
		if (isDebugBuild)
			UnityEngine.Debug.Log (message + hr);
		//UnityEngine.Debug.Log (message.ToString ());
	}
     
	public static void Log (object message, UnityEngine.Object context)
	{
		if (isDebugBuild)
			UnityEngine.Debug.Log (message, context);
		//UnityEngine.Debug.Log (message.ToString (), context);
	}
       
	public static void LogError (object message)
	{
		if (isDebugBuild)
			UnityEngine.Debug.LogError (message);
		//UnityEngine.Debug.LogError (message.ToString ());
	}
     
	public static void LogError (object message, UnityEngine.Object context)
	{
		if (isDebugBuild)
			UnityEngine.Debug.LogError (message, context);
		//UnityEngine.Debug.LogError (message.ToString (), context);
	}
     
	public static void LogWarning (object message)
	{
		if (isDebugBuild)
			UnityEngine.Debug.LogWarning (message.ToString ());
	}
     
	public static void LogWarning (object message, UnityEngine.Object context)
	{
		if (isDebugBuild)
			UnityEngine.Debug.LogWarning (message.ToString (), context);
	}
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------

}
