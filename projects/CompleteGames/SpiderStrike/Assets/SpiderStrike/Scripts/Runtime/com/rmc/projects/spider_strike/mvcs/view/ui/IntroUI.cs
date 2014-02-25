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
using strange.extensions.mediation.impl;
using com.rmc.projects.spider_strike.mvcs.view.signals;
using com.rmc.utilities;
using com.rmc.projects.spider_strike.mvcs.model.vo;
using com.rmc.projects.animation_monitor;
using System.Collections;



//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.spider_strike.mvcs.view.ui
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum IntroMode
	{
		Show,
		Skip
	}
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class IntroUI : View 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// The user interface button clicked signal.
		/// </summary>
		public UIInputChangedSignal uiInputChangedSignal {set; get;}
		
		/// <summary>
		/// The _text alpha_float.
		/// </summary>
		[SerializeField]
		private float _textAlpha_float;
		public float textAlpha{
			set {
				_textAlpha_float = value;
			}
		}
		
		// PUBLIC
		
		/// <summary>
		/// The click GUI text_gameobject.
		/// </summary>
		public GameObject clickGUIText_gameobject;


		/// <summary>
		/// The logo GUI texture_gameobjects.
		/// </summary>
		public GameObject logoGUITexture_gameobjects;
		
		//  PUBLIC STATIC
		/// <summary>
		/// The ANIMATIO n_ NAM e_ INTROU i_ STAR.
		/// </summary>
		public const string ANIMATION_NAME_INTRO_UI_START 	= "IntroUI_Start";
		
		/// <summary>
		/// The ANIMATIO n_ NAM e_ INTROU i_ STAR.
		/// </summary>
		public const string ANIMATION_NAME_INTRO_UI_END 	= "IntroUI_End";
		
		/// <summary>
		/// The intro mode.
		/// </summary>
		public IntroMode introMode = IntroMode.Show;
		
		/// <summary>
		/// The intro animation clip.
		/// </summary>
		public AnimationClip introStartAnimationClip;
		
		/// <summary>
		/// The outro animation clip.
		/// </summary>
		public AnimationClip introEndAnimationClip;
		
		
		/// <summary>
		/// The _animation binder.
		/// 
		/// NOTE: Notifies when an animation is complete
		/// 
		/// </summary>
		public AnimationMonitor animationMonitor;
		
		// PRIVATE STATIC
		
		//
		/// <summary>
		/// The _click GUI text.
		/// </summary>
		private GUIText _clickGUIText;

		/// <summary>
		/// The _logo_guitexture.
		/// </summary>
		private GUITexture _logo_guitexture;
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		
		
		
		/// <summary>
		/// Init this instance.
		/// </summary>
		public void init ()
		{
			uiInputChangedSignal 	= new UIInputChangedSignal();
			animationMonitor 		= new AnimationMonitor (gameObject);
		}
		
		
		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			
			base.Start();

			//
			_clickGUIText 	= clickGUIText_gameobject.GetComponent<GUIText>();
			_logo_guitexture = logoGUITexture_gameobjects.GetComponent<GUITexture>();

			//EXPERIMENT: STORE CLIPS IN CUSTOM PROPERTIES AND ADD THEM DYNAMICALLY
			//	NOT REQUIRED FOR THE CURRENT SETUP, BUT COULD BE USEFUL FOR DYNAMIC
			//	ANIMATION SETUP
			animation.AddClip (introStartAnimationClip, ANIMATION_NAME_INTRO_UI_START);
			animation.AddClip (introEndAnimationClip, ANIMATION_NAME_INTRO_UI_END);
			
			
			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
			//Debug.Log ("updating: " + _textAlpha_float);
			//RendererUtility.SetMaterialAlpha (_clickGUIText.material, _textAlpha_float);
			
			
			if (Input.GetMouseButton(0) || Input.anyKey) {
				
				//SEND ANY KEYCODE. ITS NOT IMPORTANT
				uiInputChangedSignal.Dispatch (new  UIInputVO (KeyCode.A, UIInputEventType.DownEnter));
				
			}
			
		}
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy ()
		{
			//
			base.OnDestroy();
			
		}
		
		/// <summary>
		/// Sets the health text.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		public void setClickText (string aMessage_string)
		{
			_clickGUIText.text = aMessage_string;
			
		}
		
		
		/// <summary>
		/// Sets the click text is visible.
		/// </summary>
		/// <param name="isVisible_boolean">Is visible_boolean.</param>
		public void setClickTextIsVisible (bool isVisible_boolean)
		{
			
			RendererUtility.SetMaterialVisibility (_clickGUIText.material, isVisible_boolean);
		}

		/// <summary>
		/// Sets the logo texture is visible.
		/// </summary>
		/// <param name="isVisible_boolean">If set to <c>true</c> is visible_boolean.</param>
		public void setLogoTextureIsVisible (bool isVisible_boolean)
		{

			RendererUtility.SetGUITextureVisibility (_logo_guitexture, isVisible_boolean);
		}

		
		/// <summary>
		/// Dos the play animation.
		/// </summary>
		/// <param name="aAnimationType">A animation type.</param>
		/// <param name="aDelayBeforeAnimation_float">A delay before animation_float.</param>
		/// <param name="aDelayAfterAnimation_float">A delay after animation_float.</param>
		public void doPlayAnimation (string animationClipName_string, float aDelayBeforeAnimation_float, float aDelayAfterAnimation_float) 
		{
			//
			doStopAnimation();
			
			//SET TIMER TO KNOW WHEN ANIMATION IS COMPLETE
			StartCoroutine (doPlayAnimationCoroutine(animationClipName_string, aDelayBeforeAnimation_float, aDelayAfterAnimation_float));
			
		}

		/// <summary>
		/// Dos the stop animation.
		/// </summary>
		public void doStopAnimation()
		{
			animation.Stop();
			
			
		}

		/// <summary>
		/// Dos the play animation coroutine.
		/// </summary>
		/// <returns>The play animation coroutine.</returns>
		/// <param name="aDelayBeforeAnimation_float">A delay before animation_float.</param>
		/// <param name="aDelayAfterAnimation_float">A delay after animation_float.</param>
		public IEnumerator doPlayAnimationCoroutine (string animationClipName_string, float aDelayBeforeAnimation_float, float aDelayAfterAnimation_float) 
		{
			
			//SEND SIGNAL
			animationMonitor.uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (animation, animation.name, AnimationMonitorEventType.PRE_START));
			
			
			//WAIT
			yield return new WaitForSeconds(aDelayBeforeAnimation_float);
			
			
			//
			
			
			if (introMode == IntroMode.Show) {

				//
				gameObject.SetActive (true);

				float animationDuration_float = animationMonitor.setAnimationAndPlay (animationClipName_string, WrapMode.Once);
				//WE SKIP THE ANIMATION AND DON'T WAIT FOR IT
				animationDuration_float = .1f; //SUPER SHORT DURATION

				//SEND SIGNAL
				animationMonitor.uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (animation, animation.name, AnimationMonitorEventType.START));
				
				
				//SET TIMER TO KNOW WHEN ANIMATION IS COMPLETE
				StartCoroutine ( onAnimationComplete (animationDuration_float, aDelayAfterAnimation_float));

			} else {


				//
				gameObject.SetActive (false);
				
				//1. FAKE ALL SIGNALS
				//2. DON'T PLAY ANY ANIMATION
				//3. DON'T CALL onAnimationComplete
				animationMonitor.uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (animation, ANIMATION_NAME_INTRO_UI_END, AnimationMonitorEventType.START));
				animationMonitor.uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (animation, ANIMATION_NAME_INTRO_UI_END, AnimationMonitorEventType.COMPLETE));
				animationMonitor.uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (animation, ANIMATION_NAME_INTRO_UI_END, AnimationMonitorEventType.POST_COMPLETE));

			}
			

			
		}
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events 
		//		(This is a loose term for -- handling incoming messaging)
		//
		//--------------------------------------
		/// <summary>
		/// Ons the animation complete.
		/// </summary>
		/// <returns>The animation complete.</returns>
		/// <param name="aAnimationDuration_float">A animation duration_float.</param>
		/// <param name="aDelayAfterAnimation_float">A delay after animation_float.</param>
		public IEnumerator onAnimationComplete (float aAnimationDuration_float, float aDelayAfterAnimation_float)
		{
			
			//ALLOW DEVELOPER TO SKIP THE WHOLE INTRO VIA INSPECTOR DROPDOWN
			string animationClipName_string = animation.name;
			
			//////////////////
			
			//WAIT
			yield return new WaitForSeconds (aAnimationDuration_float);
			
			//SEND SIGNAL
			animationMonitor.uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (animation, animationClipName_string, AnimationMonitorEventType.COMPLETE));
			
			//THEN TACK ON SOME EXTRA DELAY FOR COSMETIC TWEAKING
			yield return new WaitForSeconds (aDelayAfterAnimation_float);
			
			
			//SEND SIGNAL
			animationMonitor.uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (animation, animationClipName_string, AnimationMonitorEventType.POST_COMPLETE));
			
		}
		
		
	}
}

