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

//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.spider_strike.mvcs.controller.signals;
using UnityEngine;
using com.rmc.projects.spider_strike.mvcs.model.vo;


namespace com.rmc.projects.spider_strike.mvcs.model
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum GameState
	{
		GAME,
		GAME_OVER


	}
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class GameModel  : IGameModel
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER


		/// <summary>
		/// The _turret health_float.
		/// </summary>
		private float _turretHealth_float;
		public float turretHealth
		{ 
			get{
				return _turretHealth_float;
			}
			set
			{
				_turretHealth_float = value;
				turretHealthChangedSignal.Dispatch (_turretHealth_float);
				
			}
		}

		/// <summary>
		/// Gets or sets the turret health changed signal.
		/// </summary>
		/// <value>The turret health changed signal.</value>
		[Inject]
		public TurretHealthChangedSignal turretHealthChangedSignal { get; set;}


		/// <summary>
		/// The _score_float.
		/// </summary>
		private float _score_float;
		public float score
		{ 
			get{
				return _score_float;
			}
			set
			{
				_score_float = value;
				scoreChangedSignal.Dispatch (_score_float);
				
			}
		}

		/// <summary>
		/// The state of the _game.
		/// </summary>
		private GameState _gameState;
		public GameState gameState
		{ 
			get{
				return _gameState;
			}
			set
			{
				_gameState = value;
				
			}
		}



		/// <summary>
		/// Gets or sets the score changed signal.
		/// </summary>
		/// <value>The score changed signal.</value>
		[Inject]
		public ScoreChangedSignal scoreChangedSignal { get; set;}



		/// <summary>
		/// The _current round data V.
		/// </summary>
		private RoundDataVO _currentRoundDataVO;
		public RoundDataVO currentRoundDataVO
		{ 
			get{
				return _currentRoundDataVO;
			}
			set
			{
				_currentRoundDataVO = value;
				roundStartedSignal.Dispatch (_currentRoundDataVO);
			}
		}

		/// <summary>
		/// Gets or sets the round started signal.
		/// </summary>
		/// <value>The round started signal.</value>
		[Inject]
		public RoundStartedSignal roundStartedSignal { get; set;}


		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _current level_uint.
		/// </summary>
		private uint _currentLevel_uint;

		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///<summary>
		///	 Constructor
		/// 
		///  NOTE: **TIMING** THIS IS STEP 1 OF 3
		/// 
		///</summary>
		public GameModel( )
		{
			//Debug.Log ("GameModel.constructor()");
			
		}
		
		~GameModel()
		{
			
		}


		/// <summary>
		/// Posts the construct.
		/// 
		/// 
		///  NOTE: **TIMING** THIS IS STEP 2 OF 3
		/// 
		/// 
		/// </summary>
		[PostConstruct]
		public void postConstruct ()
		{
			//Debug.Log ("POST CONST");
		}

		/// <summary>
		/// Dos the reset model.
		/// 
		/// 
		/// 
		///  NOTE: **TIMING** THIS IS STEP 3 OF 3
		/// 
		/// 
		/// </summary>
		public void doResetModel ()
		{

			turretHealth 		= 100;
			score 				= 0;
			_currentLevel_uint 	= 0;
			//Debug.Log ("MODEL RESET FINISHED");
		}


		/// <summary>
		/// Starts the next round.
		/// </summary>
		public void startNextRound ()
		{
			_currentLevel_uint++;
			currentRoundDataVO = new RoundDataVO (_currentLevel_uint,_currentLevel_uint*3);


		}


		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

