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
using com.rmc.projects.paddle_soccer.mvcs.model.vo;
using com.rmc.projects.paddle_soccer.mvcs.view.signals;
using System.Collections.Generic;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs.view.ui.super
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
		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			base.Start();
			_lastInputVOByKeycode_dictionary = new Dictionary<KeyCode,UIInputVO>();
		}



		/// <summary>
		/// Update this instance.
		/// </summary>
		public virtual void Update()
		{
			_doProcessDownStayEvents();
		}


		
		// PUBLIC
		/// <summary>
		/// Init this instance.
		/// </summary>
		virtual public void init()
		{
			uiInputChangedSignal = new UIInputChangedSignal ();
			
		}
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy ()
		{
			//
			base.OnDestroy();
			
			//
			uiInputChangedSignal = null; //overkill to existing garbage-collection.
			
		}
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// Do update user interface input.
		/// 
		/// NOTE: We get DownEnter and DownExit
		/// 
		/// NOTE: We interpolate and SOMETIMES send DownStay
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
		/// NOTE: We use the state information here to repeatedly send 'yes I'm currently down' events
		/// 
		/// 
		/// 
		/// </summary>
		private void _doProcessDownStayEvents ()
		{

			//
			foreach (UIInputVO uiInputVO in _lastInputVOByKeycode_dictionary.Values)
			{
				if (uiInputVO.uiInputEventType == UIInputEventType.DownEnter) {
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
	}
}

