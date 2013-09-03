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
public class Lesson32_CSharp_2_Operator_Overloading : MonoBehaviour 
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
		
		//////////////////////////////////////////////////////////////////////////////
		//
		//	OVERLOADING OPERATORS -- MORE 'NATIVE' FUNCTIONALITY FOR YOUR CUSTOM CLASSES
		//
		//	LINK: http://www.tutorialspoint.com/csharp/csharp_operator_overloading.htm
		//			
		//	THESE CAN BE OVERLOADED
		//	+, -, !, ~, ++, --	
		//	+, -, *, /, %	
		//	==, !=, <, >, <=, >=	
		//
		//	THESE *CANNOT* BE OVERLOADED
		//	&&, ||
		//	+=, -=, *=, /=, %=	
		//	=, ., ?:, ->, new, is, sizeof, typeof	
		//	
		//////////////////////////////////////////////////////////////////////////////
		
		//	SETUP
		BarTab sons_bartab 		= new BarTab (120.10f);
		BarTab daughters_bartab = new BarTab (14.00f);
		BarTab mothers_bartab 	= new BarTab ();
		
		//	TEST OUTPUT
		Debug.Log ("sons_bartab		: " + sons_bartab);
		Debug.Log ("daughters_bartab: " + daughters_bartab);
		Debug.Log ("mothers_bartab	: " + mothers_bartab);
		
		//	TEST OPERATORS
		//
		//	NOTE: THE MAGIC HERE IS THAT '+=' (and other operators) IS USING A CUSTOM (NOT NATIVE) IMPLEMENTATION
		//	EXCELLENT!
		
		//	TEST OUTPUT
		Debug.Log ("sons_bartab		: " + sons_bartab);
		Debug.Log ("daughters_bartab: " + daughters_bartab);
		Debug.Log ("mothers_bartab	: " + mothers_bartab);
		//
		Debug.Log ("Greater		: " + (sons_bartab >  daughters_bartab)	);
		Debug.Log ("GreaterEqual: " + (sons_bartab >= daughters_bartab)	);
		Debug.Log ("Lesser		: " + (sons_bartab <  daughters_bartab)	);
		Debug.Log ("LesserEqual: "  + (sons_bartab <= daughters_bartab)	);
		Debug.Log ("Equals		: " + (sons_bartab == daughters_bartab)	);
		Debug.Log ("NotEquals	: " + (sons_bartab != daughters_bartab)	);
		


		
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

