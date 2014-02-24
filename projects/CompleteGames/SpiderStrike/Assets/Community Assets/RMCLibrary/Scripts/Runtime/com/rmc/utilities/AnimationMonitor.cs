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
	public class AnimationMonitor 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// Gets or sets the user interface animation complete signal.
		/// </summary>
		/// <value>The user interface animation complete signal.</value>
		public UIAnimationCompleteSignal uiAnimationCompleteSignal {set; get;}
				
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _game object.
		/// </summary>
		private GameObject _gameObject;

		/// <summary>
		/// The _animation.
		/// </summary>
		private Animation _animation;

		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		
		// PUBLIC
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.utilities.AnimationMonitor"/> class.
		/// 
		/// NOTE: We want to know when animation is complete
		/// 		We want a scalable solution (various unrelated animation instances and gameobjects)
		/// 		This current solution requires no monobehavior here.
		/// 
		/// TODO: it would be nicer to have an internal 'timer' to check then dispatch event or delegate.
		/// 
		/// 
		/// 
		/// </summary>
		public AnimationMonitor(GameObject aGameObject)
		{
			//
			_gameObject = aGameObject;
			uiAnimationCompleteSignal = new UIAnimationCompleteSignal();
			
		}

		~AnimationMonitor( )
		{
			//Debug.Log ("AnimationMonitor.destructor()");
			
		}


		
		/// <summary>
		/// Sets the animation if not yet set to.
		/// </summary>
		/// <returns>The animation if not yet set to.</returns>
		/// <param name="aAnimation">A animation.</param>
		/// <param name="aAnimationName_string">A animation name_string.</param>
		/// <param name="aWrapMode">A wrap mode.</param>
		public float setAnimationAndPlay (string aAnimationName_string, WrapMode aWrapMode)
		{

			if (_animation == null){
				_animation = _gameObject.GetComponentInChildren<Animation>();
				if (_animation == null){
					throw new UnassignedReferenceException ("animationMonitor._animation");
				}
			}
			/////////////////////////////////////////////
			/// 
			/// NOTE: The existing animation system seems unpredictable.
			/// This affects the code setup, but not the end result.
			/// 
			/// ISSUE: The animationClips shown int the animation inspector will change at runtime
			/// ISSUE: The inspector for a given animation clip will show at times the SAME name
			/// 		as another clip (bad) and show a DIFFERENT name than its own name in the project window (bad)
			/// 
			///////////////////////////////////////////// 
			if (_animation[aAnimationName_string] != null) {
				_animation.wrapMode = aWrapMode;
				_animation.name = aAnimationName_string;
				_animation.Play (aAnimationName_string);
				
				//TRIGGER WHEN ANIMATION IS COMPLETE (NOTE: ONE ANIMATION AT A TIME MAXIMUM)
				//NOTE: THERE IS NO 'AUTOMATIC' WAY TO LISTEN FOR ANIMATION COMPLETION
				// WHY *.7f, experimenting the timing
				return _animation[aAnimationName_string].length*.7f;
				
			} else {
				//KEEP THIS
				Debug.Log ("AnimationExtension Anim NOT FOUND: !!!!!" + aAnimationName_string + "!!!!");
				
				//RETURN 0 SO THAT IT FAKES LIKE IT 'IMMEDIATLY FINISHES PLAYING'
				return 0;
			}
			
			
			
		}
		
		// PUBLIC STATIC

		
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
	}
}

