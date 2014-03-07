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
using System.Collections;
using com.rmc.projects.paddle_soccer.mvcs.view.signals;
using com.rmc.utilities;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs.view.ui
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	/// <summary>
	/// HUD mode.
	/// </summary>
	public enum HUDMode
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
	public class HUDUI : View 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC

		/// <summary>
		/// Gets or sets the user interface prompt ended signal.
		/// </summary>
		/// <value>The user interface prompt ended signal.</value>
		public UIPromptEndedSignal uiPromptEndedSignal { set; get; }

		/// <summary>
		/// The paddle right GUI text_gameobject.
		/// </summary>
		public GameObject paddleRightGUIText_gameobject;


		/// <summary>
		/// The paddle right GUI text2_gameobject.
		/// </summary>
		public GameObject paddleRightGUIText2_gameobject;


		/// <summary>
		/// When the score GUI text.
		/// </summary>
		public GameObject paddleLeftGUIText_gameobject;

		/// <summary>
		/// When the score GUI text.
		/// </summary>
		public GameObject paddleLeftGUIText2_gameobject;

		
		/// <summary>
		/// When the prompt GUI text_game object.
		/// </summary>
		public GameObject promptGUIText_gameObject;

		
		/// <summary>
		/// When the prompt GUI text_game object.
		/// </summary>
		public GameObject promptGUIText2_gameObject;

		
		/// <summary>
		/// The restart GUI text_game object.
		/// </summary>
		public GameObject restartGUIText_gameObject;
		
		
		/// <summary>
		/// The restart GUI text2_game object.
		/// </summary>
		public GameObject restartGUIText2_gameObject;



		/// <summary>
		/// When the FPS GUI text_game object.
		/// </summary>
		public GameObject fpsGUIText_gameObject;

		/// <summary>
		/// When the intro mode.
		/// </summary>
		public HUDMode hudMode = HUDMode.Show;

		/// <summary>
		/// The prompt message.
		/// </summary>
		public string promptMessage;

		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _paddle right GUI text.
		/// </summary>
		private GUIText _paddleRightGUIText;

		/// <summary>
		/// The _paddle right GUI text2.
		/// </summary>
		private GUIText _paddleRightGUIText2;

		/// <summary>
		/// The _paddle left GUI text.
		/// </summary>
		private GUIText _paddleLeftGUIText;

		/// <summary>
		/// The _paddle left GUI text2.
		/// </summary>
		private GUIText _paddleLeftGUIText2;

		
		/// <summary>
		/// When the prompt GUI text.
		/// </summary>
		private GUIText _promptGUIText;

		
		/// <summary>
		/// When the prompt GUI text.
		/// </summary>
		private GUIText _promptGUIText2;

		/// <summary>
		/// The _restart GUI text.
		/// </summary>
		private GUIText _restartGUIText;
		
		
		/// <summary>
		/// The _restart GUI text2.
		/// </summary>
		private GUIText _restartGUIText2;



		/// <summary>
		/// When the FPS GUI text.
		/// </summary>
		private GUIText _fpsGUIText;




		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		/// <summary>
		/// Init this instance.
		/// </summary>
		public void init ()
		{
			uiPromptEndedSignal = new UIPromptEndedSignal ();

		}


		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			
			base.Start();

			_paddleRightGUIText 	= paddleRightGUIText_gameobject.GetComponent<GUIText>();
			_paddleRightGUIText2 	= paddleRightGUIText2_gameobject.GetComponent<GUIText>();
			_paddleLeftGUIText 		= paddleLeftGUIText_gameobject.GetComponent<GUIText>();
			_paddleLeftGUIText2 	= paddleLeftGUIText2_gameobject.GetComponent<GUIText>();
			_promptGUIText			= promptGUIText_gameObject.GetComponent<GUIText>();
			_promptGUIText2			= promptGUIText2_gameObject.GetComponent<GUIText>();
			_restartGUIText			= restartGUIText_gameObject.GetComponent<GUIText>();
			_restartGUIText2		= restartGUIText2_gameObject.GetComponent<GUIText>();
			//
			_fpsGUIText         	= fpsGUIText_gameObject.GetComponent<GUIText>();

			//CLEAR PROMPT BEFORE ITS FIRST USE
			_setPromptText ("");

		}

		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			//Debug.Log ("HUDUI.update!" + _scoreGUIText.text);
			//todo: remove this
			if (_paddleLeftGUIText.text != promptMessage) {
				_setPromptText( promptMessage);
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
		/// Sets the visibility.
		/// </summary>
		/// <param name="aIsVisible_boolean">If set to <c>true</c> a is visible_boolean.</param>
		public void setVisibility (bool aIsVisible_boolean)
		{

			RendererUtility.SetMaterialVisibility (_paddleLeftGUIText.guiText.material, 	aIsVisible_boolean);
			RendererUtility.SetMaterialVisibility (_paddleLeftGUIText2.guiText.material, 	aIsVisible_boolean);
			RendererUtility.SetMaterialVisibility (_paddleRightGUIText.guiText.material, 	aIsVisible_boolean);
			RendererUtility.SetMaterialVisibility (_paddleRightGUIText2.guiText.material, 	aIsVisible_boolean);

			RendererUtility.SetMaterialVisibility (_fpsGUIText.guiText.material, 			aIsVisible_boolean);

			//KEEP HERE AS REMINDER
			//SINCE WE FADE THIS TEXT MANUALLY, DON'T SET VISIBILITY HERE
			//RendererUtility.SetMaterialVisibility (_promptGUIText.guiText.material, 	aIsVisible_boolean);
			//RendererUtility.SetMaterialVisibility (_promptGUIText2.guiText.material, 	aIsVisible_boolean);

		}


		/// <summary>
		/// Sets the visibility for restart GU.
		/// </summary>
		/// <param name="aIsVisible_boolean">If set to <c>true</c> a is visible_boolean.</param>
		public void setVisibilityForRestartGUI (bool aIsVisible_boolean)
		{
			
			RendererUtility.SetMaterialVisibility (_restartGUIText.guiText.material, 	aIsVisible_boolean);
			RendererUtility.SetMaterialVisibility (_restartGUIText2.guiText.material, 	aIsVisible_boolean);
		}
		
		/// <summary>
		/// Sets the score text.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		public void setTextForRestartGUI (string aMessage_string)
		{
			_restartGUIText.text = aMessage_string;
			_restartGUIText2.text = aMessage_string;
			
		}

		/// <summary>
		/// Sets the score text.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		public void setLeftScoreText (string aMessage_string)
		{
				_paddleLeftGUIText.text = aMessage_string;
				_paddleLeftGUIText2.text = aMessage_string;
			
		}

		/// <summary>
		/// Sets the health text.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		public void setRightScoreText (string aMessage_string)
		{

				_paddleRightGUIText.text = aMessage_string;
				_paddleRightGUIText2.text = aMessage_string;

		}

		/// <summary>
		/// Do the prompt start.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		public void doPromptStart (string aMessage_string, bool aIsToFadeOutToo_boolean) 
		{

			//DON'T SET IMMEDIATLY. SEE 'Update()' above
			promptMessage = aMessage_string;


			
			//FOR DEVELOPMENT: ALLOW TO SKIP VIA INSPECTOR WINDOW DROPDOWN
			float fadeInDuration_float;
			float fadeOutDuration_float;
			float fadeOutDelayDuration_float;
			if (hudMode == HUDMode.Show) {
				fadeInDuration_float = 0.5f;
				fadeOutDuration_float = 0.5f;
				fadeOutDelayDuration_float = 2f;
			} else {
				fadeInDuration_float = 0.1f;
				fadeOutDuration_float = 0.1f;
				fadeOutDelayDuration_float = .1f;
			}


			//SETUP: IMMEDIATLY SET ALPHA TO 0
			RendererUtility.SetMaterialAlpha (_promptGUIText.guiText.material, 		0);
			RendererUtility.SetMaterialAlpha (_promptGUIText2.guiText.material, 	0);


			/*********
			 * 
			 * SETUP: FADE FROM 0 TO 100
			 * 
			 ********/
			Hashtable fadeTo2_hashtable = new Hashtable();
			fadeTo2_hashtable.Add(iT.FadeTo.delay,				.1f);
			fadeTo2_hashtable.Add(iT.FadeTo.amount,				1);
			fadeTo2_hashtable.Add(iT.FadeTo.time,  				fadeInDuration_float);
			fadeTo2_hashtable.Add(iT.FadeTo.easetype, 			iTween.EaseType.linear);
			//
			iTween.FadeTo (promptGUIText_gameObject, 			fadeTo2_hashtable);
			iTween.FadeTo (promptGUIText2_gameObject, 			fadeTo2_hashtable);


			/*********
			 * 
			 * SETUP: FADE FROM 100 TO 0
			 * 
			 ********/
			//_promptGUIText.font.material.color.a = 0.5f;
			if (aIsToFadeOutToo_boolean) {
				Hashtable fadeTo3_hashtable = new Hashtable();
				fadeTo3_hashtable.Add("name",						"fadeTo2");
				fadeTo3_hashtable.Add(iT.FadeTo.delay, 				fadeOutDelayDuration_float);
				fadeTo3_hashtable.Add(iT.FadeTo.alpha,				0);
				fadeTo3_hashtable.Add(iT.FadeTo.time,  				fadeOutDuration_float);
				fadeTo3_hashtable.Add(iT.FadeTo.easetype, 			iTween.EaseType.linear);
				fadeTo3_hashtable.Add(iT.FadeTo.oncompletetarget, 	gameObject);
				//
				iTween.FadeTo (promptGUIText_gameObject, 			fadeTo3_hashtable);
				//CALL COMPLETE JUST ONCE
				fadeTo3_hashtable.Add(iT.FadeTo.oncomplete, 		"_onPromptFadeOutComplete");
				iTween.FadeTo (promptGUIText2_gameObject, 			fadeTo3_hashtable);
			}

		}

		// PUBLIC STATIC
		
		// PRIVATE
		
		/// <summary>
		/// _sets the prompt text.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		private void _setPromptText (string aMessage_string)
		{
			_promptGUIText2.text = aMessage_string;
			_promptGUIText.text = aMessage_string;
			
		}

		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events 
		//		(This is a loose term for -- handling incoming messaging)
		//
		//--------------------------------------
		/// <summary>
		/// When the prompt fade out complete.
		/// </summary>
		private void _onPromptFadeOutComplete ()
		{
			CancelInvoke ("_onDelayAfterPromptFadeOutComplete");
			Invoke ("_onDelayAfterPromptFadeOutComplete", 0.5f);
			
		}

		/// <summary>
		/// When the delay after prompt fade out complete.
		/// 
		/// NOTE: Must be public
		/// 
		/// </summary>
		public void _onDelayAfterPromptFadeOutComplete ()
		{
			uiPromptEndedSignal.Dispatch ();

		}
		
	}
}

