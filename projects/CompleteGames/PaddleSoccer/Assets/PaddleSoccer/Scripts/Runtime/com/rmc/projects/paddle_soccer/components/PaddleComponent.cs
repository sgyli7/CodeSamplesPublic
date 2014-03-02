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
using com.rmc.exceptions;
using System.Collections;
using com.rmc.projects.animation_monitor;



//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.paddle_soccer.mvcs.model.data;
using com.rmc.utilities;
using com.rmc.projects.paddle_soccer.mvcs.view.ui;
using com.rmc.projects.paddle_soccer.mvcs;


namespace com.rmc.projects.paddle_soccer.components
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum AnimationType
	{
		WALK,
		ATTACK,
		TAKE_HIT,
		DIE,
		IDLE,
		JUMP
		
	}
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class PaddleComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER

		/// <summary>
		/// The _target y_float.
		/// </summary>
		public float targetY
		{ 
			get{
				return _yPosition_lerptarget.targetValue;
			}
			set
			{
				_yPosition_lerptarget.targetValue = value;
				
			}
		}


		
		// PUBLIC
		
		
		/// <summary>
		/// When the type of the _animation.
		/// </summary>
		public AnimationType animationType; 
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// When the turret spinning_lerptarget.
		/// </summary>
		private LerpTarget _yPosition_lerptarget;
		
		
		/// <summary>
		/// When the animation.
		/// </summary>
		new private Animation animation;
		
		/// <summary>
		/// When the _animation binder.
		/// 
		/// NOTE: Notifies when an animation is complete
		/// 
		/// </summary>
		public AnimationMonitor animationMonitor;
		
		/// <summary>
		/// When the ANIMATION NAMES
		/// </summary>
		public const string ANIMATION_NAME_IDLE 		= "idle";	
		public const string ANIMATION_NAME_JUMP 		= "jump";
		public const string ANIMATION_NAME_WALK 		= "walk";	
		public const string ANIMATION_NAME_ATTACK_1 	= "attack1";
		public const string ANIMATION_NAME_ATTACK_2		= "attack2";
		public const string ANIMATION_NAME_HIT_1 		= "hit1";
		public const string ANIMATION_NAME_HIT_2 		= "hit2";
		public const string ANIMATION_NAME_DEATH_1 		= "death1";
		public const string ANIMATION_NAME_DEATH_2 		= "death2";
		
		
		/// <summary>
		/// When the _move speed_float.
		/// </summary>
		private float _moveSpeed_float;


		/// <summary>
		/// The _velocity_vector2.
		/// 
		/// </summary>
		private Vector2 _velocity_vector2;


		/// <summary>
		/// The _last position_vector3.
		/// </summary>
		private Vector3 _lastPosition_vector3;
		
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		
		///<summary>
		///	Use this for initialization
		///</summary>
		public void Start () 
		{
			
			animation 						= GetComponentInChildren<Animation>();
			animationMonitor 				= GetComponentInChildren<AnimationMonitor>();
			_yPosition_lerptarget 			= new LerpTarget (0, 0, -5, 5, 0.5f);

			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			//ROTATE THE BARREL IF FIRING
			if (true) {
				_yPosition_lerptarget.lerpCurrentToTarget (Time.deltaTime);
				_doMoveToTarget();
			} 



		}
		

		
		// PUBLIC


		
		/// <summary>
		/// Do play animation.
		/// </summary>
		/// <param name="aAnimationType">A animation type.</param>
		/// <param name="aDelayBeforeAnimation_float">A delay before animation_float.</param>
		/// <param name="aDelayAfterAnimation_float">A delay after animation_float.</param>
		public void doPlayAnimation (AnimationType aAnimationType, float aDelayBeforeAnimation_float, float aDelayAfterAnimation_float) 
		{
			//
			animationType 	= aAnimationType;
			
			doStopAnimation();
			
			//
			switch (animationType) {
			case AnimationType.JUMP:
				animationMonitor.playRequest ( new AnimationMonitorRequestVO (ANIMATION_NAME_JUMP, WrapMode.Default));
				break;
			case AnimationType.WALK:
				animationMonitor.playRequest ( new AnimationMonitorRequestVO (ANIMATION_NAME_WALK, WrapMode.Loop));
				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException();
				break;
				#pragma warning restore 0162
			}
			
			
		}
		
		
		
		/// <summary>
		/// Do stop animation.
		/// </summary>
		public void doStopAnimation()
		{
			animation.Stop();
			
			
		}

		
		/// <summary>
		/// Do tween to fall from sky.
		/// </summary>
		public void doTweenToFallFromSky ()
		{
			//
			//
			Hashtable moveTo_hashtable 					= new Hashtable();
			moveTo_hashtable.Add(iT.MoveTo.y,			0);
			moveTo_hashtable.Add(iT.MoveTo.delay,  		0);
			moveTo_hashtable.Add(iT.MoveTo.time,  		1);
			moveTo_hashtable.Add(iT.MoveTo.easetype, 	iTween.EaseType.linear);
			iTween.MoveTo (gameObject, 					moveTo_hashtable);
		}
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// Do move to target.
		/// </summary>
		private void _doMoveToTarget ()
		{
			//
			transform.position = new Vector3 (
				transform.position.x, 
				_getNewYPositionOnscreen(), 
				transform.position.z);

			//STORE FOR VELOCITY CHECK
			_velocity_vector2 = transform.position - _lastPosition_vector3;
			_lastPosition_vector3 = transform.position;
		}


		/// <summary>
		/// _gets the new Y position onscreen.
		/// </summary>
		private float _getNewYPositionOnscreen ()
		{
			float newYPosition_float = _yPosition_lerptarget.current;
			if (newYPosition_float < Constants.PADDLE_Y_MINIMUM) {
				newYPosition_float = Constants.PADDLE_Y_MINIMUM;
				_yPosition_lerptarget.targetValue = _yPosition_lerptarget.current;
			} else if (newYPosition_float > Constants.PADDLE_Y_MAXIMUM) {
				newYPosition_float = Constants.PADDLE_Y_MAXIMUM;
				_yPosition_lerptarget.targetValue = _yPosition_lerptarget.current;
			}
			

			return newYPosition_float;
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
		/// NOTE: This just detects soccer ball
		/// 
		/// </summary>
		/// <param name="aCollision2D">A collision2 d.</param>
		public void OnCollisionEnter2D (Collision2D aCollision2D)
		{
			
			//Debug.Log (aCollision2D.collider.gameObject.tag);
			//
			if (aCollision2D.collider.gameObject.tag == SoccerBallUI.TAG) {
				
				//
				SoccerBallUI soccerBallUI = aCollision2D.collider.gameObject.GetComponent<SoccerBallUI>();
				//
				soccerBallUI.doGiveEnglishFromPaddleVelocity (_velocity_vector2);

			}
			
		}
		
	}
}

