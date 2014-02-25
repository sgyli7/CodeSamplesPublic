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
namespace com.rmc.projects.spider_strike.mvcs.model.data
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
	/// If you want to smoothly move from current value to target value (and back to a reset value)
	/// then this is a great class. Currently works for float only.
	/// </summary>
	public class LerpTarget
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// ALL THE VALUES
		/// </summary>
		public float current;
		public float resetValue;
		public float targetValue;
		public float acceleration;
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.spider_strike.mvcs.model.data.LerpTarget"/> class.
		/// </summary>
		/// <param name="aCurrent_float">A current_float.</param>
		/// <param name="aMinimum_float">A minimum_float.</param>
		/// <param name="aMaximum_float">A maximum_float.</param>
		/// <param name="aAcceleration_float">A acceleration_float.</param>
		public LerpTarget (float aCurrent_float, float aMinimum_float, float aMaximum_float, float aAcceleration_float)
		{
			current 		= aCurrent_float;
			resetValue 	= aMinimum_float;
			targetValue 	= aMaximum_float;
			acceleration  	= aAcceleration_float;
			
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.spider_strike.mvcs.model.data.LerpTarget"/> is reclaimed by garbage collection.
		/// </summary>
		~LerpTarget()
		{
			
		}
		
		// PUBLIC


		/// <summary>
		/// Lerps the current to target.
		/// </summary>
		/// <param name="deltaTime">Delta time.</param>
		public void lerpCurrentToTarget (float aDeltaTime_float)
		{
			_lerpCurrentTo (targetValue, aDeltaTime_float);
		}

		/// <summary>
		/// Lerps the current to reset.
		/// </summary>
		/// <param name="deltaTime">Delta time.</param>
		public void lerpCurrentToReset (float aDeltaTime_float)
		{
			_lerpCurrentTo (resetValue, aDeltaTime_float);
		}


		// PRIVATE


		/// <summary>
		/// _lerps the current to.
		/// </summary>
		/// <param name="aDeltaTime_float">A delta time_float.</param>
		/// <param name="aNextValue">A next value.</param>
		private void _lerpCurrentTo ( float aNextValue, float aDeltaTime_float)
		{
			current =  Mathf.Lerp	(
										current,
										aNextValue,
										aDeltaTime_float*acceleration
									);
		}
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------







	}
}

