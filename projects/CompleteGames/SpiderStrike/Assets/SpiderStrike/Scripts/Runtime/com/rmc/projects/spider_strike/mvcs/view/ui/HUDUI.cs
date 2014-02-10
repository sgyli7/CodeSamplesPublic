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
		public void doPromptStart (string aMessage_string) 
		{

			//
			_setPromptText (aMessage_string);


			//SETUP: IMMEDIATLY SET ALPHA TO 0
			/*
			iTween.StopByName (promptGUIText_gameObject, "fadeTo", true);
			iTween.StopByName (promptGUIText2_gameObject, "fadeFrom", true);
			Hashtable startInvisible_hashtable = new Hashtable();
			startInvisible_hashtable.Add(iT.FadeTo.delay, 				0);
			startInvisible_hashtable.Add(iT.FadeTo.alpha,				0);
			startInvisible_hashtable.Add(iT.FadeTo.time,  				0);
			//
			iTween.FadeTo (promptGUIText_gameObject, 0, 0);
			iTween.FadeTo (promptGUIText2_gameObject, 0, 0);

*/


			/*********
			 * 
			 * SETUP: FADE FROM 0 TO 100
			 * 
			 ********/
			//_promptGUIText.font.material.color.a = 0.5f;
			Hashtable fadeFrom_hastable = new Hashtable();
			fadeFrom_hastable.Add("name",						"fadeFrom");
			fadeFrom_hastable.Add(iT.FadeFrom.alpha,			.1f);
			fadeFrom_hastable.Add(iT.FadeFrom.time,  			.25);
			fadeFrom_hastable.Add(iT.FadeFrom.easetype, 		iTween.EaseType.linear);
			iTween.FadeFrom (promptGUIText_gameObject, 			fadeFrom_hastable);
			iTween.FadeFrom (promptGUIText2_gameObject, 		fadeFrom_hastable);

			/*********
			 * 
			 * SETUP: FADE FROM 100 TO 0
			 * 
			 ********/
			//_promptGUIText.font.material.color.a = 0.5f;
			Hashtable fadeTo_hashtable = new Hashtable();
			fadeTo_hashtable.Add("name",						"fadeTo");
			fadeTo_hashtable.Add(iT.FadeTo.delay, 				1.5);
			fadeTo_hashtable.Add(iT.FadeTo.alpha,				0);
			fadeTo_hashtable.Add(iT.FadeTo.time,  				.25);
			fadeTo_hashtable.Add(iT.FadeTo.easetype, 			iTween.EaseType.linear);
			fadeTo_hashtable.Add(iT.FadeTo.oncompletetarget, 	gameObject);
			//
			iTween.FadeTo (promptGUIText_gameObject, 			fadeTo_hashtable);
			//CALL COMPLETE JUST ONCE
			fadeTo_hashtable.Add(iT.FadeTo.oncomplete, 			"_onPromptRemoved");
			iTween.FadeTo (promptGUIText2_gameObject, 			fadeTo_hashtable);

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
			Debug.Log ("_onPromptRemoved!!");
			uiPromptEndedSignal.Dispatch ();
			iTween.FadeTo (promptGUIText_gameObject, 0, 0);
			iTween.FadeTo (promptGUIText2_gameObject, 0, 0);
			
		}
		
	}
}

