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
using com.rmc.projects.paddle_soccer.mvcs.model.vo;
using com.rmc.projects.paddle_soccer.mvcs.view.ui.super;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs.view.ui
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
		/// When the custom skin.
		/// </summary>
		#if UNITY_EDITOR
		public GUISkin guiSkin;
		#endif 

		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _is currently down_boolean.
		/// </summary>
		bool _isCurrentlyDown_boolean = true;

		/// <summary>
		/// The _is currently up_boolean.
		/// </summary>
		bool _isCurrentlyUp_boolean = true;

		
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


		//
		public override void Update()
		{
			//
			base.Update();

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
		/// _dos the set is currently down.
		/// </summary>
		/// <param name="aIsCurrentlyDown_boolean">If set to <c>true</c> a is currently down_boolean.</param>
		private void _doSetIsCurrentlyDown (bool aIsCurrentlyDown_boolean) 
		{
			if (_isCurrentlyDown_boolean != aIsCurrentlyDown_boolean) {
				_isCurrentlyDown_boolean = aIsCurrentlyDown_boolean;
				if (_isCurrentlyDown_boolean) {
					_doUpdateUIInput (KeyCode.DownArrow, UIInputEventType.DownEnter);
				} else {
					_doUpdateUIInput (KeyCode.DownArrow, UIInputEventType.DownExit);
				}
			}
			
		}

		// PRIVATE
		/// <summary>
		/// _dos the set is currently up.
		/// </summary>
		/// <param name="aIsCurrentlyLeft_boolean">If set to <c>true</c> a is currently left_boolean.</param>
		private void _doSetIsCurrentlyUp (bool aIsCurrentlyUp_boolean) 
		{
			if (_isCurrentlyUp_boolean != aIsCurrentlyUp_boolean) {
				_isCurrentlyUp_boolean = aIsCurrentlyUp_boolean;
				if (_isCurrentlyUp_boolean) {
					_doUpdateUIInput (KeyCode.UpArrow, UIInputEventType.DownEnter);
				} else {
					_doUpdateUIInput (KeyCode.UpArrow, UIInputEventType.DownExit);
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
		/// 
		/// 
		/// 		/// NOTE: This class must know DownEnter vs DownExit. The 'DownStay' is handled in the superclass.
		/// 
		/// 
		/// </summary>
		void OnGUI () 
		{

			if (isVisible) {
				//TODO: IS THERE A BETTER WAY TO HANDLE THE STATE OF THESE THREE 'CURRENTLY' VALUES?

				#if UNITY_EDITOR
				GUI.skin = guiSkin;
				#endif 



				//LEFT
				if (GUI.RepeatButton (new Rect (_SCREEN_MARGIN, Screen.height - _BUTTON_HEIGHT - _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT), Constants.VIRTUAL_CONTROLLER_BUTTON_LABEL_UP)) {
					_doSetIsCurrentlyUp (true);
				} else if (_isCurrentlyUp_boolean && Event.current.type == EventType.repaint) { 
					_doSetIsCurrentlyUp (false);
				}


				//RESET
				if( GUI.RepeatButton (new Rect (Screen.width/2 - (_BUTTON_WIDTH/2), Screen.height - _BUTTON_HEIGHT_SKINNY - _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT_SKINNY), Constants.VIRTUAL_CONTROLLER_BUTTON_LABEL_RESET)) {
					_doUpdateUIInput (KeyCode.Return, UIInputEventType.DownEnter);
				} 

				//FIRE
				if( GUI.RepeatButton (new Rect (Screen.width - _BUTTON_WIDTH - _SCREEN_MARGIN, Screen.height - _BUTTON_HEIGHT - _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT), Constants.VIRTUAL_CONTROLLER_BUTTON_LABEL_DOWN)) {
					_doSetIsCurrentlyDown (true);
				} else if (_isCurrentlyDown_boolean && Event.current.type == EventType.repaint) { 
					_doSetIsCurrentlyDown (false);

				}

			}
		}


	}
}

