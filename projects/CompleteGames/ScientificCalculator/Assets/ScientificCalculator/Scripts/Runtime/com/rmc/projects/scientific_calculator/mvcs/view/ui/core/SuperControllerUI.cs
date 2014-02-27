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
using com.rmc.projects.scientific_calculator.mvcs.model.vo;
using com.rmc.projects.scientific_calculator.mvcs.view.signals;
using System.Collections.Generic;

//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.scientific_calculator.components;


namespace com.rmc.projects.scientific_calculator.mvcs.view.ui.core
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
	public class SuperControllerUI : View 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		/// <summary>
		/// When the user interface button clicked signal.
		/// </summary>
		public UIInputChangedSignal uiInputChangedSignal {set; get;}


		public UITestSignal uiTestSignal { set; get; }

		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// When the _last user interface input V os_list.
		/// </summary>
		/// 
		private Dictionary<KeyCode,UIInputVO> _lastInputVOByKeycode_dictionary;

		/// <summary>
		/// Sets the visibility.
		/// </summary>
		private bool _isVisible_boolean;
		public bool isVisible
		{ 
			get{
				return _isVisible_boolean;
			}
			set
			{
				_isVisible_boolean = value;
			}
		}

		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		// PUBLIC

		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			base.Start();

		}

		/// <summary>
		/// Init this instance.
		/// </summary>
		virtual public void init()
		{
			//
			_lastInputVOByKeycode_dictionary = new Dictionary<KeyCode,UIInputVO>();
			uiInputChangedSignal = new UIInputChangedSignal ();
			uiTestSignal = new UITestSignal();
			
		}

		/// <summary>
		/// Update this instance.
		/// </summary>
		public virtual void Update()
		{

			//NOTE: See comments in '_doUpdateUIInput'
			_doProcessDownStayEvents();
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
		/// <summary>
		/// Do update user interface input.
		/// 
		/// NOTE: We get DownEnter and DownExit
		/// 
		/// NOTE: We interpolate and SOMETIMES send DownStay using _doProcessDownStayEvents
		/// 
		/// 
		/// </summary>
		/// <param name="aKeyCode">A key code.</param>
		/// <param name="aUIInputEventType">A user interface input event type.</param>
		protected void _doUpdateUIInput (KeyCode aKeyCode, UIInputEventType aUIInputEventType )
		{

			//CHECK OLD DATA
			UIInputVO newToSendUIInputVO 		= new UIInputVO (aKeyCode, aUIInputEventType);

			//STORE *ONLY* MOST RECENT PER KEYCODE
			_lastInputVOByKeycode_dictionary[newToSendUIInputVO.keyCode] = (newToSendUIInputVO);

			//ALWAYS SEND
			uiInputChangedSignal.Dispatch (newToSendUIInputVO);
			
		}

		/// <summary>
		/// Do process down stay events.
		/// 
		/// NOTE: See comments in '_doUpdateUIInput'
		/// 
		/// </summary>
		private void _doProcessDownStayEvents ()
		{
			foreach (UIInputVO uiInputVO in _lastInputVOByKeycode_dictionary.Values)
			{
				if (uiInputVO.uiInputEventType == UIInputEventType.DownEnter) {
					//Debug.Log ("_doProcessDownStayEvents() : ");
					uiInputChangedSignal.Dispatch (new UIInputVO (uiInputVO.keyCode, UIInputEventType.DownStay));
				}
			}
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
		/// Ons the user interface button press.
		/// 
		/// NOTE: Must be public (for sendmessage's use)
		/// 
		/// </summary>
		/// <param name="aGameObject">A game object.</param>
		public void onUIButtonPress (GameObject aGameObject) 
		{
			ButtonDataComponent buttonDataComponent = aGameObject.GetComponentInChildren<ButtonDataComponent>();
			_doUpdateUIInput (buttonDataComponent.keyCode, UIInputEventType.DownEnter);
		}
		
		/// <summary>
		/// Ons the user interface button press.
		/// 
		/// NOTE: Must be public (for sendmessage's use)
		/// 
		/// </summary>
		/// <param name="aGameObject">A game object.</param>
		public void onUIButtonRelease (GameObject aGameObject) 
		{
			ButtonDataComponent buttonDataComponent = aGameObject.GetComponentInChildren<ButtonDataComponent>();
			_doUpdateUIInput (buttonDataComponent.keyCode, UIInputEventType.DownExit);
		}
	}
}

