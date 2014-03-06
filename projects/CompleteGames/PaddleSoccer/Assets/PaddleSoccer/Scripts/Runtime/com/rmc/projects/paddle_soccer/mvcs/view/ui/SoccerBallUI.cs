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
using strange.extensions.mediation.impl;
using com.rmc.projects.paddle_soccer.mvcs.controller.signals;


//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.paddle_soccer.mvcs.view.ui.super;
using com.rmc.projects.paddle_soccer.components;
using strange.extensions.signal.impl;
using com.rmc.projects.paddle_soccer.mvcs.view.signals;


namespace com.rmc.projects.paddle_soccer.mvcs.view.ui
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
	public class SoccerBallUI : View 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER

		
		/// <summary>
		/// Gets or sets the is rolling.
		/// </summary>
		/// <value>The is rolling.</value>
		public bool isRolling
		{ 
			get{
				return _animator.GetBool ("isRolling_boolean");
			}
			set
			{
				_animator.SetBool ("isRolling_boolean", value);
			}
		}


		/// <summary>
		/// Gets or sets a value indicating whether this
		/// <see cref="com.rmc.projects.paddle_soccer.mvcs.view.ui.SoccerBallUI"/> is enabled.
		/// 
		/// NOTE: This is set by mediator based on GameState.
		/// NOTE: Defaults to false
		/// 
		/// 
		/// </summary>
		/// <value><c>true</c> if is enabled; otherwise, <c>false</c>.</value>
		public bool isEnabled {get;set;}


		/// <summary>
		/// Gets or sets the user interface collision enter2 D signal.
		/// </summary>
		/// <value>The user interface collision enter2 D signal.</value>
		public UICollisionEnter2DSignal uiCollisionEnter2DSignal {get; set;}

		// PUBLIC


		// PUBLIC STATIC

		// PRIVATE
		/// <summary>
		/// The _previous position_vector3.
		/// </summary>
		private Vector3 _previousPosition_vector3;

		/// <summary>
		/// The _current rotation_quaternion.
		/// </summary>
		private Quaternion _currentRotation_quaternion;

		/// <summary>
		/// The _move direction_vector2.
		/// </summary>
		private Vector2 _moveDirection_vector2;

		/// <summary>
		/// The _target angle_float.
		/// </summary>
		private float _targetAngle_float;

		/// <summary>
		/// The _turn speed_float.
		/// </summary>
		private float _turnSpeed_float;

		/// <summary>
		/// The _animator.
		/// </summary>
		private Animator _animator;


		// PRIVATE STATIC
		/// <summary>
		/// The _ STARTIN g_ PUS h_ x.
		/// </summary>
		private const int _STARTING_PUSH_X = 200;

		/// <summary>
		/// The _ STARTIN g_ PUS h_ y.
		/// </summary>
		private const int _STARTING_PUSH_Y = 50;

		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			base.Start();
			_animator = GetComponent<Animator>();

		}

		///<summary>
		///	Use this for initialization
		///</summary>
		public void init () 
		{
			isEnabled = false;
			rigidbody2D.fixedAngle = true;
			uiCollisionEnter2DSignal = new UICollisionEnter2DSignal();

		}

		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			//
			if (isEnabled) {
				_doLookInDirectionOfMovement();

				//TURN ON THE ANIMATION
				isRolling = true;

				//TURN ON THE PHYICS
				rigidbody2D.WakeUp();
			} else {

				//TURN OFF THE ANIMATION
				isRolling = false;

				//TURN OFF THE PHYSICS (SO IT DOESN'T BOUNCE OUT OF THE GOAL)
				rigidbody2D.Sleep();
			}



		}
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy ()
		{
			//
			base.OnDestroy();
			
		}
		
		// PUBLIC
		/// <summary>
		/// Dos the reset to starting position.
		/// </summary>
		public void doResetToStartingPosition() 
		{

			//RESET THE POSITION TO CENTER
			transform.position = new Vector3 (0, 0, transform.position.z);

			//TURN OFF THE ANIMATION
			isRolling = false;


			//KEEP THIS
			//RESETS ALL CURRENTLY ACTIVE PHYSICS ON THE BALL (SUCH AS FROM PREVIOUS MOVEMENT INTO THE GOAL)
			gameObject.SetActive (false);
			gameObject.SetActive (true);
			rigidbody2D.isKinematic = false;


		}

		/// <summary>
		/// Dos the give starting push.
		/// </summary>
		public void doGiveStartingPush ()
		{

			//Debug.Log ("doGiveStartingPush()");
			int direction_int = Random.Range (1,4);

			//pick one of four diagonal directions and 'push' the ball for kickoff
			if (direction_int == 1) {
				rigidbody2D.AddForce (new Vector2 (_STARTING_PUSH_X, _STARTING_PUSH_Y));
			} else if (direction_int == 2) {
				rigidbody2D.AddForce (new Vector2 (_STARTING_PUSH_X, -_STARTING_PUSH_Y));
			} else if (direction_int == 3) {
				rigidbody2D.AddForce (new Vector2 (-_STARTING_PUSH_X, _STARTING_PUSH_Y));
			} else if (direction_int == 4) {
				rigidbody2D.AddForce (new Vector2 (-_STARTING_PUSH_X, -_STARTING_PUSH_Y));

			}
			isRolling = true;

		}

		/// <summary>
		/// Dos the handle collision with paddle.
		/// 
		/// NOTE: We put some english (curve) if the paddle is moving
		/// NOTE: We add some speed, always to increase pace of current gameplay
		/// 
		/// </summary>
		/// <param name="aVelocity_vector2">A velocity_vector2.</param>
		public void doHandleCollisionWithPaddle (Vector2 aVelocity_vector2)
		{
			float bounceSpeedX_float = rigidbody2D.velocity.x*5f;
			float englishSpeedY_float = aVelocity_vector2.y*1000;
			rigidbody2D.AddForce (new Vector2 (bounceSpeedX_float, englishSpeedY_float));
		}
		

		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// _dos the look in direction of movement.
		/// </summary>
		private void _doLookInDirectionOfMovement()
		{
			// calculates the angle we should turn towards, - 90 makes the sprite rotate
			_moveDirection_vector2 	= rigidbody2D.velocity.normalized;
			_targetAngle_float 		= Mathf.Atan2(_moveDirection_vector2.y, _moveDirection_vector2.x) * Mathf.Rad2Deg - 180;
			_turnSpeed_float 		= 10f * Time.deltaTime;
			transform.rotation 		= Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, _targetAngle_float), _turnSpeed_float);
			

//			transform.rotation = Quaternion.LookRotation( transform.forward);
		}

		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events 
		//		(This is a loose term for -- handling incoming messaging)
		//
		//--------------------------------------
		/// <summary>
		/// Raises the collision enter2 d event.
		/// 
		/// NOTE: This just detect BOUNDS
		/// 
		/// </summary>
		/// <param name="aCollision2D">A collision2 d.</param>
		public void OnCollisionEnter2D (Collision2D aCollision2D)
		{

			if (isEnabled) {
				uiCollisionEnter2DSignal.Dispatch (aCollision2D.collider.gameObject);
			}

		}



	}
}

