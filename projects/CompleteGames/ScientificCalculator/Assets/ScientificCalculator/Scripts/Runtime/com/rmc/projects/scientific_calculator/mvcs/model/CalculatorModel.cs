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
using com.rmc.projects.scientific_calculator.mvcs.controller.signals;
using UnityEngine;
using com.rmc.projects.scientific_calculator.mvcs.model.vo;
using com.rmc.exceptions;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.scientific_calculator.mvcs.model
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
	public class CalculatorModel  : ICalculatorModel
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER



		/// <summary>
		/// When the _turret health_int.
		/// </summary>
		private int _turretHealth_int;
		public int turretHealth
		{ 
			get{
				return _turretHealth_int;
			}
			set
			{
				_turretHealth_int = value;
				_turretHealth_int = Mathf.Clamp (_turretHealth_int, 0, 1000);
				//turretHealthChangedSignal.Dispatch (_turretHealth_int);

				if (_turretHealth_int == 0) {
				//	turretDiedSignal.Dispatch ();
				}
				
			}
		}


		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE

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
		/// Initializes a new instance of the <see cref="com.rmc.projects.spider_strike.mvcs.model.GameModel"/> class.
		/// </summary>
		public CalculatorModel( )
		{
			//Debug.Log ("GameModel.constructor()");
			
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.spider_strike.mvcs.model.GameModel"/> is reclaimed by garbage collection.
		/// </summary>
		~CalculatorModel()
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

			//Debug.Log ("MODEL RESET FINISHED");
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

