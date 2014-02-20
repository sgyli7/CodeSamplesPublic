/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
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


//--------------------------------------
//  Namespace
//--------------------------------------
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
		/// Gets or sets the round start signal.
		/// </summary>
		/// <value>The round start signal.</value>
		[Inject]
		public RoundStartedSignal roundStartedSignal {set; get;}


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
			roundStartedSignal.AddListener (_onRoundStartedSignal);
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
			roundStartedSignal.RemoveListener (_onRoundStartedSignal);
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
			//
			iGameModel.currentRoundDataVO.clearEnemies();

			promptStartSignal.Dispatch ("Round " + aRoundDataVO.currentRound_uint + " -- Kill " + aRoundDataVO.enemiesTotalToCreate, true);


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
			Debug.Log ("changed: " + aGameState);
			if (aGameState == GameState.ROUND_DURING_CORE_GAMEPLAY) {
				Debug.Log ("about to created spider");
				iGameModel.currentRoundDataVO.addEnemy ( view.doCreateSpider() );
			}

		}


		/// <summary>
		/// _ons the enemy died signal.
		/// </summary>
		/// <param name="aEnemyThatDied_gameobject">A enemy that died_gameobject.</param>
		private void _onEnemyDiedSignal (GameObject aEnemyThatDied_gameobject)
		{

			iGameModel.currentRoundDataVO.removeEnemy (aEnemyThatDied_gameobject);
			Destroy (aEnemyThatDied_gameobject);


			//
			//Debug.Log (iGameModel.currentRoundDataVO.enemiesCreated + " and " +  iGameModel.currentRoundDataVO.enemiesTotalToCreate);
			if (iGameModel.currentRoundDataVO.enemiesCreated < iGameModel.currentRoundDataVO.enemiesTotalToCreate) {
				iGameModel.currentRoundDataVO.addEnemy (	view.doCreateSpider() 	);
			} else {

				//DONE
				gameStateChangeSignal.Dispatch ( GameState.GAME_END);

				promptStartSignal.Dispatch ("You Won The Game!", false);
				soundPlaySignal.Dispatch ( new SoundPlayVO (SoundType.GAME_OVER_WIN));

			}
		}

		/// <summary>
		/// _ons the turret died signal.
		/// </summary>
		private void _onTurretDiedSignal ()
		{
			
			//DONE
			gameStateChangeSignal.Dispatch (GameState.GAME_END);
			//
			promptStartSignal.Dispatch ("You Lost The Game!", false);
			soundPlaySignal.Dispatch ( new SoundPlayVO (SoundType.GAME_OVER_LOSS));
				
		}



	}
}
