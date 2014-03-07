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
using UnityEngine;
using com.rmc.projects.paddle_soccer.mvcs.model.vo;
using com.rmc.projects.paddle_soccer.mvcs.model;
using com.rmc.exceptions;
using System;


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
	public class GameManagerUIMediator : Mediator
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		/// <summary>
		/// Gets or sets the view.
		/// </summary>
		/// <value>The view.</value>
		[Inject]
		public GameManagerUI view 	{ get; set;}
		
		
		/// <summary>
		/// Gets or sets the right paddle score changed signal.
		/// </summary>
		/// <value>The right paddle score changed signal.</value>
		[Inject]
		public RightPaddleScoreChangedSignal rightPaddleScoreChangedSignal {set; get;}


		/// <summary>
		/// Gets or sets the left paddle score changed signal.
		/// </summary>
		/// <value>The left paddle score changed signal.</value>
		[Inject]
		public LeftPaddleScoreChangedSignal leftPaddleScoreChangedSignal {set; get;}
		
		
		/// <summary>
		/// MODEL: The main game data
		/// </summary>
		[Inject]
		public IGameModel iGameModel { get; set; } 
		
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
		/// Gets or sets the sound play signal.
		/// </summary>
		/// <value>The sound play signal.</value>
		[Inject]
		public SoundPlaySignal soundPlaySignal { get; set; }
		
		
		/// <summary>
		/// Gets or sets the game state change signal.
		/// </summary>
		/// <value>The game state change signal.</value>
		[Inject]
		public GameStateChangeSignal gameStateChangeSignal {set; get;}

		/// <summary>
		/// Gets or sets the game state change signal.
		/// </summary>
		/// <value>The game state change signal.</value>
		[Inject]
		public GameStateChangedSignal gameStateChangedSignal {set; get;}


		// PUBLIC
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		/// <summary>
		/// Raises the register event.
		/// </summary>
		public override void OnRegister()
		{
			//view.init();
			leftPaddleScoreChangedSignal.AddListener (_onLeftPaddleScoreChangedSignal);
			rightPaddleScoreChangedSignal.AddListener (_onRightPaddleScoreChangedSignal);
			gameStateChangedSignal.AddListener (_onGameStateChangedSignal);
			promptEndedSignal.AddListener (_onPromptEndedSignal);
			
		}
		
		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			leftPaddleScoreChangedSignal.AddListener (_onLeftPaddleScoreChangedSignal);
			rightPaddleScoreChangedSignal.AddListener (_onRightPaddleScoreChangedSignal);
			gameStateChangedSignal.RemoveListener (_onGameStateChangedSignal);
			promptEndedSignal.RemoveListener (_onPromptEndedSignal);
		}
		
		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start ()
		{
			
			
			
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
		/// When the prompt ended signal.
		/// </summary>
		private void _onPromptEndedSignal (string aPromptMessage_string)
		{

			if (iGameModel.gameState == GameState.ROUND_PROMPT_START) {
				gameStateChangeSignal.Dispatch (GameState.ROUND_DROP_BALL_START);
				//
			} else if (iGameModel.gameState == GameState.ROUND_DROP_BALL_START) {

				gameStateChangeSignal.Dispatch (GameState.ROUND_DROP_BALL_END);
			}
			
		}
		
		
		/// <summary>
		/// When the game state changed signal.
		/// </summary>
		/// <param name="aGameState">A game state.</param>
		private void _onGameStateChangedSignal (GameState aGameState)
		{
			
			//
			switch (aGameState){
			case GameState.INIT:
				gameStateChangeSignal.Dispatch (GameState.INTRO_START);
				break;
			case GameState.INTRO_START:
				//WAITING FOR: INTRO ANIM TO FINISH
				break;
			case GameState.GAME_START:
				gameStateChangeSignal.Dispatch (GameState.ROUND_PROMPT_START);
				//WAITING FOR: USER TO CLICK ANYWHERE
				break;
			case GameState.ROUND_PROMPT_START:
				promptStartSignal.Dispatch (String.Format
				                            (
					Constants.PROMPT_ROUND_START, 
					iGameModel.currentRoundDataVO.playerGoalsRequiredToWin), 
				                            true,
				                            true
				                            );
				view.cpuPaddleComponent.accelerationY = iGameModel.currentRoundDataVO.getRandomCPUMovementSpeedWithinRange();
				//WAITING FOR: PROMPT ANIM TO FINISH FOR "ROUND START..."
				break;
			case GameState.ROUND_DROP_BALL_START:
				promptStartSignal.Dispatch (
											Constants.PROMPT_DROP_BALL_START, 
											true, 
											false
											);
				//WAITING FOR: PROMPT ANIM TO FINISH FOR "GET READY..."
				break;
			case GameState.ROUND_DROP_BALL_END:
				//ADVANCE STATE
				gameStateChangeSignal.Dispatch (GameState.ROUND_DURING_CORE_GAMEPLAY);
				break;
			case GameState.ROUND_DURING_CORE_GAMEPLAY:
				break;
			case GameState.GAME_END:
				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException();
				break;
				#pragma warning restore 0162
			}
			
		}
		
		/// <summary>
		/// _dos the check round and game status after time.
		/// </summary>
		private void _doCheckRoundAndGameStatusAfterTime () 
		{
			//
			//Debug.Log ("_doCheckRoundAndGameStatusAfterTime()");
			//Debug.Log ("Check Player, ("+iGameModel.currentRoundDataVO.playerGoalsScoredThisRound + " of " +  iGameModel.currentRoundDataVO.playerGoalsRequiredToWin + ")");
			//Debug.Log ("Check CPU   , ("+iGameModel.currentRoundDataVO.cpuGoalsScoredThisRound + " of " +  iGameModel.currentRoundDataVO.cpuGoalsRequiredToLose + ")");



			//
			//1. LOST GAME
			//
			if (iGameModel.hasPlayerLostGame()) {

				//DONE
				gameStateChangeSignal.Dispatch ( GameState.GAME_END);
				promptStartSignal.Dispatch (Constants.PROMPT_GAME_END_LOSS, false, false);
				soundPlaySignal.Dispatch ( new SoundPlayVO (SoundType.GAME_OVER_LOSS));

			//
			//2. WON ROUND
			//
			} else if (iGameModel.hasPlayerWonRound()) {


				//
				//3. NEXT ROUND
				//
				if (iGameModel.hasNextRound()) {

					gameStateChangeSignal.Dispatch (GameState.ROUND_PROMPT_START);

				//
				//4. WON GAME
				//
				} else {
					//DONE
					gameStateChangeSignal.Dispatch ( GameState.GAME_END);
					promptStartSignal.Dispatch (Constants.PROMPT_GAME_END_WIN, false, false);
					soundPlaySignal.Dispatch ( new SoundPlayVO (SoundType.GAME_OVER_WIN));
				}

			//
			//5. NO WIN, NO LOSS, JUST PLAY NEXT ROUND
			//
			} else {


				gameStateChangeSignal.Dispatch (GameState.ROUND_DROP_BALL_START);

			}
			
		}
		

		
		/// <summary>
		/// _ons the left paddle score changed signal.
		/// 
		/// NOTE: The player scored a point
		/// 
		/// </summary>
		/// <param name="aLeftPaddleScore_int">A left paddle score_int.</param>
		private void _onLeftPaddleScoreChangedSignal (int aLeftPaddleScore_int)
		{
			if (aLeftPaddleScore_int > 0) {
				iGameModel.currentRoundDataVO.playerGoalsScoredThisRound++; //just add one
				_doCheckRoundAndGameStatusAfterTime();
			}
			
		}

		/// <summary>
		/// _ons the right paddle score changed signal.
		/// 
		///  NOTE: The CPU scored a point
		/// 
		/// </summary>
		/// <param name="aRightPaddleScore_int">A right paddle score_int.</param>
		private void _onRightPaddleScoreChangedSignal (int aRightPaddleScore_int)
		{
			if (aRightPaddleScore_int > 0) {
				iGameModel.currentRoundDataVO.cpuGoalsScoredThisRound++; //just add one
				_doCheckRoundAndGameStatusAfterTime();
			}
			
		}


		
	}
}
