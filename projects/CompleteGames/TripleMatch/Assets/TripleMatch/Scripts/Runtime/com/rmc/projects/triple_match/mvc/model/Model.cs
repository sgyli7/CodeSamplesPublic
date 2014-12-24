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
		/// 
		/// NOTE: We keep them as 2-dimensional array for 'check my neighbor' type grid-checking
		/// 
		/// </summary>
		private GemVO[,] _gemVOs;
		public GemVO[,] GemVOs
		{
			get
			{
				return _gemVOs;
			}
			
		}

		/// <summary>
		/// _s the get gem V os list from gem VO array.
		/// 
		/// NOTE: Generating a list is more useful than a 2-dimensional array for some operations.
		/// 
		/// </summary>
		/// <param name="_gemVOs">_gem V os.</param>
		private List<GemVO> _GetGemVOsListFromGemVOArray (GemVO[,] _gemVOsArray)
		{
			List<GemVO> gemVOsList = new List<GemVO>();
			//
			for (int rowIndex_int = 0; rowIndex_int < _gemVOsArray.GetLength(0); rowIndex_int += 1) 
			{
				for (int columnIndex_int = 0; columnIndex_int < _gemVOsArray.GetLength(1); columnIndex_int += 1) 
				{
					gemVOsList.Add ( _gemVOsArray[rowIndex_int,columnIndex_int]);
				}
			}

			return gemVOsList;
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
					//NOTE: We pass null and not-null values here. That is good. Just FYI
					Debug.Log ("passing... " + _selectedGemVO);
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
			_gemVOs = new GemVO[TripleMatchConstants.MAX_ROWS, TripleMatchConstants.MAX_COLUMNS];
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

			GameState = GameState.PLAYING;
			Score = 0;
			TimeLeftInRound = TripleMatchConstants.DURATION_TIME_LEFT_IN_ROUND_MAX;
			StopCoroutine ("_TimeLeftInRoundDecrement_Coroutine");
			StartCoroutine ("_TimeLeftInRoundDecrement_Coroutine");
			SelectedGemVO = null;
			
			
			//	CLEAR EXISTING GEMS (IF ANY GEMS EXIST)
			if (_gemVOs != null && _gemVOs.GetLength (0) > 0 && _gemVOs.GetLength (1) > 0)
			{
				if (OnGemVOsMarkedForRemovalChanged != null)
				{
					OnGemVOsMarkedForRemovalChanged (_GetGemVOsListFromGemVOArray(_gemVOs));
				}
			}


			//	CREATE NEW LIST
			_gemVOs = new GemVO[TripleMatchConstants.MAX_ROWS, TripleMatchConstants.MAX_COLUMNS];
			
			
			//	CREATE ALL NEW GEMS
			GemVO nextGemVO;
			int nextGemTypeIndex_int;


			//
			//
			//	TOP TO BOTTOM
			for (int rowIndex_int = 0; rowIndex_int < TripleMatchConstants.MAX_ROWS; rowIndex_int++)
			{
				//	LEFT TO RIGHT
				for (int columnIndex_int = 0; columnIndex_int < TripleMatchConstants.MAX_COLUMNS; columnIndex_int++)
				{

					//
					//	OPTION 1: ALLOW POSSIBLE MATCHES
					//
					if (TripleMatchConstants.SETTING_GAMEPLAY_WILL_ALLOW_INSTANT_MATCHES_ON_GAME_RESET)
					{
						//	choose 'any' gem type and don't worry if it matches a neighbor
						nextGemTypeIndex_int = Random.Range (0, TripleMatchConstants.MAX_GEM_TYPE_INDEX);
						nextGemVO = new GemVO (rowIndex_int, columnIndex_int, nextGemTypeIndex_int);
						_gemVOs[rowIndex_int, columnIndex_int] = nextGemVO;
					}

					//
					//	OPTION 2: DO NOT ALLOW POSSIBLE MATCHES
					//
					else
					{
						//BUILD A LIST OF POSSIBLE GEMTYPES
						List<int> nextGemTypeIndexList = new List<int> ();
						for (var i = 0; i < TripleMatchConstants.MAX_GEM_TYPE_INDEX; i++)
						{
							nextGemTypeIndexList.Add (i);
						}

						//RANDOMLY PICK FROM THE LIST OF POSSIBLE GEMTYPES
						//	1. this should prevent 100% of matches (immediately following this algorythm)
						//	2. but the while() has a failsafe to prevent lock-up
						do
						{
							//	if the next gem type results in 1 or more matches, then pick again. 
							//	we want no matches
							nextGemTypeIndex_int = nextGemTypeIndexList[Random.Range (0, nextGemTypeIndexList.Count)];
							nextGemTypeIndexList.Remove (nextGemTypeIndex_int);
							nextGemVO = new GemVO (rowIndex_int, columnIndex_int, nextGemTypeIndex_int);
							_gemVOs[rowIndex_int, columnIndex_int] = nextGemVO;

						} while (HasMatches() && nextGemTypeIndexList.Count > 0);
					}


					
				
				}
			}
			
			
			Debug.Log (this);
			
			if (OnGameResetted != null)
			{
				OnGameResetted ();
			}

		}
		
		/// <summary>
		/// Determines if is there A match containing either gem V the specified gemVO1 gemVO2.
		/// 
		/// </summary>
		/// <returns><c>true</c> if is there A match containing either gem V the specified gemVO1 gemVO2; otherwise, <c>false</c>.</returns>
		/// <param name="gemVO1">Gem V o1.</param>
		/// <param name="gemVO2">Gem V o2.</param>
		public bool IsThereAMatchContainingEitherGemVO (GemVO gemVO1, GemVO gemVO2)
		{

			bool isThereAMatchContainingEitherGemVO = false;
			
			//	1. BUILD LIST OF MATCHES
			List<List<GemVO>> gemVOsMatchingInAllChecksListOfLists = new List<List<GemVO>>();
			gemVOsMatchingInAllChecksListOfLists.AddRange (_CheckForMatchesHorizontal());
			gemVOsMatchingInAllChecksListOfLists.AddRange (_CheckForMatchesVertical());

			foreach (List<GemVO> gemVOList in gemVOsMatchingInAllChecksListOfLists)
			{
				if (gemVOList.Contains (gemVO1) || gemVOList.Contains (gemVO2))
				{

					isThereAMatchContainingEitherGemVO = true;
					break;
				}

			}

			return isThereAMatchContainingEitherGemVO;
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

		/// <summary>
		/// Dos the instantly swap two gem V os.
		/// </summary>
		/// <param name="gemVO1">Gem V o1.</param>
		/// <param name="gemV02">Gem v02.</param>
		public void DoInstantlySwapTwoGemVOs (GemVO gemVO1, GemVO gemVO2)
		{

			//	1. SWAP INTERNAL DATA
			int rowIndex = gemVO1.RowIndex;
			int columnIndex = gemVO1.ColumnIndex;
			//
			gemVO1.RowIndex = gemVO2.RowIndex;
			gemVO1.ColumnIndex = gemVO2.ColumnIndex;
			gemVO2.RowIndex = rowIndex;
			gemVO2.ColumnIndex = columnIndex;

			//	2. SWAP ITS 'ADDRESS' IN THE GRID
			_gemVOs[gemVO1.RowIndex, gemVO1.ColumnIndex] = gemVO1;
			_gemVOs[gemVO2.RowIndex, gemVO2.ColumnIndex] = gemVO2;

		}


		
		
		/// <summary>
		/// _s the check for matches.
		/// </summary>
		public bool HasMatches ()
		{
			//Debug.Log ("HasMatches()");
			
			//	1. BUILD LIST OF MATCHES
			List<List<GemVO>> gemVOsMatchingInAllChecksListOfLists = new List<List<GemVO>>();
			gemVOsMatchingInAllChecksListOfLists.AddRange (_CheckForMatchesHorizontal());
			gemVOsMatchingInAllChecksListOfLists.AddRange (_CheckForMatchesVertical());
			return gemVOsMatchingInAllChecksListOfLists.Count > 0;
			
		}

		
		/// <summary>
		/// _s the check for matches.
		/// </summary>
		public void CheckForMatches ()
		{
			//Debug.Log ("CheckForMatches()");

			//	1. BUILD LIST OF MATCHES
			List<List<GemVO>> gemVOsMatchingInAllChecksListOfLists = new List<List<GemVO>>();
			gemVOsMatchingInAllChecksListOfLists.AddRange (_CheckForMatchesHorizontal());
			gemVOsMatchingInAllChecksListOfLists.AddRange (_CheckForMatchesVertical());
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
			int totalAmountRemoved = 0;
			for (int rowIndex_int = 0; rowIndex_int < TripleMatchConstants.MAX_ROWS; rowIndex_int++)
			{
				for (int columnIndex_int = 0; columnIndex_int < TripleMatchConstants.MAX_COLUMNS; columnIndex_int++)
				{
					
					if (_gemVOs[rowIndex_int, columnIndex_int] == null)
					{
						totalAmountRemoved++;
					};
					
				}
			}
			
			Debug.Log ("totalAmountRemoved: " + totalAmountRemoved);
			
			if (totalAmountRemoved > 0)
			{
				_DoShiftGemsDownToFillGaps();
				_DoAddNewGemsToFillGaps();
			}



		}
		
		
		//	PRIVATE

		
		/// <summary>
		/// _s the check for matches horizontal.
		/// </summary>
		private List<List<GemVO>> _CheckForMatchesHorizontal ()
		{
			
			
			List<List<GemVO>> gemVOsMatchingInAllChecksListOfLists = new List<List<GemVO>>();
			//HORIZONTAL
			for (int rowIndex_int = 0; rowIndex_int < _gemVOs.GetLength(0); rowIndex_int += 1) 
			{
				
				//clear matches
				List<GemVO> gemVOsMatchingInCurrentCheck = new List<GemVO>();
				
				//Debug.Log ("CHECK: " + _gemVOs.GetLength(1));
				//VERTICAL
				for (int columnIndex_int = 0; columnIndex_int < _gemVOs.GetLength(1); columnIndex_int += 1) 
				{
					
					
					
					//TODO: MOVE DELCARATION OUTSIDE OF FOR/FOR
					GemVO nextGemVO = _gemVOs[rowIndex_int, columnIndex_int];

					//NOTE: WE DO A NUL CHECK, BECAUSE WE ALSO RUN HasMatches() before the grid is completely drawn in.
					if (nextGemVO != null)
					{
						//	FIRST CHECK IN THIS AXIS?, ADD IT!
						if (gemVOsMatchingInCurrentCheck.Count == 0)
						{
							gemVOsMatchingInCurrentCheck.Add (nextGemVO);
						}
						//	NOT THE FIRST CHECK IN THIS AXIS?, CHECK FOR MATCHING TYPE!
						else if (gemVOsMatchingInCurrentCheck[0].GemTypeIndex == nextGemVO.GemTypeIndex)
						{
							gemVOsMatchingInCurrentCheck.Add (nextGemVO);
							
						}
						
						
						//	NEXT DOESN'T MATCH PREVIOUS,...
						//	OR END OF THE AXIS?
						if (gemVOsMatchingInCurrentCheck[0].GemTypeIndex != nextGemVO.GemTypeIndex ||
						    columnIndex_int == _gemVOs.GetLength(1) -1)
						{
							//	DO WE HAVE ENOUGH TO MAKE A REWARD?
							if (gemVOsMatchingInCurrentCheck.Count >= TripleMatchConstants.MIN_MATCHES_PER_HORIZONTAL_AXIS_FOR_REWARD)
							{
								//Debug.Log ("Single Match : " + gemVOsMatchingInCurrentCheck.Count);
								gemVOsMatchingInAllChecksListOfLists.Add (gemVOsMatchingInCurrentCheck);
							}
							
							//	CLEAR OUT CURRENT LIST
							gemVOsMatchingInCurrentCheck = new List<GemVO>();
							gemVOsMatchingInCurrentCheck.Add (nextGemVO);
						}
					}
					
				}
			}
			
			return gemVOsMatchingInAllChecksListOfLists;
		}
		
		
		/// <summary>
		/// _s the check for matches vertical.
		/// </summary>
		private List<List<GemVO>> _CheckForMatchesVertical()
		{
			
			List<List<GemVO>> gemVOsMatchingInAllChecksListOfLists = new List<List<GemVO>>();
			
			//VERTICAL
			for (int columnIndex_int = 0; columnIndex_int < _gemVOs.GetLength(1); columnIndex_int += 1) 
			{
				
				//clear matches
				List<GemVO> gemVOsMatchingInCurrentCheck = new List<GemVO>();
				
				//Debug.Log ("CHECK: " + _gemVOs.GetLength(1));
				//HORIZONTAL
				for (int rowIndex_int = 0; rowIndex_int < _gemVOs.GetLength(0); rowIndex_int += 1) 
				{
					
					//TODO: MOVE DELCARATION OUTSIDE OF FOR/FOR
					GemVO nextGemVO = _gemVOs[rowIndex_int, columnIndex_int];
					//NOTE: WE DO A NUL CHECK, BECAUSE WE ALSO RUN HasMatches() before the grid is completely drawn in.
					if (nextGemVO != null)
					{
						//Debug.Log ("	... [" + nextGemVO);
						
						//	FIRST CHECK IN THIS AXIS?, ADD IT!
						if (gemVOsMatchingInCurrentCheck.Count == 0)
						{
							gemVOsMatchingInCurrentCheck.Add (nextGemVO);
						}
						//	NOT THE FIRST CHECK IN THIS AXIS?, CHECK FOR MATCHING TYPE!
						else if (gemVOsMatchingInCurrentCheck[0].GemTypeIndex == nextGemVO.GemTypeIndex)
						{
							gemVOsMatchingInCurrentCheck.Add (nextGemVO);
							//Debug.Log ("\tMatches last t=" + nextGemVO.GemTypeIndex  + " C=" + gemVOsMatchingInCurrentCheck.Count);
							
						}
						
						
						//	NEXT DOESN'T MATCH PREVIOUS,...
						//	OR END OF THE AXIS?
						if (gemVOsMatchingInCurrentCheck[0].GemTypeIndex != nextGemVO.GemTypeIndex ||
						    rowIndex_int == _gemVOs.GetLength(0) -1)
						{
							//	DO WE HAVE ENOUGH TO MAKE A REWARD?
							if (gemVOsMatchingInCurrentCheck.Count >= TripleMatchConstants.MIN_MATCHES_PER_VERTICAL_AXIS_FOR_REWARD)
							{
								//Debug.Log ("Single Match : " + gemVOsMatchingInCurrentCheck.Count);
								gemVOsMatchingInAllChecksListOfLists.Add (gemVOsMatchingInCurrentCheck);
							}
							
							//	CLEAR OUT CURRENT LIST
							gemVOsMatchingInCurrentCheck = new List<GemVO>();
							gemVOsMatchingInCurrentCheck.Add (nextGemVO);
							
						}
					}
					
				}
			}
			
			return gemVOsMatchingInAllChecksListOfLists;
			
		}	
		
		/// <summary>
		/// _s the do mark gem V os for deletion.
		/// </summary>
		/// <param name="gemVOsMatchingInAllChecksListOfLists">Gem V os matching in all checks list of lists.</param>
		private void _DoMarkGemVOsForDeletion (List<List<GemVO>> gemVOsMatchingInAllChecksListOfLists)
		{
			
			//	1. REMOVE FROM MASTER LIST, NOW THE MODEL HAS NO RECORD OF THEM ANYMORE. THAT IS OK, JUST REMEMBER THAT
			foreach (List<GemVO> gemVOList in gemVOsMatchingInAllChecksListOfLists)
			{
				foreach (GemVO gemVO in gemVOList)
				{
					//
					for (int rowIndex_int = 0; rowIndex_int < TripleMatchConstants.MAX_ROWS; rowIndex_int++)
					{
						for (int columnIndex_int = 0; columnIndex_int < TripleMatchConstants.MAX_COLUMNS; columnIndex_int++)
						{
							
							if (_gemVOs[rowIndex_int, columnIndex_int] == gemVO)
							{
								//Debug.Log ("FOUND: " + gemVO + " replaced with null");
								_gemVOs[rowIndex_int, columnIndex_int] = null;
							};
						}
					}
				}
			}
			
			//	2. SEND SMALL COPIED LIST TO VIEW FOR DELETION
			if (OnGemVOsMarkedForRewardAndRemovalChanged != null)
			{
				OnGemVOsMarkedForRewardAndRemovalChanged (gemVOsMatchingInAllChecksListOfLists);
			}
		}
		

		
		/// <summary>
		/// _s the do shift gems down to fill gaps.
		/// </summary>
		private void _DoShiftGemsDownToFillGaps ()
		{

			List<GemVO> gemVOsMarkedForShiftingDownChanged = new List<GemVO>();

			// START AT THE BOTTOM ROW
			for (int rowIndexToCheck_int = TripleMatchConstants.MAX_ROWS -1; rowIndexToCheck_int >= 0; rowIndexToCheck_int--)
			{
				//	CHECK LEFT TO RIGHT
				for (int columnIndexToCheck_int = 0; columnIndexToCheck_int < TripleMatchConstants.MAX_COLUMNS; columnIndexToCheck_int++)
				{

					//IS A SPOT NULL?
					//Debug.Log ("found : " + _gemVOs[rowIndexToCheck_int, columnIndexToCheck_int]);
					if (_gemVOs[rowIndexToCheck_int, columnIndexToCheck_int] == null)
					{
						//Debug.Log ("1found null: " + rowIndexToCheck_int + "," +  columnIndexToCheck_int);
						//...THEN CHECK EACH SPOT ABOVE
						for (int rowIndexToFind_int = rowIndexToCheck_int; rowIndexToFind_int >= 0; rowIndexToFind_int--)
						{
							// ...AND SWAP FIRST NON-NULL (above) INTO THE NULL SPOT (Below)
							if (_gemVOs[rowIndexToFind_int, columnIndexToCheck_int] != null)
							{

								//Debug.Log ("2found NOT null: " + rowIndexToCheck_int + " , " +  columnIndexToCheck_int);

								//COPY THE OLD TO THE NEW
								_gemVOs[rowIndexToCheck_int, columnIndexToCheck_int] = _gemVOs[rowIndexToFind_int, columnIndexToCheck_int];
								gemVOsMarkedForShiftingDownChanged.Add (_gemVOs[rowIndexToCheck_int, columnIndexToCheck_int]);
								_gemVOs[rowIndexToFind_int, columnIndexToCheck_int] = null; //CLEAR OUT THE OLD 

								//UPDATE THE PROPERTIES WITHIN THE NEW, SO THE VIEW CAN TWEEN TO NEW POSITION
								_gemVOs[rowIndexToCheck_int, columnIndexToCheck_int].RowIndex = rowIndexToCheck_int;
								_gemVOs[rowIndexToCheck_int, columnIndexToCheck_int].ColumnIndex = columnIndexToCheck_int;

								break;
							}
							
						}
					};
					
				}
			}

			Debug.Log ("Marked for shift: " + gemVOsMarkedForShiftingDownChanged.Count);

			if (OnGemVOsMarkedForShiftingDownChanged != null)
			{
				OnGemVOsMarkedForShiftingDownChanged (gemVOsMarkedForShiftingDownChanged);
			}
		}
		
		/// <summary>
		/// _s the do add new gems to fill gaps.
		/// </summary>
		private void _DoAddNewGemsToFillGaps ()
		{

			List<GemVO> gemVOsAddedToFillGapsChanged = new List<GemVO>();
			GemVO nextGemVO;
			int nextGemTypeIndex_int;

			// START AT THE BOTTOM ROW
			for (int rowIndex_int = TripleMatchConstants.MAX_ROWS -1; rowIndex_int >= 0; rowIndex_int--)
			{
				//	CHECK LEFT TO RIGHT
				for (int columnIndex_int = 0; columnIndex_int < TripleMatchConstants.MAX_COLUMNS; columnIndex_int++)
				{
					if (_gemVOs[rowIndex_int, columnIndex_int] == null)
					{
						//	SET INDEX (THIS MEANS THE COLOR)
						nextGemTypeIndex_int = Random.Range (0, TripleMatchConstants.MAX_GEM_TYPE_INDEX);
						
						//	CREATE 1 NEW GEM
						nextGemVO = new GemVO (rowIndex_int, columnIndex_int, nextGemTypeIndex_int);
						_gemVOs[rowIndex_int, columnIndex_int] = nextGemVO;
						gemVOsAddedToFillGapsChanged.Add (nextGemVO);
					}
				}
			}
			
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

