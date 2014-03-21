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
using com.rmc.projects.coins_and_platforms.components.core;
using com.rmc.projects.coins_and_platforms.constants;
using com.rmc.projects.coins_and_platforms.managers;
using com.rmc.projects.coins_and_platforms.components.player;
using UnityEngine;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.coins_and_platforms.components.enemy
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
	[RequireComponent (typeof (EnemyAIComponent))]
	public class EnemyDetectPlayerComponent : SuperTriggerComponent 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		/// <summary>
		/// The _enemy AI component.
		/// </summary>
		private EnemyAIComponent _enemyAIComponent;
		
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public EnemyDetectPlayerComponent ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~EnemyDetectPlayerComponent ( )
		{
			
			
		}
		
		
		
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			_wasTriggered = false;
			_enemyAIComponent = GetComponent <EnemyAIComponent>();
		}
		
		
		
		/// <summary>
		/// Called once per frame
		/// </summary>
		void Update()
		{
			
		}
		
		// PUBLIC
		/// <summary>
		/// Dos the refresh 
		/// </summary>
		public void doRefreshEnemy ()
		{
			_wasTriggered = false;
			
		}
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// Does trigger waypoing.
		/// 
		/// NOTE: We crudely evaluate victory here. Todo: More checks could be added (player velocity.y)
		/// 
		/// </summary>
		private void _doTriggerCollisionWithPlayer (PlayerInputComponent aPlayerInputComponent)
		{

			//FLAG THE COLLISION
			_wasTriggered = true;
			//
			if (aPlayerInputComponent.isVulnerableToEnemy) {
				SimpleGameManager.Instance.audioManager.doPlaySound (AudioClipType.ENEMY_KILLS_PLAYER);
				aPlayerInputComponent.doKnockOut();
				//BUT REFRESH QUICKLY COLLISION FLAG FOR ANY SUBSEQUENT INTERACTION
				Invoke ("doRefreshEnemy", 0.25f);
			} else {
				SimpleGameManager.Instance.audioManager.doPlaySound (AudioClipType.PLAYER_KILLS_ENEMY);
				_enemyAIComponent.doKnockOut();
			}
			
		}
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Raises the trigger enter2 d event.
		/// </summary>
		/// <param name="collider2D">Collider2 d.</param>
		public void OnTriggerEnter2D (Collider2D collider2D)
		{
			if (collider2D.gameObject.tag == MainConstants.PLAYER_TAG) {
				if (!_wasTriggered) {
					PlayerInputComponent playerInputComponent = collider2D.gameObject.GetComponent<PlayerInputComponent>();
					_doTriggerCollisionWithPlayer(playerInputComponent);
				}
			}
			
		}
		
	}
}