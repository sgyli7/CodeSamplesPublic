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

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs.model.vo
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	/// <summary>
	/// Move type.
	/// </summary>
	public enum MoveType
	{
		UpOneTick,
		DownOneTick,
	}

	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class PlayerMoveVO 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		/// <summary>
		/// The type of the _move.
		/// </summary>
		private MoveType _moveType;
		public MoveType moveType { 
			get
			{
				return _moveType;
			}
			set
			{
				_moveType = value;
			}
		}


		/// <summary>
		/// The _amount_float.
		/// </summary>
		private float _amount_float;
		public float amount {
			get
			{
				return _amount_float;
			}
			set
			{
				_amount_float = value;
			}
		}
		
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Constructor / Destructor
		//--------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.paddle_soccer.mvcs.model.vo.PlayerMoveVO"/> class.
		/// </summary>
		/// <param name="aMoveType">A move type.</param>
		public PlayerMoveVO (MoveType aMoveType )
		{
			_moveType = aMoveType;
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.paddle_soccer.mvcs.model.vo.PlayerMoveVO"/> class.
		/// </summary>
		/// <param name="aMoveType">A move type.</param>
		/// <param name="aAmount_float">A amount_float.</param>
		public PlayerMoveVO (MoveType aMoveType, float aAmount_float )
		{
			_moveType = aMoveType;
			_amount_float = aAmount_float;
			
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.paddle_soccer.mvcs.model.vo.PlayerMoveVO"/> is reclaimed by garbage collection.
		/// </summary>
		~PlayerMoveVO()
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

