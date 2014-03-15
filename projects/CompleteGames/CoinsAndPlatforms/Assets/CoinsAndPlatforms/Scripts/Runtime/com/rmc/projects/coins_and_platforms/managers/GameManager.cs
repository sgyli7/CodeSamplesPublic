/**
* Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
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
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.coins_and_platforms.managers
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
	public class GameManager : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		public enum GameOverReason
		{	
			WIN,
			LOSS
		}

		// PRIVATE
		private GameOverReason _lastGameOverReason;

		private GUIText _scoreGUIText;


		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public GameManager ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~GameManager ( )
		{
			
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			//TODO, REFRENCE THIS WITHOUT HACKY INDEX #
			_scoreGUIText = GameObject.Find ("_GUI").GetComponentsInChildren<GUIText>()[0];
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
		}
		
		// PUBLIC
		public void doGameOver (GameOverReason aGameOverReason) 
		{
			_lastGameOverReason = aGameOverReason;
			_doGameOverImmediate();

		}



		/// <summary>
		/// _dos the game over immediate.
		/// </summary>
		private void _doGameOverImmediate()
		{
			//Time.timeScale = .1f;

			switch (_lastGameOverReason) {
			case GameOverReason.WIN:
				_doSetScore ("You Win!");
				break;
			case GameOverReason.LOSS:
				_doSetScore("You Lose!");
				break;
			}


			Invoke ("_doGameOverAfterPause", 0.25f);
		}


		/// <summary>
		/// _dos the game over after pause.
		/// </summary>
		private void _doGameOverAfterPause()
		{

			//Time.timeScale = 1;

			//clean up
			SimpleGameManager.Instance.enemyManager.doDespawnAllEnemies();
			SimpleGameManager.Instance.enemyManager.doDeListAllBosses();
			SimpleGameManager.Instance.platformManager.doDeListAllPlatforms();


			switch (_lastGameOverReason) {
				case GameOverReason.WIN:
					//SimpleGameManager.Instance.loadCurrentLevelAgain();
					Application.LoadLevel (Application.loadedLevel);
					break;
				case GameOverReason.LOSS:
					//SimpleGameManager.Instance.loadCurrentLevelAgain();
					Application.LoadLevel (Application.loadedLevel);
					break;
			}


		}
		/// <summary>
		/// _dos the set score.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		private void _doSetScore (string aMessage_string) 
		{
			if (_scoreGUIText) {
				_scoreGUIText.text = "Score: " + aMessage_string;
			}
		}

		//PRIVATE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
