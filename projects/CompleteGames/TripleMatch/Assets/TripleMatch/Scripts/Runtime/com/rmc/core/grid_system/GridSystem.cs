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
using com.rmc.core.grid_system.data;

//--------------------------------------
//  Namespace
//--------------------------------------
using System.Collections.Generic;
using com.rmc.core.exceptions;


namespace com.rmc.core.grid_system
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum Frequency
	{
		Always,
		Sometimes
		
	}
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------

	

	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class GridSystem<T> : Object where T : GridSpotVO, new()
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
		private T[,] _gridSpotVO_array;
		public T[,] GridSpotVOArray
		{
			get
			{
				return _gridSpotVO_array;
			}
			
		}

		/// <summary>
		/// Gets the list from grid spot V os.
		/// 
		/// NOTE: We keep a List format for Count and loop operations
		/// 
		/// </summary>
		/// <returns>The list from grid spot V os.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public List<T> GridSpotVOList ()
		{
			return ConvertGridSpotVOArrayToList (_gridSpotVO_array);

		}

		
		/// <summary>
		/// The _frequency of instant matches upon reset.
		/// </summary>
		private Frequency _frequencyOfInstantMatchesUponReset;  //Frequency.Sometimes; //keep this default. Set From Model for production before Use

		//	PUBLIC

		
		// 	PUBLIC STATIC
		
		/// <summary>
		/// Gets the list from grid spot V os.
		/// </summary>
		/// <returns>The list from grid spot V os.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static List<T> ConvertGridSpotVOArrayToList (T[,] gridSpotVO_array)
		{
			List<T> gridSpotVOList = new List <T>();
			//
			for (int rowIndex_int = 0; rowIndex_int < gridSpotVO_array.GetLength(0); rowIndex_int += 1) 
			{
				for (int columnIndex_int = 0; columnIndex_int < gridSpotVO_array.GetLength(1); columnIndex_int += 1) 
				{
					gridSpotVOList.Add ( gridSpotVO_array[rowIndex_int,columnIndex_int]);
				}
			}
			
			return gridSpotVOList;
			
		}
		
		
		// 	PRIVATE
		
		private int _maxRows_int;
		private int _maxColumns_int;
		private int _maxGridSpotTypeIndex_int;	
		private int _minMatchesForRewardHorizontal_int; //axis-specific for easy debugging
		private int _minMatchesForRewardVertical_int; //axis-specific for easy debugging


		
		//--------------------------------------
		// 	Constructor / Creation
		//--------------------------------------	
		
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.core.grid_system.GridSystem"/> class.
		/// </summary>
		public GridSystem 
			(
				int maxRows_int, 
			  	int maxColumns_int, 
			  	int minMatchesForRewardHorizontal_int, 
			  	int minMatchesForRewardVertical_int,
			  	int maxGridSpotTypeIndex_int
		    ) 
		{
			_maxRows_int = maxRows_int;
			_maxColumns_int = maxColumns_int;
			_minMatchesForRewardHorizontal_int = minMatchesForRewardHorizontal_int;
			_minMatchesForRewardVertical_int = minMatchesForRewardVertical_int;
			_maxGridSpotTypeIndex_int = maxGridSpotTypeIndex_int;
			
		}
		
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		// 	PUBLIC
		
		
		//	PRIVATE
		
		
		//--------------------------------------
		// 	Event Handlers
		//--------------------------------------

		/// <summary>
		/// Reset this instance.
		/// </summary>
		public void Reset (Frequency frequencyOfInstantMatchesUponReset)
		{
			_gridSpotVO_array = new T[_maxRows_int, _maxColumns_int];
			_frequencyOfInstantMatchesUponReset = frequencyOfInstantMatchesUponReset;
			PopulateGrid();


		}

		
		/// <summary>
		/// Show nice debuggable output
		/// </summary>
		override public string ToString ()
		{
			string s = "";
			s+= "[Model] (Single Click Here For Grid Output)";
			s+= "\n";
			for (int rowIndex_int = 0; rowIndex_int < _gridSpotVO_array.GetLength(0); rowIndex_int += 1) 
			{
				for (int columnIndex_int = 0; columnIndex_int < _gridSpotVO_array.GetLength(1); columnIndex_int += 1) 
				{
					s += _gridSpotVO_array[rowIndex_int,columnIndex_int].TypeIndex;
				}
				s += "\n";
			}
			return s;
			
		}


		/// <summary>
		/// Populates the grid.
		/// </summary>
		public void PopulateGrid ()
		{
			
			//	CREATE ALL NEW GEMS
			T nextGridSpotVO;
			int nextGemTypeIndex_int;
			
			//
			//
			//	TOP TO BOTTOM
			for (int rowIndex_int = 0; rowIndex_int < _maxRows_int; rowIndex_int++)
			{
				//	LEFT TO RIGHT
				for (int columnIndex_int = 0; columnIndex_int < _maxColumns_int; columnIndex_int++)
				{


					//	DUE TO THE GRID SIZE (64 DEFAULT) AND THE GRID SPOT VARIETY (5 TYPES)...
					//		1. IT IS LIKELY THAT There will be a match
					//
					//	choose 'any' gem type and don't worry if it matches a neighbor
					nextGemTypeIndex_int = Random.Range (0, _maxGridSpotTypeIndex_int);
					nextGridSpotVO = new T ();
					nextGridSpotVO.Initialize(rowIndex_int, columnIndex_int, nextGemTypeIndex_int);
					_gridSpotVO_array[rowIndex_int, columnIndex_int] = nextGridSpotVO;
					
					
				}
			}


			//	DUE TO THE GRID SIZE (64 DEFAULT) AND THE GRID SPOT VARIETY (5 TYPES)...
			//		1. IT IS LIKELY THAT There will be a match
			//		2. In the rare event we don't have a match, repeat

			if (_frequencyOfInstantMatchesUponReset == Frequency.Always && !HasMatches())
			{
				Debug.Log ("Reset Set for 'Always' Matches and HasMatches=" + HasMatches());
				PopulateGrid();
			}

		}


		/// <summary>
		/// Determines whether this instance is there A match containing either gem V the specified gridSpotVO1 gridSpotVO2.
		/// </summary>
		/// <returns><c>true</c> if this instance is there A match containing either gem V the specified gridSpotVO1 gridSpotVO2;
		/// otherwise, <c>false</c>.</returns>
		/// <param name="gridSpotVO1">Grid spot V o1.</param>
		/// <param name="gridSpotVO2">Grid spot V o2.</param>
		public bool IsThereAMatchContainingEitherGemVO (T gridSpotVO1, T gridSpotVO2)
		{
			
			bool isThereAMatchContainingEitherGemVO = false;
			
			//	1. BUILD LIST OF MATCHES
			List<List<T>> gemVOsMatchingInAllChecksListOfLists = GetMatches();
			
			foreach (List<T> gemVOList in gemVOsMatchingInAllChecksListOfLists)
			{
				if (gemVOList.Contains (gridSpotVO1) || gemVOList.Contains (gridSpotVO2))
				{
					
					isThereAMatchContainingEitherGemVO = true;
					break;
				}
				
			}
			
			return isThereAMatchContainingEitherGemVO;
		}

		
		
		/// <summary>
		/// Dos the instantly swap two gem V os.
		/// </summary>
		/// <param name="gemVO1">Gem V o1.</param>
		/// <param name="gemV02">Gem v02.</param>
		public void DoInstantlySwapTwoGemVOs (T gridSpotVO1, T gridSpotVO2)
		{
			
			//	1. SWAP INTERNAL DATA
			int rowIndex = gridSpotVO1.RowIndex;
			int columnIndex = gridSpotVO1.ColumnIndex;
			//
			gridSpotVO1.RowIndex = gridSpotVO2.RowIndex;
			gridSpotVO1.ColumnIndex = gridSpotVO2.ColumnIndex;
			gridSpotVO2.RowIndex = rowIndex;
			gridSpotVO2.ColumnIndex = columnIndex;
			
			//	2. SWAP ITS 'ADDRESS' IN THE GRID
			_gridSpotVO_array[gridSpotVO1.RowIndex, gridSpotVO1.ColumnIndex] = gridSpotVO1;
			_gridSpotVO_array[gridSpotVO2.RowIndex, gridSpotVO2.ColumnIndex] = gridSpotVO2;
			
		}
		
		
		
		
		/// <summary>
		/// _s the check for matches.
		/// </summary>
		public bool HasMatches ()
		{
			return GetMatches().Count > 0;
		}

		
		/// <summary>
		/// Gets the matches.
		/// </summary>
		/// <returns>The matches.</returns>
		public List<List<T>> GetMatches ()
		{
			List<List<T>> gemVOsMatchingInAllChecksListOfLists = new List<List<T>>();
			gemVOsMatchingInAllChecksListOfLists.AddRange (_GetMatchesHorizontal());
			gemVOsMatchingInAllChecksListOfLists.AddRange (_GetMatchesVertical());
			return gemVOsMatchingInAllChecksListOfLists;

		}

		
		/// <summary>
		/// Adds the gems to fill gaps.
		/// </summary>
		public int DoFillGapsInGems ()
		{
			
			
			//todo: Remove this 
			//3. Count the gaps. This is for debugging only
			//
			int totalAmountRemoved = 0;
			for (int rowIndex_int = 0; rowIndex_int < _maxRows_int; rowIndex_int++)
			{
				for (int columnIndex_int = 0; columnIndex_int < _maxColumns_int; columnIndex_int++)
				{
					
					if (_gridSpotVO_array[rowIndex_int, columnIndex_int] == null)
					{
						totalAmountRemoved++;
					};
					
				}
			}
			
			//Debug.Log ("totalAmountRemoved: " + totalAmountRemoved);
			
			return totalAmountRemoved;
			
			
		}
		
		

		
		/// <summary>
		/// _s the do mark gem V os for deletion.
		/// </summary>
		/// <param name="gemVOsMatchingInAllChecksListOfLists">Gem V os matching in all checks list of lists.</param>
		public void DoMarkGemVOsForDeletion (List<List<T>> gemVOsMatchingInAllChecksListOfLists)
		{
			
			//	1. REMOVE FROM MASTER LIST, NOW THE MODEL HAS NO RECORD OF THEM ANYMORE. THAT IS OK, JUST REMEMBER THAT
			foreach (List<T> gemVOList in gemVOsMatchingInAllChecksListOfLists)
			{
				foreach (T gemVO in gemVOList)
				{
					//
					for (int rowIndex_int = 0; rowIndex_int < _maxRows_int; rowIndex_int++)
					{
						for (int columnIndex_int = 0; columnIndex_int < _maxColumns_int; columnIndex_int++)
						{
							
							if (_gridSpotVO_array[rowIndex_int, columnIndex_int] == gemVO)
							{
								//Debug.Log ("FOUND: " + gemVO + " replaced with null");
								_gridSpotVO_array[rowIndex_int, columnIndex_int] = null;
							};
						}
					}
				}
			}
			
		}
		
		//	PRIVATE

		
		/// <summary>
		/// _s the do shift gems down to fill gaps.
		/// </summary>
		public List<T>  DoShiftGemsDownToFillGaps ()
		{
			
			List<T> gemVOsMarkedForShiftingDownChanged = new List<T>();
			
			// START AT THE BOTTOM ROW
			for (int rowIndexToCheck_int = _maxRows_int -1; rowIndexToCheck_int >= 0; rowIndexToCheck_int--)
			{
				//	CHECK LEFT TO RIGHT
				for (int columnIndexToCheck_int = 0; columnIndexToCheck_int < _maxColumns_int; columnIndexToCheck_int++)
				{
					
					//IS A SPOT NULL?
					//Debug.Log ("found : " + _gemVOs[rowIndexToCheck_int, columnIndexToCheck_int]);
					if (_gridSpotVO_array[rowIndexToCheck_int, columnIndexToCheck_int] == null)
					{
						//Debug.Log ("1found null: " + rowIndexToCheck_int + "," +  columnIndexToCheck_int);
						//...THEN CHECK EACH SPOT ABOVE
						for (int rowIndexToFind_int = rowIndexToCheck_int; rowIndexToFind_int >= 0; rowIndexToFind_int--)
						{
							// ...AND SWAP FIRST NON-NULL (above) INTO THE NULL SPOT (Below)
							if (_gridSpotVO_array[rowIndexToFind_int, columnIndexToCheck_int] != null)
							{
								
								//Debug.Log ("2found NOT null: " + rowIndexToCheck_int + " , " +  columnIndexToCheck_int);
								
								//COPY THE OLD TO THE NEW
								_gridSpotVO_array[rowIndexToCheck_int, columnIndexToCheck_int] = _gridSpotVO_array[rowIndexToFind_int, columnIndexToCheck_int];
								gemVOsMarkedForShiftingDownChanged.Add (_gridSpotVO_array[rowIndexToCheck_int, columnIndexToCheck_int]);
								_gridSpotVO_array[rowIndexToFind_int, columnIndexToCheck_int] = null; //CLEAR OUT THE OLD 
								
								//UPDATE THE PROPERTIES WITHIN THE NEW, SO THE VIEW CAN TWEEN TO NEW POSITION
								_gridSpotVO_array[rowIndexToCheck_int, columnIndexToCheck_int].RowIndex = rowIndexToCheck_int;
								_gridSpotVO_array[rowIndexToCheck_int, columnIndexToCheck_int].ColumnIndex = columnIndexToCheck_int;
								
								break;
							}
							
						}
					};
					
				}
			}
			
			return gemVOsMarkedForShiftingDownChanged;
		}
		
		/// <summary>
		/// _s the do add new gems to fill gaps.
		/// </summary>
		public List<T> DoAddNewGemsToFillGaps ()
		{
			
			List<T> gemVOsAddedToFillGapsChanged = new List<T>();
			T nextGemVO;
			int nextGemTypeIndex_int;
			
			// START AT THE BOTTOM ROW
			for (int rowIndex_int = _maxRows_int -1; rowIndex_int >= 0; rowIndex_int--)
			{
				//	CHECK LEFT TO RIGHT
				for (int columnIndex_int = 0; columnIndex_int < _maxColumns_int; columnIndex_int++)
				{
					if (_gridSpotVO_array[rowIndex_int, columnIndex_int] == null)
					{
						//	SET INDEX (THIS MEANS THE COLOR)
						nextGemTypeIndex_int = Random.Range (0, _maxGridSpotTypeIndex_int);
						
						//	CREATE 1 NEW GEM
						nextGemVO = new T();
						nextGemVO.Initialize(rowIndex_int, columnIndex_int, nextGemTypeIndex_int);
						_gridSpotVO_array[rowIndex_int, columnIndex_int] = nextGemVO;
						gemVOsAddedToFillGapsChanged.Add (nextGemVO);
					}
				}
			}
			
			return gemVOsAddedToFillGapsChanged;
			
		}



		//	PRIVATE





		/// <summary>
		/// _s the check for matches horizontal.
		/// </summary>
		private List<List<T>> _GetMatchesHorizontal ()
		{

			
			List<List<T>> gemVOsMatchingInAllChecksListOfLists = new List<List<T>>();
			//HORIZONTAL
			for (int rowIndex_int = 0; rowIndex_int < _gridSpotVO_array.GetLength(0); rowIndex_int += 1) 
			{

				//clear matches
				List<T> gemVOsMatchingInCurrentCheck = new List<T>();
				
				//Debug.Log ("CHECK: " + _gemVOs.GetLength(1));
				//VERTICAL
				for (int columnIndex_int = 0; columnIndex_int < _gridSpotVO_array.GetLength(1); columnIndex_int += 1) 
				{
					
					
					
					//TODO: MOVE DELCARATION OUTSIDE OF FOR/FOR
					T nextGemVO = _gridSpotVO_array[rowIndex_int, columnIndex_int];
					
					//NOTE: WE DO A NUL CHECK, BECAUSE WE ALSO RUN HasMatches() before the grid is completely drawn in.
					if (nextGemVO != null)
					{
						//	FIRST CHECK IN THIS AXIS?, ADD IT!
						if (gemVOsMatchingInCurrentCheck.Count == 0)
						{
							gemVOsMatchingInCurrentCheck.Add (nextGemVO);
						}
						//	NOT THE FIRST CHECK IN THIS AXIS?, CHECK FOR MATCHING TYPE!
						else if (gemVOsMatchingInCurrentCheck[0].TypeIndex == nextGemVO.TypeIndex)
						{
							gemVOsMatchingInCurrentCheck.Add (nextGemVO);
							
						}
						
						
						//	NEXT DOESN'T MATCH PREVIOUS,...
						//	OR END OF THE AXIS?
						if (gemVOsMatchingInCurrentCheck[0].TypeIndex != nextGemVO.TypeIndex ||
						    columnIndex_int == _gridSpotVO_array.GetLength(1) -1)
						{
							//	DO WE HAVE ENOUGH TO MAKE A REWARD?
							if (gemVOsMatchingInCurrentCheck.Count >= _minMatchesForRewardHorizontal_int)
							{
								//Debug.Log ("Single Match : " + gemVOsMatchingInCurrentCheck.Count);
								gemVOsMatchingInAllChecksListOfLists.Add (gemVOsMatchingInCurrentCheck);
							}

							//	CLEAR OUT CURRENT LIST
							gemVOsMatchingInCurrentCheck = new List<T>();
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
		private List<List<T>> _GetMatchesVertical()
		{
			
			List<List<T>> gemVOsMatchingInAllChecksListOfLists = new List<List<T>>();
			
			//VERTICAL
			for (int columnIndex_int = 0; columnIndex_int < _gridSpotVO_array.GetLength(1); columnIndex_int += 1) 
			{

				//clear matches
				List<T> gemVOsMatchingInCurrentCheck = new List<T>();
				
				//Debug.Log ("CHECK: " + _gemVOs.GetLength(1));
				//HORIZONTAL
				for (int rowIndex_int = 0; rowIndex_int < _gridSpotVO_array.GetLength(0); rowIndex_int += 1) 
				{

					//TODO: MOVE DELCARATION OUTSIDE OF FOR/FOR
					T nextGemVO = _gridSpotVO_array[rowIndex_int, columnIndex_int];
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
						else if (gemVOsMatchingInCurrentCheck[0].TypeIndex == nextGemVO.TypeIndex)
						{
							gemVOsMatchingInCurrentCheck.Add (nextGemVO);
							//Debug.Log ("\tMatches last t=" + nextGemVO.GemTypeIndex  + " C=" + gemVOsMatchingInCurrentCheck.Count);
							
						}
						
						
						//	NEXT DOESN'T MATCH PREVIOUS,...
						//	OR END OF THE AXIS?
						if (gemVOsMatchingInCurrentCheck[0].TypeIndex != nextGemVO.TypeIndex ||
						    rowIndex_int == _gridSpotVO_array.GetLength(0) -1)
						{
							//	DO WE HAVE ENOUGH TO MAKE A REWARD?
							if (gemVOsMatchingInCurrentCheck.Count >= _minMatchesForRewardVertical_int)
							{
								//Debug.Log ("Single Match : " + gemVOsMatchingInCurrentCheck.Count);
								gemVOsMatchingInAllChecksListOfLists.Add (gemVOsMatchingInCurrentCheck);
							}
							
							//	CLEAR OUT CURRENT LIST
							gemVOsMatchingInCurrentCheck = new List<T>();
							gemVOsMatchingInCurrentCheck.Add (nextGemVO);
							
						}
					}
					
				}
			}
			
			return gemVOsMatchingInAllChecksListOfLists;
			
		}	


	}
}
