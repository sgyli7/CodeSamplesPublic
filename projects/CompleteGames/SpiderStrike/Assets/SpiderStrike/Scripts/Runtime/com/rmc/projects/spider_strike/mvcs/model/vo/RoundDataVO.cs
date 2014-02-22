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
using com.rmc.projects.spider_strike.mvcs.controller.signals;

//--------------------------------------
//  Namespace
//--------------------------------------
using System.Collections.Generic;
using com.rmc.projects.spider_strike.mvcs.model.data;


namespace com.rmc.projects.spider_strike.mvcs.model.vo
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
		/// The current round_uint.
		/// </summary>
		public uint currentRound_uint;

		/// <summary>
		/// The total enemies to kill_uint.
		/// </summary>
		public uint enemiesTotalToCreate;

		/// <summary>
		/// The enemies created.
		/// </summary>
		public uint enemiesCreated;

		/// <summary>
		/// The enemies spawned at once_range.
		/// </summary>
		public Range enemiesSpawnedAtOnceRange;

		/// <summary>
		/// The enemy speed_range.
		/// </summary>
		public Range enemySpeedRange;


		/// <summary>
		/// The enemy health_range.
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
		///<summary>
		///	 Constructor
		///</summary>
		public RoundDataVO (uint aCurrentRound_uint, uint aTotalEnemiesToKill_uint, Range aEnemiesSpawnedAtOnce_range, Range aEnemyHealth_range, Range aEnemySpeed_range)
		{
			currentRound_uint 				= aCurrentRound_uint;
			enemiesTotalToCreate 			= aTotalEnemiesToKill_uint;
			enemiesSpawnedAtOnceRange 		= aEnemiesSpawnedAtOnce_range;
			enemySpeedRange					= aEnemySpeed_range;
			enemyHealthRange				= aEnemyHealth_range;
			//
			
		}
		
		~RoundDataVO()
		{
			
		}
		
		// PUBLIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------

		public void clearEnemies ()
		{
			enemies = new List<GameObject>();
			enemiesCreated = 0;
		}

		public void addEnemy (GameObject aGameObject)
		{
			enemies.Add (aGameObject);
			//keep this count so even when we remove enemies, 
			//		we know the total 'ever' created in this round
			enemiesCreated ++; 
		}

		public void removeEnemy (GameObject aGameObject)
		{
			enemies.Remove (aGameObject);
		}
	}
}

