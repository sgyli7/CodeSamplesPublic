/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
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

//--------------------------------------
//  Namespace
//--------------------------------------
using System.Collections;
using com.rmc.projects.spider_strike.mvcs.view.signals;
using com.rmc.utilities;


namespace com.rmc.projects.spider_strike.mvcs.view.ui
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
		/// The health GUI text.
		/// </summary>
		public GameObject healthGUIText_gameobject;


		/// <summary>
		/// The health GUI text.
		/// </summary>
		public GameObject healthGUIText2_gameobject;


		/// <summary>
		/// The score GUI text.
		/// </summary>
		public GameObject scoreGUIText_gameObject;

		/// <summary>
		/// The score GUI text.
		/// </summary>
		public GameObject scoreGUIText2_gameObject;

		
		/// <summary>
		/// The prompt GUI text_game object.
		/// </summary>
		public GameObject promptGUIText_gameObject;

		
		/// <summary>
		/// The prompt GUI text_game object.
		/// </summary>
		public GameObject promptGUIText2_gameObject;

		/// <summary>
		/// The FPS GUI text_game object.
		/// </summary>
		public GameObject fpsGUIText_gameObject;

		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The health GUI text.
		/// </summary>
		private GUIText _healthGUIText;

		/// <summary>
		/// The health GUI text.
		/// </summary>
		private GUIText _healthGUIText2;

		/// <summary>
		/// The score GUI text.
		/// </summary>
		private GUIText _scoreGUIText;

		/// <summary>
		/// The score GUI text.
		/// </summary>
		private GUIText _scoreGUIText2;

		
		/// <summary>
		/// The prompt GUI text.
		/// </summary>
		private GUIText _promptGUIText;

		
		/// <summary>
		/// The prompt GUI text.
		/// </summary>
		private GUIText _promptGUIText2;

		/// <summary>
		/// The FPS GUI text.
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

			_healthGUIText 		= healthGUIText_gameobject.GetComponent<GUIText>();
			_healthGUIText2 	= healthGUIText2_gameobject.GetComponent<GUIText>();
			_scoreGUIText 		= scoreGUIText_gameObject.GetComponent<GUIText>();
			_scoreGUIText2 		= scoreGUIText2_gameObject.GetComponent<GUIText>();
			_promptGUIText		= promptGUIText_gameObject.GetComponent<GUIText>();
			_promptGUIText2		= promptGUIText2_gameObject.GetComponent<GUIText>();
			_fpsGUIText         = fpsGUIText_gameObject.GetComponent<GUIText>();
			//Debug.Log ("HUD START");


			//CLEAR PROMPT BEFORE ITS FIRST USE
			_setPromptText ("");

		}

		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
			
			
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
			RendererUtility.SetMaterialVisibility (_scoreGUIText.guiText.material, 		aIsVisible_boolean);
			RendererUtility.SetMaterialVisibility (_scoreGUIText2.guiText.material, 	aIsVisible_boolean);
			RendererUtility.SetMaterialVisibility (_healthGUIText.guiText.material, 	aIsVisible_boolean);
			RendererUtility.SetMaterialVisibility (_healthGUIText2.guiText.material, 	aIsVisible_boolean);
			RendererUtility.SetMaterialVisibility (_fpsGUIText.guiText.material, 	aIsVisible_boolean);


		}
		
		// PUBLIC

		/// <summary>
		/// Sets the score text.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		public void setScoreText (string aMessage_string)
		{
			_scoreGUIText.text = aMessage_string;
			_scoreGUIText2.text = aMessage_string;
			
		}

		/// <summary>
		/// Sets the health text.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		public void setHealthText (string aMessage_string)
		{
			_healthGUIText.text = aMessage_string;
			_healthGUIText2.text = aMessage_string;

		}

		/// <summary>
		/// Dos the prompt start.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		public void doPromptStart (string aMessage_string, bool aIsToFadeOutToo_boolean) 
		{

			//
			_setPromptText (aMessage_string);


			//SETUP: IMMEDIATLY SET ALPHA TO 0


			Hashtable fadeTo_hashtable = new Hashtable();
			fadeTo_hashtable.Add(iT.FadeTo.amount,				0);
			fadeTo_hashtable.Add(iT.FadeTo.time,  				0);
			fadeTo_hashtable.Add(iT.FadeTo.easetype, 			iTween.EaseType.linear);
			//
			iTween.FadeTo (promptGUIText_gameObject, 			fadeTo_hashtable);
			iTween.FadeTo (promptGUIText2_gameObject, 			fadeTo_hashtable);

			//_doSetGUITextGameObjectAlpha (promptGUIText_gameObject, 0);
			//_doSetGUITextGameObjectAlpha (promptGUIText2_gameObject, 0);

			/*********
			 * 
			 * SETUP: FADE FROM 0 TO 100
			 * 
			 ********/
			Hashtable fadeTo2_hashtable = new Hashtable();
			fadeTo2_hashtable.Add(iT.FadeTo.delay,				.1f);
			fadeTo2_hashtable.Add(iT.FadeTo.amount,				1);
			fadeTo2_hashtable.Add(iT.FadeTo.time,  				.5);
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
				fadeTo3_hashtable.Add(iT.FadeTo.delay, 				2);
				fadeTo3_hashtable.Add(iT.FadeTo.alpha,				0);
				fadeTo3_hashtable.Add(iT.FadeTo.time,  				.5);
				fadeTo3_hashtable.Add(iT.FadeTo.easetype, 			iTween.EaseType.linear);
				fadeTo3_hashtable.Add(iT.FadeTo.oncompletetarget, 	gameObject);
				//
				iTween.FadeTo (promptGUIText_gameObject, 			fadeTo3_hashtable);
				//CALL COMPLETE JUST ONCE
				fadeTo3_hashtable.Add(iT.FadeTo.oncomplete, 			"_onPromptRemoved");
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
			_promptGUIText.text = aMessage_string;
			_promptGUIText2.text = aMessage_string;
			
		}

		/// <summary>
		/// _dos the set GUI text game object alpha.
		/// </summary>
		/// <param name="aGameObject">A game object.</param>
		/// <param name="aAlpha_float">A alpha_float.</param>
		private void _doSetGUITextGameObjectAlpha (GameObject aGameObject, float aAlpha_float)
		{
			GUIText guiText = aGameObject.guiText;
			guiText.color 	= new Color (guiText.color.r, guiText.color.g, guiText.color.b, aAlpha_float);

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
		/// _ons the prompt removed.
		/// </summary>
		private void _onPromptRemoved ()
		{
			//Debug.Log ("_onPromptRemoved!!");
			uiPromptEndedSignal.Dispatch ();
			
		}
		
	}
}

