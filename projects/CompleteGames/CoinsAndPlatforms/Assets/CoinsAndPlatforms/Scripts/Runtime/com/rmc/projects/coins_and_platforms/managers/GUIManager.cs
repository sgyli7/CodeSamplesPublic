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
using com.rmc.exceptions;
using System;
using com.rmc.projects.coins_and_platforms.constants;




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
	public class GUIManager : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		
		// PRIVATE
		
		/// <summary>
		/// The _score GUI text.
		/// </summary>
		private GUIText _scoreGUIText;
		private GUIText _scoreGUIText2;
		
		
		/// <summary>
		/// The _lives GUI text.
		/// </summary>
		private GUIText _livesGUIText;
		private GUIText _livesGUIText2;
		
		/// <summary>
		/// The _prompt GUI text.
		/// </summary>
		private GUIText _promptGUIText;
		private GUIText _promptGUIText2;

		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public GUIManager ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~GUIManager ( )
		{
			
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			//
			_doSetBrittleReferences();
		}
		
		
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
		}

		
		// PUBLIC
		/// <summary>
		/// Sets the score text.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		public void setScoreText (string aMessage_string)
		{
			_scoreGUIText.text 	= "Score: " + aMessage_string;
			_scoreGUIText2.text = "Score: " + aMessage_string;

		}


		/// <summary>
		/// Sets the lives text.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		public void setLivesText (string aMessage_string)
		{
			//
			_livesGUIText.text 	= "Lives: " + aMessage_string;
			_livesGUIText2.text = "Lives: " + aMessage_string;
			
		}

		/// <summary>
		/// Sets the prompt text.
		/// </summary>
		/// <param name="aMessage_string">A message_string.</param>
		public void setPromptText (string aMessage_string)
		{
			_promptGUIText.text = aMessage_string;
			_promptGUIText2.text = aMessage_string;
			
		}
		
		

		// PRIVATE
		
		
		/// <summary>
		/// _dos the set brittle references.
		/// 
		/// NOTE: For simplicity, this brittle approach is used instead of alternatives;
		/// 		* public transform references, set via dragging from hierarchy items
		/// 		* Inversion Of Control (StrangeIoC) where less GameObject-to-GameObject references are needed.
		/// 		* Manager dynamically spawning via Instantiate()
		/// 		* Etc...
		/// 
		/// 
		/// NOTE: We could shift this code to a newly created GUIManager. For now its fine.
		/// 
		/// 
		/// </summary>
		private void _doSetBrittleReferences()
		{
			
			_scoreGUIText 				= _doThrowErrorIfNull (GameObject.Find (MainConstants.ScoreGUIText).GetComponent<GUIText>()) as GUIText;
			_scoreGUIText2 				= _doThrowErrorIfNull (GameObject.Find (MainConstants.ScoreGUIText2).GetComponent<GUIText>()) as GUIText;
			_livesGUIText 				= _doThrowErrorIfNull (GameObject.Find (MainConstants.LivesGUIText).GetComponent<GUIText>()) as GUIText;
			_livesGUIText2 				= _doThrowErrorIfNull (GameObject.Find (MainConstants.LivesGUIText2).GetComponent<GUIText>()) as GUIText;
			_promptGUIText 				= _doThrowErrorIfNull (GameObject.Find (MainConstants.PromptGUIText).GetComponent<GUIText>()) as GUIText;
			_promptGUIText2 			= _doThrowErrorIfNull (GameObject.Find (MainConstants.PromptGUIText2).GetComponent<GUIText>()) as GUIText;

		}

		/// <summary>
		/// Throws the error if null.
		/// </summary>
		/// <returns>The error if null.</returns>
		/// <param name="aToCheck_object">A to check_object.</param>
		private UnityEngine.Object _doThrowErrorIfNull(UnityEngine.Object aToCheck_object)
		{
			
			if (aToCheck_object == null) {
				throw new Exception ("Must not be null : " + aToCheck_object);
			}
			
			return aToCheck_object;
			
		}



		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
