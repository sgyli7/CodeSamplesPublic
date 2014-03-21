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
using com.rmc.projects.coins_and_platforms.managers;
using com.rmc.projects.coins_and_platforms.constants;

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
	public class PlayerInputComponent : SuperMovementComponent 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC

		// PRIVATE
		/// <summary>
		/// The _run speed_float.
		/// </summary>
		private float _runSpeed_float = 60f;

		/// <summary>
		/// Gets or sets a value indicating whether this
		/// <see cref="com.rmc.projects.coins_and_platforms.components.super.PlayerInputComponent"/> is vulnerable to enemy.
		/// </summary>
		/// <value><c>true</c> if is vulnerable to enemy; otherwise, <c>false</c>.</value>
		public bool isVulnerableToEnemy {
			get {
				return false;
			}
		}
		
		/// <summary>
		/// The height of the _target jump.
		/// </summary>
		private float _targetJumpHeight = 50f;
		
		/// <summary>
		/// The _last controller collider hit.
		/// </summary>
		private RaycastHit2D _lastControllerColliderHit;

		// PRIVATE STATIC

		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public PlayerInputComponent ()
		{

			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~PlayerInputComponent ( )
		{
			
			
		}
		
		
		
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			SimpleGameManager.Instance.doRefreshInstance();
			_normalizedHorizontalSpeed_float = 1;
		}
		
		
		
		/// <summary>
		/// Called once per frame
		/// </summary>
		void Update()
		{
			_doHandleMovement();
		}
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE

		/// <summary>
		/// _dos the handle movement.
		/// </summary>
		private void _doHandleMovement()
		{


			
			//ALWAYS ALLOW RESTART
			if( Input.GetKeyDown( KeyCode.Space ))
			{
				SimpleGameManager.Instance.gameManager.doRestartGame();
			}


			//IF ENABLED, TAKE INPUT....
			if (_characterController2D.enabled) {

				//PREPARE FOR CALCULATIONS
				_velocity_vector3 = _getCurrentVelocityBeforeModifications();
				
				//DO CALCULATIONS
				if( _characterController2D.isGrounded ) {
					if (_velocity_vector3.y != 0) {
						SimpleGameManager.Instance.audioManager.doPlaySound (AudioClipType.PLAYER_LANDS);
						_setAnimationTrigger (MainConstants.IDLE_TRIGGER);
						_velocity_vector3.y = 0;
					}
				}
				
				
				
				if( Input.GetKey( KeyCode.RightArrow ) ){
					//
					_setAnimationTrigger (MainConstants.WALKING_TRIGGER);
					_normalizedHorizontalSpeed_float = 1;

				} else if( Input.GetKey( KeyCode.LeftArrow ) ) {
					//
					_setAnimationTrigger (MainConstants.WALKING_TRIGGER);
					_normalizedHorizontalSpeed_float = -1;

				} else {

					_normalizedHorizontalSpeed_float = 0;

				}
				
				
				/*
				*  DO NOT ALLOW DOUBLE JUMP (YET?)
				* 
				* 
				* 
				*/
				if( Input.GetKeyDown( KeyCode.UpArrow ) && _characterController2D.isGrounded )
				{
					_setAnimationTrigger (MainConstants.JUMPING_TRIGGER);
					_velocity_vector3.y = Mathf.Sqrt( Mathf.Abs(_targetJumpHeight * SuperMovementComponent.GRAVITY_Y) );
					SimpleGameManager.Instance.audioManager.doPlaySound (AudioClipType.PLAYER_JUMPS);
				}


				
				//MOVE RIGHT
				_velocity_vector3 = _doUpdateHorizontalVelocity 
					(
						_velocity_vector3,
						_normalizedHorizontalSpeed_float,
						_runSpeed_float
						);


				//
				_doSetScaleFromHorizontalVelocity(_normalizedHorizontalSpeed_float);

				//RETURN TO IDLE BASED ON VELOCITY (NOT KEYPRESSES, IN CASE WE ADD FRICTION LATER)
				if (_normalizedHorizontalSpeed_float == 0 &&  _characterController2D.isGrounded) {
					_setAnimationTrigger (MainConstants.IDLE_TRIGGER);
				}
				
				//MOVE DOWN
				_velocity_vector3 = _doUpdateVerticalVelocity (	_velocity_vector3 );
				
				
				
				//USE CALCULATIONS
				_setCurrentVelocityAfterModifications (_velocity_vector3);

			}

		}

		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
	}
}
