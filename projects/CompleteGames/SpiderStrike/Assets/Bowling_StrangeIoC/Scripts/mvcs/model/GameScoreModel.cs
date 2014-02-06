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
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class GameScoreModel  : IGameScoreModel
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER


		/// <summary>
		/// The _total pins knocked over_int.
		/// </summary>
		private uint _totalPinsKnockedOver_int;
		public uint totalPinsKnockedOver
		{ 
			get
			{
				return _totalPinsKnockedOver_int;
			}
			set
			{
				_totalPinsKnockedOver_int = value;
				totalPinsKnockedOverChangedSignal.Dispatch (_totalPinsKnockedOver_int);
				
			}
		}

		[Inject]
		public TotalPinsKnockedOverChangedSignal totalPinsKnockedOverChangedSignal {set;get;}

		
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
		public GameScoreModel( )
		{
			//Debug.Log ("GameStateModel.constructor()");
			
		}
		
		~GameScoreModel()
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
			
			//Debug.Log ("GameScoreModel.postConstruct()");
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
			totalPinsKnockedOver = 0;
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

