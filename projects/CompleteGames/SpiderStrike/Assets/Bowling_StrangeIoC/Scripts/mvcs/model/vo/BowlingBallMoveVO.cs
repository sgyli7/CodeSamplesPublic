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
using UnityEngine;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.bowling_strangeioc.mvc.model.vo
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	/// <summary>
	/// Event listening mode.
	/// </summary>
	public enum MoveType
	{
		THROW,
		SPIN_LEFT,
		MOVE_BY,
		MOVE_TO,
		
	}
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class BowlingBallMoveVO 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
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

		private Vector2 _vector2;
		public Vector2 vector2 {
			get
			{
				return _vector2;
			}
			set
			{
				_vector2 = value;
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
		///<summary>
		///	 Constructor
		///</summary>
		public BowlingBallMoveVO (MoveType aMoveType, Vector2 aVector2 = default (Vector2) )
		{
			_moveType = aMoveType;
			_vector2 = aVector2;
			
		}
		
		~BowlingBallMoveVO()
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
	}
}

