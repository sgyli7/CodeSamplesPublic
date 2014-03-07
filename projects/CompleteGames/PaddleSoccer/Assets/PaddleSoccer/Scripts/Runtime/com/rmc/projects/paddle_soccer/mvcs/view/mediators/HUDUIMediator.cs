/**
 * Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furn
 * 
 * ished to do so, subject to
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
using strange.extensions.mediation.impl;
using com.rmc.projects.paddle_soccer.mvcs.view.ui;
using com.rmc.projects.paddle_soccer.mvcs.controller.signals;
using com.rmc.projects.paddle_soccer.mvcs.model;
using System;
using UnityEngine;


//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.paddle_soccer.mvcs.model.vo;


namespace com.rmc.projects.paddle_soccer.mvcs.view.mediators
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
	public class HUDUIMediator : Mediator
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		/// <summary>
		/// Gets or sets the view.
		/// </summary>
		/// <value>The view.</value>
		[Inject]
		public HUDUI view 	{ get; set;}
		
		/// <summary>
		/// Gets or sets the right paddle score changed signal.
		/// </summary>
		/// <value>The right paddle score changed signal.</value>
		[Inject]
		public RightPaddleScoreChangedSignal rightPaddleScoreChangedSignal { get; set;}


		/// <summary>
		/// Gets or sets the left paddle score changed signal.
		/// </summary>
		/// <value>The left paddle score changed signal.</value>
		[Inject]
		public LeftPaddleScoreChangedSignal leftPaddleScoreChangedSignal { get; set;}

		/// <summary>
		/// Gets or sets the prompt start signal.
		/// </summary>
		/// <value>The prompt start signal.</value>
		[Inject]
		public PromptStartSignal promptStartSignal { get; set;}

		/// <summary>
		/// Gets or sets the prompt start signal.
		/// </summary>
		/// <value>The prompt start signal.</value>
		[Inject]
		public PromptEndedSignal promptEndedSignal { get; set;}

		/// <summary>
		/// Gets or sets the game state changed signal.
		/// </summary>
		/// <value>The game state changed signal.</value>
		[Inject]
		public GameStateChangedSignal gameStateChangedSignal {set; get;}

		
		/// <summary>
		/// Gets or sets the sound play signal.
		/// </summary>
		/// <value>The sound play signal.</value>
		[Inject]
		public SoundPlaySignal soundPlaySignal { get; set;}


		/// <summary>
		/// Gets or sets the cross platform changed signal.
		/// </summary>
		/// <value>The cross platform changed signal.</value>
		[Inject]
		public CrossPlatformChangedSignal crossPlatformChangedSignal {get;set;}
		



		// PUBLIC
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _restart GUI message_string.
		/// </summary>
		private string _restartGUIMessage_string;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		/// <summary>
		/// Raises the register event.
		/// </summary>
		public override void OnRegister()
		{

			view.init ();
			//Debug.Log ("HUD IS READY - WHY AFTER???");
			rightPaddleScoreChangedSignal.AddListener (_onRightPaddleScoreChangedSignal);
			leftPaddleScoreChangedSignal.AddListener (_onLeftPaddleScoreChangedSignal);
			promptStartSignal.AddListener (_onPromptStartSignal);
			view.uiPromptEndedSignal.AddListener (_onUIPromptEndedSignal);
			gameStateChangedSignal.AddListener (_onGameStateChangedSignal);
			crossPlatformChangedSignal.AddListener (_onCrossPlatformChangedSignal);


			
		}
		
		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			rightPaddleScoreChangedSignal.RemoveListener (_onRightPaddleScoreChangedSignal);
			leftPaddleScoreChangedSignal.RemoveListener (_onLeftPaddleScoreChangedSignal);
			promptStartSignal.RemoveListener (_onPromptStartSignal);
			view.uiPromptEndedSignal.RemoveListener (_onUIPromptEndedSignal);
			gameStateChangedSignal.RemoveListener (_onGameStateChangedSignal);
			crossPlatformChangedSignal.RemoveListener (_onCrossPlatformChangedSignal);
		}
		
		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start()
		{
			view.setVisibility (false);
			view.setVisibilityForRestartGUI (false);
		}



		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update()
		{
			
			
		}
		
		
		// PUBLIC
		
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// When the game state changed signal.
		/// </summary>
		/// <param name="aGameState">A game state.</param>
		private void _onGameStateChangedSignal (GameState aGameState)
		{
			//
			if (aGameState == GameState.ROUND_PROMPT_START || aGameState == GameState.ROUND_DROP_BALL_START) {

				view.setVisibility (true);
			} else if (aGameState == GameState.GAME_END) {
				view.setVisibilityForRestartGUI (true);

				view.setTextForRestartGUI (_restartGUIMessage_string);
			}
			
		}


		/// <summary>
		/// _ons the left paddle score changed signal.
		/// </summary>
		/// <param name="aNewValue_int">A new value_int.</param>
		private void _onLeftPaddleScoreChangedSignal (int aNewValue_int)
		{
			view.setLeftScoreText (String.Format (Constants.HUD_LEFT_SCORE, aNewValue_int));
			
		}


		/// <summary>
		/// _ons the right paddle score changed signal.
		/// </summary>
		/// <param name="aNewValue_int">A new value_int.</param>
		private void _onRightPaddleScoreChangedSignal (int aNewValue_int)
		{
			view.setRightScoreText (String.Format (Constants.HUD_RIGHT_SCORE, aNewValue_int));

		}


		/// <summary>
		/// When the prompt start signal.
		/// </summary>
		/// <param name="aNewValue_float">A new value_float.</param>
		private void _onPromptStartSignal (string aMessage_string, bool aIsToFadeOutToo_boolean, bool hasSound_boolean)
		{
			if (hasSound_boolean) {
				soundPlaySignal.Dispatch ( new SoundPlayVO (SoundType.ROUND_START));
			}
			view.doPromptStart (aMessage_string, aIsToFadeOutToo_boolean);
			
		}

		/// <summary>
		/// When the user interface prompt ended signal.
		/// </summary>
		private void _onUIPromptEndedSignal ()
		{
			promptEndedSignal.Dispatch (view.promptMessage);
			
		}

		/// When the cross platform changed signal fires.
		/// 
		/// NOTE: 	During startup we dispatch this signal based on
		/// 		Application.platform so obvservers can handle themselves.
		/// 
		/// </summary>
		/// <param name="aRuntimePlatform">A runtime platform.</param>
		private void _onCrossPlatformChangedSignal (RuntimePlatform aRuntimePlatform)
		{
			//THIS FUNCTIONALITY SHOULD RUN ONLY ON SOME PLATFORMS.
			if (aRuntimePlatform != RuntimePlatform.IPhonePlayer) {
				
				_restartGUIMessage_string = Constants.HUD_CLICK_RESTART_KEYBOARD;
			} else {
				_restartGUIMessage_string = Constants.HUD_CLICK_RESTART_VIRTUAL;
			}

			
		}
		
	}
}

