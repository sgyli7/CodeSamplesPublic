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
using com.rmc.projects.paddle_soccer.mvcs.controller.signals;
using System.Collections.Generic;
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
		/// When the total enemies to kill_uint.
		/// </summary>
		public uint goalsRequired;

		/// <summary>
		/// When the enemies created.
		/// </summary>
		public uint goalsCurrent;

		/// <summary>
		/// When the enemies spawned at once_range.
		/// </summary>
		public Range enemiesSpawnedAtOnceRange;

		/// <summary>
		/// When the enemy speed_range.
		/// </summary>
		public Range enemySpeedRange;


		/// <summary>
		/// When the enemy health_range.
		/// </summary>
		public Range enemyHealthRange;

		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// Gets or sets the enemies.
		/// </summary>
		/// <value>The enemies.</value>
		private List<GameObject> enemies;
		
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.paddle_soccer.mvcs.model.vo.RoundDataVO"/> class.
		/// </summary>
		/// <param name="aCurrentRound_uint">A current round_uint.</param>
		/// <param name="aTotalEnemiesToKill_uint">A total enemies to kill_uint.</param>
		/// <param name="aEnemiesSpawnedAtOnce_range">A enemies spawned at once_range.</param>
		/// <param name="aEnemyHealth_range">A enemy health_range.</param>
		/// <param name="aEnemySpeed_range">A enemy speed_range.</param>
		public RoundDataVO (uint aCurrentRound_uint, uint aTotalEnemiesToKill_uint, Range aEnemiesSpawnedAtOnce_range, Range aEnemyHealth_range, Range aEnemySpeed_range)
		{
			currentRound_uint 				= aCurrentRound_uint;
			goalsRequired 			= aTotalEnemiesToKill_uint;
			enemiesSpawnedAtOnceRange 		= aEnemiesSpawnedAtOnce_range;
			enemySpeedRange					= aEnemySpeed_range;
			enemyHealthRange				= aEnemyHealth_range;
			//
			
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.paddle_soccer.mvcs.model.vo.RoundDataVO"/> is reclaimed by garbage collection.
		/// </summary>
		~RoundDataVO()
		{
			
		}
		
		// PUBLIC
		
		// PRIVATE
		/// <summary>
		/// Clears the enemies.
		/// </summary>
		public void clearEnemies ()
		{
			enemies = new List<GameObject>();
			goalsCurrent = 0;
		}
		
		/// <summary>
		/// Adds the enemy.
		/// </summary>
		/// <param name="aGameObject">A game object.</param>
		public void addEnemy (GameObject aGameObject)
		{
			enemies.Add (aGameObject);
			//keep this count so even when we remove enemies, 
			//		we know the total 'ever' created in this round
			goalsCurrent ++; 
		}
		
		/// <summary>
		/// Removes the enemy.
		/// </summary>
		/// <param name="aGameObject">A game object.</param>
		public void removeEnemy (GameObject aGameObject)
		{
			enemies.Remove (aGameObject);
		}
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

