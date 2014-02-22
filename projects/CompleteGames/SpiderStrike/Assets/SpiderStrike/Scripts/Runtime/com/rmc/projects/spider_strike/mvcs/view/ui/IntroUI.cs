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

		// PRIVATE STATIC

		//
		/// <summary>
		/// The _click GUI text.
		/// </summary>
		private GUIText _clickGUIText;




		//--------------------------------------
		//  Methods
		//--------------------------------------	
		
		
		
		/// <summary>
		/// Init this instance.
		/// </summary>
		public void init ()
		{
			uiInputChangedSignal = new UIInputChangedSignal();
		}
		
		
		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			
			base.Start();
			_clickGUIText = clickGUIText_gameobject.GetComponent<GUIText>();
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
		/// Dos the name of the play animation by.
		/// </summary>
		/// <param name="aAnimationName_string">A animation name_string.</param>
		public void doPlayAnimationByName (string aAnimationName_string)
		{

			//Debug.Log ("doPlayAnimationByName: " + aAnimationName_string);
			if (introMode == IntroMode.Show) {

				//
				gameObject.SetActive (true);
				//
				float animationDuration_float = animation.setAnimationIfNotYetSetTo (aAnimationName_string, WrapMode.Once);
			
				//SET TIMER TO KNOW WHEN ANIMATION IS COMPLETE
				CancelInvoke("onAnimationComplete");
				if (animationDuration_float != 0) {
					InvokeRepeating ("onAnimationComplete", animationDuration_float, animationDuration_float);
				}
			} else {

				//
				gameObject.SetActive (false);
				//

				//SKIP IT
				Invoke ("onAnimationComplete", .1f);
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
		/// 
		/// 
		/// NOTE: Method must be ***public*** due to InvokeRepeating
		/// TODO: PACK THIS 'ON COMPLETE' FUNCTIONALITY INTO THE EXTENSION METHODS FOR 'Animation'
		/// 
		///
		/// </summary>
		public void onAnimationComplete ()
		{
			//Debug.Log ("onAnimationComplete : " + animation.name);

			if (animation.wrapMode != WrapMode.Loop) {
				CancelInvoke("onAnimationComplete");
			}
			if (introMode == IntroMode.Show) {
				//RESPECT THE ANIMATION PROPERLY
				animation.getUIAnimationCompleteSignal().Dispatch (animation.name);
			} else {
				//FAKE LIKE THE 'END' HAPPENED
				animation.getUIAnimationCompleteSignal().Dispatch (ANIMATION_NAME_INTRO_UI_END);
			}
		}

		
	}
}

