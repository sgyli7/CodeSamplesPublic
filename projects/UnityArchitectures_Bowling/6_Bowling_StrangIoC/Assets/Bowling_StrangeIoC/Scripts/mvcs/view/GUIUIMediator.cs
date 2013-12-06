/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
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
using com.rmc.projects.bowling_strangeioc.mvc.controller.signals;
using com.rmc.projects.bowling_strangeioc.mvc.model;
using strange.extensions.mediation.impl;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.bowling_strangeioc.mvc.view.ui
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
	public class GUIUIMediator : Mediator 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		[Inject]
		public GUIUI view {set;get;}
		
		[Inject]
		public TotalPinsKnockedOverChangedSignal totalPinsKnockedOverChangedSignal {get;set;}
		
		[Inject]
		public TotalPinsKnockedOverChangeSignal totalPinsKnockedOverChangeSignal {get;set;}
		
		[Inject]
		public BowlingBallStateChangedSignal bowlingBallStateChangedSignal {get;set;}
		

		// PUBLIC STATIC
		
		// PRIVATE
		private BowlingBallState _bowlingBallState;

		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		/// <summary>
		/// Raises the register event.
		/// </summary>
		public override void OnRegister()
		{
			totalPinsKnockedOverChangedSignal.AddListener (onTotalPinsKnockedOverChangedSignal);
			bowlingBallStateChangedSignal.AddListener (onBowlingBallStateChangedSignal);
		}
		
		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			totalPinsKnockedOverChangedSignal.RemoveListener (onTotalPinsKnockedOverChangedSignal);
			bowlingBallStateChangedSignal.RemoveListener (onBowlingBallStateChangedSignal);
		}

		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			if (_bowlingBallState == BowlingBallState.MOVING_GAME_MODE) {
				totalPinsKnockedOverChangeSignal.Dispatch ( view.doCalculateTotalPinsKnockedOver() );
			}
			
		}
		
		
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events 
		//		(This is a loose term for -- handling incoming messaging)
		//
		//--------------------------------------
		/// <summary>
		/// Ons the bowling ball state changed signal.
		/// </summary>
		/// <param name="aBowlingBallState">A bowling ball state.</param>
		public void onBowlingBallStateChangedSignal (BowlingBallState aBowlingBallState)
		{
			switch (aBowlingBallState) {
				case BowlingBallState.PRE_GAME_AIM_MODE:
					_bowlingBallState = aBowlingBallState;
					view.instructionsText = "1. Use Mouse/Arrow Keys to aim \n2. Use MouseButton/Spacebar to throw.";
					totalPinsKnockedOverChangeSignal.Dispatch (0);
					break;
				case BowlingBallState.MOVING_GAME_MODE:
					_bowlingBallState = aBowlingBallState;
					view.instructionsText = "3. Use MouseButton/Spacebar to reset.";
					break;
				default:
					//TODO, A) USE THIS CUSTOM EXCEPTION? AND B) DISABLE THE 'UNREACHABLE' WARNING?
					//throw new SwitchStatementException();
					break;
			}
			
			view.doRefreshDisplayText();
			
		}

		/// <summary>
		/// Ons the total pins knocked over changed signal.
		/// </summary>
		/// <param name="aTotalPinsKnockedOver_uint">A total pins knocked over_uint.</param>
		public void onTotalPinsKnockedOverChangedSignal (uint aTotalPinsKnockedOver_uint)
		{
			view.totalPinsKnockedOver = aTotalPinsKnockedOver_uint;
			view.doRefreshDisplayText();
			
		}
		
		
	}
	
}
