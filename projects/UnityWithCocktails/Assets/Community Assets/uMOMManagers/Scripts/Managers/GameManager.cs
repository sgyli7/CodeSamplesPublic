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
using UnityEditor;
using System.Collections.Generic;
using com.rmc.utilities;
using com.rmc.managers.eventmanager;
using com.rmc.events;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.managers.mom
{
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Abstract manager.
	/// </summary>
	public class GameManager : BaseManager
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PUBLIC
		
		// PUBLIC STATIC
		public static string SCORE_CHANGED = "SCORE_CHANGED";
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		///<summary>
		///	 Constructor
		///</summary>
		public GameManager ( )
		{
			//Debug.Log ("GameManager.constructor()");
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~GameManager ( )
		{
			//Debug.Log ("GameManager.deconstructor()");
			
		}
		
		// PUBLIC

		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		override public void onAddManager()
		{
			
		}
		
		
		override public void onReset(IManager aIManager)
		{
			
			//JUST RE-GET THIS OFTEN
			if (!hasEventListener (GameManager.SCORE_CHANGED, _onScoreChanged) ) {
				addEventListener (GameManager.SCORE_CHANGED, _onScoreChanged);
			} else {
				removeEventListener (GameManager.SCORE_CHANGED, _onScoreChanged);	
			}
			
		}
		
		private int countUpToDispatch_int = 199;
		override public void onUpdate()
		{
			if (countUpToDispatch_int++ > 200) {
				dispatchEvent (new com.rmc.events.Event (GameManager.SCORE_CHANGED) );
				countUpToDispatch_int = 0;
			}
		}
		
		override public void onRemoveManager()
		{
			
			if (hasEventListener (GameManager.SCORE_CHANGED, _onScoreChanged) ) {
				Debug.Log ("&&&&&&&& REMOVE");
				removeEventListener (GameManager.SCORE_CHANGED, _onScoreChanged);
			}
		}
		
		
		
		
		/// <summary>
		/// _ons the score changed.
		/// </summary>
		/// <param name='aIEvent'>
		/// A I event.
		/// </param>
		public void _onScoreChanged(IEvent aIEvent)
		{
			Debug.Log ("GameManager._onScoreChanged()");
		}
		
	}
}

