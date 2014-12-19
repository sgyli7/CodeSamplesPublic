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



//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.triple_match.mvc.model.data;


namespace com.rmc.projects.triple_match
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
	public class TripleMatchConstants 
	{ 

		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// 	PUBLIC
		
		public const int MAX_ROWS = 8;
		public const int MAX_COLUMNS = 8;
		public const int MAX_GEM_TYPE_INDEX = 5;

		//
		public static float ROW_SIZE = 0.4f;
		public static float COLUMN_SIZE = 0.4f;

		//
		public static float DELAY_TO_START_GAME = 0.25f;
		public static float DURATION_GEM_TWEEN_SWAP = 0.5f;
		public static float DURATION_GEM_TWEEN_ENTRY = 0.5f;
		public static float DURATION_GEM_TWEEN_EXIT = 0.5f;
		public static float DURATION_FLOATING_SCORE_EXIT = 0.5f;
		//
		public static string TEXT_TITLE = "Triple Match";
		public static string TEXT_GAME_RESET_TEXT = "Reset Game";
		public static string TEXT_SCORE_LABEL = "Score: ";
		public static string TEXT_POINTS = " Pts";

		//
		public static string PATH_GEM_VIEW_PREFAB = "Prefabs/GemViewPrefab";
		public static string PATH_FLOATING_SCORE_VIEW_PREFAB = "Prefabs/FloatingScoreViewPrefab";

		//
		public static float POSITION_OFFSET_FLOATING_SCORE_VIEW_Y = 30;

		//
		public static int SCORE_POINTS_PER_GEM = 50;
		public static int SCORE_MULTIPLYER_PER_GEM = 2;


		//--------------------------------------
		//  Methods
		//--------------------------------------


		//	PUBLIC STATIC

		/// <summary>
		/// Gets the length of the score reward for match of.
		/// </summary>
		public static int GetScoreRewardForMatchOfLength (int gemCount_int)
		{
			return gemCount_int * TripleMatchConstants.SCORE_POINTS_PER_GEM * TripleMatchConstants.SCORE_MULTIPLYER_PER_GEM;
		}

		/// <summary>
		/// Gets the gem tween entry delay.
		/// </summary>
		public static float GetGemTweenEntryDelay (GemVO gemVO)
		{
			return (gemVO.ColumnIndex) * 0.05f;
		}
	}

}
