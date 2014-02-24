/**
 * Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
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
using com.rmc.projects.spider_strike.mvcs.view.ui;
using com.rmc.projects.spider_strike.mvcs.controller.signals;
using UnityEngine;
using com.rmc.projects.spider_strike.mvcs.model.vo;
using com.rmc.projects.spider_strike.mvcs.model;
using System;


//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.exceptions;
using System.Collections;


namespace com.rmc.projects.spider_strike.mvcs.view
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
		/// The enemy died signal.
		/// </summary>
		[Inject]
		public EnemyDiedSignal enemyDiedSignal {set; get;}
		
		/// <summary>
		/// Gets or sets the player died signal.
		/// </summary>
		/// <value>The player died signal.</value>
		[Inject]
		public TurretDiedSignal turretDiedSignal {set; get;}
		
		
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
		/// Gets or sets the game state changed signal.
		/// </summary>
		/// <value>The game state changed signal.</value>
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
			enemyDiedSignal.AddListener (_onEnemyDiedSignal);
			turretDiedSignal.AddListener (_onTurretDiedSignal);
			gameStateChangedSignal.AddListener (_onGameStateChangedSignal);
			promptEndedSignal.AddListener (_onPromptEndedSignal);
			
		}
		
		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			enemyDiedSignal.RemoveListener (_onEnemyDiedSignal);
			turretDiedSignal.RemoveListener (_onTurretDiedSignal);
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
		
		//	PUBLIC
		
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// _ons the round start signal.
		/// </summary>
		/// <param name="aRoundDataVO">A round data V.</param>
		//TODO: IS THIS SIGNAL NEEDED, WHY NOT JUST CHECK ONGAMESTATE?
		private void _onRoundStartedSignal (RoundDataVO aRoundDataVO)
		{
			
			
		}
		
		/// <summary>
		/// _ons the prompt ended signal.
		/// </summary>
		private void _onPromptEndedSignal ()
		{
			
			//
			if (iGameModel.gameState == GameState.ROUND_START) {
				gameStateChangeSignal.Dispatch (GameState.ROUND_DURING_CORE_GAMEPLAY);
			}
			
		}
		
		
		/// <summary>
		/// _ons the game state changed signal.
		/// </summary>
		/// <param name="aGameState">A game state.</param>
		private void _onGameStateChangedSignal (GameState aGameState)
		{
			
			//
			switch (aGameState){
			case GameState.INIT:
				gameStateChangeSignal.Dispatch (GameState.INTRO_START); //todo: uncomment, this line is required
				break;
			case GameState.INTRO_START:
				//WAITING FOR: INTRO ANIM TO FINISH
				break;
			case GameState.GAME_START:
				gameStateChangeSignal.Dispatch (GameState.ROUND_START);
				//WAITING FOR: USER TO CLICK ANYWHERE
				break;
			case GameState.ROUND_START:
				iGameModel.currentRoundDataVO.clearEnemies();
				promptStartSignal.Dispatch (String.Format
				                            (
					"Round {0} -- Kill {1}", 
					iGameModel.currentRoundDataVO.currentRound_uint, 
					iGameModel.currentRoundDataVO.enemiesTotalToCreate), 
				                            true
				                            );
				//WAITING FOR: PROMPT ANIM TO FINISH
				break;
			case GameState.ROUND_DURING_CORE_GAMEPLAY:
				_doCreateNextSpiderBatch (iGameModel.currentRoundDataVO);
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
		/// _dos the remove enemy after time.
		/// </summary>
		/// <param name="aEnemyThatDied_gameobject">A enemy that died_gameobject.</param>
		/// <param name="aDelay_float">A delay_float.</param>
		private void _doRemoveEnemyAfterTime (EnemyUI aEnemyThatDied_enemyUI, float aTotalTimeUntilDestory_float ) 
		{
			
			//
			iGameModel.currentRoundDataVO.removeEnemy (aEnemyThatDied_enemyUI.gameObject);

			aEnemyThatDied_enemyUI.doTweenToSinkIntoGround();
			
			//
			Destroy (aEnemyThatDied_enemyUI.gameObject, aTotalTimeUntilDestory_float);
			
		}
		
		/// <summary>
		/// _dos the check round and game status after time.
		/// 
		/// NOTE: Must be public
		/// 
		/// </summary>
		public void _doCheckRoundAndGameStatusAfterTime () 
		{
			//
			//Debug.Log (iGameModel.currentRoundDataVO.enemiesCreated + " and " +  iGameModel.currentRoundDataVO.enemiesTotalToCreate);


			//
			//1. CONTINUE THIS ROUND
			//
			if (iGameModel.currentRoundDataVO.enemiesCreated < iGameModel.currentRoundDataVO.enemiesTotalToCreate) {
				_doCreateNextSpiderBatch(iGameModel.currentRoundDataVO);

			//
			//2. GO TO NEXT ROUND
			//
			} else if (iGameModel.hasNextRound()) {

				gameStateChangeSignal.Dispatch ( GameState.ROUND_START);

			//
			//3. END THE GAME
			//
			} else {


				//DONE
				gameStateChangeSignal.Dispatch ( GameState.GAME_END);
				promptStartSignal.Dispatch (Constants.PROMPT_GAME_END_WIN, false);
				soundPlaySignal.Dispatch ( new SoundPlayVO (SoundType.GAME_OVER_WIN));
				
			}
			
		}
		
		
		
		
		/// <summary>
		/// _dos the create next spider batch.
		/// </summary>
		/// <param name="aRoundDataVO">A round data V.</param>
		private void _doCreateNextSpiderBatch(RoundDataVO aRoundDataVO)
		{
			
			//how many to create?
			//1. get a number within range
			//2. be sure not to exceed the remaining allowed
			int enemiesToSpawnAtOnce_int 	= aRoundDataVO.enemiesSpawnedAtOnceRange.getRandomIntValueWithinRange();
			enemiesToSpawnAtOnce_int 		= (int)Mathf.Clamp ((float)enemiesToSpawnAtOnce_int, 0, iGameModel.currentRoundDataVO.enemiesTotalToCreate - iGameModel.currentRoundDataVO.enemiesCreated);
			
			//
			for (var enemyToSpawnIndex_int = 0; enemyToSpawnIndex_int < enemiesToSpawnAtOnce_int; enemyToSpawnIndex_int++) {
				iGameModel.currentRoundDataVO.addEnemy ( view.doCreateSpider(iGameModel.currentRoundDataVO) );
			}
		}
		
		/// <summary>
		/// _ons the enemy died signal.
		/// </summary>
		/// <param name="aEnemyThatDied_gameobject">A enemy that died_gameobject.</param>
		private void _onEnemyDiedSignal (EnemyUI aEnemyThatDied_enemyui)
		{
			
			//
			_doRemoveEnemyAfterTime (aEnemyThatDied_enemyui, 2f);


			//
			CancelInvoke ("_doCheckRoundAndGameStatusAfterTime");
			Invoke ("_doCheckRoundAndGameStatusAfterTime", 2.5f);
			
			
		}
		
		/// <summary>
		/// _ons the turret died signal.
		/// </summary>
		private void _onTurretDiedSignal ()
		{
			
			//DONE
			gameStateChangeSignal.Dispatch (GameState.GAME_END);
			//
			promptStartSignal.Dispatch (Constants.PROMPT_GAME_END_LOSS, false);
			soundPlaySignal.Dispatch ( new SoundPlayVO (SoundType.GAME_OVER_LOSS));
			
		}
		
		
		
	}
}
