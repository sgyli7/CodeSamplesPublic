/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
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
using com.rmc.projects.bowling_strangeioc.mvc.controller.signals;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.bowling_strangeioc.mvc.model
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	/// <summary>
	/// Event listening mode.
	/// </summary>
	public enum BowlingBallState
	{
		PRE_GAME_AIM_MODE,
		MOVING_GAME_MODE
		
	}
	
	/// <summary>
	/// Input mode.
	/// NOTE: GAME MAY ACTIVELY TOGGLE BETWEEN THESE AS YOU PLAY
	/// </summary>
	public enum InputMode
	{
		MOUSE_ONLY,
		KEYBOARD_ONLY
	}
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class GameStateModel : IGameStateModel
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		/// <summary>
		/// The state of the _bowling ball.
		/// 
		/// NOTE: We check this from outside this class for handling input
		/// 
		/// </summary>
		private BowlingBallState _bowlingBallState;
		public BowlingBallState bowlingBallState { 
			get
			{
				return _bowlingBallState;
			}
			set
			{

				//TODO, ADD if (_bowlingBallState != value) to reduce traffic
				_bowlingBallState = value;
				//Debug.Log ("Mode.bowlingBallState CHANGED");
				bowlingBallStateChangedSignal.Dispatch (_bowlingBallState);
				
			}
		}


		/// <summary>
		/// The _input mode.
		/// </summary>
		private InputMode _inputMode;
		public InputMode inputMode { 
			get
			{
				return _inputMode;
			}
			set
			{
				if (_inputMode != value) {
					_inputMode = value;
					//Debug.Log ("Mode.inputMode CHANGED");
					inputModeChangedSignal.Dispatch (_inputMode);
				}
				
			}
		} 


		/// <summary>
		/// Gets or sets the bowling ball state changed signal.
		/// </summary>
		/// <value>The bowling ball state changed signal.</value>
		[Inject]
		public BowlingBallStateChangedSignal bowlingBallStateChangedSignal {set;get;}


		/// <summary>
		/// Gets or sets the input mode changed signal.
		/// </summary>
		/// <value>The input mode changed signal.</value>
		[Inject]
		public InputModeChangedSignal inputModeChangedSignal {set;get;} 
		
		
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
		///<summary>
		///	 Constructor
		/// 
		///  NOTE: **TIMING** THIS IS STEP 1 OF 3
		/// 
		///</summary>
		public GameStateModel( )
		{
			//Debug.Log ("GameStateModel.constructor()");
			
		}
		
		~GameStateModel()
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
			
			//Debug.Log ("GameStateModel.postConstruct()");
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
			//Debug.Log ("******GameStateModel.doResetModel()");
			//the views are ready now, so do the intial setup which will dispatch signals
			bowlingBallState 	= BowlingBallState.PRE_GAME_AIM_MODE;
			inputMode 			= InputMode.MOUSE_ONLY;	
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

