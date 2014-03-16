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
using com.rmc.projects.coins_and_platforms.managers;
using com.rmc.projects.coins_and_platforms.constants;
namespace com.rmc.projects.coins_and_platforms.components
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
	public class PlayerDetectEnemyComponent : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public PlayerDetectEnemyComponent ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~PlayerDetectEnemyComponent ( )
		{
			
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			
		}
		

		/// <summary>
		/// Raises the application quit event.
		/// </summary>
		void OnApplicationQuit() 
		{
			
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
		void OnTriggerEnter2D(Collider2D aCollider2D)
		{


			//TODO: detect player hitting from 'above'
			bool isPlayerOnOffense_boolean = true;


			//
			if (aCollider2D.gameObject.layer == LayerMask.NameToLayer (MainConstants.ENEMY_LAYER)) {

				if (isPlayerOnOffense_boolean) {

					SimpleGameManager.Instance.audioManager.doPlaySound (AudioManager.CLIP_NAME.PLAYER_KILLS_ENEMY);
					SimpleGameManager.Instance.gameManager.doGameOver (GameManager.GameOverReason.LOSS);
				} else {
					SimpleGameManager.Instance.audioManager.doPlaySound (AudioManager.CLIP_NAME.ENEMY_KILLS_PLAYER);
					SimpleGameManager.Instance.gameManager.doGameOver (GameManager.GameOverReason.WIN);

				}

			}			
		}
	}
}