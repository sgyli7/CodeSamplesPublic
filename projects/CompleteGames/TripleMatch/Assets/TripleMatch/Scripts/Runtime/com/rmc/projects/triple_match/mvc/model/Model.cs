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
using com.rmc.projects.triple_match.mvc.model.data.vo;
using System.Collections.Generic;
using System.Collections;
using com.rmc.core.support;
using com.rmc.core.grid_system;

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
		UNKNOWN,
		INITIALIZED,
		RESETTING,
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

		/// <summary>
		/// The _grid system.
		/// </summary>
		private GridSystem<GemVO> _gridSystem;


		// GETTER / SETTER
		/// <summary>
		/// Gets the gem V os.
		/// </summary>
		/// <value>The gem V os.</value>
		public GemVO[,] GemVOArray
		{
			get
			{
				return _gridSystem.GridSpotVOArray;
			}
		}

		/// <summary>
		/// Gems the VO count.
		/// </summary>
		/// <returns>The VO count.</returns>
		public List<GemVO> GemVOList ()
		{
			return _gridSystem.GridSpotVOList();
		}

		/// <summary>
		/// The state of the _game.
		/// </summary>
		private GameState _gameState = GameState.UNKNOWN;
		public GameState GameState 
		{
			get
			{
				return _gameState;
			}
			set
			{
				_gameState = value;

				//Debug.Log ("_gameState: " + _gameState);
				//Option: Dispatch delegate? Not needed for demo, but will help when scaling up the project
				
			}
		}



		public delegate void OnIsInputEnabledChangedDelegate (bool isInputEnabled);
		public OnIsInputEnabledChangedDelegate OnIsInputEnabledChanged;
		private bool _IsInputEnabled = false;
		public bool IsInputEnabled 
		{
			get
			{
				return _IsInputEnabled;
			}
			set
			{
				_IsInputEnabled = value;
				
				//Debug.Log ("_IsInputEnabled: " + IsInputEnabled);
				if (OnIsInputEnabledChanged != null)
				{
					OnIsInputEnabledChanged (IsInputEnabled);
				}
				
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
					//NOTE: We pass null and not-null values here. That is good. Just FYI
					OnSelectedGemVOChanged (_selectedGemVO);
				}
				
			}
		}
		
		//
		public delegate void OnGameResettedDelegate ();
		public OnGameResettedDelegate OnGameResetted;


		/// <summary>
		/// This is a list of lists so each inner list can be rewarded as a group (point multipliers, etc...)
		/// </summary>
		public delegate void OnGemVOsMarkedForRewardAndRemovalChangedDelegate (List<List<GemVO>> gemVOs);
		public OnGemVOsMarkedForRewardAndRemovalChangedDelegate OnGemVOsMarkedForRewardAndRemovalChanged;

		/// <summary>
		/// This is a list of gemVOs that are removed without points scored. Used during reset 
		/// </summary>
		public delegate void OnGemVOsMarkedForRemovalChangedDelegate (List<GemVO> gemVOs);
		public OnGemVOsMarkedForRemovalChangedDelegate OnGemVOsMarkedForRemovalChanged;

		public delegate void OnGemVOsMarkedForShiftingDownChangedDelegate (List<GemVO> gemVOs);
		public OnGemVOsMarkedForShiftingDownChangedDelegate OnGemVOsMarkedForShiftingDownChanged;

		public delegate void OnGemVOsAddedToFillGapsChangedDelegate (List<GemVO> gemVOs);
		public OnGemVOsAddedToFillGapsChangedDelegate OnGemVOsAddedToFillGapsChanged;
		



		
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

				_highestScoreEverThisSession = Mathf.Max (_score_int, _highestScoreEverThisSession);
				if (OnScoreChanged != null)
				{
					OnScoreChanged (_score_int);
				}
			}
		}


		/// <summary>
		/// Sets the score.
		/// </summary>
		public void SetScore (int score_int, float delayUntilSet_float = 0)
		{
			StartCoroutine (ScoreScore_Coroutine(score_int, delayUntilSet_float));
		}

		/// <summary>
		/// Scores the score WITH DELAY
		/// </summary>
		private IEnumerator ScoreScore_Coroutine (int score_int, float delayUntilSet_float)
		{
			yield return new WaitForSeconds (delayUntilSet_float);

			//
			Score = score_int;
		}


		/// <summary>
		/// Stored until game closes, and shown through UI to tease user to replay the game
		/// 
		/// Optional: In the future, we could store persistently between sessions too.
		/// 
		/// </summary>
		private int _highestScoreEverThisSession = 0;
		public int GetHighestScoreEverThisSession()
		{
			return _highestScoreEverThisSession;
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
		public delegate void OnTimeLeftInRoundChangedDelegate (int timeLeftInRound_int, int timeTotalInRound_int);
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
					OnTimeLeftInRoundChanged (_timeLeftInRound_int, TripleMatchConstants.DURATION_TIME_TOTAL_IN_ROUND);
				}
			}
		}

		public static bool AreGemVOsSwappable (GemVO gemVO1, GemVO gemVO2)
		{
			
			bool areGemVOsSwappable = false;
			
			//	Are Neighbors?
			//		off by exactly one in EITHER row OR column
			//
			//	Use if/else-if to ease debugging of each axis indivisually
			//
			if (gemVO1.RowIndex == gemVO2.RowIndex &&
			    Mathf.Abs (gemVO1.ColumnIndex - gemVO2.ColumnIndex) == 1)
			{
				areGemVOsSwappable = true;
			}
			else if (gemVO1.ColumnIndex == gemVO2.ColumnIndex &&
			         Mathf.Abs (gemVO1.RowIndex - gemVO2.RowIndex) == 1) 
			{
				areGemVOsSwappable = true;
			}
			
			return areGemVOsSwappable;
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
			_gridSystem = new GridSystem<GemVO>
				(
					TripleMatchConstants.MAX_ROWS, 
				    TripleMatchConstants.MAX_COLUMNS,
					TripleMatchConstants.MIN_GEMS_PER_HORIZONTAL_AXIS_MATCH_REWARD,
					TripleMatchConstants.MIN_GEMS_PER_VERTICAL_AXIS_MATCH_REWARD,
					TripleMatchConstants.MAX_GEM_TYPE_INDEX
				);

			GameState = GameState.INITIALIZED;

		}



		///<summary>
		///	Called once per frame
		///</summary>
		protected void Update () 
		{

			
		}
		
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		// 	PUBLIC
		
		
		/// <summary>
		/// Resets the game.
		/// </summary>
		public void GameReset ()
		{

			GameState = GameState.RESETTING;
			IsInputEnabled = false;
			//
			Score = 0;
			TimeLeftInRound = TripleMatchConstants.DURATION_TIME_TOTAL_IN_ROUND;
			StopCoroutine ("_TimeLeftInRoundDecrement_Coroutine");
			StartCoroutine ("_TimeLeftInRoundDecrement_Coroutine");
			SelectedGemVO = null;
			
			
			//	CLEAR EXISTING GEMS (IF ANY GEMS EXIST)
			if (_gridSystem.GridSpotVOArray != null && _gridSystem.GridSpotVOArray.GetLength (0) > 0 && _gridSystem.GridSpotVOArray.GetLength (1) > 0)
			{
				if (OnGemVOsMarkedForRemovalChanged != null)
				{
					OnGemVOsMarkedForRemovalChanged (_gridSystem.GridSpotVOList());
				}
			}


			//	CREATE NEW LIST
			//THIS IS THE DEFAULT, CHANGE THE VALUE IN TripleMatchConstants if needed
			//UnitTests may set this externally too
			_gridSystem.Reset(TripleMatchConstants.FREQUENCY_OF_INSTANT_MATCHES_UPON_RESET);

			
			Debug.Log (_gridSystem.ToString());
			
			if (OnGameResetted != null)
			{
				OnGameResetted ();
			}
			
			GameState = GameState.PLAYING;

		}

		

		
		
		public void DoInstantlySwapTwoGemVOs (GemVO gemVO1, GemVO gemVO2)
		{
			_gridSystem.DoInstantlySwapTwoGridSpotVOs (gemVO1, gemVO2);
		}
		
		public bool IsThereAMatchContainingEitherGemVO (GemVO gemVO1, GemVO gemVO2)
		{
			return _gridSystem.IsThereAMatchContainingEitherGridSpotVO (gemVO1, gemVO2);
		}

		
		/// <summary>
		/// _s the check for matches.
		/// </summary>
		public void CheckForMatches ()
		{
			//Debug.Log ("CheckForMatches()");

			//	1. BUILD LIST OF MATCHES
			List<List<GemVO>> gemVOsMatchingInAllChecksListOfLists = _gridSystem.GetMatches();
			_DoMarkGemVOsForDeletion (gemVOsMatchingInAllChecksListOfLists);


		}

		/// <summary>
		/// Adds the gems to fill gaps.
		/// </summary>
		public void DoFillGapsInGems ()
		{
			
			
			//todo: Remove this 
			//3. Count the gaps. This is for debugging only
			//
			int totalAmountRemoved = _gridSystem.DoFillGapsInGridSpots_Overall();
			
			//Debug.Log ("totalAmountRemoved: " + totalAmountRemoved);
			
			if (totalAmountRemoved > 0)
			{
				_DoFillGapsInGems__ShiftDown();
				_DoFillGapsInGems__DropNewFromAbove();

			}


		}


		
		//	PRIVATE


		/// <summary>
		/// _s the do mark gem V os for deletion.
		/// </summary>
		/// <param name="gemVOsMatchingInAllChecksListOfLists">Gem V os matching in all checks list of lists.</param>
		private void _DoMarkGemVOsForDeletion (List<List<GemVO>> gemVOsMatchingInAllChecksListOfLists)
		{
			
			_gridSystem.DoMarkGridSpotVOsForDeletion (gemVOsMatchingInAllChecksListOfLists);
			
			//	2. SEND SMALL COPIED LIST TO VIEW FOR DELETION
			if (OnGemVOsMarkedForRewardAndRemovalChanged != null)
			{
				OnGemVOsMarkedForRewardAndRemovalChanged (gemVOsMatchingInAllChecksListOfLists);
			}
		}
		



		/// <summary>
		/// _s the do shift gems down to fill gaps.
		/// </summary>
		private void _DoFillGapsInGems__ShiftDown ()
		{

			List<GemVO> gemVOsMarkedForShiftingDownChanged = _gridSystem.DoFillGapsInGridSpots__ShiftDown();

			//Debug.Log ("Marked for shift: " + gemVOsMarkedForShiftingDownChanged.Count);

			if (OnGemVOsMarkedForShiftingDownChanged != null)
			{
				OnGemVOsMarkedForShiftingDownChanged (gemVOsMarkedForShiftingDownChanged);
			}
		}
		
		/// <summary>
		/// _s the do add new gems to fill gaps.
		/// </summary>
		private void _DoFillGapsInGems__DropNewFromAbove ()
		{

			List<GemVO> gemVOsAddedToFillGapsChanged = _gridSystem.DoFillGapsInGridSpots__DropNewFromAbove();
			
			//Debug.Log ("Marked for add: " + gemVOsAddedToFillGapsChanged.Count);
			
			if (OnGemVOsAddedToFillGapsChanged != null)
			{
				OnGemVOsAddedToFillGapsChanged (gemVOsAddedToFillGapsChanged);
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
				_OnGameOver();
				if (OnTimeLeftInRoundExpired != null)
				{
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
		/// <summary>
		/// Handle GameOver
		/// </summary>
		public void _OnGameOver ()
		{
			GameState = GameState.GAME_OVER;
			IsInputEnabled = false;
			SelectedGemVO = null;
		}
	}
}

