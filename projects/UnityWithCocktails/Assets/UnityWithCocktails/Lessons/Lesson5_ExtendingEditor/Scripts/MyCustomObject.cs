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
[System.Serializable]
public class MyCustomObject 
{
		

	//--------------------------------------
	//  Attributes
	//--------------------------------------
		

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	
	// PUBLIC
	/// <summary>
	/// The x.
	/// </summary>
	public float x;
	
	/// <summary>
	/// The y.
	/// </summary>
	public float y;
	
	/// <summary>
	/// The z.
	/// </summary>
	public float z;
	
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	// PUBLIC
	/// <summary>
	/// Initializes a new instance of the <see cref="MyCustomObject"/> class.
	/// 
	/// NOTE: This is a demo-only class to show off some custom type of data in your inspector
	/// 
	/// </summary>
	public MyCustomObject (float aX_float, float aY_float, float aZ_float)
	{
		x = aX_float;
		y = aY_float;
		z = aZ_float;
		
	}
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Events
	//--------------------------------------
	
}
