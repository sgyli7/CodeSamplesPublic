/**
 * Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
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
using com.rmc.projects.spider_strike.mvcs.view.signals;

//--------------------------------------
//  Namespace
//--------------------------------------
//NOTE: NO NEED TO add 'using com.rmc.extension_methods;' in any class for this to work
	
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
/// 
/// Its like 'extending' that class but without needing to extend it. Magical!
/// 
/// </summary>
using System;


public static class AnimationExtensions 
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
	
	// PUBLIC
	
	// PUBLIC STATIC
	/// <summary>
	/// Gets or sets the user interface animation complete.
	/// </summary>
	/// <value>The user interface animation complete.</value>
	public static UIAnimationCompleteSignal uiAnimationCompleteSignal {set; get;}


	/// <summary>
	/// Gets the user interface animation complete signal.
	/// </summary>
	/// <returns>The user interface animation complete signal.</returns>
	/// <param name="aAnimation">A animation.</param>
	public static UIAnimationCompleteSignal getUIAnimationCompleteSignal (this Animation aAnimation) 
	{
		if (uiAnimationCompleteSignal == null) {
			uiAnimationCompleteSignal = new UIAnimationCompleteSignal();
		}
		return uiAnimationCompleteSignal;
		
	}
	
	/// <summary>
	/// Sets the animation if not yet set to.
	/// </summary>
	/// <returns>The animation if not yet set to.</returns>
	/// <param name="aAnimation">A animation.</param>
	/// <param name="aAnimationName_string">A animation name_string.</param>
	/// <param name="aWrapMode">A wrap mode.</param>
	public static float setAnimationIfNotYetSetTo (this Animation aAnimation, string aAnimationName_string, WrapMode aWrapMode)
	{
		
		
		/////////////////////////////////////////////
		/// 
		/// NOTE: The animation system seems unpredictable.
		/// This affects the code setup, but not the end result.
		/// 
		/// ISSUE: The animationClips shown int the animation inspector will change at runtime
		/// ISSUE: The inspector for a given animation clip will show at times the SAME name
		/// 		as another clip (bad) and show a DIFFERENT name than its own name in the project window (bad)
		/// 
		///////////////////////////////////////////// 
		if (aAnimation[aAnimationName_string] != null) {
			Debug.Log ("SET: " + aWrapMode);
			aAnimation.wrapMode = aWrapMode;
			aAnimation.name = aAnimationName_string;
			aAnimation.Play (aAnimationName_string);

			//TRIGGER WHEN ANIMATION IS COMPLETE (NOTE: ONE ANIMATION AT A TIME MAXIMUM)
			//NOTE: THERE IS NO 'AUTOMATIC' WAY TO LISTEN FOR ANIMATION COMPLETION
			// WHY *.7f, experimenting the timing
			return aAnimation[aAnimationName_string].length*.7f;

		} else {
			//KEEP THIS
			Debug.Log ("AnimationExtension Anim NOT FOUND: !!!!!" + aAnimationName_string + "!!!!");

			//RETURN 0 SO THAT IT FAKES LIKE IT 'IMMEDIATLY FINISHES PLAYING'
			return 0;
		}

		

	}
	


	
	// PRIVATE
	
	// PRIVATE STATIC
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------

}

