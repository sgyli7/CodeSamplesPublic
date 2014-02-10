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
using com.rmc.projects.spider_strike.mvcs.controller.signals;
using strange.extensions.signal.impl;

//--------------------------------------
//  Namespace
//--------------------------------------
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
	public class VirtualControllerUI : SuperControllerUI, IControllerUI
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// The custom skin.
		/// </summary>
		#if UNITY_EDITOR
		public GUISkin guiSkin;
		#endif 

		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		private const float _SCREEN_TOP_MARGIN = 30;
		private const float _SCREEN_MARGIN = 20;
		private const float _BUTTON_WIDTH = 120;
		private const float _BUTTON_HEIGHT = 100;
		private const float _BUTTON_HEIGHT_SKINNY = 70;
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			
			base.Start();
			
		}
		

		// PUBLIC
		/// <summary>
		/// Init this instance.
		/// </summary>
		override public void init()
		{
			base.init();

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
		/// The _is firing_boolean.
		/// </summary>
		bool _isCurrentlyFiring_boolean = true;

		/// <summary>
		/// _dos the set is firing.
		/// </summary>
		/// <param name="aIsFiring_boolean">If set to <c>true</c> a is firing_boolean.</param>
		private void _doSetIsCurrentlyFiring (bool aIsCurrentlyFiring_boolean) 
		{
			if (_isCurrentlyFiring_boolean != aIsCurrentlyFiring_boolean) {
				_isCurrentlyFiring_boolean = aIsCurrentlyFiring_boolean;
				if (_isCurrentlyFiring_boolean) {
					_doUpdateUIInput (KeyCode.Space, UIInputEventType.Down);
				} else {
					_doUpdateUIInput (KeyCode.Space, UIInputEventType.Up);
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
		/// Raises the GUI event.
		/// </summary>
		void OnGUI () 
		{

			#if UNITY_EDITOR
			GUI.skin = guiSkin;
			#endif 
			
			//RESET
			if (GUI.Button (new Rect (Screen.width/2 - _BUTTON_WIDTH/2, _SCREEN_TOP_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT_SKINNY), "Reset")) {
				_doUpdateUIInput (KeyCode.Return, UIInputEventType.Down);
			}

			//LEFT
			if (GUI.Button (new Rect (_SCREEN_MARGIN, Screen.height - _BUTTON_HEIGHT - _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT), "Left")) {
				_doUpdateUIInput (KeyCode.LeftArrow, UIInputEventType.Down);
			}

			//RIGHT
			if (GUI.Button (new Rect (_SCREEN_MARGIN + _SCREEN_MARGIN + _BUTTON_WIDTH, Screen.height - _BUTTON_HEIGHT - _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT), "Right")) {
				_doUpdateUIInput (KeyCode.RightArrow, UIInputEventType.Down);
			}

			//FIRE
			if( GUI.RepeatButton (new Rect (Screen.width - _BUTTON_WIDTH - _SCREEN_MARGIN, Screen.height - _BUTTON_HEIGHT - _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT), "Fire")) {
				_doSetIsCurrentlyFiring (true);
			} else if (_isCurrentlyFiring_boolean && Event.current.type == EventType.repaint) { 
				_doSetIsCurrentlyFiring (false);

			}


		}


	}
}

