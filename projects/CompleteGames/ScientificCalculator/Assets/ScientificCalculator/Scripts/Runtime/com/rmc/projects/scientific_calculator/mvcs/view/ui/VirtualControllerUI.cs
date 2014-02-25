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
using com.rmc.projects.scientific_calculator.mvcs.model.vo;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.scientific_calculator.mvcs.view.ui
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
		/// When the _is firing_boolean.
		/// </summary>
		bool _isCurrentlyFiring_boolean = true;
		
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
		/// Do set is firing.
		/// </summary>
		/// <param name="aIsFiring_boolean">If set to <c>true</c> a is firing_boolean.</param>
		private void _doSetIsCurrentlyFiring (bool aIsCurrentlyFiring_boolean) 
		{
			if (_isCurrentlyFiring_boolean != aIsCurrentlyFiring_boolean) {
				_isCurrentlyFiring_boolean = aIsCurrentlyFiring_boolean;
				if (_isCurrentlyFiring_boolean) {
					_doUpdateUIInput (KeyCode.Space, UIInputEventType.DownEnter);
				} else {
					_doUpdateUIInput (KeyCode.Space, UIInputEventType.DownExit);
				}
			}
			
		}

		// PRIVATE
		/// <summary>
		/// When the _is currently left_boolean.
		/// </summary>
		bool _isCurrentlyLeft_boolean = true;
		
		/// <summary>
		/// Do set is currently left.
		/// </summary>
		/// <param name="aIsCurrentlyLeft_boolean">If set to <c>true</c> a is currently left_boolean.</param>
		private void _doSetIsCurrentlyLeft (bool aIsCurrentlyLeft_boolean) 
		{
			if (_isCurrentlyLeft_boolean != aIsCurrentlyLeft_boolean) {
				_isCurrentlyLeft_boolean = aIsCurrentlyLeft_boolean;
				if (_isCurrentlyLeft_boolean) {
					_doUpdateUIInput (KeyCode.LeftArrow, UIInputEventType.DownEnter);
				} else {
					_doUpdateUIInput (KeyCode.LeftArrow, UIInputEventType.DownExit);
				}
			}
			
		}


		// PRIVATE
		/// <summary>
		/// When the _is currently left_boolean.
		/// </summary>
		bool _isCurrentlyRight_boolean = true;
		
		/// <summary>
		/// Do set is currently left.
		/// </summary>
		/// <param name="aIsCurrentlyLeft_boolean">If set to <c>true</c> a is currently left_boolean.</param>
		private void _doSetIsCurrentlyRight (bool aIsCurrentlyRight_boolean) 
		{
			if (_isCurrentlyRight_boolean != aIsCurrentlyRight_boolean) {
				_isCurrentlyRight_boolean = aIsCurrentlyRight_boolean;
				if (_isCurrentlyRight_boolean) {
					_doUpdateUIInput (KeyCode.RightArrow, UIInputEventType.DownEnter);
				} else {
					_doUpdateUIInput (KeyCode.RightArrow, UIInputEventType.DownExit);
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
				if (GUI.RepeatButton (new Rect (_SCREEN_MARGIN, Screen.height - _BUTTON_HEIGHT - _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT), "Left")) {
					_doSetIsCurrentlyLeft (true);
				} else if (_isCurrentlyLeft_boolean && Event.current.type == EventType.repaint) { 
					_doSetIsCurrentlyLeft (false);
				}

				//RIGHT
				if (GUI.RepeatButton (new Rect (_SCREEN_MARGIN + _SCREEN_MARGIN + _BUTTON_WIDTH, Screen.height - _BUTTON_HEIGHT - _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT), "Right")) {
					_doSetIsCurrentlyRight (true);
				} else if (_isCurrentlyRight_boolean && Event.current.type == EventType.repaint) { 
					_doSetIsCurrentlyRight (false);
				}

				//RESET
				if( GUI.RepeatButton (new Rect (Screen.width - (_BUTTON_WIDTH - _SCREEN_MARGIN)*3, Screen.height - _BUTTON_HEIGHT_SKINNY - _SCREEN_MARGIN, _BUTTON_WIDTH, _BUTTON_HEIGHT_SKINNY), "Reset")) {
					_doUpdateUIInput (KeyCode.Return, UIInputEventType.DownEnter);
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
}

