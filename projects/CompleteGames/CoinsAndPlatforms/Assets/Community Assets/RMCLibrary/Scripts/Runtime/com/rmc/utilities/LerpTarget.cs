/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
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
		/// The _current_float.
		/// </summary>
		private float _current_float;
		public float current {
			get{
				return _current_float;
			}
			set{
				_current_float = value;
				_doForceTargetValueWithinLimits();
			}
		}
		
		
		/// <summary>
		/// The _minimum_float.
		/// </summary>
		private float _minimum_float;
		public float minimum {
			get{
				return _minimum_float;
			}
			set{
				_minimum_float = value;
				_doForceTargetValueWithinLimits();
			}
		}
		
		/// <summary>
		/// The _maximum_float.
		/// </summary>
		private float _maximum_float;
		public float maximum {
			get{
				return _maximum_float;
			}
			set{
				_maximum_float = value;
				_doForceTargetValueWithinLimits();
			}
		}
		
		
		/// <summary>
		/// The _target value_float.
		/// </summary>
		private float _targetValue_float;
		public float targetValue {
			get{
				return _targetValue_float;
			}
			set{
				_targetValue_float = value;
				_doForceTargetValueWithinLimits();
			}
		}
		
		/// <summary>
		/// The difference between current and targetValue.
		/// </summary>
		public float deltaCurrentToTargetValue {
			get{
				return _targetValue_float - current;
			}
		}
		
		/// <summary>
		/// The acceleration.
		/// </summary>
		public float acceleration;
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Constructor / Destructor
		//--------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.utilities.LerpTarget"/> class.
		/// </summary>
		/// <param name="aCurrent_float">A current_float.</param>
		/// <param name="aTarget_float">A target_float.</param>
		/// <param name="aMinimum_float">A minimum_float.</param>
		/// <param name="aMaximum_float">A maximum_float.</param>
		/// <param name="aAcceleration_float">A acceleration_float.</param>
		public LerpTarget (float aCurrent_float, float aTarget_float, float aMinimum_float, float aMaximum_float, float aAcceleration_float)
		{
			current 		= aCurrent_float;
			targetValue 	= aTarget_float;
			minimum			= aMinimum_float;
			maximum			= aMaximum_float;
			acceleration  	= aAcceleration_float;
			
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.utilities.LerpTarget"/> is reclaimed by garbage collection.
		/// </summary>
		~LerpTarget()
		{
			
		}

		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		
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
		/// Returns a <see cref="System.String"/> that represents the current <see cref="com.rmc.projects.utilities.LerpTarget"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="com.rmc.projects.utilities.LerpTarget"/>.</returns>
		public override string ToString()
		{
			return "[LerpTarget(c: "+current+" t: "+targetValue+" d: "+deltaCurrentToTargetValue+" min: "+minimum+" max: "+maximum+")]";
		}
		
		
		
		// PRIVATE
		/// <summary>
		/// _lerps the current to.
		/// </summary>
		/// <param name="aDeltaTime_float">A delta time_float.</param>
		/// <param name="aNextValue">A next value.</param>
		private void _lerpCurrentTo ( float aNextValue, float aDeltaTime_float)
		{
			
			//UPDATE
			current =  Mathf.Lerp	
				(
					current,
					aNextValue,
					acceleration*aDeltaTime_float
					);
		}
		
		/// <summary>
		/// _dos the force current value within limits.
		/// </summary>
		private void _doForceTargetValueWithinLimits()
		{
			
			//LIMIT
			//DIRECTLY AFFECT THE PRIVATE VARIABLE HERE (OTHERWISE INFINITE LOOP)
			_targetValue_float = Mathf.Clamp (_targetValue_float, minimum, maximum); 
			
		}
		
		
		
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
		
		
		
		
		
		
	}
}

