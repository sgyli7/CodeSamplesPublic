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
using UnityEngine;

//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.coins_and_platforms.constants;


namespace com.rmc.projects.coins_and_platforms.components.super
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
	public class GroundDetectorComponent : SuperTriggerComponent 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// The is walking toward solid ground_boolean.
		/// </summary>
		private bool _isWalkingTowardSolidGround_boolean = true;

		// PRIVATE STATIC

		// PRIVATE
		private CharacterController2D _characterController2D;

		private EnemyAIComponent _enemyAIComponent;

		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public GroundDetectorComponent ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~GroundDetectorComponent ( )
		{
			
			
		}
		
		
		
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			_wasTriggered = false;
			_characterController2D 	= gameObject.transform.parent.GetComponent<CharacterController2D>();
			_enemyAIComponent 		= gameObject.transform.parent.GetComponent<EnemyAIComponent>();
			
		}
		
		
		
		/// <summary>
		/// Called once per frame
		/// </summary>
		void Update()
		{

			if (!_isWalkingTowardSolidGround_boolean) {

				Debug.Log ("must turn");

				_enemyAIComponent.runSpeed_float = -_enemyAIComponent.runSpeed_float;
				_isWalkingTowardSolidGround_boolean = true;
			}

		}
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// _dos the trigger waypoing.
		/// </summary>
		private void _doTriggerWaypoint ()
		{
			_wasTriggered = true;

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
			if (_characterController2D.isGrounded || true) {
				if (collider2D.gameObject.layer != LayerMask.NameToLayer (MainConstants.PLATFORM_LAYER)) {
					Debug.Log ("enter: " + collider2D.gameObject.layer);
					_isWalkingTowardSolidGround_boolean = true;
				}

			}

		}

		/// <summary>
		/// Raises the trigger exit2 d event.
		/// </summary>
		/// <param name="collider2D">Collider2 d.</param>
		public void OnTriggerExit2D (Collider2D collider2D)
		{
			if (_characterController2D.isGrounded || true) {
				if (collider2D.gameObject.layer != LayerMask.NameToLayer (MainConstants.PLATFORM_LAYER)) {
					Debug.Log ("exit: " + collider2D.gameObject.layer);
					_isWalkingTowardSolidGround_boolean = false;
				}
				
			}

		}
		
	}
}