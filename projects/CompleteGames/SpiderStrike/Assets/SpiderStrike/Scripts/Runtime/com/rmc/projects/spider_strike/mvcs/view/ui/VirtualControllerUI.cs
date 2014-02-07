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
		public GUISkin customSkin;

		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		private float _SCREEN_MARGIN = 10;
		private float _BUTTON_WIDTH = 100;
		private float _BUTTON_HEIGHT = 80;
		private float _BUTTON_HEIGHT_SKINNY = 30;
		
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
			
			GUI.skin = customSkin;

			
			//RESET
			if (GUI.Button (new Rect (Screen.width/2 - _BUTTON_WIDTH/2, _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT_SKINNY), "Reset")) {
			    _doPressButton (ButtonType.Reset);
			}

			//LEFT
			if (GUI.Button (new Rect (_SCREEN_MARGIN, Screen.height - _BUTTON_HEIGHT - _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT), "Left")) {
			    _doPressButton (ButtonType.Left);
			}

			//RIGHT
			if (GUI.Button (new Rect (_SCREEN_MARGIN + _SCREEN_MARGIN + _BUTTON_WIDTH, Screen.height - _BUTTON_HEIGHT - _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT), "Right")) {
			    _doPressButton (ButtonType.Right);
			}

			//FIRE
			if( GUI.Button (new Rect (Screen.width - _BUTTON_WIDTH - _SCREEN_MARGIN, Screen.height - _BUTTON_HEIGHT - _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT), "Fire")) {
			    _doPressButton (ButtonType.Fire);
			}
		}
	}
}

