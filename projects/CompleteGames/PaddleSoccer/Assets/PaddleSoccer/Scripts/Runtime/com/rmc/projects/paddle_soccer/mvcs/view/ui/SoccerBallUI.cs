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
	public class SoccerBallUI : SuperPaddleUI 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER


		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="com.rmc.projects.paddle_soccer.mvcs.view.ui.SoccerBallUI"/> is
		/// running update.
		/// 
		/// NOTE: This is set by mediator based on GameState.
		/// NOTE: Defaults to false
		/// 
		/// </summary>
		/// <value><c>true</c> if is running update; otherwise, <c>false</c>.</value>
		public bool isRunningUpdate {get;set;}

		// PUBLIC


		// PUBLIC STATIC
		/// <summary>
		/// The TA.
		/// </summary>
		public static string TAG = "SoccerBallTag";
		
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


		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			base.Start();

		}

		///<summary>
		///	Use this for initialization
		///</summary>
		override public void init () 
		{
			base.init();
			isRunningUpdate = false;
			rigidbody2D.fixedAngle = true;

		}

		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			//
			if (isRunningUpdate) {
				_doLookInDirectionOfMovement();

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

			transform.position = new Vector3 (0, 0, transform.position.z);


		}

		/// <summary>
		/// Dos the give starting push.
		/// </summary>
		public void doGiveStartingPush ()
		{

			rigidbody2D.AddForce (new Vector2 (-200, 0));

		}

		/// <summary>
		/// Dos the give english from paddle velocity.
		/// 
		/// NOTE: English = (angled adjustment from moving paddle)
		/// 
		/// </summary>
		/// <param name="aVelocity_vector2">A velocity_vector2.</param>
		public void doGiveEnglishFromPaddleVelocity (Vector2 aVelocity_vector2)
		{
			rigidbody2D.AddForce (new Vector2 (0, aVelocity_vector2.y*3000));
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
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, _targetAngle_float), _turnSpeed_float);
			

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

			//Debug.Log (aCollision2D.collider.gameObject.tag);
			//
			if (aCollision2D.collider.gameObject.tag == BoundaryComponent.TAG) {

				//
				BoundaryComponent boundaryComponent = aCollision2D.collider.gameObject.GetComponent<BoundaryComponent>();
				//
				if (boundaryComponent.boundaryType == BoundaryType.LeftGoal) {

					//Debug.Log ("OnCollisionEnter2D() " + boundaryComponent.boundaryType);
				} else if (boundaryComponent.boundaryType == BoundaryType.RightGoal) {

					//Debug.Log ("OnCollisionEnter2D() " + boundaryComponent.boundaryType);
				}
			}

		}



	}
}

