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
using com.rmc.projects.paddle_soccer.mvcs.controller.signals;
using UnityEngine;
using com.rmc.projects.paddle_soccer.mvcs.model.vo;
using com.rmc.exceptions;
using com.rmc.projects.paddle_soccer.mvcs.model.data;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs.model
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum GameState
	{
		NULL,
		INIT,
		INTRO_START,
		GAME_START,
		ROUND_START,
		ROUND_DURING_CORE_GAMEPLAY,
		GAME_END

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
		/// When the state of the _game.
		/// 
		/// NOTE: Typically View/Controller will change the state here, 
		/// because timing of animations is required
		/// 
		/// NOTE: Sometimes the model CHANGES IMMEDIATELY FROM STATE-A TO STATE-B ECT... TOO
		/// 
		/// NOTE: THIS IS NOT A FINITE STATE MACHINE. ITS MORE ELEGANT (YET VULNERABLE)
		/// 
		/// 
		/// </summary>
		private GameState _gameState;
		public GameState gameState
		{ 
			get{
				return _gameState;
			}
			set
			{

				//**************************
				//
				// NOTE: new 'Value' must e UNIQUE
				//
				//**************************

				if (_gameState != value ) {
					_gameState = value;
					Debug.Log ("GM.GameState: " + _gameState);
					//
					switch (_gameState){
					case GameState.INIT:
						doResetModel();
						break;
					case GameState.INTRO_START:
						//MODEL DOES NOTHING
						break;
					case GameState.GAME_START:
						//MODEL DOES NOTHING
						break;
					case GameState.ROUND_START:
						doRoundStart();
						break;
					case GameState.ROUND_DURING_CORE_GAMEPLAY:
						//MODEL DOES NOTHING
						break;
					case GameState.GAME_END:
						//MODEL DOES NOTHING
						break;
					default:
						#pragma warning disable 0162
						throw new SwitchStatementException();
						break;
						#pragma warning restore 0162
					}
					gameStateChangedSignal.Dispatch (_gameState);
				}
			}
		}

		/// <summary>
		/// Gets or sets the game state changed signal.
		/// </summary>
		/// <value>The game state changed signal.</value>
		[Inject]
		public GameStateChangedSignal gameStateChangedSignal { get; set;}



		/// <summary>
		/// When the _turret health_int.
		/// </summary>
		private int _rightPaddleScore_int;
		public int rightPaddleScore
		{ 
			get{
				return _rightPaddleScore_int;
			}
			set
			{
				_rightPaddleScore_int = value;
				_rightPaddleScore_int = Mathf.Clamp (_rightPaddleScore_int, 0, 1000);
				turretHealthChangedSignal.Dispatch (_rightPaddleScore_int);

				if (_rightPaddleScore_int == 0) {
					rightPaddleScoreChangedSignal.Dispatch (_rightPaddleScore_int);
				}
				
			}
		}

		/// <summary>
		/// Gets or sets the turret health changed signal.
		/// </summary>
		/// <value>The turret health changed signal.</value>
		[Inject]
		public RightPaddleScoreChangedSignal turretHealthChangedSignal { get; set;}


		/// <summary>
		/// When the _score_float.
		/// </summary>
		private int _leftPaddleScore_int;
		public int leftPaddleScore
		{ 
			get{
				return _leftPaddleScore_int;
			}
			set
			{
				_leftPaddleScore_int = value;
				leftPaddleScoreChangedSignal.Dispatch (_leftPaddleScore_int);
				
			}
		}



		/// <summary>
		/// Gets or sets the score changed signal.
		/// </summary>
		/// <value>The score changed signal.</value>
		[Inject]
		public LeftPaddleScoreChangedSignal leftPaddleScoreChangedSignal { get; set;}



		/// <summary>
		/// When the _current round data V.
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
			}
		}

		/// <summary>
		/// Gets or sets the right paddle score changed signal.
		/// </summary>
		/// <value>The right paddle score changed signal.</value>
		[Inject]
		public RightPaddleScoreChangedSignal rightPaddleScoreChangedSignal {set; get;}



		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// When the _current round_uint.
		/// </summary>
		private uint _currentRound_uint;

		/// <summary>
		/// When the _total rounds per game_uint.
		/// </summary>
		private uint _totalRoundsPerGame_uint = 1;

		/// <summary>
		/// Has a next level?
		/// </summary>
		/// <returns><c>true</c>, if next level was hased, <c>false</c> otherwise.</returns>
		public bool hasNextRound(){
			return _currentRound_uint < _totalRoundsPerGame_uint;
		}

		
		// PRIVATE STATIC
		/// <summary>
		/// When the _ ENEMIE s_ PE r_ ROUN.
		/// </summary>
		private const int _GOALS_REQUIRED_PER_ROUND = 2;
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.paddle_soccer.mvcs.model.GameModel"/> class.
		/// </summary>
		public GameModel( )
		{
			//Debug.Log ("GameModel.constructor()");
			
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.paddle_soccer.mvcs.model.GameModel"/> is reclaimed by garbage collection.
		/// </summary>
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

			rightPaddleScore 		= 0;
			leftPaddleScore 		= 0;
			_currentRound_uint 		= 0;
			//Debug.Log ("MODEL RESET FINISHED");
		}


		/// <summary>
		/// Starts the next round.
		/// </summary>
		public void doRoundStart ()
		{
			//
			_currentRound_uint++;

			//
			uint goalsRequiredToWin_uint 			= _currentRound_uint*_GOALS_REQUIRED_PER_ROUND;
			Range enemiesSpawnedAtOnce_range	= new Range (1, _currentRound_uint);
			Range enemyHealth_range 			= new Range (11, 22);
			Range enemySpeed_range				= new Range (1f, 2f);
			//
			currentRoundDataVO = new RoundDataVO (
				_currentRound_uint,
				goalsRequiredToWin_uint,
				enemiesSpawnedAtOnce_range,
				enemyHealth_range,
				enemySpeed_range
				);


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

