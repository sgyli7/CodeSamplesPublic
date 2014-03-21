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
using com.rmc.projects.coins_and_platforms.constants;
using com.rmc.projects.coins_and_platforms.components.core;
using UnityEngine;

//--------------------------------------
//  Namespace
//--------------------------------------
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
	public class EnemyAIComponent : SuperMovementComponent 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// The run speed_float.
		/// </summary>
		public float runSpeed_float = 8f;
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _was grounded_boolean.
		/// </summary>
		private bool _wasGrounded_boolean = false;

		/// <summary>
		/// The _spawn point position_vector3.
		/// </summary>
		private Vector3 _spawnPointPosition_vector3;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public EnemyAIComponent ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~EnemyAIComponent ( )
		{
			
			
		}

		
		
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			_normalizedHorizontalSpeed_float = 1;
			_spawnPointPosition_vector3 = transform.position;
		}
		
		
		
		/// <summary>
		/// Called once per frame
		/// </summary>
		void Update()
		{
			//*************************
			//  PREPARE
			//*************************
			_velocity_vector3 = _getCurrentVelocityBeforeModifications();
			
			//*************************
			//  MOVE H
			//*************************
			_velocity_vector3 = _doUpdateHorizontalVelocity 
				(
					_velocity_vector3,
					_normalizedHorizontalSpeed_float,
					runSpeed_float
				);


			//*************************
			//  FACE FORWARD
			//*************************
			_doSetScaleFromHorizontalVelocity (_normalizedHorizontalSpeed_float);

			//*************************
			//  MOVE V
			//*************************
			_velocity_vector3 = _doUpdateVerticalVelocity (	_velocity_vector3 );

			//*************************
			//  UPDATE
			//*************************
			_setCurrentVelocityAfterModifications (_velocity_vector3);


			//*************************
			//  STORE
			//*************************
			_wasGrounded_boolean = _characterController2D.isGrounded;
		}

		/// <summary>
		/// Dos the kill enemy.
		/// </summary>
		public void doDie ()
		{
			//TODO, SHOW A SHELL ANIMATION AND FLY OFFSCREEN (IMMEDIATY OUT OF 'PLAY' (DON'T SLIDE THE SHELL)
			_characterController2D.enabled = false;
			transform.Rotate (new Vector3 (1, 0, 0));
			_setAnimationTrigger (MainConstants.ENEMY_DYING_TRIGGER);
		}

		/// <summary>
		/// Dos the reset to spawn point.
		/// </summary>
		public void doResetToSpawnPoint ()
		{
			gameObject.transform.position = _spawnPointPosition_vector3;
			doResetPhysicsAndAnimation();
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
		
	
	}
}