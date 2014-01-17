/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
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
using System.Collections;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.unity_car_racer
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
	public class CarInputComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Attributes
		//--------------------------------------
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC

		/////////////////////////////////////////
		/// 
		/// REQUIRED VALUES
		/// 
		/////////////////////////////////////////

		/// <summary>
		/// The speed_float.
		/// </summary>
		//public float speed_float = 2; //NOT USED as speed is not set explicitly. SEE 'maxSpeed_float' instead.

		/// <summary>
		/// The accelleration_float.
		/// </summary>
		public float acceleration_float = 40;

		/// <summary>
		/// The turn rate_float.
		/// </summary>
		public float turnRate_float = 5;

		/// <summary>
		/// The mass_float.
		/// </summary>
		public float mass_float = 3;

		/// <summary>
		/// The camera follow distance_float.
		/// </summary>
		public float cameraFollowDistance_float = 10;
 

		/////////////////////////////////////////
		/// 
		/// BONUS VALUES
		/// 
		/////////////////////////////////////////


		/// <summary>
		/// The max speed_float.
		/// </summary>
		private bool _isGravityRelative_boolean;
		public bool isGravityRelative {
			get{
				return _isGravityRelative_boolean;
			}
			set{
				_isGravityRelative_boolean = value;
				if (_isGravityRelative_boolean) {
					_gravityRelativeMultiplier_float = 2;
				} else {
					_gravityRelativeMultiplier_float = 1;
				}
			}

		}

		/////////////////////////////////////////
		/// 
		/// OTHER VALUES
		/// 
		/////////////////////////////////////////

		// PUBLIC STATIC
		/// <summary>
		/// The max speed_float.
		/// </summary>
		public float maxSpeed_float = 100;

		/// <summary>
		/// The carflipped_audioclip.
		/// </summary>
		public AudioClip carFlipped_audioclip;
		
		// PRIVATE

		/// <summary>
		/// The car flipped_audiosource.
		/// </summary>
		private AudioSource carFlipped_audiosource;

		/// <summary>
		/// The current speed_float. 
		/// 
		/// NOTE: This is calculated based on public "speed_float" and "acceleration_float" as well as keyboard input.
		/// 
		/// </summary>
		private float currentSpeed_float = 0;


		/// <summary>
		/// The _input get axis vertical_float.
		/// </summary>
		private float _inputGetAxisVertical_float;


		/// <summary>
		/// The _position on restart y_float.
		/// </summary>
		private float _positionOnRestartY_float = 2;


		/// <summary>
		/// The _is input enabled_boolean.
		/// </summary>
		private bool _isInputEnabled_boolean;
		public bool isInputEnabled  
		{
			//ACCESSIBLE FROM OUTSIDE (ONLY GET)
			get{
				return _isInputEnabled_boolean;
			}
			private set{

				if (_isInputEnabled_boolean != value) {
					_isInputEnabled_boolean = value;

					//OPTIONAL: SET A TIMER TO AUTO RESET HERE
					//...
				}
			}
		}

		/// <summary>
		/// The smooth follow component.
		/// </summary>
		private SmoothFollow _smoothFollow_monobehavior;

		/// <summary>
		/// The _gravity relative multiplier_float.
		/// 
		/// 	NOTE: With relative gravity applied, more force is needed to drive the car.
		/// 
		/// </summary>
		private float _gravityRelativeMultiplier_float;
		
		// PRIVATE STATIC

		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			//SETUP AUDIO
			carFlipped_audiosource = GetComponent<AudioSource>();
			carFlipped_audiosource.clip = carFlipped_audioclip;

			//
			isGravityRelative = false;

			//STORE CAMERA REFERENCE TO UPDATE PROPERTIES AS NEEDED
			_smoothFollow_monobehavior = Camera.main.GetComponent<SmoothFollow>();

			//START CAR IN ORIGINAL POSITION
			doResetCar();



			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			if (isInputEnabled) {
				//THERE IS NO EXPLICIT INSTANTATNEOUS ACCELERATION IN PHYSICS
				//HERE IS A COMPLETE WORKAROUND
				_doUpdateSpeed ();
				
				//MOVE BASED ON 
				_doTakeInputAndHandleMovement();

			}

			//HANDLE GRAVITY/ROTATION ISSUES
			if (_isGravityRelative_boolean) {
				_doHandleGravity_Relative();
			} else {
				_doHandleGravity_Normal();
			}

			//UPDATE BASED ON CHANGES TO PUBLIC PROPERTIES
			_doHandleInspectorUpdates();
			
		}
		
		// PUBLIC
		/// <summary>
		/// Resets the level.
		/// </summary>
		public void doResetLevel ()
		{

			Application.LoadLevel (Application.loadedLevel);

		}


		/// <summary>
		/// Resets the car in-place without reseting the world.
		/// 
		/// NOTE: This is required if the user flips the car
		/// 
		/// </summary>
		public void doResetCar ()
		{
			isInputEnabled = true;
			transform.position = new Vector3 (transform.position.x, transform.position.y + _positionOnRestartY_float, transform.position.z);
			transform.rotation = Quaternion.identity;

		}

		// PUBLIC STATIC
		
		// PRIVATE
		
		


		/// <summary>
		/// Do the update speed.
		/// </summary>
		private void _doUpdateSpeed () 
		{
			//TAKE KEY INPUT
			_inputGetAxisVertical_float =  Input.GetAxis ("Vertical");
			
			//UPDATE SPEED
			if (_inputGetAxisVertical_float != 0) {
				
				//KEY IS DOWN, SO INPUT VARS INFLUENCE PHYSICS
				currentSpeed_float = _inputGetAxisVertical_float * acceleration_float;
				currentSpeed_float = Mathf.Clamp (currentSpeed_float, -maxSpeed_float, maxSpeed_float);
			} else {
				//KEY IS NOT DOWN, RESET SPEED
				currentSpeed_float = 0;
			}
			
		}

		/// <summary>
		/// Do the handle input and movement.
		/// </summary>
		private void _doTakeInputAndHandleMovement () 
		{
			//MOVE FORWARD
			rigidbody.AddForce (transform.forward * currentSpeed_float * _gravityRelativeMultiplier_float);
			
			//TURN
			if (_inputGetAxisVertical_float >= 0) {

				//NORMAL STEERING
				rigidbody.AddRelativeTorque (new Vector3 (0, _gravityRelativeMultiplier_float* turnRate_float * Input.GetAxis ("Horizontal"), 0));
			
			} else {
				//REVERSE STEERING
				rigidbody.AddRelativeTorque (new Vector3 (0, -_gravityRelativeMultiplier_float* turnRate_float * Input.GetAxis ("Horizontal"), 0));

			}
			
		}

		/// <summary>
		/// Do the handle gravity_ relative.
		/// </summary>
		private void _doHandleGravity_Relative()
		{

			//ATTEMPT 1: 	RESET GRAVITY TO CAR-DOWN DIRECTION
			//			 	NOT BAD, BUT INTRODUCES COMPLEXITIES AND
			//			 	INTRODUCES SCALABILITY ISSUES FOR A LARGER 
			//				GAME WITH MORE RIGID BODIES
			//Physics.gravity = transform.up*_DEFAULT_GRAVITY_Y_FLOAT; 


			//ATTEMPT 2: 	ADD CONSTANT FORCE RELATIVELY 'TOWARDS WORLD-DOWN'
			//				PRETTY GOOD UNTIL INCLINES ARE EXTREME
			//rigidbody.AddForce (-transform.up * rigidbody.mass*2);

			//ATTEMPT 3: 	ADD CONSTANT FORCE RELATIVELY 'TOWARDS TERRAIN'
			//				BETTER STILL THAN 1 AND 2
			/*
			Physics.gravity = new Vector3 (0,0,0);
			RaycastHit raycastHit;
			if(Physics.Raycast(transform.position, -transform.up, out raycastHit, 10)){
				
				if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer ("TerrainLayer")) {

					//ADD FORCE
					//_doHandleTerrainCollision_Relative (transform.position, raycastHit.normal, 1);
				}
			} 
			*/

			//ATTEMPT 4: ADD A FORCE WHERE CAR MEETS TERRAIN TO STICK TO TERRAIN
			//			 NOTE: WE DO NOTHING HERE. INSTEAD SEE "OnCollisionStay"

		}

		/// <summary>
		/// _dos the handle ground collision_ relative.
		/// </summary>
		private void _doHandleTerrainCollision_Relative(Vector3 aPosition_vector3, Vector3 aNormal_vector3, float aForceMultiplier_float)
		{
			
			//DEBUG LOOKS GOOD
			Debug.DrawRay (aPosition_vector3, -aNormal_vector3);


			//ADD FORCE
			rigidbody.AddForce (-aNormal_vector3 * rigidbody.mass*aForceMultiplier_float, ForceMode.Acceleration);
			
		} 

		
		/// <summary>
		/// Do the handle gravity_ normal.
		/// </summary>
		private void _doHandleGravity_Normal()
		{
			//IS CAR FLIPPED, THEN DISABLE CAR
			if (_isCarFlippedOver() || _isCarFallenOffTerrain()) {
				
				if (isInputEnabled) {
					//PLAY SOUND ONCE AND DISABLE CAR
					isInputEnabled = false;
					carFlipped_audiosource.Play();
				}
				
			}
			
		}

		/// <summary>
		/// Is the car flipped over.
		/// </summary>
		/// <returns><c>true</c>, if car flipped over was _ised, <c>false</c> otherwise.</returns>
		private bool _isCarFlippedOver ()
		{
			if (transform.up.y > 0.6) {
				return false;
			} else {
				return true;
			}
		}

		/// <summary>
		/// Is the car fallen off terrain.
		/// </summary>
		/// <returns><c>true</c>, if car fallen off terrain was _ised, <c>false</c> otherwise.</returns>
		private bool _isCarFallenOffTerrain ()
		{
			if (transform.position.y > 0) {
				return false;
			} else {
				return true;
			}
		}




		/// <summary>
		/// do the handle inspector updates.
		/// </summary>
		private void _doHandleInspectorUpdates()
		{
			if (!rigidbody.mass.Equals(mass_float)) {
				rigidbody.mass = mass_float;
			}

			if (!_smoothFollow_monobehavior.distance.Equals(cameraFollowDistance_float)){
				_smoothFollow_monobehavior.distance = cameraFollowDistance_float;
			}


		}
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		void OnCollisionStay (Collision aCollision)
		{
			if (isGravityRelative) {
				foreach (ContactPoint contactPoint in aCollision.contacts) {
					_doHandleTerrainCollision_Relative (contactPoint.point, contactPoint.normal, .1f);
				}
			}


		}
	}
}
