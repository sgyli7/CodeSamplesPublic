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
using UnityEngine;
using com.rmc.projects.paddle_soccer.mvcs.model.vo;
using com.rmc.projects.animation_monitor;



//--------------------------------------
//  Namespace
//--------------------------------------
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
	public class IntroUIMediator : Mediator
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		/// <summary>
		/// Gets or sets the view.
		/// </summary>
		/// <value>The view.</value>
		[Inject]
		public IntroUI view 	{ get; set;}
		
		/// <summary>
		/// MODEL: The main game data
		/// </summary>
		[Inject]
		public IGameModel iGameModel { get; set; } 

		/// <summary>
		/// Gets or sets the game state change signal.
		/// </summary>
		/// <value>The game state change signal.</value>
		[Inject]
		public GameStateChangeSignal gameStateChangeSignal {set; get;}


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


		// PUBLIC
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// When the _was clicked_boolean.
		/// NOTE: Used to accept exactly 0,1 clicks
		/// </summary>
		private bool _wasClicked_boolean = false;


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
			gameStateChangedSignal.AddListener (_onGameStateChangedSignal);
			view.uiInputChangedSignal.AddListener (_onUIInputChangedSignal);

			
		}
		
		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			gameStateChangedSignal.RemoveListener (_onGameStateChangedSignal);
			view.uiInputChangedSignal.RemoveListener (_onUIInputChangedSignal);
			view.animationMonitor.uiAnimationMonitorSignal.AddListener (_onUIAnimationCompleteSignal);
		}
		
		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start()
		{
			view.animationMonitor.uiAnimationMonitorSignal.AddListener (_onUIAnimationCompleteSignal);	
			view.setClickText (Constants.HUD_CLICK_ANYWHERE);
			view.setClickTextIsVisible 		(false);
			view.setLogoTextureIsVisible 	(false);
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
		/// When the user interface input changed signal.
		/// </summary>
		/// <param name="">.</param>
		private void _onUIInputChangedSignal (UIInputVO aUIInputVO) 
		{

			//USER CLICKED? - PLAY THE 'END'
			if (iGameModel.gameState == GameState.INTRO_START && !_wasClicked_boolean) {
				_wasClicked_boolean = true;
				view.doPlayAnimation (IntroUI.ANIMATION_NAME_INTRO_UI_END, 0, 0);
				soundPlaySignal.Dispatch ( new SoundPlayVO (SoundType.BUTTON_CLICK));
				//
			}
		}



		/// <summary>
		/// When the game state changed signal.
		/// </summary>
		/// <param name="aGameState">A game state.</param>
		private void _onGameStateChangedSignal (GameState aGameState)
		{
			//
			if (aGameState == GameState.INTRO_START) {
				_wasClicked_boolean = false;
				//
				view.setClickTextIsVisible 		(true);
				view.setLogoTextureIsVisible 	(true);
				view.doPlayAnimation (IntroUI.ANIMATION_NAME_INTRO_UI_START, 0, 0);
			}
			
		}


		/// <summary>
		/// When the user interface animation complete signal.
		/// </summary>
		/// <param name="aAnimationType">A animation type.</param>
		private void _onUIAnimationCompleteSignal (AnimationMonitorEventVO aUIAnimationMonitorEventVO)
		{

			//Debug.Log ("AnimEnd: " + aUIAnimationMonitorEventVO.animationClipName + " DELAY?: " + aUIAnimationMonitorEventVO.animationMonitorEventType);
			//we only care to hear 1 time, after any delays
			if (aUIAnimationMonitorEventVO.animationMonitorEventType == AnimationMonitorEventType.POST_COMPLETE ) {
				if (aUIAnimationMonitorEventVO.animationMonitorRequestVO.animationClipName == IntroUI.ANIMATION_NAME_INTRO_UI_END) {
					view.gameObject.SetActive (false);
					gameStateChangeSignal.Dispatch (GameState.GAME_START);
				}
			}

			
		}
		
	}
}

