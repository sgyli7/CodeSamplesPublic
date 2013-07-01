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
	public class LevelManager : BaseManager
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		///<summary>
		///	 Current Level
		///</summary>
		private string _currentLevel;
		public string currentLevel 
		{
			get 
			{
				return _currentLevel;
			}
			set 
			{
				_currentLevel = value;
				Application.LoadLevel (_currentLevel);
			}
		}
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		///<summary>
		///	 Put a list of all the scene names that you'd like to navigate to. Don't list the current scene
		///</summary>
		public List<string> _listOtherScenes = new List<string>()
	    {
	        "TestLevel1",
			"TestLevel2"
	    };
		
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
		public LevelManager ( )
		{
			//Debug.Log ("LevelManager.constructor()");
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~LevelManager ( )
		{
			//Debug.Log ("LevelManager.deconstructor()");
			
		}
		
		// PUBLIC

		/// <summary>
		/// Loads the previous level.
		/// </summary>
		public void loadPreviousLevel ()
		{
			if (_currentLevel == null) {
				currentLevel = _listOtherScenes[0];
			} else {
				//CURRENT
				int currentIndex_int = _listOtherScenes.IndexOf (currentLevel);
				//NEXT
				currentIndex_int--;
				//CORRECT
				currentLevel = _getCorrectedLevelNameByIndex(currentIndex_int);
			}
		}
	
		
		/// <summary>
		/// Loads the next level.
		/// </summary>
		public void loadNextLevel ()
		{
			if (_currentLevel == null) {
				currentLevel = _listOtherScenes[0];
			} else {
				//CURRENT
				int currentIndex_int = _listOtherScenes.IndexOf (currentLevel);
				//NEXT
				currentIndex_int++;
				//CORRECT
				currentLevel = _getCorrectedLevelNameByIndex(currentIndex_int);
			}
		}
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		/// <summary>
		/// _gets the index of the corrected level name by.
		/// </summary>
		/// <returns>
		/// The corrected level name by index.
		/// </returns>
		/// <param name='aDesiredIndex_int'>
		/// A desired index_int.
		/// </param>
		private string _getCorrectedLevelNameByIndex (int aDesiredIndex_int)
		{
			int correctedIndex_int;
			//
			if (aDesiredIndex_int < 0) {
				correctedIndex_int = _listOtherScenes.Count-1;
			} else if (aDesiredIndex_int >= _listOtherScenes.Count) {
				correctedIndex_int = 0;
			} else {
				correctedIndex_int = aDesiredIndex_int;
			}
			return _listOtherScenes[correctedIndex_int];
		}
		
		// PRIVATE STATIC
		
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		override public void onAddManager()
		{
			Debug.Log ("onAddManager(): " + this);
			
		}
		
		override public void onReset(IManager aIManager)
		{
			Debug.Log ("	onReset(): " + this);
			
		}
		
		override public void onUpdate()
		{
			//Debug.Log ("onUpdate(): " + this);
			
		}
		
		override public void onRemoveManager()
		{
			Debug.Log ("onRemoveManager(): " + this);
			
		}
	}
}

