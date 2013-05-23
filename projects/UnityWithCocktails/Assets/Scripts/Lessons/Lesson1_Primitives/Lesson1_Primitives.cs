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

//--------------------------------------
//  Class
//--------------------------------------
public class Lesson1_Primitives : MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	///<summary>
	///	This is a sample getter/setter property.
	///</summary>
		
	// PUBLIC
	///<summary>
	///	This is a sample public property.
	///</summary>
	
	// PUBLIC STATIC
	///<summary>
	///	This is a sample public static property.
	///</summary>
	
	// PRIVATE
	///<summary>
	///	This is a sample private property.
	///</summary>
	
	// PRIVATE STATIC
	///<summary>
	///	This is a sample private static property.
	///</summary>
	
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		
		//	REFERENCE
		// 	SEE ALSO sbyte, byte, char, short, ushort, long, ulong, more on 
		//		http://msdn.microsoft.com/en-us/library/exx3b86w%28VS.80%29.aspx
		//		http://msdn.microsoft.com/en-us/library/ya5y69ds%28v=VS.80%29.aspx
		
		//	DECLARE 
		string		sample_string   	= "sample_string";
		bool		isSample_boolean 	= true;
		uint		sample_uint     	= 1;
		int 		sample_int 			= -1;
		float 		sample_float 		= 1.1f;
		double      sample_double   	= 1.2;
		//
		object      sample_object       = new Object();
		//
		string[]    sampleArray1_str     = new string[2];
		sampleArray1_str[0]				= "sampleArray1Index0_string";
		sampleArray1_str[1]				= "sampleArray1Index1_string";
		//
		string[]    sampleArray2_str     = new string[2];
		sampleArray2_str[0]				= "sampleArray2Index0_string";
		sampleArray2_str[1]				= "sampleArray2Index1_string";
		
		//	USE
		Debug.Log ("--------------");
		Debug.Log ("sample_string: " 		+ sample_string);
		Debug.Log ("isSample_boolean: " 	+ isSample_boolean);
		Debug.Log ("sample_uint: "	 		+ sample_uint);
		Debug.Log ("sample_int: " 			+ sample_int);
		Debug.Log ("sample_float: " 		+ sample_float);
		Debug.Log ("sample_double: " 		+ sample_double);
		//
		Debug.Log ("sample_object: " 		+ sample_object);
		Debug.Log ("sampleArray1_str: " 	+ sampleArray1_str.ToString());
		Debug.Log ("sampleArray2_str: " 	+ sampleArray2_str.ToString());
		
		//	REFLECTION
		Debug.Log ("--------------");
		Debug.Log ("sample_string" 		+ sample_string			);
		Debug.Log ("	type 	: " + sample_string.GetType()	);
		Debug.Log ("	typeof 	: " + typeof(string)			);
		Debug.Log ("	is 		: " + (sample_string is string)	);
		Debug.Log ("	as 		: " + (sample_string as string)	);
		
		
	}
	
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () 
	{
		
		
	}
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------

}

