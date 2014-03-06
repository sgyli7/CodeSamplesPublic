/**
 * Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furn
 * 
 * ished to do so, subject to
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

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs.model.data
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------

	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Storage of a min/max value and ability to get a random value out.
	/// 
	/// NOTE: This is usefull for a characters min/max movement speed for ex.
	/// 
	/// </summary>
	public class Range
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// The minimum.
		/// </summary>
		public float minimum;

		/// <summary>
		/// The maximum.
		/// </summary>
		public float maximum;
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		
		//--------------------------------------
		//  Constructor / Destructor
		//--------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.paddle_soccer.mvcs.model.data.Range"/> class.
		/// </summary>
		/// <param name="aMinimum_float">A minimum_float.</param>
		/// <param name="aMaximum_float">A maximum_float.</param>
		public Range (float aMinimum_float, float aMaximum_float)
		{
			minimum = aMinimum_float;
			maximum = aMaximum_float;
			
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.paddle_soccer.mvcs.model.data.Range"/> is reclaimed by garbage collection.
		/// </summary>
		~Range()
		{
			
		}

		//--------------------------------------
		//  Methods
		//--------------------------------------

		// PUBLIC
		/// <summary>
		/// Gets the random float value within range.
		/// </summary>
		/// <returns>The random float value within range.</returns>
		public float getRandomFloatValueWithinRange ()
		{
			float return_float = Random.Range (minimum, maximum);
			return return_float;
		}

		/// <summary>
		/// Gets the random int value within range.
		/// </summary>
		/// <returns>The random int value within range.</returns>
		public int getRandomIntValueWithinRange ()
		{
			return Mathf.RoundToInt (getRandomFloatValueWithinRange());
		}

		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------







	}
}

