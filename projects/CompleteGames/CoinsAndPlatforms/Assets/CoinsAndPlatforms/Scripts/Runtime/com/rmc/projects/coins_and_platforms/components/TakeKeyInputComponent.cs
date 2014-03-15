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
using System.Collections;


//--------------------------------------
//  Namespace
//--------------------------------------
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
	public class TakeKeyInputComponent : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		private bool _isOnGround_boolean = false;

		private float _jumpVelocity_float = 15f; //10f is best

		private float _horizontalForce_float = 100f;

		private float _distanceToGround_float = 0.001f;

		private Vector3 _raycastOrigin_vector2;

		private Animator _animator;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public TakeKeyInputComponent ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~TakeKeyInputComponent ( )
		{
			
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{

			_distanceToGround_float = renderer.bounds.size.y/2 - 0.05f;

			_animator = GetComponent<Animator>();
			//Debug.Log ("h: " + _animator.playbackTime = 1f;);




		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			if (Input.GetKey (KeyCode.RightArrow)) {

				rigidbody2D.AddForce (new Vector2 (_horizontalForce_float,0));
				transform.localScale = new Vector3 (1, 1, 1);
				_animator.SetTrigger ("WalkingTrigger");

			} else if (Input.GetKey (KeyCode.LeftArrow)) {

				rigidbody2D.AddForce (new Vector2 (-_horizontalForce_float,0));
				transform.localScale = new Vector3 (-1, 1, 1);
				_animator.SetTrigger ("WalkingTrigger");
			} else {
				_animator.SetTrigger ("IdleTrigger");
				//rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
			}


			//if falling or static (but not rising up)
			if (rigidbody2D.velocity.y <= 0) {
				_doMoveDetectGrounded();
			}

			if (_isOnGround_boolean) {
				//Debug.Log ("isGrounded: " + isGrounded);
				if (Input.GetKey(KeyCode.UpArrow)){ // only jump from the ground
					//rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, _jumpVelocity_float); 
				} else {
					//rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 0);
				}
			} else {

				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y - .5f);
			}
		}

		/// <summary>
		/// Fixeds the update.
		/// </summary>
		void FixedUpdate ()
		{ 
			//rigidbody2D.drag = 2;
			//transform.Translate( * Time.deltaTime, Space.World);
		}

		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// _dos the move detect grounded.
		/// </summary>
		void _doMoveDetectGrounded ()
		{
			RaycastHit2D[] raycastHit2D_array;
			_raycastOrigin_vector2 = new Vector2 (transform.position.x, transform.position.y) - new Vector2 (0,renderer.bounds.size.y/2);
			raycastHit2D_array = Physics2D.RaycastAll (_raycastOrigin_vector2, -Vector3.up, _distanceToGround_float/100);

			Debug.DrawRay (_raycastOrigin_vector2, -Vector3.up.normalized*_distanceToGround_float/100);
			//
			_isOnGround_boolean = false;
			foreach (RaycastHit2D raycastHit2D in raycastHit2D_array) {
				if (raycastHit2D.collider.gameObject.layer ==  LayerMask.NameToLayer ("PlatformLayer")) {


					//TODO: PUT PLAYER ABOVE TO 'RIDE THE CURVED SURFACE OF PLATFORM
					transform.position = new Vector2 (transform.position.x, raycastHit2D.point.y + raycastHit2D.normal.normalized.y);


					//WORKS
					_isOnGround_boolean = true;


					break;
				} 
			}


		}


		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		void onDidFootStep()
		{
			//Debug.Log ("Foot");

		}
	}
}
