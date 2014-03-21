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
using com.rmc.utilities;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.coins_and_platforms.components.player
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
				//IF PLAYER IS MOVING DOWNWARD AND NOT ON THE GROUND IT IS ATTACKING!
				return !(_characterController2D.velocity.y < -10 && !_characterController2D.isGrounded);
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
			normalizedHorizontalSpeed = 1;
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
		/// Does handle movement.
		/// </summary>
		private void _doHandleMovement()
		{


			
			//*************************
			//  ALWAYS ALLOW RESTART
			//*************************
			if( Input.GetKeyDown( KeyCode.Space ))
			{
				SimpleGameManager.Instance.gameManager.doRestartGame();
			}


			//*************************
			//  TAKE INPUT
			//*************************
			if (_characterController2D.enabled) {

				//PREPARE FOR CALCULATIONS
				_velocity_vector3 = _getCurrentVelocityBeforeModifications();
				

				//*************************
				//  PREPARE MOVEMENT
				//************************
				if( Input.GetKey( KeyCode.RightArrow ) ){
					normalizedHorizontalSpeed = 1;
				} else if( Input.GetKey( KeyCode.LeftArrow ) ) {
					normalizedHorizontalSpeed = -1;
				} else {
					normalizedHorizontalSpeed = 0;

				}

				
				//*************************
				//  PREPARE ANIMATION STATES
				//************************
				if( Input.GetKeyDown( KeyCode.RightArrow ) || Input.GetKeyDown( KeyCode.LeftArrow ) ) {
					_onState_JustStartedWalking();
				}

				//UPDATE ANIMATOR WITH MOVEMENT (BESIDES THIS VAR, IT LISTENS ONLY FOR TRIGGERS)
				_animator.SetBool 		("isGrounded", _characterController2D.isGrounded);

				//DO CALCULATIONS
				//Debug.Log ("g: " +  _characterController2D.isGrounded);
				if( _characterController2D.isGrounded ) {

					//CORRECT VALUE
					if (!MathUtility.IsFloatZero(_velocity_vector3.y)) {
						_velocity_vector3.y = 0;
						_onState_JustLanded();
					}
					
				}

				
				//*************************
				//  UPDATE ANIMATION
				//*************************
				if ( normalizedHorizontalSpeed == 0 &&  _characterController2D.isGrounded) {
					_onState_WhileStandingStillOnGround();
				}
				
				//*************************
				//  JUMPING (NO DOUBLE JUMP)
				//*************************
				if( Input.GetKeyDown( KeyCode.UpArrow ) && _characterController2D.isGrounded )
				{
					_onState_JustJumped();
					_velocity_vector3.y = Mathf.Sqrt( Mathf.Abs(_targetJumpHeight * SuperMovementComponent.GRAVITY_Y) );
					SimpleGameManager.Instance.audioManager.doPlaySound (AudioClipType.PLAYER_JUMPS);
				}

				
				//*************************
				//  MOVE H
				//*************************
				_velocity_vector3 = _doUpdateHorizontalVelocity 
					(
						_velocity_vector3,
						normalizedHorizontalSpeed,
						_runSpeed_float
						);


				//
				_doSetScaleFromHorizontalVelocity(normalizedHorizontalSpeed);


				//*************************
				//  MOVE V
				//*************************
				_velocity_vector3 = _doUpdateVerticalVelocity (	_velocity_vector3 );
				
				
				
				//*************************
				//  UPDATE
				//*************************
				_setCurrentVelocityAfterModifications (_velocity_vector3);


				//*************************
				//  PLAY SOUND UNIQUELY AS WE LAND
				//*************************
				if (!_wasGrounded_boolean && _characterController2D.isGrounded) {
					SimpleGameManager.Instance.audioManager.doPlaySound (AudioClipType.PLAYER_LANDS);
				}


				//*************************
				//  STORE
				//*************************
				_wasGrounded_boolean = _characterController2D.isGrounded;

			}

		}

		/// <summary>
		/// Dos the die.
		/// </summary>
		public void doKnockOut ()
		{
			_setAnimationTrigger (MainConstants.UNIVERSAL_IDLE_TRIGGER);
			_setAnimationTrigger (MainConstants.UNIVERSAL_DYING_TRIGGER);
			setVerticalScale (false);
			_characterController2D.clearCurrentPlatformMask();
		}


		/// <summary>
		/// Dos the die.
		/// </summary>
		public void setVerticalScale (bool aHeadsUp_boolean)
		{
			if (aHeadsUp_boolean) {
				transform.localScale = new Vector3( transform.localScale.x, Mathf.Abs (transform.localScale.y), transform.localScale.z );
			} else {
				transform.localScale = new Vector3( transform.localScale.x, -Mathf.Abs (transform.localScale.y), transform.localScale.z );
			}
		}

		/// <summary>
		/// Dos the reset physics and animation.
		/// </summary>
		override public void doResetPhysicsAndAnimation ()
		{


			base.doResetPhysicsAndAnimation();

			//PHYSICS
			_characterController2D.revertToOriginalCurrentPlatformMask();
			_doStopAnimation();
		}
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Ons the boundary hit.
		/// </summary>
		override public void onBoundaryHit ()
		{
			base.onBoundaryHit();
			SimpleGameManager.Instance.gameManager.doKillPlayer();
			SimpleGameManager.Instance.audioManager.doPlaySound(AudioClipType.PLAYER_FALLS_OFFSCREEN);
		}


		//--------------------------------------
		//  Animation State Cues
		//--------------------------------------
		/// <summary>
		/// Marks Cue: For just landed.
		/// </summary>
		private void _onState_JustLanded() 
		{
			//Debug.Log ("_onState_JustLanded");
			_setAnimationTrigger (MainConstants.UNIVERSAL_IDLE_TRIGGER);

		}

		/// <summary>
		/// Marks Cue: For just jumped.
		/// </summary>
		private void _onState_JustJumped() 
		{
			//Debug.Log ("_onState_JustJumped");
			_setAnimationTrigger (MainConstants.PLAYER_JUMPING_TRIGGER);
		}

		/// <summary>
		/// Marks Cue: For just started walking.
		/// </summary>
		private void _onState_JustStartedWalking() 
		{
			//Debug.Log ("_onState_JustStartedWalking");
			_setAnimationTrigger (MainConstants.UNIVERSAL_WALKING_TRIGGER);
		}

		/// <summary>
		/// Marks Cue: For while standing still on ground.
		/// </summary>
		private void _onState_WhileStandingStillOnGround() 
		{
			//Debug.Log ("_onState_WhileStandingStillOnGround");
			_setAnimationTrigger (MainConstants.UNIVERSAL_IDLE_TRIGGER, true);

		}




		
	}
}
