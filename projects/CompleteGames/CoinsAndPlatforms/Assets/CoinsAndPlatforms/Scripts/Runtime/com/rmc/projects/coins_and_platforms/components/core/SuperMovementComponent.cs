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

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.coins_and_platforms.components.core
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
	[RequireComponent (typeof (CharacterController2D) )]
	public class SuperMovementComponent : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _current trigger name_string.
		/// </summary>
		private string _currentTriggerName_string;

		/// <summary>
		/// The _character controller2 d.
		/// </summary>
		protected CharacterController2D _characterController2D;

		/// <summary>
		/// The _animator.
		/// </summary>
		protected Animator _animator;

		/// <summary>
		/// The current velocity for calculations_vector3.
		/// </summary>
		protected Vector3 _velocity_vector3;

		/// <summary>
		/// The normalized horizontal speed.
		/// </summary>
		protected float _normalizedHorizontalSpeed_float = 0;
		public float normalizedHorizontalSpeed
		{
			get{
				return _normalizedHorizontalSpeed_float;
			} 
			set {
				_normalizedHorizontalSpeed_float = value;
			}
		}

		// PRIVATE STATIC
		/// <summary>
		/// The raw movement direction. 1 = RIGHT
		/// </summary>
		public static float RAW_MOVE_DIRECTION = 1;

		/// <summary>
		/// FRICTION ON GROUND
		/// </summary>
		public static float GROUND_DAMPING = 60;

		/// <summary>
		/// FRICTION IN AIR
		/// </summary>
		public static float NOT_GROUND_DAMPING = 100;


		/// <summary>
		/// MAIN GRAVITY
		/// </summary>
		public static float GRAVITY_Y = -90;

		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public SuperMovementComponent ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~SuperMovementComponent ( )
		{
			
			
		}

		/// <summary>
		/// Awake this instance.
		/// </summary>
		void Awake()
		{
			_characterController2D 	= GetComponent<CharacterController2D>();
			_animator 				= GetComponent<Animator>();
			_characterController2D.onControllerCollidedEvent += onControllerCollider;
		}
		
		


		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			
		}
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
		}
		
		// PUBLIC
		
		
		/// <summary>
		/// Dos the reset physics and animation.
		/// </summary>
		public void doResetPhysicsAndAnimation ()
		{
			//PHYSICS
			_characterController2D.velocity = Vector2.zero;
			_characterController2D.enabled = true;
			
			//ANIMATION
			_setAnimationTrigger (MainConstants.UNIVERSAL_IDLE_TRIGGER);
			
		}

		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// Gets the current velocity.
		/// </summary>
		/// <returns>The current velocity.</returns>
		protected Vector3 _getCurrentVelocityBeforeModifications () 
		{

			return _characterController2D.velocity;

		}

		/// <summary>
		/// _sets the animation trigger.
		/// </summary>
		/// <param name="aTriggerName_string">A trigger name_string.</param>
		protected void _setAnimationTrigger (string aTriggerName_string) 
		{

			//todo: fix repeatedely starting the walk animation on key-hold-down
			//Debug.Log (aTriggerName_string + " and " + _currentTriggerName_string);
			if (aTriggerName_string != _currentTriggerName_string) {

				_animator.SetTrigger (aTriggerName_string);
				_currentTriggerName_string = aTriggerName_string;
			}

		}

		/// <summary>
		/// Does update horizontal velocity.
		/// </summary>
		/// <returns>The update horizontal velocity.</returns>
		/// <param name="aVelocity_vector3">A velocity_vector3.</param>
		/// <param name="aNormalizedMovement_float">A normalized movement_float.</param>
		/// <param name="arunSpeed_float_float">Arun speed_float_float.</param>
		protected Vector3 _doUpdateHorizontalVelocity (Vector3 aVelocity_vector3, float aNormalizedMovement_float, float arunSpeed_float_float)
		{
			// apply horizontal speed smoothing it
			float smoothedMovementFactor_float = _characterController2D.isGrounded ? GROUND_DAMPING : NOT_GROUND_DAMPING; // how fast do we change direction?
			aVelocity_vector3.x = Mathf.Lerp( aVelocity_vector3.x, aNormalizedMovement_float * RAW_MOVE_DIRECTION * arunSpeed_float_float, Time.deltaTime * smoothedMovementFactor_float );

			//
			return aVelocity_vector3;
		}


		/// <summary>
		/// Does set scale from horizontal velocity.
		/// </summary>
		/// <param name="aNormalizedMovement_float">A normalized movement_float.</param>
		protected void _doSetScaleFromHorizontalVelocity (float aNormalizedMovement_float) 
		{

			if (aNormalizedMovement_float > 0) {
				if( transform.localScale.x < 0f ) {
					transform.localScale = new Vector3( Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z );
				}
			} else if (aNormalizedMovement_float < 0) {
				if( transform.localScale.x > 0f ) {
					transform.localScale = new Vector3( -Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z );
				}

			}

		}

		/// <summary>
		/// Does update vertical velocity.
		/// </summary>
		/// <returns>The update vertical velocity.</returns>
		/// <param name="aVelocity_float">A velocity_float.</param>
		protected Vector3 _doUpdateVerticalVelocity (Vector3 aVelocity_float)
		{
			
			// apply gravity before moving
			aVelocity_float.y += GRAVITY_Y * Time.deltaTime;
			return aVelocity_float;
		}

		/// <summary>
		/// _sets the current velocity after modifications.
		/// </summary>
		/// <param name="aVelocity_vector3">A velocity_vector3.</param>
		protected void _setCurrentVelocityAfterModifications (Vector3 aVelocity_vector3)
		{

			if (_characterController2D.enabled) {
				_characterController2D.move( aVelocity_vector3 * Time.deltaTime );
			}
		}

		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Ons the controller collider.
		/// </summary>
		/// <param name="raycastHit2D">Raycast hit2 d.</param>
		void onControllerCollider( RaycastHit2D raycastHit2D )
		{

			//CURRENTLY FOR DEBUG USE ONLY


			// bail out on plain old ground hits
			if( raycastHit2D.normal.y == 1f )
				return;
			
			// logs any collider hits
			//Debug.Log( "flags: " + _characterController2D.collisionState + ", hit.normal: " + hit.normal );
		}

	}
}