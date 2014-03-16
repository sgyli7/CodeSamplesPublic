/**
 * I modified the existing script. It came with 2DCharacterController -srivello
 * todo: cleanup code formatting
 **/
// Marks the right margin of code *******************************************************************


using UnityEngine;
using com.rmc.projects.coins_and_platforms.managers;
using com.rmc.projects.coins_and_platforms.constants;
using com.rmc.projects.coins_and_platforms.components.super;


public class PlayerInputComponent : SuperMovementComponent
{
	// movement config

	/// <summary>
	/// The run speed_float.
	/// </summary>
	public float runSpeed_float = 8f;
	public float targetJumpHeight = 4f;

	public RaycastHit2D lastControllerColliderHit;





	/// <summary>
	/// Called once per frame
	/// </summary>
	void Update()
	{
		//PREPARE FOR CALCULATIONS
		_velocity_vector3 = _getCurrentVelocityBeforeModifications();
		
		

		//DO CALCULATIONS
		if( _characterController2D.isGrounded ) {
			if (_velocity_vector3.y != 0) {
				SimpleGameManager.Instance.audioManager.doPlaySound (AudioManager.CLIP_NAME.PLAYER_LANDS);
				_setAnimationTrigger (MainConstants.IDLE_TRIGGER);
				_velocity_vector3.y = 0;
			}
		}



		if( Input.GetKey( KeyCode.RightArrow ) )
		{
			_setAnimationTrigger (MainConstants.WALKING_TRIGGER);
			normalizedHorizontalSpeed = 1;
			if( transform.localScale.x < 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
		else if( Input.GetKey( KeyCode.LeftArrow ) )
		{
			_setAnimationTrigger (MainConstants.WALKING_TRIGGER);
			normalizedHorizontalSpeed = -1;
			if( transform.localScale.x > 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
		else
		{
			_setAnimationTrigger (MainConstants.IDLE_TRIGGER);
			normalizedHorizontalSpeed = 0;
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
			_velocity_vector3.y = Mathf.Sqrt( 2f * targetJumpHeight * GRAVITY_Y );
			SimpleGameManager.Instance.audioManager.doPlaySound (AudioManager.CLIP_NAME.PLAYER_JUMPS);
		}


		//MOVE RIGHT
		_velocity_vector3 = _doUpdateHorizontalVelocity 
			(
				_velocity_vector3,
				normalizedHorizontalSpeed,
				runSpeed_float
				);
		
		//MOVE DOWN
		_velocity_vector3 = _doUpdateVerticalVelocity (	_velocity_vector3 );



		//USE CALCULATIONS
		_setCurrentVelocityAfterModifications (_velocity_vector3);
	}

}
