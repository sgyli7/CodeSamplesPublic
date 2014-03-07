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
namespace com.rmc.projects.animation_monitor
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
	public class AnimationMonitorRequestVO
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// When the name of the animation clip.
		/// </summary>
		public string animationClipName;

		/// <summary>
		/// When the wrap mode.
		/// </summary>
		public WrapMode wrapMode;

		/// <summary>
		/// When the delay before animation.
		/// </summary>
		public float delayBeforeAnimation;


		/// <summary>
		/// When the delay after animation.
		/// </summary>
		public float delayAfterAnimation;

		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Constructor / Destructor
		//--------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.animation_monitor.AnimationMonitorRequestVO"/> class.
		/// </summary>
		/// <param name="aAnimationClipName_string">A animation clip name_string.</param>
		/// <param name="aWrapMode">A wrap mode.</param>
		/// <param name="aDelayBeforeAnimation_float">A delay before animation_float.</param>
		/// <param name="aDelayAfterAnimation_float">A delay after animation_float.</param>
		public AnimationMonitorRequestVO (string aAnimationClipName_string, WrapMode aWrapMode,  float aDelayBeforeAnimation_float = 0, float aDelayAfterAnimation_float = 0 )
		{
			animationClipName			= aAnimationClipName_string;
			wrapMode					= aWrapMode;
			delayBeforeAnimation		= aDelayBeforeAnimation_float;
			delayAfterAnimation			= aDelayAfterAnimation_float;
			
		}		

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.animation_monitor.AnimationMonitorRequestVO"/> is reclaimed by garbage collection.
		/// </summary>
		~AnimationMonitorRequestVO()
		{
			
		}


		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		
		//--------------------------------------
		//  Constructor / Destructor
		//--------------------------------------
		
		// PUBLIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

