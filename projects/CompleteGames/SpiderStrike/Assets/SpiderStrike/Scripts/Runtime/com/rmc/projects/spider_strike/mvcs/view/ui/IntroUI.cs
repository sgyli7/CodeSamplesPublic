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
using com.rmc.projects.spider_strike.mvcs.view.signals;

//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.utilities;
using com.rmc.projects.spider_strike.mvcs.model.vo;


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
	public class IntroUI : View 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// Gets or sets the user interface intro ended signal.
		/// </summary>
		/// <value>The user interface intro ended signal.</value>
		public UIIntroEndedSignal uiIntroEndedSignal { set; get; }

		
		/// <summary>
		/// The user interface button clicked signal.
		/// </summary>
		public UIInputChangedSignal uiInputChangedSignal {set; get;}

		/// <summary>
		/// The _text alpha_float.
		/// </summary>
		float _textAlpha_float = 1.0f;
		public float textAlpha 
		{
			get { 
				return _textAlpha_float; 
			}
			set { 
				_textAlpha_float = value; 

				//THIS IS NEVER CALLED. WHY?
				//WORKAROUND: CALL THIS IN 'UPDATE'
				//RendererUtility.SetMaterialAlpha (_clickGUIText.material, _textAlpha_float);
				Debug.Log ("a1: " + _textAlpha_float);
			}
		}

		// PUBLIC
		public GameObject clickGUIText_gameobject;
		
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
			uiIntroEndedSignal = new UIIntroEndedSignal ();
			uiInputChangedSignal = new UIInputChangedSignal();
			
		}
		
		
		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			
			base.Start();
			_clickGUIText = clickGUIText_gameobject.GetComponent<GUIText>();
			
			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
			RendererUtility.SetMaterialAlpha (_clickGUIText.material, _textAlpha_float);


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
		
	}
}

