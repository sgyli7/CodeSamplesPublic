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
	public class GUIManager : BaseManager
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		GameManager _gameManager;
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		///<summary>
		///	 Constructor
		///</summary>
		public GUIManager ( )
		{
			//Debug.Log ("GUIManager.constructor()");
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~GUIManager ( )
		{
			//Debug.Log ("GUIManager.deconstructor()");
			
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

		override public void onReset(IManager aIManager)
		{
			
			//JUST RE-GET THIS OFTEN
			_gameManager = MOM.Instance.getManager<GameManager>();
			
			//
			if (_gameManager != null) {
				
				if (!_gameManager.hasEventListener (GameManager.SCORE_CHANGED, _onScoreChanged) ) {
					_gameManager.addEventListener (GameManager.SCORE_CHANGED, _onScoreChanged);
				} else {
					_gameManager.removeEventListener (GameManager.SCORE_CHANGED, _onScoreChanged);
				}
			}
			
		}
		
		override public void onUpdate()
		{
			
		}
		
		
		override public void onRemoveManager()
		{
			if (_gameManager == null) {
				if (_gameManager.hasEventListener (GameManager.SCORE_CHANGED, _onScoreChanged) ) {
					_gameManager.removeEventListener (GameManager.SCORE_CHANGED, _onScoreChanged);
				}
				_gameManager = null;
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
			Debug.Log ("GUIManager._onScoreChanged()");
		}
		

	}
}

