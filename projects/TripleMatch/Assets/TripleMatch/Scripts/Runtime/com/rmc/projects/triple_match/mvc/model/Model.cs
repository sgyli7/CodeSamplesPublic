/**
 * Copyright (C) 2005-2015 by Rivello Multimedia Consulting (RMC).                    
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
using com.rmc.projects.triple_match.mvc.model.data;
using System.Collections.Generic;
using System.Collections;
using com.rmc.core.support;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.triple_match.mvc.model
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum GameState
	{
		UNKOWN,
		INITIALIZED,
		PLAYING,
		GAME_OVER

	}
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class Model: SingletonMonobehavior<Model>
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// The _gem V os.
		/// </summary>
		private GemVO[,] _gemVOs;
		public GemVO[,] GemVOs
		{
			get
			{
				return _gemVOs;
			}
			
		}

		private GameState _gameState = GameState.UNKOWN;
		public GameState GameState 
		{
			get
			{
				return _gameState;
			}
			set
			{
				_gameState = value;

				//Option: Dispatch game state? Not needed for demo, but will help when scaling up the project
				
			}
		}


		/// <summary>
		/// 
		/// SelectedGemVO
		/// 
		/// 	Model - stores it
		/// 	View - displays it (via delegate listening)
		/// 	Controller - updates it
		/// 
		/// </summary>
		public delegate void OnSelectedGemVOChangedDelegate (GemVO gemVO);
		public OnSelectedGemVOChangedDelegate OnSelectedGemVOChanged;
		private GemVO _selectedGemVO;
		public GemVO SelectedGemVO 
			{
			get
			{
				return _selectedGemVO;
			}
			set
			{
				_selectedGemVO = value;
				
				if (OnSelectedGemVOChanged != null)
				{
					OnSelectedGemVOChanged (_selectedGemVO);
				}
				
			}
		}
		
		//
		public delegate void OnGameResettedDelegate ();
		public OnGameResettedDelegate OnGameResetted;

		public delegate void OnGemVOsMarkedForDeletionChangedDelegate (List<GemVO> gemVOs);
		public OnGemVOsMarkedForDeletionChangedDelegate OnGemVOsMarkedForDeletionChanged;

		
		/// <summary>
		/// 
		/// Score
		/// 
		/// 	Model - stores it
		/// 	View - displays it (via delegate listening)
		/// 	Controller - updates it
		/// 
		/// </summary>
		public delegate void OnScoreChangedDelegate (int score_int);
		public OnScoreChangedDelegate OnScoreChanged;
		private int _score_int;
		public int Score 
		{
			get
			{
				return _score_int;
			}
			private set
			{
				_score_int = value;
				if (OnScoreChanged != null)
				{
					OnScoreChanged (_score_int);
				}
			}
		}
		public void SetScore (int score_int, float delayUntilSet_float = 0)
		{
			StartCoroutine (ScoreScore_Coroutine(score_int, delayUntilSet_float));
		}
		private IEnumerator ScoreScore_Coroutine (int score_int, float delayUntilSet_float)
		{
			yield return new WaitForSeconds (delayUntilSet_float);

			//
			Score = score_int;

		}


		/// <summary>
		/// 
		/// TimeLeftInRound -- The game has 1 minute long rounds. At the end the game is over, regardless of performance
		/// 
		/// 	Model - stores it, updates it
		/// 	View - displays it (via delegate listening)
		/// 	Controller - Nothing. (It could listen for OnTimeLeftInRoundExpired and coordinate more complex reactions if needed)
		/// 
		/// </summary>
		public delegate void OnTimeLeftInRoundExpiredDelegate ();
		public OnTimeLeftInRoundExpiredDelegate OnTimeLeftInRoundExpired;
		public delegate void OnTimeLeftInRoundChangedDelegate (int timeLeftInRound_int);
		public OnTimeLeftInRoundChangedDelegate OnTimeLeftInRoundChanged;
		private int _timeLeftInRound_int;
		public int TimeLeftInRound
		{
			get
			{
				return _timeLeftInRound_int;
			}
			private set
			{
				_timeLeftInRound_int = value;
				if (OnTimeLeftInRoundChanged != null)
				{
					OnTimeLeftInRoundChanged (_timeLeftInRound_int);
				}
			}
		}


		// 	PUBLIC



		
		// 	PRIVATE
		
		
		//--------------------------------------
		// 	Unity Methods
		//--------------------------------------
		
		
		/// <summary>
		/// Start this instance.
		/// </summary>
		protected void Start () 
		{
			_gemVOs = new GemVO[TripleMatchConstants.MAX_ROWS, TripleMatchConstants.MAX_COLUMNS];
			GameState = GameState.INITIALIZED;
		}



		/// <summary>
		/// Debug only
		/// </summary>
		private bool _debugging_HasCheckedForMatches = false;


		///<summary>
		///	Called once per frame
		///</summary>
		protected void Update () 
		{


			if (GameState == GameState.PLAYING)
			{
				if (Input.GetKeyDown (KeyCode.Space))
				{
					if (!_debugging_HasCheckedForMatches)
					{
						_CheckForMatches();
					}
					else
					{
						//CLEAR THOSE MARKED
						List<GemVO> gemVOsMarkedForDeletion = new List<GemVO>();
						if (OnGemVOsMarkedForDeletionChanged != null)
						{
							OnGemVOsMarkedForDeletionChanged (gemVOsMarkedForDeletion);
						}
					}
					_debugging_HasCheckedForMatches = ! _debugging_HasCheckedForMatches;
					
				}
			}

			
		}
		
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		// PUBLIC
		
		
		/// <summary>
		/// Resets the game.
		/// </summary>
		public void GameReset ()
		{

			GameState = GameState.PLAYING;
			Score = 0;
			TimeLeftInRound = TripleMatchConstants.DURATION_TIME_LEFT_IN_ROUND_MAX;
			StopCoroutine ("_TimeLeftInRoundDecrement_Coroutine");
			StartCoroutine ("_TimeLeftInRoundDecrement_Coroutine");
			SelectedGemVO = null;
			
			
			//	CLEAR EXISTING GEMS
			foreach (GemVO gemVO in _gemVOs)
			{
				//	TODO: CLEAR EACH
			}
			_gemVOs = new GemVO[TripleMatchConstants.MAX_ROWS, TripleMatchConstants.MAX_COLUMNS];
			
			
			//	CREATE ALL NEW GEMS
			GemVO nextGemVO;
			int nextGemTypeIndex;
			//
			for (int rowIndex_int = 0; rowIndex_int < TripleMatchConstants.MAX_ROWS; rowIndex_int++)
			{
				for (int columnIndex_int = 0; columnIndex_int < TripleMatchConstants.MAX_COLUMNS; columnIndex_int++)
				{
					//	SET INDEX (THIS MEANS THE COLOR)
					nextGemTypeIndex = Random.Range (0, TripleMatchConstants.MAX_GEM_TYPE_INDEX);
					
					//	CREATE 1 NEW GEM
					nextGemVO = new GemVO (rowIndex_int, columnIndex_int, nextGemTypeIndex);
					_gemVOs[rowIndex_int, columnIndex_int] = nextGemVO;
				}
			}
			
			
			Debug.Log (this);
			
			if (OnGameResetted != null)
			{
				OnGameResetted ();
			}
		}
		
		
		
		
		/// <summary>
		/// Show nice debuggable output
		/// </summary>
		override public string ToString ()
		{
			string s = "";
			s+= "[Model] (Single Click Here For *Gem* Grid Output)";
			s+= "\n";
			for (int rowIndex_int = 0; rowIndex_int < _gemVOs.GetLength(0); rowIndex_int += 1) 
			{
				for (int columnIndex_int = 0; columnIndex_int < _gemVOs.GetLength(1); columnIndex_int += 1) 
				{
					s += _gemVOs[rowIndex_int,columnIndex_int].GemTypeIndex;
				}
				s += "\n";
			}
			return s;
			
		}

	
		
		//	PRIVATE
		private void _CheckForMatches ()
		{
			Debug.Log ("_CheckForMatches()");

			List<GemVO> gemVOsMarkedForDeletion = new List<GemVO>();
			GemVO prevGemVO;
			GemVO nextGemVO;
			//HORIZONTAL
			for (int rowIndex_int = 0; rowIndex_int < _gemVOs.GetLength(0); rowIndex_int += 1) 
			{
				//VERTICAL (Start at index 1)
				for (int columnIndex_int = 1; columnIndex_int < _gemVOs.GetLength(1); columnIndex_int += 1) 
				{
					nextGemVO = _gemVOs[rowIndex_int,columnIndex_int];
					prevGemVO = _gemVOs[rowIndex_int,columnIndex_int-1];

					//TODO: CHECK FOR MORE THAN 2
					if (nextGemVO.GemTypeIndex == prevGemVO.GemTypeIndex)
					{

						if (!gemVOsMarkedForDeletion.Contains (prevGemVO))
						{
							gemVOsMarkedForDeletion.Add (prevGemVO);
						}
						if (!gemVOsMarkedForDeletion.Contains (nextGemVO))
						{
							gemVOsMarkedForDeletion.Add (nextGemVO);
						}

					}
				}
			}

			if (OnGemVOsMarkedForDeletionChanged != null)
			{
				OnGemVOsMarkedForDeletionChanged (gemVOsMarkedForDeletion);
			}

		}	

		//--------------------------------------
		// 	Coroutines
		//--------------------------------------

		/// <summary>
		/// Times the left in round decrement_ coroutine.
		/// </summary>
		/// <returns>The left in round decrement_ coroutine.</returns>
		private IEnumerator _TimeLeftInRoundDecrement_Coroutine ()
		{

			//	TIMING ON 'SECONDS' IS LESS ACCURATE THAN FIXED UPDATE, BUT THIS IS ACCEPTABLE FOR DEMO USE
			yield return new WaitForSeconds (TripleMatchConstants.DURATION_TIME_LEFT_IN_ROUND_TICK);
			int nextTimeLeftInRound_int = Mathf.CeilToInt(TimeLeftInRound - TripleMatchConstants.TIME_LEFT_IN_ROUND_DECREMENT_PER_TICK);

			//	CORRECT NEGATIVE TIME WITHOUT DISPATCHING DELEGATE
			if (nextTimeLeftInRound_int <= 0) 
			{
				nextTimeLeftInRound_int = 0;
			}

			TimeLeftInRound = nextTimeLeftInRound_int;

			if (TimeLeftInRound == 0)
			{
				if (OnTimeLeftInRoundExpired != null)
				{

					GameState = GameState.GAME_OVER;
					OnTimeLeftInRoundExpired();
				}

			}
			else
			{
				StopCoroutine ("_TimeLeftInRoundDecrement_Coroutine");
				StartCoroutine ("_TimeLeftInRoundDecrement_Coroutine");
			}



		}


		//--------------------------------------
		// 	Event Handlers
		//--------------------------------------
	}
}

