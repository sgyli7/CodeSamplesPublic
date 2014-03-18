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


//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.exceptions;


namespace com.rmc.projects.coins_and_platforms.managers
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum GameOverReason
	{	
		WIN,
		LOSS
	}

	/// <summary>
	/// Game state.
	/// </summary>
	public enum GameState
	{
		NULL,
		MENU,
		GAME_BEGIN,
		GAME,
		GAME_END
	}
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class GameManager : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// The state of the _game.
		/// </summary>
		private GameState _gameState;
		public GameState gameState
		{
			get {
				return _gameState;
			}
			set {

				if (_gameState != value) {

					//SET
					_gameState = value;

					//KEEP TRACE
					Debug.Log ("_gameState: " + _gameState);

					//SWITCH
					switch (_gameState)
					{
					case GameState.MENU:
						//TODO
						//MENU WILL DO THIS PART
						gameState = GameState.GAME_BEGIN;
						break;
					case GameState.GAME_BEGIN:
						_doResetGUI();
						_doResetPlayer();
						//KEEP THIS
						gameState = GameState.GAME;
						break;
					case GameState.GAME:
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
			}

		}

		/// <summary>
		/// The _score_float.
		/// </summary>
		private float _score_float;
		public float score
		{
			get {
				return _score_float;
			}
			set {
				_score_float = value;
				_doRefreshGUI();
			}
			
		}


		/// <summary>
		/// The _lives_float.
		/// </summary>
		private float _lives_float;
		public float lives
		{
			get {
				return _lives_float;
			}
			set {
				_lives_float = value;
				_doRefreshGUI();
			}
			
		}

		
		// PUBLIC
		
		// PUBLIC STATIC

		// PRIVATE
		/// <summary>
		/// The _last game over reason.
		/// </summary>
		private GameOverReason _lastGameOverReason;

		/// <summary>
		/// The _score GUI text.
		/// </summary>
		private GUIText _scoreGUIText;


		/// <summary>
		/// The _lives GUI text.
		/// </summary>
		private GUIText _livesGUIText;


		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public GameManager ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~GameManager ( )
		{
			
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			//
			_doSetBrittleReferences();

			//
			gameState = GameState.MENU;
		}


		/// <summary>
		/// _dos the set brittle references.
		/// 
		/// NOTE: For simplicity, this brittle approach is used instead of alternatives;
		/// 		* public transform references, set via dragging from hierarchy items
		/// 		* Inversion Of Control (StrangeIoC) where less GameObject-to-GameObject references are needed.
		/// 		* Manager dynamically spawning via Instantiate()
		/// 		* Etc...
		/// 
		/// 
		/// </summary>
		private void _doSetBrittleReferences()
		{

			_scoreGUIText = GameObject.Find ("ScoreGUIText").GetComponent<GUIText>();
			_livesGUIText = GameObject.Find ("LivesGUIText").GetComponent<GUIText>();

		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
		}
		
		// PUBLIC

		/// <summary>
		/// Dos the restart game.
		/// </summary>
		public void doRestartGame () 
		{
			Application.LoadLevel (Application.loadedLevel);
			
		}


		public void doGameOver (GameOverReason aGameOverReason) 
		{
			_lastGameOverReason = aGameOverReason;
			_doGameOverImmediate();

		}



		/// <summary>
		/// _dos the game over immediate.
		/// </summary>
		private void _doGameOverImmediate()
		{
			//Time.timeScale = .1f;

			switch (_lastGameOverReason) {
			case GameOverReason.WIN:
				//_doSetScore ("You Win!");
				break;
			case GameOverReason.LOSS:
				//_doSetScore("You Lose!");
				break;
			}


			Invoke ("_doGameOverAfterPause", 0.25f);
		}


		/// <summary>
		/// _dos the game over after pause.
		/// </summary>
		private void _doGameOverAfterPause()
		{

			//Time.timeScale = 1;

			//clean up
			SimpleGameManager.Instance.enemyManager.doDespawnAllEnemies();
			SimpleGameManager.Instance.enemyManager.doDeListAllBosses();
			SimpleGameManager.Instance.platformManager.doDeListAllPlatforms();


			switch (_lastGameOverReason) {
				case GameOverReason.WIN:
					//SimpleGameManager.Instance.loadCurrentLevelAgain();
					Application.LoadLevel (Application.loadedLevel);
					break;
				case GameOverReason.LOSS:
					//SimpleGameManager.Instance.loadCurrentLevelAgain();
					Application.LoadLevel (Application.loadedLevel);
					break;
			}


		}

		/// <summary>
		/// _dos the reset GU.
		/// </summary>
		private void _doResetGUI() 
		{
			score = 0;
			lives = 1;

		}

		/// <summary>
		/// _dos the reset player.
		/// </summary>
		private void _doResetPlayer() 
		{

			
		}




		/// <summary>
		/// _dos the refresh GUI
		/// </summary>
		private void _doRefreshGUI () 
		{
			if (_scoreGUIText) {
				_scoreGUIText.text = "Score: " + score.ToString();
			}

			if (_livesGUIText) {
				_livesGUIText.text = "Lives: " + lives.ToString();
			}

		}

		//PRIVATE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
