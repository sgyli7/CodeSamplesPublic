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
using com.rmc.projects.paddle_soccer.mvcs.view.signals;
using System.Collections;

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
	[RequireComponent (typeof(Animation))]
	public class AnimationMonitor : MonoBehaviour
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// Gets or sets the user interface animation monitor signal.
		/// </summary>
		/// <value>The user interface animation monitor signal.</value>
		public UIAnimationMonitorEventSignal uiAnimationMonitorSignal {set; get;}
				
		/// <summary>
		/// The animation.
		/// </summary>
		private new Animation animation;
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		// PRIVATE STATIC

		//--------------------------------------
		//  Constructor / Destructor
		//--------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.animation_monitor.AnimationMonitor"/> class.
		/// </summary>
		public AnimationMonitor()
		{
			uiAnimationMonitorSignal = new UIAnimationMonitorEventSignal();
			
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.animation_monitor.AnimationMonitor"/> is reclaimed by garbage collection.
		/// </summary>
		~AnimationMonitor( )
		{
			//Debug.Log ("AnimationMonitor.destructor()");
			
		}

		//--------------------------------------
		//  Methods
		//--------------------------------------	

		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start ()
		{
			animation = GetComponent<Animation>();

		}

		/// <summary>
		/// Plays the request.
		/// </summary>
		/// <param name="aAnimationMonitorRequestVO">A animation monitor request V.</param>
		public void playRequest (AnimationMonitorRequestVO aAnimationMonitorRequestVO)
		{
		
			StartCoroutine (_playRequestCoroutine (aAnimationMonitorRequestVO));

		}


		
		// PUBLIC STATIC
		
		
		
		// PRIVATE

		/// <summary>
		/// Plays the request coroutine.
		/// </summary>
		/// <returns>The request coroutine.</returns>
		/// <param name="aAnimationMonitorRequestVO">A animation monitor request V.</param>
		private IEnumerator _playRequestCoroutine (AnimationMonitorRequestVO aAnimationMonitorRequestVO)
		{

			//SEND SIGNAL
			uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (AnimationMonitorEventType.PRE_START, aAnimationMonitorRequestVO));


			//WAIT
			yield return new WaitForSeconds(aAnimationMonitorRequestVO.delayBeforeAnimation);

			//PLAY THE ANIMATION
			if (animation[aAnimationMonitorRequestVO.animationClipName] != null) {
				animation.wrapMode = aAnimationMonitorRequestVO.wrapMode;
				animation.Play (aAnimationMonitorRequestVO.animationClipName);
				//Debug.Log ("Play: " + aAnimationMonitorRequestVO.animationClipName);

			} else {
				//KEEP THIS
				Debug.Log ("AnimationMonitor:  AnimationClip NOT FOUND: !!!!!" + aAnimationMonitorRequestVO.animationClipName + "!!!!");

			}

			//SEND SIGNAL
			uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (AnimationMonitorEventType.START, aAnimationMonitorRequestVO));


			//SET TIMER TO KNOW WHEN ANIMATION IS COMPLETE
			StartCoroutine ( _onAnimationComplete (aAnimationMonitorRequestVO));


				
		}
			

		
		// PRIVATE STATIC
		
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
		//--------------------------------------
		//  Events 
		//		(This is a loose term for -- handling incoming messaging)
		//
		//--------------------------------------
		/// <summary>
		/// Ons the animation complete.
		/// </summary>
		/// <returns>The animation complete.</returns>
		/// <param name="aAnimationMonitorRequestVO">A animation monitor request V.</param>
		private IEnumerator _onAnimationComplete (AnimationMonitorRequestVO aAnimationMonitorRequestVO)
		{

			//WAIT
			yield return new WaitForSeconds (animation[aAnimationMonitorRequestVO.animationClipName].length);
			
			//SEND SIGNAL
			uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (AnimationMonitorEventType.COMPLETE, aAnimationMonitorRequestVO));

			//THEN TACK ON SOME EXTRA DELAY FOR COSMETIC TWEAKING
			yield return new WaitForSeconds (aAnimationMonitorRequestVO.delayAfterAnimation);
			
			
			//SEND SIGNAL
			uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (AnimationMonitorEventType.POST_COMPLETE, aAnimationMonitorRequestVO));
			
		}
		
	}
}

