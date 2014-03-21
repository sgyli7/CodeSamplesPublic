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
namespace com.rmc.utilities
{
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Utility
	/// </summary>
	public class MathUtility
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		// PUBLIC
		
		// PUBLIC STATIC

		/// <summary>
		/// Determines if the float is near enough to zero to be considered zero
		/// 
		/// NOTE: This is because of unique nature of Floats. It replaces error-prone " aFloat == 0 " check.
		/// 
		/// </summary>
		/// <returns><c>true</c>, if float zero was ised, <c>false</c> otherwise.</returns>
		/// <param name="aValue_float">A value_float.</param>
		public static bool IsFloatZero (float aValue_float)
		{
			return _IsApproximately (aValue_float, Mathf.Epsilon, 0.2f);
		}


		/// <summary>
		/// Determines if values are 'close enough'
		/// </summary>
		/// <param name="aValue1_float">A value1_float.</param>
		/// <param name="aValue2_float">A value2_float.</param>
		/// <param name="aTolerance_float">A tolerance_float.</param>
		private static bool _IsApproximately(float aValue1_float, float aValue2_float, float aTolerance_float)
		{
			return Mathf.Abs(aValue1_float - aValue2_float) < aTolerance_float;
		}

		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
		
		

	}
}

