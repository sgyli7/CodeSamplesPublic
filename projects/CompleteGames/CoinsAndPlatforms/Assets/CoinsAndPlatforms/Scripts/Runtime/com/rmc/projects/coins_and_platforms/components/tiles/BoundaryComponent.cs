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
using com.rmc.projects.coins_and_platforms.constants;
using com.rmc.projects.coins_and_platforms.components.core;
using com.rmc.projects.coins_and_platforms.components.player;
using com.rmc.projects.coins_and_platforms.components.enemy;





//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.coins_and_platforms.components.tiles
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum BoundaryType
	{
		TOP,
		BOTTOM,
		LEFT,
		RIGHT
	}
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class BoundaryComponent : SuperTriggerComponent 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER

		// PUBLIC
		/// <summary>
		/// The type of the _boundary.
		/// </summary>
		public BoundaryType _boundaryType;
		
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
		public BoundaryComponent ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~BoundaryComponent ( )
		{
			
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			doRefreshBoundary();
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
		}
		
		// PUBLIC
		/// <summary>
		/// Dos the refresh boundary.
		/// </summary>
		public void doRefreshBoundary ()
		{
			_wasTriggered = false;

		}
		
		// PUBLIC STATIC
		
		// PRIVATE
		
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

			//NOTE: CURRENTLY ALL WALL TYPES 'KILL' YOU.
			//TODO: Perhaps make only BOTTOM kill and the rest just do nothing (bounce player via physics
			if (_boundaryType == BoundaryType.TOP ||
			    _boundaryType == BoundaryType.BOTTOM || 
			    _boundaryType == BoundaryType.LEFT ||
			    _boundaryType == BoundaryType.RIGHT) {
				//
				if (collider2D.gameObject.tag == MainConstants.PLAYER_TAG) {
					if (!_wasTriggered) {
						_wasTriggered = true;
						Invoke ("doRefreshBoundary",1f);
						PlayerInputComponent playerInputComponent = collider2D.gameObject.GetComponent<PlayerInputComponent>();
						playerInputComponent.onBoundaryHit();

					}
				} else if (collider2D.gameObject.tag == MainConstants.ENEMY_TAG) {
					EnemyAIComponent enemyAIComponent = collider2D.gameObject.GetComponent<EnemyAIComponent>();
					enemyAIComponent.onBoundaryHit();
				}
				
			}

		}
		
		
	}
}