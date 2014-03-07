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
using UnityEngine;
using com.rmc.projects.paddle_soccer.mvcs.model.data;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs.model.vo
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
	public class RoundDataVO 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// When the current round_uint.
		/// </summary>
		public uint currentRound_uint;

		/// <summary>
		/// The player goals required to win.
		/// </summary>
		public uint playerGoalsRequiredToWin;

		/// <summary>
		/// The player goals scored this round.
		/// </summary>
		public uint playerGoalsScoredThisRound;

		/// <summary>
		/// The cpu goals scored this round.
		/// </summary>
		public uint cpuGoalsScoredThisRound;

		////
	

		/// <summary>
		/// The cpu goals required to lose.
		/// </summary>
		public uint cpuGoalsRequiredToLose;

		/// <summary>
		/// The cpu move speed_range.
		/// </summary>
		public Range cpuMoveSpeed_range;

		/// <summary>
		/// Gets the random CPU movement speed within range.
		/// </summary>
		/// <returns>The random CPU movement speed within range.</returns>
		public float getRandomCPUMovementSpeedWithinRange () 
		{
			return cpuMoveSpeed_range.getRandomFloatValueWithinRange();

		}


		// PUBLIC STATIC
		
		// PRIVATE
		
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Constructor / Destructor
		//--------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.paddle_soccer.mvcs.model.vo.RoundDataVO"/> class.
		/// </summary>
		/// <param name="aCurrentRound_uint">A current round_uint.</param>
		/// <param name="aPlayerGoalsRequiredToWin_uint">A player goals required to win_uint.</param>
		/// <param name="aCPUGoalsRequiredToLose_uint">A CPU goals required to lose_uint.</param>
		/// <param name="aCPUMoveSpeed_range">A CPU move speed_range.</param>
		public RoundDataVO (uint aCurrentRound_uint, uint aPlayerGoalsRequiredToWin_uint, uint aCPUGoalsRequiredToLose_uint, Range aCPUMoveSpeed_range)
		{
			currentRound_uint 				= aCurrentRound_uint;
			playerGoalsRequiredToWin 		= aPlayerGoalsRequiredToWin_uint;
			cpuGoalsRequiredToLose 			= aCPUGoalsRequiredToLose_uint;
			cpuMoveSpeed_range				= aCPUMoveSpeed_range;
			//
			playerGoalsScoredThisRound 		= 0;
			cpuGoalsScoredThisRound			= 0;
			
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.paddle_soccer.mvcs.model.vo.RoundDataVO"/> is reclaimed by garbage collection.
		/// </summary>
		~RoundDataVO()
		{
			
		}

		//--------------------------------------
		//  Methods
		//--------------------------------------

		// PUBLIC
		
		// PRIVATE


		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

