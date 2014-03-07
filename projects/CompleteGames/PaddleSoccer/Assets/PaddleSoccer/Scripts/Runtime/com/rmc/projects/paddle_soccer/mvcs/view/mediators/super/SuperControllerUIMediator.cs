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
using UnityEngine;
using com.rmc.projects.paddle_soccer.mvcs.controller.signals;
using strange.extensions.mediation.impl;
using com.rmc.projects.paddle_soccer.mvcs.model.vo;
using com.rmc.projects.paddle_soccer.mvcs.model;
using com.rmc.projects.paddle_soccer.mvcs.view.ui.super;



//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs.view.mediators.super
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
	public class SuperControllerUIMediator : Mediator
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		/*
		 * NOTE: According to my tests and
		 * 		http://kendlj.wordpress.com/2014/01/03/unit-testing-strangeioc-mediator/
		 * 
		 * 		We cannot do "mediationBinder.Bind<IControllerUI>().To<VirtualControllerUIMediator>();
		 * 
		 * 		So this is a workaround
		 * 
		 **/
		public IControllerUI view 	{ get; set;}

		
		/// <summary>
		/// Gets or sets the sound play signal.
		/// </summary>
		/// <value>The sound play signal.</value>
		[Inject]
		public SoundPlaySignal soundPlaySignal { get; set;}

		/// <summary>
		/// Gets or sets the player move signal.
		/// </summary>
		/// <value>The player move signal.</value>
		[Inject]
		public PlayerDoMoveSignal playerDoMoveSignal 		{ get; set;}

		/// <summary>
		/// Gets or sets the game reset signal.
		/// </summary>
		/// <value>The game reset signal.</value>
		[Inject]
		public GameResetSignal gameResetSignal 		{ get; set;}


		/// <summary>
		/// MODEL: The main game data
		/// </summary>
		[Inject]
		public IGameModel iGameModel { get; set; } 


		/// <summary>
		/// Gets or sets the cross platform changed signal.
		/// </summary>
		/// <value>The cross platform changed signal.</value>
		[Inject]
		public CrossPlatformChangedSignal crossPlatformChangedSignal {get;set;}

		
		// PUBLIC
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		/// <summary>
		/// Spin amount per click
		/// </summary>
		private const float _PADDLE_MOVE_PER_TICK = 0.25f;
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		/// <summary>
		/// Raises the register event.
		/// </summary>
		public override void OnRegister()
		{
			view.init();
			view.uiInputChangedSignal.AddListener (_onUIInputChangedSignal);
			crossPlatformChangedSignal.AddListener (_onCrossPlatformChangedSignal);
	}
		
		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			view.uiInputChangedSignal.RemoveListener (_onUIInputChangedSignal);
			crossPlatformChangedSignal.RemoveListener (_onCrossPlatformChangedSignal);
		}
		
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update()
		{
			
			
		}
		
		
		// PUBLIC
		/// <summary>
		/// Resets the game.
		/// 
		/// </summary>
		public void _doResetGame ()
		{
			gameResetSignal.Dispatch ();

		}
		
		
		// PRIVATE
		/// <summary>
		/// _dos the send move.
		/// </summary>
		/// <param name="aPlayerMoveVO">A player move V.</param>
		private void _doSendMove (PlayerMoveVO aPlayerMoveVO) 
		{
			if (iGameModel.gameState == GameState.ROUND_DURING_CORE_GAMEPLAY) {
				playerDoMoveSignal.Dispatch (aPlayerMoveVO);
			}
		
		}
		
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// When the cross platform changed signal fires.
		/// 
		/// NOTE: 	During startup we dispatch this signal based on
		/// 		Application.platform so obvservers can handle themselves.
		/// 
		/// </summary>
		/// <param name="aRuntimePlatform">A runtime platform.</param>
		protected virtual void _onCrossPlatformChangedSignal (RuntimePlatform aRuntimePlatform)
		{
			//OVERRIDE FOR USEAGE

		}


		/// <summary>
		/// When the user interface input signal.
		/// </summary>
		/// <param name="aUIInputType">A user interface input type.</param>
		private void _onUIInputChangedSignal (UIInputVO aUIInputVO)
		{


			//
			if (aUIInputVO.uiInputEventType == UIInputEventType.DownEnter) {


				//KEYDOWN
				switch (aUIInputVO.keyCode) {
					case KeyCode.LeftArrow:
					case KeyCode.RightArrow:
					case KeyCode.Return:
						soundPlaySignal.Dispatch (new SoundPlayVO (SoundType.BUTTON_CLICK));
						_doResetGame();
						break;
				}

			} else if (aUIInputVO.uiInputEventType == UIInputEventType.DownExit) {



			} else if (aUIInputVO.uiInputEventType == UIInputEventType.DownStay) {

				//KEYSTAY
				switch (aUIInputVO.keyCode) {
					case KeyCode.UpArrow:
						_doSendMove (		 new PlayerMoveVO( MoveType.UpOneTick, _PADDLE_MOVE_PER_TICK));
						break;
					case KeyCode.DownArrow:
						_doSendMove (new PlayerMoveVO( MoveType.DownOneTick, _PADDLE_MOVE_PER_TICK));
						break;
				}
				
				
			}
			
			
		}
	}
}

